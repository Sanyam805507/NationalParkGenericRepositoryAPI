using NationalParkGenericRepositoryAPI.Data;
using NationalParkWEBAPP.Models;
using NationalParkWEBAPP.Repository.IRepository;

namespace NationalParkWEBAPP.Repository
{
    public class TrailRepository : Repository<Trail>, ITrailRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TrailRepository(IHttpClientFactory httpClientFactory): base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }

       
    }
}
