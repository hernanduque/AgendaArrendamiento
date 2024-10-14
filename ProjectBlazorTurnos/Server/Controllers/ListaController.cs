using Microsoft.AspNetCore.Mvc;
using ProjectBlazorTurnos.Shared;
using Repositorio;
//using System.Collections.Generic;
//using System.Threading.Tasks;

namespace ProjectBlazorTurnos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : Controller
    {
        private readonly IListasRepositorio _IListasRepositorio;
      
        public ListaController(IListasRepositorio ListasRepositorio)
        {
            _IListasRepositorio = ListasRepositorio;
        }

        [HttpGet("GetAllTipoPersona")]
        public async Task<IEnumerable<ModelsTipoPersona>> GetAllTipoPersona()
        {
            return await _IListasRepositorio.GetAllTipoPersona();
        }

        [HttpGet("GetAllTipoDocumento")]
        public async Task<IEnumerable<ModelsTipoDocumento>> GetAllTipoDocumento()
        {
            return await _IListasRepositorio.GetAllTipoDocumento();
        }

        [HttpGet("GetAllLugarAtencion")]
        public async Task<IEnumerable<ModelsLugarAtencion>> GetAllLugarAtencion()
        {
            return await _IListasRepositorio.GetAllLugarAtencion();
        }

        [HttpGet("GetAllLAsesorLugar/{strcodigolugar}")]
        public async Task<IEnumerable<MODELS_ASESOR_LUGAR>> GetAllLAsesorLugar(string strcodigolugar)
        {
            return await _IListasRepositorio.GetAllLAsesorLugar(strcodigolugar);
        }

       
        [HttpGet("GetAllLOCUPACION")]
        public async Task<IEnumerable<Models_Ocupacion>> GetAllLOCUPACION([FromQuery(Name = "strcodigoasesor")] string strcodigoasesor, [FromQuery(Name = "strfechasolicitud")] string strfechareserva)
        {
            return await _IListasRepositorio.GetAllLOCUPACION(new Models_Parametros() { strcodigoasesor= strcodigoasesor,strfechareserva= strfechareserva });
        }

        [HttpGet("GetAllConsultaHorariosReservados")]
        public async Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaHorariosReservados([FromQuery(Name = "strcodigoasesor")] string strcodigoasesor, [FromQuery(Name = "strfechasolicitud")] string strfechareserva, [FromQuery(Name = "stremail")] string stremail)
        {
            return await _IListasRepositorio.GetAllConsultaHorariosReservados(new Models_Parametros() { strcodigoasesor = strcodigoasesor, strfechareserva = strfechareserva, stremail= stremail });
        }

        [HttpGet("GetAllConsultaServicioCliente")]
        public async Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaServicioCliente()
        {
            return await _IListasRepositorio.GetAllConsultaServicioCliente();
        }

        [HttpGet("GetUser")]
        public async Task<IEnumerable<ModelsValidacionCliente>> GetUser([FromQuery(Name = "strcodigoasesor")] string strcodigoasesor, [FromQuery(Name = "stremail")] string stremail)
        {
            return await _IListasRepositorio.GetUser(new Models_Parametros() { strcodigoasesor = strcodigoasesor, stremail = stremail });
        }

    }
}
