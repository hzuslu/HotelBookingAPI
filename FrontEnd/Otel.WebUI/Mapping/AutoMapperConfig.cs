using AutoMapper;
using Otel.EntityLayer.Concrete;
using Otel.WebUI.DTOs.ServiceDTO;

namespace Otel.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDTO, Service>().ReverseMap();
            CreateMap<CreateServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
        }
    }
}
