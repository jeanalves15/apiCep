using apiCep.Dtos;
using apiCep.Interfaces;
using apiCep.Models;
using AutoMapper;

namespace apiCep.Service
{
    public class BancoService : IBancoServices
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public BancoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }
        public async Task<ResponseGenerico<List<BancoResponse>>> BuscarTodos()
        {
            var bancos = await _brasilApi.BuscarTodosBancos();
            return _mapper.Map<ResponseGenerico<List<BancoResponse>>>(bancos);

        }

        public async Task<ResponseGenerico<BancoResponse>> BuscarBanco(string codigoBanco)
        {
            var banco = await _brasilApi.BuscarBanco(codigoBanco);
            return _mapper.Map<ResponseGenerico<BancoResponse>>(banco);
        }

        
    }
}
