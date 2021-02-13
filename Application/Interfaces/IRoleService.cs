using Application.DTOs.Account;
using Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<Response<string>> CreateRoleAsync(CreateRoleRequest request);
        Task<Response<IEnumerable<GetAllRoleResponse>>> GetRolesAsync();
        Task<Response<string>> DeleteRoleAsync(DeleteRoleRequest request);
        Task<Response<string>> UpdateRoleAsync(UpdateRoleRequest request);
    }
}
