using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoksaProject.Models
{
    public interface IRepository<T>
    {
        T Get(int Id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Delete(int? id);

        T Update(T entity);
    }

    
}