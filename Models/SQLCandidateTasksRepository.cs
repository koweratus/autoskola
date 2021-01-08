using System.Collections.Generic;
using CoksaProject.Data;

namespace CoksaProject.Models
{
    public class SQLCandidateTasksRepository : IRepository<CandidateTasks>
    {        private readonly ApplicationDbContext _context;

        public SQLCandidateTasksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CandidateTasks Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CandidateTasks> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public CandidateTasks Add(CandidateTasks entity)
        {
            _context.CandidateTaskses.Add(entity);
            _context.SaveChanges();
            return entity;         }

        public CandidateTasks Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public CandidateTasks Update(CandidateTasks entity)
        {
            throw new System.NotImplementedException();
        }
    }
}