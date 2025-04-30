using apiCep.Dtos;
using apiCep.Models;

namespace apiCep.Interfaces
{
    public interface IBancoServices
    {
        Task<ResponseGenerico<List<BancoResponse>>> BuscarTodos();
        Task<ResponseGenerico<BancoResponse>> BuscarBanco(string codigoBanco);
    }
}
