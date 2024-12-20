using AutoMapper;
using OkalaExchangeRatesTestTask.Application.Models;
using OkalaExchangeRatesTestTask.Domain.Entities;

namespace OkalaExchangeRatesTestTask.WebAPI.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CryptoPriceData, CryptoPrice>()
            .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
            .ForMember(dest => dest.Quote, opt => opt.MapFrom(src => src.Quote.ToDictionary(q => q.Key, q => q.Value.Price)));
    }
}
