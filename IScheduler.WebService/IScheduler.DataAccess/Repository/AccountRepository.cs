using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using IScheduler.DataAccess.Context;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAppDbContext _dbContext;

        public AccountRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Account>> GetUsersAsync()
        {
            return Task.Run(() =>
            {
                List<Account> accounts = _dbContext.Users.ToList();
                return accounts;
            });
        }

        public Task<Account> GetUserAsync(string id)
        {
            return Task.Run(() =>
            {
                Account account = _dbContext.Users.Find(id);
                return account;
            });
        }

        public Task<Account> UpdateUserAsync(Account account)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrEmpty(account.Id)) account.Id = Guid.NewGuid().ToString();
                _dbContext.Users.AddOrUpdate(account);
                return account;
            });
        }

        public Task<Account> DeleteUserAsync(string id)
        {
            return Task.Run(() =>
            {
                Account account = _dbContext.Users.Find(id);
                if (account == null) return null;
                _dbContext.Users.Remove(account);
                return account;
            });
        }
    }
}