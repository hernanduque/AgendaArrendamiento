using ProjectBlazorTurnos.Shared;
using System.Net.Http.Json;

namespace ProjectBlazorTurnos.Client.Services
{
    public class grabarClienteServicio : IgrabarClienteServicio
    {
        private readonly HttpClient _httpClient;
        public grabarClienteServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task InsertClientes(Models_Clientes_Turnos ClientesTurnos)
        {
            try
            {
                //insert
                var data=await _httpClient.PostAsJsonAsync<Models_Clientes_Turnos>($"api/GrabarClientes/PostGrabar", ClientesTurnos);
            }
            catch (Exception E)
            {

                throw E;
            }

        }



        public async Task GrabarCita(Models_Clientes_Citas Models_Clientes_Citasx)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Models_Clientes_Citas>($"api/GrabarClientes/GrabarCita", Models_Clientes_Citasx);

                //if (response.IsSuccessStatusCode)
                //{

                //}
                //else
                //{
                //    throw new Exception(string.Concat(response.StatusCode.ToString(),response.Content.ToString(),response.RequestMessage.ToString(), response.Content.ReadAsStringAsync().Result));

                //    //Console.WriteLine("Internal server Error");
                //}
            }
            catch (Exception E)
            {

                throw E;
            }
        }

        public async Task DeleteReserva(Models_Parametros objparametros)
        {
            var urlParams = new Dictionary<string, string>{
                { "CodigoReserva", objparametros.strcodigoasesor },
                { "EmailCliente", objparametros.stremail }
            };
            var encodedParams = new FormUrlEncodedContent(urlParams);
            var paramText = await encodedParams.ReadAsStringAsync();

            await _httpClient.DeleteAsync($"api/GrabarClientes/DeleteReserva?{paramText}");
        }

        public async Task ActualizacionAtencionCliente(Models_Parametros objparametros)
        {
            var urlParams = new Dictionary<string, string>{
                { "strcodigoreserva", objparametros.strcodigoasesor },
                { "estado", objparametros.strfechareserva },
                { "mensaje", objparametros.stremail },
            };
            var encodedParams = new FormUrlEncodedContent(urlParams);
            var paramText = await encodedParams.ReadAsStringAsync();

            try
            {
                await _httpClient.DeleteAsync($"api/GrabarClientes/ActualizacionAtencionCliente?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
        

    }
}
