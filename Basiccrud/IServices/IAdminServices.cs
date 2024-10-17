
using Basiccrud.Common;
using Basiccrud.Models;

namespace Basiccrud.IServices
{
    public interface IAdminServices
    {
        Task<AdminModel> RegisterAdmin(AdminModel adminModel);
        Task<AdminModel> GetAdminByUId(GlobalUIdModel uIdModel);
        Task<List<AdminModel>> GetAllAdmin();
        Task<AdminModel> UpdateAdminByUId(AdminModel updatedAdminModel);
        Task<AdminModel> DeleteAdminByUId(GlobalUIdModel uIdModel);
    }
}
