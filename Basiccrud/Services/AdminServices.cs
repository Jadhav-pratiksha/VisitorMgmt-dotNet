using AutoMapper;
using Basiccrud.CosmosDb;
using Basiccrud.IServices;

namespace Basiccrud.Services
{
    public class AdminServices:IAdminServices
    {
        public ICosmosDbServices _cosmosDbServices;
        public IMapper _mapper;

        public AdminServices(ICosmosDbServices cosmosDbServices, IMapper mapper)
        {
            _cosmosDbServices = cosmosDbServices;
            _mapper = mapper;
        }


    }
}
