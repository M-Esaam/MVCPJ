namespace RepositoryPatternWithUOW.Core.Repository
{
    public interface IUnitOfWorkRepository: IDisposable
    {
       //IBaseRepository<UnitOfWork> BaseRepository { get; }
       
        void Complete();
    }
}
