using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AgenciaArriendo.Server.Models;
using AgenciaArriendo.shared;
using Microsoft.EntityFrameworkCore;

namespace AgenciaArriendo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorApartamentoController : ControllerBase
    {
        private readonly AgenciaarriendoContext _dbContext;
        public SectorApartamentoController(AgenciaarriendoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<SectorApartamentoDTO>>();
            var listaSectorApartamentoDTO= new List<SectorApartamentoDTO>();

            try
            {
                foreach(var item in await _dbContext.TableSectorApartamentos.ToListAsync())
                {
                    listaSectorApartamentoDTO.Add(new SectorApartamentoDTO
                    {

                       Strcodigosector =item.Strcodigosector,

                       Strnombresector =item.Strnombresector,
    });
                }
                responseApi.Escorrecto = true;
                responseApi.Valor = listaSectorApartamentoDTO;
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
