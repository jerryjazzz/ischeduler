using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using IScheduler.DataAccess.Context;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IAppDbContext _dbContext;

        public AssignmentRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Assignment>> GetAssignmentsAsync()
        {
            return Task.Run(() =>
            {
                List<Assignment> assignments = _dbContext.Assignments.ToList();
                return assignments;
            });
        }

        public Task<Assignment> GetAssignmentAsync(string id)
        {
            return Task.Run(() =>
            {
                Assignment assignment = _dbContext.Assignments.Find(id);
                return assignment;
            });
        }

        public Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            return Task.Run(() =>
            {
                assignment.Id = Guid.NewGuid().ToString();
                _dbContext.Assignments.Add(assignment);
                return assignment;
            });
        }

        public Task<Assignment> UpdateAssignmentAsync(Assignment assignment)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrEmpty(assignment.Id)) assignment.Id = Guid.NewGuid().ToString();
                _dbContext.Assignments.AddOrUpdate(assignment);
                return assignment;
            });
        }

        public Task<Assignment> DeleteAssignmentAsync(string id)
        {
            return Task.Run(() =>
            {
                Assignment assignment = _dbContext.Assignments.Find(id);
                if (assignment == null) return null;
                _dbContext.Assignments.Remove(assignment);
                return assignment;
            });
        }
    }
}