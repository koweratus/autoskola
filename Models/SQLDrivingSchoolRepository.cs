using System.Collections.Generic;
using System.Linq;
using CoksaProject.Data;

namespace CoksaProject.Models
{
    public class SQLDrivingSchoolRepository : IRepository<DrivingSchool>
    {
        private readonly ApplicationDbContext _context;

        public SQLDrivingSchoolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DrivingSchool Get(int Id)
        {
            return _context.DrivingSchools.Find(Id);        }

        public IEnumerable<DrivingSchool> GetAll()
        {
            return _context.DrivingSchools;
        }

        public DrivingSchool Add(DrivingSchool entity)
        {
            throw new System.NotImplementedException();
        }

        public DrivingSchool Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public DrivingSchool Update(DrivingSchool entity)
        {
            throw new System.NotImplementedException();
        }
    }
}