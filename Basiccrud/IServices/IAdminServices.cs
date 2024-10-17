
using Basiccrud.Models;

namespace Basiccrud.IServices
{
    public interface IAdminServices
    {
        Task<AdminModel> RegisterAdmin(AdminModel adminModel);
    }
}
