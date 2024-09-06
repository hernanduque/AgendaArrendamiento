using Microsoft.AspNetCore.Mvc;
using ProjectBlazorTurnos.Server.Service;
using ProjectBlazorTurnos.Shared;
using Repositorio;

namespace ProjectBlazorTurnos.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GrabarClientesController : Controller
    {

        private readonly IGrabarClientes _IGrabarClientes;

        private readonly IEmailSender _IEmailSender;

        private readonly IEmailSenderCancel _IEmailSenderCancel;

        public GrabarClientesController(IGrabarClientes GrabarClientesparam, IEmailSender emailsender, IEmailSenderCancel emailsenderCancel)
        {
            _IGrabarClientes = GrabarClientesparam;
            _IEmailSender = emailsender;
            _IEmailSenderCancel = emailsenderCancel;
        }

        /// <summary>
        /// El parametro se retorna desde el HTML en el FromBody
        /// </summary>
        /// <param name="ClientesTurnos"></param>
        /// <returns></returns>       
        [HttpPost("PostGrabar")]
        public async Task<IActionResult> Post([FromBody] Models_Clientes_Turnos ClientesTurnos)
        {
            if (ClientesTurnos == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(ClientesTurnos.STRCEDULA))
                ModelState.AddModelError("STRCEDULA", "Cedula no puede estar en blanco");

            if (string.IsNullOrEmpty(ClientesTurnos.STRCODIGOTIPODOCUMENTO))
                ModelState.AddModelError("STRCODIGOTIPODOCUMENTO", "Tipo Documento no puede estar en blanco");

            if (string.IsNullOrEmpty(ClientesTurnos.STRCODIGOTIPOPERSONA))
                ModelState.AddModelError("STRCODIGOTIPOPERSONA", "Tipo Persona no puede estar en blanco");

            if (string.IsNullOrEmpty(ClientesTurnos.STRNOMBRES))
                ModelState.AddModelError("STRNOMBRES", "Los Nombres no puede estar en blanco");

            if (string.IsNullOrEmpty(ClientesTurnos.STRAPELLIDOS))
                ModelState.AddModelError("STRAPELLIDOS", "Los Apellidos no puede estar en blanco");

            if (string.IsNullOrEmpty(ClientesTurnos.STREMAIL))
                ModelState.AddModelError("STREMAIL", "El Email no puede estar en blanco");


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _IGrabarClientes.InsertClientes(ClientesTurnos);

            return NoContent();
            //return Ok();
        }


        /// <summary>
        /// El parametro se retorna desde el HTML en el FromBody
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>       
        [HttpPost("GrabarCita")]
        public async Task<IActionResult> GrabarCita([FromBody] Models_Clientes_Citas Models_Clientes_Citasx)
        {

            await _IGrabarClientes.GrabarCita(Models_Clientes_Citasx);

            try
            {
                await _IEmailSender.SendEmail(Models_Clientes_Citasx.fecha, Models_Clientes_Citasx.strhorareservax, Models_Clientes_Citasx.StrSede, Models_Clientes_Citasx.nombreasesor, Models_Clientes_Citasx.stremailcliente, Models_Clientes_Citasx.STRCODIGORESERVA);
            }
            catch (Exception e)
            {
               return NotFound(e.Message);
            }

            return NoContent();
            //return Ok();
        }

        [HttpDelete("DeleteReserva")]
        public async Task<IActionResult> DeleteReserva(string? CodigoReserva, string? EmailCliente)
        {

            await _IGrabarClientes.DeleteReserva(CodigoReserva);

            await _IEmailSenderCancel.SendEmail(CodigoReserva, EmailCliente);

            return NoContent();
        }

        [HttpDelete("ActualizacionAtencionCliente")]
        public async Task<IActionResult> ActualizacionAtencionCliente(string? strcodigoreserva, string? estado, string? mensaje)
        {

            await _IGrabarClientes.ActualizacionAtencionCliente(strcodigoreserva, estado, mensaje);

            return NoContent();
        }
    }
}
