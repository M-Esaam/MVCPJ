
using RepositoryEF;
using RepositoryModel.Interfaces;
using RepositoryPatternWithUOW.Core.Repository;
using RepositoryPatternWithUOW.EF;

namespace RepositoryPatternWithUOW.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        ApplicationDbContext context;
        IUnitOfWorkRepository unitOfWork;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public BaseRepository(ApplicationDbContext context,IUnitOfWorkRepository unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            unitOfWork.Complete();
           
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            unitOfWork.Complete();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Update(T entity)

        { 
            context.Update(entity); 
            unitOfWork.Complete();
            return entity;
           
        }
    }
}
