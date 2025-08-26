using NationalParkGenericRepositoryAPI.Data;
using NationalParkWEBAPP.Models;
using NationalParkWEBAPP.Repository.IRepository;

namespace NationalParkWEBAPP.Repository
{
    public class NationalParkRepository : Repository<NationalPark>, INationalParkRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NationalParkRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }


    }
}