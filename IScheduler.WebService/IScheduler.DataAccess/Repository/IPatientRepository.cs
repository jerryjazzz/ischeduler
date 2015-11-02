using System.Collections.Generic;
using System.Threading.Tasks;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientAsync(string id);
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<Patient> DeletePatientAsync(string id);
    }
}