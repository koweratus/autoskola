using System.Collections.Generic;
using System.Threading.Tasks;
using CoksaProject.Data;

namespace CoksaProject.Models
{
    public class SQLCarRepository : IRepository<Car>

    {
        private readonly ApplicationDbContext _context;

        public SQLCarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        Car IRepository<Car>.Get(int Id)
        {
            return _context.Car.Find(Id);
        }

        IEnumerable<Car> IRepository<Car>.GetAll()
        {
            return _context.Car;
        }

        Car IRepository<Car>.Add(Car entity)
        {
            _context.Car.Add(entity);
            _context.SaveChanges();
            return entity;        }

        Car IRepository<Car>.Delete(int? id)
        {
            Car cars= _context.Car.Find(id);
            if (cars != null)
            {
                _context.Car.Remove(cars);
                _context.SaveChanges();
            }

            return cars;        }

        public Car Update(Car entity)
        {
            var employe=_context.Car.Attach(entity);
            employe.State = Microsoft.EntityFrameworkCore
                .EntityState.Modified;
            _context.SaveChanges();
            return entity;        }
    }
}