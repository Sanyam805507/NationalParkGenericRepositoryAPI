namespace NationalParkGenericRepositoryAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        INationalParkRepository NationalPark { get; }  
        ITrailRepository Trail { get; }
        

        void Save();
    }
}
