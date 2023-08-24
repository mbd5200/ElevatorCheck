using AutoMapper;
using ElevatorCheckAPI.Api.Aspects;
using ElevatorCheckAPI.Business.Abstract;
using ElevatorCheckAPI.Entity.Poco;
using ElevatorCheckAPI.Entity.Result;
using ElevatorCheckAPI.Entity.DTO.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ElevatorCheckAPI.Api.Validation.FluentValidation;
using ElevatorCheckAPI.Entity.DTO.Structure;

namespace ElevatorCheckAPI.Api.Controllers
{
    public class StructureController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStructureService _structureService;
        private readonly IMapper _mapper;
        public StructureController(IMapper mapper, IStructureService StructureService, IUserService userService)
        {
            _mapper = mapper;
            _structureService = StructureService;
            _userService = userService;
        }

        [HttpGet("/Structures")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetStructures()
        {
            var Structures = await _structureService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false, "User");
            //user = null;
            if (Structures != null)
            {
                List<StructureDTOResponse> StructureDTOResponseList = new();

                foreach (var Structure in Structures)
                {
                    StructureDTOResponseList.Add(_mapper.Map<StructureDTOResponse>(Structure));
                }
                return Ok(Sonuc<List<StructureDTOResponse>>.SuccessWithData(StructureDTOResponseList));
            }
            else
            {
                return NotFound(Sonuc<List<UserResponseDTO>>.SuccessNoDataFound());
            }
        }


        [HttpGet("/Structure/{StructureGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetStructure(Guid structureGUID)
        {
            var structure = await _structureService.GetAsync(q => q.Guid == structureGUID, "User");
            //user = null;
            if (structure != null)
            {
                StructureDTOResponse structureDTOResponse = _mapper.Map<StructureDTOResponse>(structure);

                return Ok(Sonuc<StructureDTOResponse>.SuccessWithData(structureDTOResponse));
            }
            else
            {
                return NotFound(Sonuc<StructureDTOResponse>.SuccessNoDataFound());
            }
        }

        [HttpPost("/AddStructure")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> AddStructure([FromBody] StructureDTORequest structureDTO)
        {
            User user = await _userService.GetAsync(q => q.Guid == structureDTO.UserGUID);

            Structure structure = _mapper.Map<Structure>(structureDTO);

            structure.User = user;

            await _structureService.AddAsync(structure);

            return Ok(Sonuc<bool>.SuccessWithData(true));
        }


        [HttpPost("/UpdateStructure")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateStructure([FromBody] StructureDTORequest structureDTO)
        {
            Structure structure = await _structureService.GetAsync(q => q.Guid == structureDTO.Guid);

            User user = await _userService.GetAsync(q => q.Guid == structureDTO.UserGUID);

            structure.User = user;
            structure.StructureName = structureDTO.StructureName;
            structure.Address = structureDTO.Address;
            structure.MaintenanceFee = structureDTO.MaintenanceFee ?? structure.MaintenanceFee;

            await _structureService.UpdateAsync(structure);

            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpPost("/RemoveStructure")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveStructure([FromBody] StructureDTORequest structureDTO)
        {
            Structure structure = await _structureService.GetAsync(q => q.Guid == structureDTO.Guid);

            structure.IsActive = false;
            structure.IsDeleted = true;
            await _structureService.UpdateAsync(structure);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }
    }
}
