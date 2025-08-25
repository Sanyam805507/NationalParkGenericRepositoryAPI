using NationalParkGenericRepositoryAPI.Data;
using NationalParkGenericRepositoryAPI.Repository.IRepository;

namespace NationalParkGenericRepositoryAPI.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            NationalPark =new NationalParkRepository(context);
            Trail =new TrailRepository(context);
        }
        public INationalParkRepository NationalPark {  get; set; }
        public ITrailRepository Trail {  get; set; }    

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
