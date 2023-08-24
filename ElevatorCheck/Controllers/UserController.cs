using AutoMapper;
using ElevatorCheckAPI.Entity.DTO.User;
using ElevatorCheckAPI.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using ElevatorCheckAPI.Api.Validation.FluentValidation;
using ElevatorCheckAPI.Business.Abstract;
using ElevatorCheckAPI.Helper.CustomException;
using System.Net;

namespace ElevatorCheckAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("/Users")]
        [ProducesResponseType(typeof(Sonuc<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();

            List<UserResponseDTO> userDTOList = new();

            foreach (var user in users)
            {
                userDTOList.Add(_mapper.Map<UserResponseDTO>(user));

            }

            return Ok(Sonuc<List<UserResponseDTO>>.SuccessWithData(userDTOList));
        }

        [HttpGet("/User/{id}")]
        [ProducesResponseType(typeof(Sonuc<UserResponseDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetAsync(q => q.id == id);

            if (user != null)
            {
                UserResponseDTO userDTO = _mapper.Map<UserResponseDTO>(user);

                return Ok(Sonuc<UserResponseDTO>.SuccessWithData(userDTO));
            }
            return NotFound(Sonuc<UserResponseDTO>.SuccessNoDataFound("Kullanıcı Bulunamadı"));

        }

    }
}
