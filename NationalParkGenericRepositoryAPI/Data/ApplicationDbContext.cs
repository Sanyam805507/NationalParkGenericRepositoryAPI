using Microsoft.EntityFrameworkCore;
using NationalParkGenericRepositoryAPI.Models;

namespace NationalParkGenericRepositoryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<NationalPark> NationalParks { get; set; }
        public DbSet<Trail> Trails { get; set; }
    }
}
