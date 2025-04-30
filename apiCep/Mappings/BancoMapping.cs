using apiCep.Dtos;
using apiCep.Models;
using AutoMapper;

namespace apiCep.Mappings
{
    public class BancoMapping:Profile
    {
        public BancoMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<BancoResponse, BancoModel>();
            CreateMap<BancoModel, BancoResponse>();
                
        }
    }
}
