using Basiccrud.Common;
using Basiccrud.Entities;
using Basiccrud.Models;

namespace Basiccrud.IServices
{
    public interface IVisitorServices
    {
        Task<VisitorModel> RegisterVisitor(VisitorModel visitorModel);
        Task<VisitorModel> GetVisitorByVisitorUId(GlobalUIdModel uIdModel);
        Task<List<VisitorModel>> GetAllVisitor();

        Task<VisitorModel>UpdateVisitorByUId(VisitorModel updatedVisitorModel);

        Task<VisitorModel> DeleteVisitorByUId(GlobalUIdModel uIdModel);
    }
}
