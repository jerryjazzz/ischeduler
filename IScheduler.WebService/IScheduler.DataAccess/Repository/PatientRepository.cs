using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using IScheduler.DataAccess.Context;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IAppDbContext _dbContext;

        public PatientRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Patient>> GetPatientsAsync()
        {
            return Task.Run(() =>
            {
                List<Patient> patients = _dbContext.Patients.ToList();
                return patients;
            });
        }

        public Task<Patient> GetPatientAsync(string id)
        {
            return Task.Run(() =>
            {
                Patient patient = _dbContext.Patients.Find(id);
                return patient;
            });
        }

        public Task<Patient> CreatePatientAsync(Patient patient)
        {
            return Task.Run(() =>
            {
                patient.Id = Guid.NewGuid().ToString();
                _dbContext.Patients.Add(patient);
                return patient;
            });
        }

        public Task<Patient> UpdatePatientAsync(Patient patient)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrEmpty(patient.Id)) patient.Id = Guid.NewGuid().ToString();
                _dbContext.Patients.AddOrUpdate(patient);
                return patient;
            });
        }

        public Task<Patient> DeletePatientAsync(string id)
        {
            return Task.Run(() =>
            {
                Patient patient = _dbContext.Patients.Find(id);
                if (patient == null) return null;
                _dbContext.Patients.Remove(patient);
                return patient;
            });
        }
    }
}