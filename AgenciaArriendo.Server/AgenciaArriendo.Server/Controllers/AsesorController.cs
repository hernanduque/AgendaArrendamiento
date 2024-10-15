using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AgenciaArriendo.Server.Models;
using AgenciaArriendo.shared;
using Microsoft.EntityFrameworkCore;

namespace AgenciaArriendo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsesorController : ControllerBase
    {
        private readonly AgenciaarriendoContext _dbContext;
        public AsesorController(AgenciaarriendoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<AsesorDTO>>();
            var listaAsesorDTO = new List<AsesorDTO>();

            try
            {
                foreach (var item in await _dbContext.TableAsesors.ToListAsync())
                {
                    listaAsesorDTO.Add(new AsesorDTO
                    {

                        Strcodigoasesor = item.Strcodigoasesor,

                        Strnombreasesor = item.Strnombreasesor,

                        Strcedula = item.Strcedula,

                        Stremail = item.Stremail,

                        Strestado = item.Strestado,

                    });
                }
                responseApi.Escorrecto = true;
                responseApi.Valor = listaAsesorDTO;
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
