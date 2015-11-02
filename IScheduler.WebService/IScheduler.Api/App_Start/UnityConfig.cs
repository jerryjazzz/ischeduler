using Microsoft.Practices.Unity;
using System.Web.Http;
using IScheduler.DataAccess.Context;
using IScheduler.DataAccess.Repository;
using Unity.WebApi;

namespace IScheduler.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAppDbContext, AppDbContext>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<IAssignmentRepository, AssignmentRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}