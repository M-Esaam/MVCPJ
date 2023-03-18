
using BookingLibrary.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryEF;
using RepositoryModel.Interfaces;
using RepositoryPatternWithUOW.Core.Repository;
using RepositoryPatternWithUOW.EF.Repository;
using static System.Reflection.Metadata.BlobBuilder;

namespace RepositoryEF.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
      

        public ApplicationDbContext context;
       public IBaseRepository<Hotel> Hotels { get;}
       public IBaseRepository<Hotel_Manager> HotelManagers { get;}

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            this.context = context;
            Hotels = new BaseRepository<Hotel>(context);
            HotelManagers = new BaseRepository<Hotel_Manager>(context);
            // UnitOfWork=new IBaseRepository<UnitOfWork>(context);

        }
        //public IBaseRepository<Hotel> Hotels { get; private set; }
        //public IBaseRepository<Hotel_Manager> HotelManagers { get; private set; }
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
