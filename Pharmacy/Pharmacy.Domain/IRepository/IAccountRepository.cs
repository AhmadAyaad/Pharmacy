using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Domain.IRepository
{
    public interface IAccountRepository
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetUserByIdIncludedRoleAsync(string userId);
        Task<User> GetUserByNameAsync(string userName);
        Task<User> GetUserByEmailAsync(string userEmail);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetAllActiveAccountsEmailByRoleAsync();
        Task<IList<string>> GetRolesByUserAsync(User user);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task<bool> CheckPasswordAsync(string userName, string password);
        Task<IdentityResult> ChangePasswordAsync(string userName, string password, string newPassword);
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);
        Task<string> GeneratePasswordResetTokenAsync(User user);

    }
}
