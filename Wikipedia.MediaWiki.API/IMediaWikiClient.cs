using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wikipedia.MediaWiki.Models;

namespace Wikipedia.MediaWiki.API
{
    public interface IMediaWikiClient
    {
        Task<List<Page>> Search(string keyword, int? offset = 0, int? limit = 10);
        Task<List<Page>> SearchTitle(string keyword, int? offset = 0, int? limit = 10);
        Task<Dictionary<string, string[]>> GetInfoBox(long pageId);
    }
}
