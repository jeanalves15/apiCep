using apiCep.Dtos;
using apiCep.Interfaces;
using apiCep.Models;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace apiCep.Rest
{
    public class BrasilApiService : IBrasilApi
    {
        public async Task<ResponseGenerico<BancoModel>> BuscarBanco(string codigoBanco)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{codigoBanco}");
            var response = new ResponseGenerico<BancoModel>();

            using (var client = new HttpClient())
            {
                var responseApiBrasil = await client.SendAsync(request);
                var contentResp = await responseApiBrasil.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<BancoModel>(contentResp);
                if (responseApiBrasil.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseApiBrasil.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseApiBrasil.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }

        public async Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoCEP(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            var response = new ResponseGenerico<EnderecoModel>();

            using(var client =new HttpClient())
            {
                var responseApiBrasil = await client.SendAsync(request);
                var contentResp = await responseApiBrasil.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResp);
                if (responseApiBrasil.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseApiBrasil.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseApiBrasil.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject> (contentResp);
                }
            }
            return response;
            
        }

        public  async Task<ResponseGenerico<List<BancoModel>>> BuscarTodosBancos()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1");
            var response = new ResponseGenerico<List<BancoModel>>();

            using (var client = new HttpClient())
            {
                var responseApiBrasil = await client.SendAsync(request);
                var contentResp = await responseApiBrasil.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<BancoModel>>(contentResp);
                if (responseApiBrasil.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseApiBrasil.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseApiBrasil.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;

        }
    }
}
