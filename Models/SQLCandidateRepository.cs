using System.Collections.Generic;
using System.Linq;
using CoksaProject.Data;
using Microsoft.AspNetCore.Identity;

namespace CoksaProject.Models
{
    public class SQLCandidateRepository : IRepository<Candidate>

    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SQLCandidateRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        Candidate IRepository<Candidate>.Get(int Id)
        {
            return _context.Candidates.Find(Id);
        }

        IEnumerable<Candidate> IRepository<Candidate>.GetAll()
        {
            return _context.Candidates;
        }

        Candidate IRepository<Candidate>.Add(Candidate entity)
        {
            _context.Candidates.Add(entity);
            _context.SaveChanges();
            return entity;        }

        Candidate IRepository<Candidate>.Delete(int? id)
        {
            Candidate candidate= _context.Candidates.Find(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                _context.SaveChanges();
            }

            return candidate;
            
        }

        public Candidate Update(Candidate entity)
        {
            var entitys=_context.Candidates.Attach(entity);
            entitys.State = Microsoft.EntityFrameworkCore
                .EntityState.Modified;
            _context.SaveChanges();
            return entity;        
        }
    }
}