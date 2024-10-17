using AutoMapper;
using Basiccrud.Common;
using Basiccrud.CosmosDb;
using Basiccrud.Entities;
using Basiccrud.IServices;
using Basiccrud.Models;
using System.Formats.Asn1;

namespace Basiccrud.Services
{
    public class VisitorServices: IVisitorServices
    {
        public ICosmosDbServices _cosmosDbServices;
        public IMapper _mapper;
        public VisitorServices(ICosmosDbServices cosmosDbServices, IMapper mapper) 
        {
            _cosmosDbServices = cosmosDbServices;
            _mapper = mapper;
        }

        public async Task<VisitorModel> RegisterVisitor(VisitorModel visitorModel) 
        {
            // mapping model to entity
            var visitor =  _mapper.Map<Visitor>(visitorModel);
            visitor.Initialize(true, Credentials.VisitorDocumentType, "UId", "Pratiksha");
            var response = await _cosmosDbServices.RegisterVisitor(visitor);

            // reverse mapping response entity to model
            var result = _mapper.Map<VisitorModel>(response);
            return result;
            
        }

        public async Task<VisitorModel> GetVisitorByVisitorUId(GlobalUIdModel uIdModel) 
        {
            
            var response = await _cosmosDbServices.GetVisitorByVisitorUId(uIdModel.UId);
            if (response == null) 
            {
                throw new Exception("Visitor Not Found!");
            }
            var result = _mapper.Map<VisitorModel>(response);
            return result;

        }

        public async Task<List<VisitorModel>> GetAllVisitor()
        {
            var response = await _cosmosDbServices.GetALLVisitor();

            if (response == null)
            {
                throw new Exception("not get all visitor");
            }
            var result = _mapper.Map<List<VisitorModel>>(response);
            return result;
        }

        public async Task<VisitorModel> UpdateVisitorByUId(VisitorModel updatedVisitorModel)
        {

            try
            {
                var existingVisitor = await _cosmosDbServices.GetVisitorByVisitorUId(updatedVisitorModel.UId);
                if (existingVisitor == null)
                {
                    throw new Exception("Visitor Not Found!");
                }
                var visitor = _mapper.Map(updatedVisitorModel, existingVisitor);
                visitor.Archieved = true;
                await _cosmosDbServices.ReplaceAsync(visitor);

                visitor.Initialize(false, Credentials.VisitorDocumentType, "UId", "Pratiksha");
                var response = await _cosmosDbServices.RegisterVisitor(visitor);
                var result = _mapper.Map<VisitorModel>(response);
                return result;
            }
            catch (Exception ex) { throw ex; }

        }

        public async Task<VisitorModel> DeleteVisitorByUId(GlobalUIdModel uIdModel)
        {
            try
            {

                var existingVisitor = await _cosmosDbServices.GetVisitorByVisitorUId(uIdModel.UId);
                if (existingVisitor == null)
                {
                    throw new Exception("Visitor Not Found!");
                }
                existingVisitor.Archieved = true;
                await _cosmosDbServices.ReplaceAsync(existingVisitor);

                existingVisitor.Initialize(false, Credentials.VisitorDocumentType, "UId", "Pratiksha");
                existingVisitor.Active = false;
                var res = await _cosmosDbServices.RegisterVisitor(existingVisitor);
                var response = _mapper.Map<VisitorModel>(res);
                return response;
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }

        }

    }
}
