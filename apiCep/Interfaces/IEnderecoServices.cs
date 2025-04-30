using apiCep.Dtos;
using apiCep.Models;

namespace apiCep.Interfaces
{
    public interface IEnderecoServices
    {
        Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);
    }
}
