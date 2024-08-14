using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAcademy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(GroupCreateDto groupCreateDto)
        {
            return Ok(await _groupService.Create(groupCreateDto));
        }


        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _groupService.GetAll());
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var data = await _groupService.GetOne(name);
            return Ok(data.Students[0].Name);
        }
    }
}
