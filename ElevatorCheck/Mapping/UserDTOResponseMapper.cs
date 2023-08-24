using AutoMapper;
using ElevatorCheckAPI.Entity.DTO.User;
using ElevatorCheckAPI.Entity.Poco;

namespace ElevatorCheckAPI.Api.Mapping
{

    public class UserDTOResponseMapper : Profile
    {
        public UserDTOResponseMapper()
        {
            CreateMap<User, UserResponseDTO>()
            .ForMember(dest => dest.AdiSoyadi, opt =>
            {
                opt.MapFrom(src => src.NameSurname);
            })
                .ForMember(dest => dest.KullaniciAdi, opt =>
                {
                    opt.MapFrom(src => src.Username);
                })
                .ForMember(dest => dest.Sifre, opt =>
                {
                    opt.MapFrom(src => src.Password);
                })
                .ForMember(dest => dest.Tel, opt =>
                {
                    opt.MapFrom(src => src.Phone);
                })
                .ForMember(dest => dest.Firma, opt =>
                {
                    opt.MapFrom(src => src.Company);
                }).ReverseMap();

        }
    }
}
