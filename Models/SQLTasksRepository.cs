using System.Collections.Generic;
using System.Linq;
using CoksaProject.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace CoksaProject.Models
{
    public class SQLTasksRepository : IRepository<Tasks>
    {
        private readonly ApplicationDbContext _context;

    
        public SQLTasksRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        Tasks IRepository<Tasks>.Get(int Id)
        {
            return _context.Taskses.Find(Id);
        }

            
        public IEnumerable<Tasks> GetAll()
        {
            return _context.Taskses;
      
        }

        Tasks  IRepository<Tasks>.Add(Tasks entity)
        {
            _context.Taskses.Add(entity);
            _context.SaveChanges();
            return entity; 
        }

        public Tasks Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Tasks Update(Tasks entity)
        {
            var entitys=_context.Taskses.Attach(entity);
            entitys.State = Microsoft.EntityFrameworkCore
                .EntityState.Modified;
            _context.SaveChanges();
            return entity;             }
    }
}