using Basiccrud.Common;
using Basiccrud.IServices;
using Basiccrud.Models;
using Basiccrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basiccrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpPost]
        public async Task<AdminModel> RegisterAdmin(AdminModel adminModel)
        {
            var response = await _adminServices.RegisterAdmin(adminModel);
            return response;
        }

        [HttpPost]
        public async Task<AdminModel> GetAdminByUId(GlobalUIdModel uIdModel)
        {
            var response = await _adminServices.GetAdminByUId(uIdModel);
            return response;
        }

        [HttpPost]
        public async Task<List<AdminModel>> GetAllAdmin()
        {
            var response = await _adminServices.GetAllAdmin();
            return response;
        }

        [HttpPost]
        public async Task<AdminModel> UpdateAdminByUId(AdminModel updatedAdminModel)
        {
            var response = await _adminServices.UpdateAdminByUId(updatedAdminModel);
            return response;
        }

        [HttpPost]
        public async Task<AdminModel> DeleteAdminByUId(GlobalUIdModel uIdModel)
        {
            var response = await _adminServices.DeleteAdminByUId(uIdModel);
            return response;
        }
    }
}
