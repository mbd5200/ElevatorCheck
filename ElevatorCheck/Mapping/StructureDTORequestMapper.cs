using AutoMapper;
using ElevatorCheckAPI.Entity.DTO.Structure;
using ElevatorCheckAPI.Entity.Poco;

namespace ElevatorCheckAPI.Api.Mapping
{
    public class StructureDTORequestMapper:Profile
    {
        public StructureDTORequestMapper() 
        {
            CreateMap<Structure, StructureDTORequest>()
                   .ForMember(dest => dest.Guid,
                   opt =>
                   {
                       opt.MapFrom(src => src.Guid);
                   }).ForMember(dest => dest.StructureName,
                   opt =>
                   {
                       opt.MapFrom(src => src.StructureName);
                   }).ForMember(dest => dest.Address,
                   opt =>
                   {
                       opt.MapFrom(src => src.Address);
                   }).ForMember(dest => dest.MaintenanceCompany,
                   opt =>
                   {
                       opt.MapFrom(src => src.MaintenanceCompany);
                   }).ForMember(dest => dest.UserGUID,
                   opt =>
                   {
                       opt.MapFrom(src => src.User.Guid);
                   }).ForMember(dest => dest.MaintenanceFee,
                   opt =>
                   {
                       opt.MapFrom(src => src.MaintenanceFee);
                   }).ReverseMap();
        }



    }
    }

