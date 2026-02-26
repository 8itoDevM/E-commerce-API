using AutoMapper;
using fakeshop.API.Models.Domain;
using fakeshop.API.Models.DTO;

namespace fakeshop.API.Mappings {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
