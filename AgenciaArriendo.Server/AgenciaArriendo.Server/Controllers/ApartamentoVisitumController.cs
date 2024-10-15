using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AgenciaArriendo.Server.Models;
using AgenciaArriendo.shared;
using Microsoft.EntityFrameworkCore;

namespace AgenciaArriendo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentoVisitumController : ControllerBase
    {
        private readonly AgenciaarriendoContext _dbContext;
        public ApartamentoVisitumController(AgenciaarriendoContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ApartamentoVisitumDTO>>();
            var listaApartamentoVisitumDTO = new List<ApartamentoVisitumDTO>();

            try
            {
                foreach (var item in await _dbContext.TableApartamentoVisita.Include(d => d.StrcodigosectorNavigation).Include(r => r.StrestadoNavigation).ToListAsync())
                {
                    listaApartamentoVisitumDTO.Add(new ApartamentoVisitumDTO
                    {

                        Strcodigo = item.Strcodigo,

                        Strapartamentovisita = item.Strapartamentovisita,

                        Strestado = item.Strestado,

                        Strcodigosector = item.Strcodigosector,

                        
                    });
                }
                responseApi.Escorrecto = true;
                responseApi.Valor = listaApartamentoVisitumDTO;
            }


            catch (Exception ex)
            {
                responseApi.Escorrecto = false;
                responseApi.Mensaje = ex.Message;
                throw;
            }
            return Ok(responseApi);
        }
        [HttpGet]
        [Route("Buscar/{Strcodigo}")]
        public async Task<IActionResult> Buscar(String Strcodigo)
        {
            var responseApi = new ResponseAPI<ApartamentoVisitumDTO>();
            var ApartamentoVisitumDTO = new ApartamentoVisitumDTO();

            try
            {
                var TableApartamentoVisita = await _dbContext.TableApartamentoVisita.FirstOrDefaultAsync(x => x.Strcodigo == Strcodigo);
                if (Strcodigo != null)
                {
                    ApartamentoVisitumDTO.Strcodigo = TableApartamentoVisita.Strcodigo;

                    ApartamentoVisitumDTO.Strapartamentovisita = TableApartamentoVisita.Strapartamentovisita;

                    ApartamentoVisitumDTO.Strestado = TableApartamentoVisita.Strestado;

                    ApartamentoVisitumDTO.Strcodigosector = TableApartamentoVisita.Strcodigosector;


                    responseApi.Escorrecto = true;
                    responseApi.Valor = ApartamentoVisitumDTO;

                }
                else
                {
                    responseApi.Escorrecto = false;
                    responseApi.Mensaje = "Apartamento no encontrado";
                }                
            }


            catch (Exception ex)
            {
                responseApi.Escorrecto = false;
                responseApi.Mensaje = ex.Message;
                throw;
            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(ApartamentoVisitumDTO apartamentoVisitum)
        {
            var responseApi = new ResponseAPI<String>();
           
            try
            {
                var TableApartamentoVisita = new TableApartamentoVisitum
                {

                };



                responseApi.Escorrecto = true;
                responseApi.Valor = ApartamentoVisitumDTO;
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
