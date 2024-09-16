﻿using AutoMapper;
using Otel.EntityLayer.Concrete;
using Otel.WebUI.DTOs.AboutDTO;
using Otel.WebUI.DTOs.LoginDTO;
using Otel.WebUI.DTOs.RegisterDTO;
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

            CreateMap<CreateUserDTO, AppUser>().ReverseMap();

            CreateMap<LoginUserDTO, AppUser>().ReverseMap();

            CreateMap<ResultAboutDTO, About>().ReverseMap();
            CreateMap<UpdateAboutDTO, About>().ReverseMap();

        }
    }
}
