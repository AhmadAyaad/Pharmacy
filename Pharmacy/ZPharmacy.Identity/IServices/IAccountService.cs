using System.Threading.Tasks;
using ZPharmacy.Identity.DTOS;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Identity.IServices
{
    public interface IAccountService
    {
        Task<Response> RegisterUserAsync(ReigsterUserDTO reigsterUserDTO);
        Task<Response<UserDTO>> LoginAsync(LoginDTO loginDTO);
        Task<string> GetUserNameAsync(string userId);
    }
}
