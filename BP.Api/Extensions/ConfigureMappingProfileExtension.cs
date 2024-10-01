using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BP.Api.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMAppingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);
            return service;
        }
    }

    public class AutoMapperMAppingProfile : Profile
    {
        public AutoMapperMAppingProfile()
        {
            CreateMap<BP.Api.Data.Models.Contact, BP.Api.Models.ContactDVO>()
                .ForMember(x=>x.FullName,y=>y.MapFrom(z=>z.FirstName +" "+z.LastName))
                .ForMember(x=>x.Id,y=>y.MapFrom(z=>z.Id))
                .ReverseMap();
        }
    }
}
