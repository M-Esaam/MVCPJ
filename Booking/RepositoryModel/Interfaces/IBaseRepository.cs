using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModel.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetByID(int id);

        IEnumerable<T> GetAll();

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

    }
}
