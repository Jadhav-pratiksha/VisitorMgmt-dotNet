using AutoMapper;
using Basiccrud.Common;
using Basiccrud.CosmosDb;
using Basiccrud.Entities;
using Basiccrud.IServices;
using Basiccrud.Models;

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

        public async Task<AdminModel> RegisterAdmin(AdminModel adminModel)
        {
            // mapping model to entity
            var admin = _mapper.Map<Admin>(adminModel);
            admin.Initialize(true, Credentials.AdminDocumentType, "UId", "Pratiksha");
            var response = await _cosmosDbServices.RegisterAdmin(admin);

            // reverse mapping response entity to model
            var result = _mapper.Map<AdminModel>(response);
            return result;

        }


    }
}
