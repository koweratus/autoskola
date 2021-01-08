using System.Collections.Generic;
using CoksaProject.Data;

namespace CoksaProject.Models
{
    public class SQLHoursRepository : IRepository<Hours>
    {
        private readonly ApplicationDbContext _context;

        public SQLHoursRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Hours Get(int Id)
        {
            return _context.Hourses.Find(Id);
        }

        public IEnumerable<Hours> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Hours Add(Hours entity)
        {
            _context.Hourses.Add(entity);
            _context.SaveChanges();
            return entity; 
        }

        public Hours Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Hours Update(Hours entity)
        {
            var entitys=_context.Hourses.Attach(entity);
            entitys.State = Microsoft.EntityFrameworkCore
                .EntityState.Modified;
            _context.SaveChanges();
            return entity;             }
    }
}