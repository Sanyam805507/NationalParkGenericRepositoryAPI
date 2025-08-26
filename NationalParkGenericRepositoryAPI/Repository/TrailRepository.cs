using Microsoft.EntityFrameworkCore;
using NationalParkGenericRepositoryAPI.Data;
using NationalParkGenericRepositoryAPI.Models;
using NationalParkGenericRepositoryAPI.Repository.IRepository;

namespace NationalParkGenericRepositoryAPI.Repository
{
    public class TrailRepository:Repository<Trail>,ITrailRepository
    {
        private readonly ApplicationDbContext _context;
        public TrailRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
        //public ICollection<Trail> GetTrails()
        //{
        //    return _context.Trails.Include(t => t.NationalPark).ToList();
        //}
    }
}
