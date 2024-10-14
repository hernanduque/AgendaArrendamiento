using ProjectBlazorTurnos.Shared;
using System.Net.Http.Json;


namespace ProjectBlazorTurnos.Client.Services
{
    public class listaServicio : IlistaServicio

    {
        private readonly HttpClient _httpClient;
        public listaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ModelsTipoDocumento>> GetAllTipoDocumento()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ModelsTipoDocumento>>($"api/Lista/GetAllTipoDocumento");

        }

        public async Task<IEnumerable<ModelsTipoPersona>> GetAllTipoPersona()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ModelsTipoPersona>>($"api/Lista/GetAllTipoPersona");
        }

        public async Task<IEnumerable<ModelsLugarAtencion>> GetAllLugarAtencion()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ModelsLugarAtencion>>($"api/Lista/GetAllLugarAtencion");
        }

        public async Task<IEnumerable<MODELS_ASESOR_LUGAR>> GetAllLAsesorLugar(string? strcodigolugar)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MODELS_ASESOR_LUGAR>>($"api/Lista/GetAllLAsesorLugar/{strcodigolugar}");
        }

        public async Task<IEnumerable<Models_Ocupacion>> GetAllLOCUPACION(Models_Parametros objparametros)
        {
            try
            {
                var urlParams = new Dictionary<string, string>{
                { "strcodigoasesor", objparametros.strcodigoasesor },
                { "strfechasolicitud", objparametros.strfechareserva }
            };
                var encodedParams = new FormUrlEncodedContent(urlParams);
                var paramText = await encodedParams.ReadAsStringAsync();

                return await _httpClient.GetFromJsonAsync<IEnumerable<Models_Ocupacion>>($"api/Lista/GetAllLOCUPACION?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaHorariosReservados(Models_Parametros objparametros)
        {
            try
            {
                var urlParams = new Dictionary<string, string>{
                { "strcodigoasesor", objparametros.strcodigoasesor },
                { "strfechasolicitud", objparametros.strfechareserva },
                { "stremail", objparametros.stremail }
            };
                var encodedParams = new FormUrlEncodedContent(urlParams);
                var paramText = await encodedParams.ReadAsStringAsync();

                return await _httpClient.GetFromJsonAsync<IEnumerable<ModelsCancelaciones>>($"api/Lista/GetAllConsultaHorariosReservados?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaServicioCliente()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<ModelsCancelaciones>>($"api/Lista/GetAllConsultaServicioCliente");
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async Task<IEnumerable<ModelsValidacionCliente>> GetUser(Models_Parametros objparametros)
        {
            try
            {
                var urlParams = new Dictionary<string, string>{
                { "strcodigoasesor", objparametros.strcodigoasesor },
                { "stremail", objparametros.stremail }
            };
                var encodedParams = new FormUrlEncodedContent(urlParams);
                var paramText = await encodedParams.ReadAsStringAsync();

                return await _httpClient.GetFromJsonAsync<IEnumerable<ModelsValidacionCliente>>($"api/Lista/GetUser?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}
