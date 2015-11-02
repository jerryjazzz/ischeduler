using System.Data.Entity;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Context
{
    public interface IAppDbContext
    {
        IDbSet<Account> Users { get; }
        IDbSet<Role> Roles { get; }
        IDbSet<Address> Addresses { get; }
        IDbSet<Assignment> Assignments { get; }
        IDbSet<Patient> Patients { get; }
    }
}