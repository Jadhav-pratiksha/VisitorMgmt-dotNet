using Basiccrud.IServices;
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
    }
}
