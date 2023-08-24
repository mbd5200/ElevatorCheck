using AutoMapper;
using ElevatorCheckAPI.Business.Abstract;
using ElevatorCheckAPI.Entity.DTO.Maintenance;
using ElevatorCheckAPI.Entity.DTO.Structure;
using ElevatorCheckAPI.Entity.Poco;
using ElevatorCheckAPI.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElevatorCheckAPI.Api.Controllers
{
    public class MaintenanceController : Controller
    {
 
            private readonly IMaintenanceService _maintenanceService;
            private readonly IStructureService _structureService;
            private readonly IMapper _mapper;
            public MaintenanceController(IMapper mapper, IMaintenanceService MaintenanceService, IStructureService StructureService)
            {
                _mapper = mapper;
                _maintenanceService = MaintenanceService;
                _structureService = StructureService;
            }

            [HttpGet("/Maintenances")]
            [ProducesResponseType(typeof(Sonuc<List<StructureDTOResponse>>), (int)HttpStatusCode.OK)]

            public async Task<IActionResult> GetMaintenances()
            {
                var maintenances = await _maintenanceService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false, "Structure");
            
                if (maintenances != null)
                {
                    List<MaintenanceDTOResponse> MaintenanceDTOResponseList = new();

                    foreach (var maintenance in maintenances)
                    {
                        MaintenanceDTOResponseList.Add(_mapper.Map<MaintenanceDTOResponse>(maintenance));
                    }
                    return Ok(Sonuc<List<MaintenanceDTOResponse>>.SuccessWithData(MaintenanceDTOResponseList));
                }
                else
                {
                    return NotFound(Sonuc<List<StructureDTOResponse>>.SuccessNoDataFound());
                }
            }


            [HttpGet("/Maintenance/{MaintenanceGUID}")]
            [ProducesResponseType(typeof(Sonuc<List<StructureDTOResponse>>), (int)HttpStatusCode.OK)]

            public async Task<IActionResult> GetMaintenance(Guid maintenanceGUID)
            {
                var maintenance = await _maintenanceService.GetAsync(q => q.Guid == maintenanceGUID, "Structure");
                
                if (maintenance != null)
                {
                    MaintenanceDTOResponse MaintenanceDTOResponse = _mapper.Map<MaintenanceDTOResponse>(maintenance);

                    return Ok(Sonuc<MaintenanceDTOResponse>.SuccessWithData(MaintenanceDTOResponse));
                }
                else
                {
                    return NotFound(Sonuc<MaintenanceDTOResponse>.SuccessNoDataFound());
                }
            }

            [HttpPost("/AddMaintenance")]
            [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

            public async Task<IActionResult> AddMaintenance([FromBody] MaintenanceDTORequest MaintenanceDTO)
            {
                Structure Structure = await _structureService.GetAsync(q => q.Guid == MaintenanceDTO.StructureGUID);

                Maintenance Maintenance = _mapper.Map<Maintenance>(MaintenanceDTO);

                Maintenance.Structure = Structure;

                await _maintenanceService.AddAsync(Maintenance);

                return Ok(Sonuc<bool>.SuccessWithData(true));
            }


            [HttpPost("/UpdateMaintenance")]
            [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> UpdateMaintenance([FromBody] MaintenanceDTORequest maintenanceDTO)
            {
                Maintenance maintenance = await _maintenanceService.GetAsync(q => q.Guid == maintenanceDTO.Guid);

                Structure structure = await _structureService.GetAsync(q => q.Guid == maintenanceDTO.StructureGUID);

                maintenance.Structure = structure;
                maintenance.LastMaintenanceDate = maintenanceDTO.LastMaintenanceDate;
                maintenance.RemainingDate = maintenanceDTO.RemainingDate;
                

                await _maintenanceService.UpdateAsync(maintenance);

                return Ok(Sonuc<bool>.SuccessWithData(true));
            }

        }
    }

