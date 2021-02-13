using Application.DTOs.Account;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRoleAsync(CreateRoleRequest request)
        {
            return Ok(await _roleService.CreateRoleAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roleService.GetRolesAsync());
        }
        [HttpPost("deleteRole")]
        public async Task<IActionResult> DeleteRole(DeleteRoleRequest request)
        {
            return Ok(await _roleService.DeleteRoleAsync(request));
        }
        [HttpPost("updateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
        {
            return Ok(await _roleService.UpdateRoleAsync(request));
        }
        #region private

        #endregion
    }
}