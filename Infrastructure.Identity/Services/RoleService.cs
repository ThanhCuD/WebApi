using Application.DTOs.Account;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Response<int>> CreateRoleAsync(CreateRoleRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.Name);
            if (role != null)
            {
                throw new ApiException($"{request.Name} has been taken!");
            }
            var newRole = new IdentityRole()
            {
                Name = request.Name
            };
            await _roleManager.CreateAsync(newRole);
            return new Response<int>(newRole.Id);
        }

        public async Task<Response<int>> DeleteRoleAsync(DeleteRoleRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role == null)
            {
                throw new ApiException("not found id");
            }
            await _roleManager.DeleteAsync(role);
            return new Response<int>(role.Id);
        }

        public async Task<Response<IEnumerable<GetAllRoleResponse>>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var lst = new List<GetAllRoleResponse>();
            foreach (var item in roles)
            {
                var roleResponse = new GetAllRoleResponse()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                lst.Add(roleResponse);
            }
            return new Response<IEnumerable<GetAllRoleResponse>>(lst);
        }
    }
}
