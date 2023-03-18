using BookingLibrary.Models;
using RepositoryModel.Interfaces;

namespace RepositoryPatternWithUOW.Core.Repository
{
    public interface IUnitOfWorkRepository: IDisposable
    {
        //IBaseRepository<UnitOfWork> BaseRepository { get; }
        IBaseRepository<Hotel> Hotels { get; }
        IBaseRepository<Hotel_Manager> HotelManagers { get; }
        int Complete();
    }
}
