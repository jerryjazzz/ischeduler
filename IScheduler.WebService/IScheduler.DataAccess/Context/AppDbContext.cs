using System.Data.Entity;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<Account, Role>, IAppDbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Assignment> Assignments { get; set; }
        public IDbSet<Patient> Patients { get; set; }
    }
}
