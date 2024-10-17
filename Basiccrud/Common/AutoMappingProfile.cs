using AutoMapper;
using Basiccrud.Entities;
using Basiccrud.Models;

namespace Basiccrud.Common
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile() 
        {
            CreateMap<Visitor, VisitorModel>().ReverseMap();
        }
    }
}
