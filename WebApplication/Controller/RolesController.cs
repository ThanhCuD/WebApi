using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Account;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        #region private

        #endregion
    }
}