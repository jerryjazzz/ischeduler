using System.Collections.Generic;
using System.Threading.Tasks;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAssignmentsAsync();
        Task<Assignment> GetAssignmentAsync(string id);
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<Assignment> UpdateAssignmentAsync(Assignment assignment);
        Task<Assignment> DeleteAssignmentAsync(string id);
    }
}