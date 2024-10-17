using Basiccrud.Common;
using Basiccrud.Entities;
using Basiccrud.Models;

namespace Basiccrud.CosmosDb
{
    public interface ICosmosDbServices
    {
        Task<Visitor> RegisterVisitor(Visitor visitor);

        Task<Visitor> GetVisitorByVisitorUId(string visitorUId);

        Task<List<Visitor>> GetALLVisitor();

        Task<Visitor> UpdateVisitorByUId(string visitorUId);

        Task<Visitor> DeleteVisitorByUId(string visitorUId);

        Task ReplaceAsync(dynamic ExistingItem);
    }
}
