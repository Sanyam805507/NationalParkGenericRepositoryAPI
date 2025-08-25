using NationalParkGenericRepositoryAPI.Data;
using NationalParkGenericRepositoryAPI.Models;
using NationalParkGenericRepositoryAPI.Repository.IRepository;

namespace NationalParkGenericRepositoryAPI.Repository
{
    public class NationalParkRepository:Repository<NationalPark>,INationalParkRepository
    {
        private readonly ApplicationDbContext _context;
        public NationalParkRepository(ApplicationDbContext context):base(context) 
        {
                _context = context;
        }
    }
}
