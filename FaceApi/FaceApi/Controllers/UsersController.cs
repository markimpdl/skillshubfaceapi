using FaceApi.DTOs;
using FaceApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaceApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            // Você já terá o fluxo de upload e integração com Azure em outro Service (não incluso aqui para clareza)
            var user = await _userService.CreateUserAsync(dto.Name, dto.SchoolIds, dto.BasePhotoUrl, dto.AzurePersonId);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _userService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _userService.GetByIdAsync(id));
    }
}
