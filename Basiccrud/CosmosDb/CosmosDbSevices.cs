using Basiccrud.Common;
using Basiccrud.Entities;
using Basiccrud.Models;
using Microsoft.Azure.Cosmos;
using Nest;

namespace Basiccrud.CosmosDb
{
    public class CosmosDbSevices:ICosmosDbServices
    {
        public Container _container;
        public CosmosDbSevices() 
        {
            _container = GetContainer();
        }

        public async Task<Visitor> RegisterVisitor(Visitor visitor)
        {
            var response = await _container.CreateItemAsync(visitor);
            return response;
        }

        public async Task<Visitor> GetVisitorByVisitorUId(string visitorUId)
        {
            var response = _container.GetItemLinqQueryable<Visitor>(true).Where(b => b.UId == visitorUId && b.DocumentType == Credentials.VisitorDocumentType && b.Active && !b.Archieved).AsEnumerable().FirstOrDefault();
            return response;
        }

        public async Task<List<Visitor>> GetALLVisitor() 
        {
            var response = _container.GetItemLinqQueryable<Visitor>(true).Where(b => b.DocumentType == Credentials.VisitorDocumentType && b.Active && !b.Archieved).ToList();
            return response;
        }

        public async Task<Visitor>UpdateVisitorByUId(string visitorUId)
        {
            var response = _container.GetItemLinqQueryable<Visitor>(true).Where(b => b.UId == visitorUId && b.DocumentType == Credentials.VisitorDocumentType && b.Active && !b.Archieved).AsEnumerable().FirstOrDefault();
            return response;
        }
        public async Task<Visitor>DeleteVisitorByUId(string visitorUId)
        {
            var response = _container.GetItemLinqQueryable<Visitor>(true).Where(b => b.UId == visitorUId && b.DocumentType == Credentials.VisitorDocumentType && b.Active && !b.Archieved).AsEnumerable().FirstOrDefault();
            return response;
        }
        public async Task ReplaceAsync(dynamic ExistingItem) 
        {
            try 
            {
                await _container.ReplaceItemAsync(ExistingItem, ExistingItem.Id);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Admin> RegisterAdmin(Admin admin)
        {
            var response = await _container.CreateItemAsync(admin);
            return response;
        }

        // to create cosmos services.x










        // to access database related things.
        private Container GetContainer()
        {
            string URI = Environment.GetEnvironmentVariable("cosmos-url");
            string PrimaryKey = Environment.GetEnvironmentVariable("auth-token");
            string DatabaseName = Environment.GetEnvironmentVariable("database-name");
            string ContainerName = Environment.GetEnvironmentVariable("container-name");

            CosmosClient cosmosclient = new CosmosClient(URI, PrimaryKey);
            Database database = cosmosclient.GetDatabase(DatabaseName);
            Container container = database.GetContainer(ContainerName);
            return container;
        }
    }
    


}
