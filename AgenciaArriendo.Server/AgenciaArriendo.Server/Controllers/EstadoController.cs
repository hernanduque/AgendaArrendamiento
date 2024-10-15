using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AgenciaArriendo.Server.Models;
using AgenciaArriendo.shared;
using Microsoft.EntityFrameworkCore;

namespace AgenciaArriendo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly AgenciaarriendoContext _dbContext;
        public EstadoController(AgenciaarriendoContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<EstadoDTO>>();
            var listaEstadoDTO = new List<EstadoDTO>();

            try
            {
                foreach (var item in await _dbContext.TableEstados.ToListAsync())
                {
                    listaEstadoDTO.Add(new EstadoDTO
                    {

                        Strcodigoestado = item.Strcodigoestado,

                        Descestado = item.Descestado,



                    });
                }
                responseApi.Escorrecto = true;
                responseApi.Valor = listaEstadoDTO;
            }


            catch (Exception ex)
            {
                responseApi.Escorrecto = false;
                responseApi.Mensaje = ex.Message;
                throw;
            }
            return Ok(responseApi);
        }
    }
}