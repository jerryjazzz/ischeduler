using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using IScheduler.DataAccess.Dto;
using IScheduler.DataAccess.Repository;

namespace IScheduler.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Patient")]
    public class PatientController : BaseController
    {
        private readonly IPatientRepository _repository;
        
        public PatientController(IPatientRepository repository)
        {
            this._repository = repository;
        }
        
        [Route("All")]
        public async Task<IHttpActionResult> GetPatients()
        {
            try
            {
                IList<Patient> patients = await _repository.GetPatientsAsync();
                if (patients == null || patients.Count == 0) return NotFound();
                return Ok(patients);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }

        public async Task<IHttpActionResult> GetPatient(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return BadRequest();
                Patient patient = await _repository.GetPatientAsync(id);
                if (patient == null) return NotFound();
                return Ok(patient);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
        
        [Route("Register")]
        public async Task<IHttpActionResult> PostPatient(Patient patient)
        {
            try
            {
                if (patient == null) return BadRequest();
                Patient retPatent = await _repository.CreatePatientAsync(patient);
                if (retPatent == null) return BadRequest();
                return Created("", retPatent);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
        
        [Route("Update")]
        public async Task<IHttpActionResult> PutPatient(Patient patient)
        {
            try
            {
                if (string.IsNullOrEmpty(patient?.Id)) return BadRequest();
                Patient retPatient = await _repository.UpdatePatientAsync(patient);
                if (retPatient == null) return BadRequest();
                return Ok(retPatient);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
        
        [Route("Delete")]
        public async Task<IHttpActionResult> DeletePatient(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return BadRequest();
                Patient patient = await _repository.DeletePatientAsync(id);
                if (patient == null) return NotFound();
                return Ok(patient);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
    }
}
