using Application.DTOs.Account;
using Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<Response<int>> CreateRoleAsync(CreateRoleRequest request);
        Task<Response<IEnumerable<GetAllRoleResponse>>> GetRolesAsync();
        Task<Response<int>> DeleteRoleAsync(DeleteRoleRequest request);
    }
}
