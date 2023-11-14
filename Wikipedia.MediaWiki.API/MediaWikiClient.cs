using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wikipedia.MediaWiki.Models;

namespace Wikipedia.MediaWiki.API
{
    public class MediaWikiClient : IMediaWikiClient
    {
        #region Fields

        private const string EndpointURL = "https://en.wikipedia.org/w/api.php";
        private HttpClient _client;
        private HtmlParser _parser;
        private static Lazy<MediaWikiClient> lazy;

        #endregion

        #region Constructors

        private MediaWikiClient(HttpClient client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            _client = client;
            _parser = new HtmlParser();
        }

        public static MediaWikiClient Init(HttpClient client)
        {
            if (lazy == null)
            {
                lazy = new Lazy<MediaWikiClient>(() => new MediaWikiClient(client));
            }

            return lazy.Value;
        }

        #endregion

        public async Task<Dictionary<string, string[]>> GetInfoBox(long pageId)
        {
            var json = await _client.GetStringAsync($"{EndpointURL}?action=parse&pageid={pageId}&format=json&prop=text");

            var parse = JsonConvert.DeserializeObject<Models.Vendor.Parse>(json);

            if (parse == null)
            {
                return null;
            }

            if (parse.Error != null)
            {
                throw new Exception(parse.Error.Info);
            }

            var document = _parser.Parse(parse.Page.Parse.Content);

            var trs = document.QuerySelectorAll(".infobox > tbody > tr");
            Dictionary<string, string[]> infoBox = new Dictionary<string, string[]>();

            foreach (var tr in trs.Where(x => x.FirstElementChild is IHtmlTableHeaderCellElement))
            {
                var th = tr.FirstElementChild as IHtmlTableHeaderCellElement;
                var td = tr.LastElementChild as IHtmlTableDataCellElement;

                var lis = td.QuerySelectorAll("li");

                if (lis.Any())
                {
                    infoBox.Add(th.TextContent, lis.Select(x => x.TextContent).ToArray());
                }
                else
                {
                    infoBox.Add(th.TextContent, new string[] { td.TextContent });
                }
            }

            return infoBox;
        }

        public async Task<List<Page>> Search(string keyword, int? offset = 0, int? limit = 10)
        {
            var json = await _client.GetStringAsync($"{EndpointURL}?format=json&action=query&generator=search&" +
                $"gsrsearch={keyword}&gsrlimit={limit}&gsroffset={offset}&prop=extracts|pageimages&exintro&explaintext&" +
                "piprop=original");

            var vendorPages = JObject.Parse(json)?["query"]?["pages"]?.Values().Select(x => x.ToObject<Models.Vendor.Page>());

            var pages = Mapper.Map<List<Page>>(vendorPages);

            return pages ?? new List<Page>();
        }

        public async Task<List<Page>> SearchTitle(string keyword, int? offset = 0, int? limit = 10)
        {
            var json = await _client.GetStringAsync($"{EndpointURL}?format=json&action=query&generator=search&" +
                $"gsrsearch={keyword}&gsrlimit={limit}&gsroffset={offset}&prop=extracts|pageimages&exintro&explaintext&" +
                "piprop=original");

            var vendorPages = JObject.Parse(json)?["query"]?["pages"]?.Values().Select(x => x.ToObject<Models.Vendor.Page>());

            var pages = Mapper.Map<List<Page>>(vendorPages);

            return pages ?? new List<Page>();
        }
    }
}