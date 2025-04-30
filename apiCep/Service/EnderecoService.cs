using apiCep.Dtos;
using apiCep.Interfaces;
using AutoMapper;

namespace apiCep.Service
{
    public class EnderecoService : IEnderecoServices
    {
        public readonly IMapper _mapper;
        public readonly IBrasilApi _brasilApi;

        public EnderecoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep)
        {
            var endereco = await _brasilApi.BuscarEnderecoCEP (cep);
            return _mapper.Map<ResponseGenerico<EnderecoResponse>>(endereco);

        }
    }
}
