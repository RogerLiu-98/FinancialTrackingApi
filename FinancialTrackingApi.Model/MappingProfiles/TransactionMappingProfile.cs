using AutoMapper;
using FinancialTrackingApi.DataAccess.Entities;

namespace FinancialTrackingApi.Model.MappingProfiles
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<Transaction, TransactionModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Category.Description));

            CreateMap<TransactionModel, Transaction>();
        }
    }
}
