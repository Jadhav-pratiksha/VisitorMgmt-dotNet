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

        public async Task<AdminModel> GetAdminByUId(GlobalUIdModel uIdModel)
        {

            var response = await _cosmosDbServices.GetAdminByUId(uIdModel.UId);
            if (response == null)
            {
                throw new Exception("Admin Not Found!");
            }
            var result = _mapper.Map<AdminModel>(response);
            return result;

        }
        public async Task<List<AdminModel>> GetAllAdmin()
        {
            var response = await _cosmosDbServices.GetAllAdmin();

            if (response == null)
            {
                throw new Exception("not get all admin");
            }
            var result = _mapper.Map<List<AdminModel>>(response);
            return result;
        }

        public async Task<AdminModel> UpdateAdminByUId(AdminModel updatedAdminModel)
        {

            try
            {
                var existingAdmin = await _cosmosDbServices.GetAdminByUId(updatedAdminModel.UId);
                if (existingAdmin == null)
                {
                    throw new Exception("Admin Not Found!");
                }
                var admin = _mapper.Map(updatedAdminModel, existingAdmin);
                admin.Archieved = true;
                await _cosmosDbServices.ReplaceAsync(admin);

                admin.Initialize(false, Credentials.AdminDocumentType, "UId", "Pratiksha");
                var response = await _cosmosDbServices.RegisterAdmin(admin);
                var result = _mapper.Map<AdminModel>(response);
                return result;
            }
            catch (Exception ex) { throw ex; }

        }

        public async Task<AdminModel> DeleteAdminByUId(GlobalUIdModel uIdModel)
        {
            try
            {

                var existingAdmin = await _cosmosDbServices.DeleteAdminByUId(uIdModel.UId);
                if (existingAdmin == null)
                {
                    throw new Exception("Admin Not Found!");
                }
                existingAdmin.Archieved = true;
                await _cosmosDbServices.ReplaceAsync(existingAdmin);

                existingAdmin.Initialize(false, Credentials.AdminDocumentType, "UId", "Pratiksha");
                existingAdmin.Active = false;
                var res = await _cosmosDbServices.RegisterAdmin(existingAdmin);
                var response = _mapper.Map<AdminModel>(res);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
