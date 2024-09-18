using AutoMapper;
using Otel.EntityLayer.Concrete;
using Otel.WebUI.DTOs.AboutDTO;
using Otel.WebUI.DTOs.BookingDTO;
using Otel.WebUI.DTOs.LoginDTO;
using Otel.WebUI.DTOs.RegisterDTO;
using Otel.WebUI.DTOs.ServiceDTO;
using Otel.WebUI.DTOs.StaffDTO;
using Otel.WebUI.DTOs.TestimonialDTO;

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

            CreateMap<ResultTestimonialDTO, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDTO, Staff>().ReverseMap();

            CreateMap<CreateBookingDTO, Booking>().ReverseMap();
            CreateMap<UpdateBookingDTO, Booking>().ReverseMap();

        }
    }
}
