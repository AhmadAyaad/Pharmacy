using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;

namespace ZPharmacy.Infrastructure.Repostiory
{
    public class AccountRepository :  IAccountRepository
    {
        private readonly PharmacyDbContext _context;
        private readonly ApplicationUserManager _applicationUserManager;

        public AccountRepository(PharmacyDbContext context,ApplicationUserManager applicationUserManager)
        {
            _context = context;
            _applicationUserManager = applicationUserManager;
        }

        public Task<IdentityResult> ChangePasswordAsync(string userName, string password, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPasswordAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllActiveAccountsEmailByRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesByUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(string userId)
        {
            return _applicationUserManager.FindByIdAsync(userId);
        }

        public Task<User> GetUserByIdIncludedRoleAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
