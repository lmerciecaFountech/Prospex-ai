using AutoMapper;
using SalesForce.Models;

namespace SalesForce.Mappers
{
    /// <summary>
    /// Graph Mapper initializer.
    /// </summary>
    public static class SalesForceMapper
    {
        #region Public methods
        /// <summary>
        /// Initialize mappers for graph service.
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.Vendor.Account, Account>()
                    .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active__c))
                    .ForMember(dest => dest.CustomerPriority, opt => opt.MapFrom(src => src.CustomerPriority__c))
                    .ForMember(dest => dest.NumberofLocations, opt => opt.MapFrom(src => src.NumberofLocations__c))
                    .ForMember(dest => dest.SLAExpirationDate, opt => opt.MapFrom(src => src.SLAExpirationDate__c))
                    .ForMember(dest => dest.SLASerialNumber, opt => opt.MapFrom(src => src.SLASerialNumber__c))
                    .ForMember(dest => dest.SLA, opt => opt.MapFrom(src => src.SLA__c))
                    .ForMember(dest => dest.UpsellOpportunity, opt => opt.MapFrom(src => src.UpsellOpportunity__c));
                cfg.CreateMap<Models.Vendor.Asset, Asset>();
                cfg.CreateMap<Models.Vendor.Contact, Contact>()
                    .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages__c))
                    .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level__c));
                cfg.CreateMap<Models.Vendor.Event, Event>();
                cfg.CreateMap<Models.Vendor.Lead, Lead>()
                    .ForMember(dest => dest.CurrentGenerators, opt => opt.MapFrom(src => src.CurrentGenerators__c))
                    .ForMember(dest => dest.NumberofLocations, opt => opt.MapFrom(src => src.NumberofLocations__c))
                    .ForMember(dest => dest.Primary, opt => opt.MapFrom(src => src.Primary__c))
                    .ForMember(dest => dest.ProductInterest, opt => opt.MapFrom(src => src.ProductInterest__c))
                    .ForMember(dest => dest.SICCode, opt => opt.MapFrom(src => src.SICCode__c));
                cfg.CreateMap<Models.Vendor.Opportunity, Opportunity>()
                    .ForMember(dest => dest.CurrentGenerators, opt => opt.MapFrom(src => src.CurrentGenerators__c))
                    .ForMember(dest => dest.DeliveryInstallationStatus, opt => opt.MapFrom(src => src.DeliveryInstallationStatus__c))
                    .ForMember(dest => dest.MainCompetitors, opt => opt.MapFrom(src => src.MainCompetitors__c))
                    .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderNumber__c))
                    .ForMember(dest => dest.TrackingNumber, opt => opt.MapFrom(src => src.TrackingNumber__c));
                cfg.CreateMap<Models.Vendor.Partner, Partner>();
                cfg.CreateMap<Models.Vendor.Pricebook2, Pricebook2>();
                cfg.CreateMap<Models.Vendor.Product2, Product2>();
                cfg.CreateMap<Models.Vendor.User, User>();
            });
        }
        #endregion
    }
}