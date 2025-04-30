using apiCep.Dtos;
using apiCep.Models;
using AutoMapper;

namespace apiCep.Mappings
{
    public class EnderecoMappings:Profile
    {
        public EnderecoMappings()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<EnderecoResponse, EnderecoModel>();
            CreateMap<EnderecoModel, EnderecoResponse>();
        }
    }
}
