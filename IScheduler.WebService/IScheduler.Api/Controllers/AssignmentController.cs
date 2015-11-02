using System;
using System.Threading.Tasks;
using System.Web.Http;
using IScheduler.DataAccess.Dto;
using IScheduler.DataAccess.Repository;

namespace IScheduler.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Assignment")]
    public class AssignmentController : BaseController
    {
        private readonly IAssignmentRepository _repository;
        
        public AssignmentController(IAssignmentRepository repository)
        {
            _repository = repository;
        }
        
        [Route("All")]
        public async Task<IHttpActionResult> GetAssignment()
        {
            try
            {
                var assignments = await _repository.GetAssignmentsAsync();
                if (assignments == null) return NotFound();
                return Ok(assignments);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
        
        public async Task<IHttpActionResult> GetAssignment(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return BadRequest();
                var assignment = await _repository.GetAssignmentAsync(id);
                if (assignment == null) return NotFound();
                return Ok(assignment);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
        
        [Route("Register")]
        public async Task<IHttpActionResult> PostAssignment(Assignment assignment)
        {
            try
            {
                if (assignment == null) return BadRequest();
                assignment = await _repository.CreateAssignmentAsync(assignment);
                if (assignment == null) return InternalServerError();
                return Created("", assignment);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
        
        [Route("Update")]
        public async Task<IHttpActionResult> PutAssignment(Assignment assignment)
        {
            try
            {
                if (assignment == null) return BadRequest();
                assignment = await _repository.UpdateAssignmentAsync(assignment);
                if (assignment == null) return InternalServerError();
                return Ok(assignment);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
        
        [Route("Delete")]
        public async Task<IHttpActionResult> DeleteAssignment(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return BadRequest();
                var assignment = await _repository.DeleteAssignmentAsync(id);
                if (assignment == null) return NotFound();
                return Ok(assignment);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
    }
}
