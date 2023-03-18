
using RepositoryEF;
using RepositoryModel.Interfaces;
using RepositoryPatternWithUOW.Core.Repository;

namespace RepositoryPatternWithUOW.EF.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
      //  public IBaseRepository<UnitOfWork> BaseRepository;

        public ApplicationDbContext context;

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            this.context = context;
           // UnitOfWork=new IBaseRepository<UnitOfWork>(context);
            
        }

        public void Complete()
        {
            context.SaveChanges(); 
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
