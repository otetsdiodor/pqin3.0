using Microsoft.AspNet.Identity;
using ORMF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace pqin3._0.Models
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserLockoutStore<User, string>, IUserTwoFactorStore<User, string>
    {
        //NastedContext _context;
        IAuthRepo<User> _context;
        public UserStore()
        { }
        //public UserStore(NastedContext context)
        //{
        //    _context = context;
        //}
        public UserStore(IAuthRepo<User> context)
        {
            _context = context;
        }

        public Task CreateAsync(User user)
        {
            return Task.Factory.StartNew(() => _context.Add(user));
        }

        public Task DeleteAsync(User user)
        {
            return Task.Factory.StartNew(() => _context.Delete(user.Id));
        }

        public void Dispose()
        {
            Console.WriteLine("DISPOSED AHHA");
        }

        public Task<User> FindByIdAsync(string userId)
        {
            var kek = (User)_context.GetById(userId);
            return Task.Factory.StartNew(() => kek);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var user = (User)_context.GetByName(userName);
            return Task.Factory.StartNew(() => user);
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.Factory.StartNew(() => false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return Task.Factory.StartNew(() => new DateTimeOffset(DateTime.Now));
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            var us = (User)_context.GetById(user.Id);
            return Task.Factory.StartNew(() => us.PasswordHash/*.GetHashCode().ToString()*/);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.Factory.StartNew(() => false);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            var us = (User)_context.GetById(user.Id);
            if (us.PasswordHash == null || us.PasswordHash == "")
            {
                return Task.Factory.StartNew(() => false);
            }
            return Task.Factory.StartNew(() => true);
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            return Task.Factory.StartNew(() => Console.WriteLine("LOL"));
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return Task.Factory.StartNew(() => Console.WriteLine("LOL"));
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return Task.Factory.StartNew(() => Console.WriteLine("LOOOOL"));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.Factory.StartNew(() => _context.Update(user));
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.Factory.StartNew(() => Console.WriteLine("LOL"));
        }

        public Task UpdateAsync(User user)
        {
            return Task.Factory.StartNew(() => _context.Update(user));
        }
    }
}