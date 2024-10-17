using Basiccrud.Common;
using Basiccrud.IServices;
using Basiccrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basiccrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        public IVisitorServices _visitorServices;
        public VisitorController(IVisitorServices visitorServices) 
        {
            _visitorServices = visitorServices;
        }

        [HttpPost]
        public async Task<VisitorModel> RegisterVisitor(VisitorModel visitorModel) 
        {
            var response = await _visitorServices.RegisterVisitor(visitorModel);
            return response;
        }

        [HttpPost]
        public async Task<VisitorModel> GetVisitorByVisitorUId(GlobalUIdModel uIdModel) 
        {
            var response = await _visitorServices.GetVisitorByVisitorUId(uIdModel);
            return response;
        }

        [HttpPost]
        public async Task<List<VisitorModel>> GetALLVisitor()
        {
            var response = await _visitorServices.GetAllVisitor();
            return response;
        }

        [HttpPost]
        public async Task<VisitorModel> UpdateVisitorByUId(VisitorModel updatedVisitorModel)
        {
            var response = await _visitorServices.UpdateVisitorByUId(updatedVisitorModel);
            return response;
        }

        [HttpPost]
        public async Task<VisitorModel> DeleteVisitorByUId(GlobalUIdModel uIdModel)
        {
            var response = await _visitorServices.DeleteVisitorByUId(uIdModel);
            return response;
        }


    }
}
