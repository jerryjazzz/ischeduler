using System.Collections.Generic;
using System.Threading.Tasks;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetUsersAsync();
        Task<Account> GetUserAsync(string id);
        Task<Account> UpdateUserAsync(Account account);
        Task<Account> DeleteUserAsync(string id);
    }
}