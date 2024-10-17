using Basiccrud.IServices;
using Basiccrud.Models;
using Basiccrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basiccrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController: ControllerBase
    {
        public IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices= adminServices;
        }

        [HttpPost]
        public async Task<AdminModel> RegisterAdmin(AdminModel adminModel)
        {
            var response = await _adminServices.RegisterAdmin(adminModel);
            return response;
        }
    }
}
