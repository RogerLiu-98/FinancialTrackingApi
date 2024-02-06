using AutoMapper;
using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.Model;

namespace FinancialTrackingApi.Service.MappingProfiles
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<Transaction, TransactionModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Category.Description));

            CreateMap<TransactionModel, Transaction>()
                .ForMember(dest => dest.Category.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Category.Name, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Category.Description, opt => opt.MapFrom(src => src.CategoryDescription));
        }
    }
}
