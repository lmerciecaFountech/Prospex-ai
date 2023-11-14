using AutoMapper;
using System;
using System.Linq.Expressions;
using Wikipedia.MediaWiki.Models;

namespace Wikipedia.MediaWiki.API.Mappers
{
    public static class MediaWikiMapper
    {
        public static void Initialize()
        {
            var imageUrlExpression = GetImageUrlExpression();

            Mapper.Initialize(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.CreateMap<Models.Vendor.Page, Page>()
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(imageUrlExpression));
            });
        }

        private static Expression<Func<Models.Vendor.Page, string>> GetImageUrlExpression()
        {
            Func<Models.Vendor.Page, string> imageUrlFunc = (src) =>
            {
                return src?.Original?.Source;
            };

            Expression<Func<Models.Vendor.Page, string>> imageUrlExpression = (src) => imageUrlFunc(src);

            return imageUrlExpression;
        }
    }
}
