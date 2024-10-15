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
                    Strapartamentovisita = apartamentoVisitum.Strapartamentovisita,
                    Strestado = apartamentoVisitum.Strestado,
                    Strcodigosector = apartamentoVisitum.Strcodigosector,
                };
                    _dbContext.TableApartamentoVisita.Add(TableApartamentoVisita);
                    await _dbContext.SaveChangesAsync();

    if (TableApartamentoVisita.Strcodigo != null)
    {
        responseApi.Escorrecto = true;
        responseApi.Valor = TableApartamentoVisita.Strcodigo;
    }
    else
    {
        responseApi.Escorrecto = false;
        responseApi.Mensaje = "No guardado";
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

[HttpPut]
[Route("Editar/{Strcodigo}")]
public async Task<IActionResult> Editar(ApartamentoVisitumDTO apartamentoVisitum, String Strcodigo)
{
    var responseApi = new ResponseAPI<String>();

    try
    {
        
        var TableApartamentoVisita = await _dbContext.TableApartamentoVisita.FirstOrDefaultAsync(e => e.Strcodigo == Strcodigo);
        await _dbContext.SaveChangesAsync();

        if (TableApartamentoVisita != null)
        {                    
            //TableApartamentoVisita.Strcodigo = apartamentoVisitum.Strcodigo;
            TableApartamentoVisita.Strapartamentovisita = apartamentoVisitum.Strapartamentovisita;
            TableApartamentoVisita.Strestado = apartamentoVisitum.Strestado;
            TableApartamentoVisita.Strcodigosector = apartamentoVisitum.Strcodigosector;


            _dbContext.TableApartamentoVisita.Update(TableApartamentoVisita);
            await _dbContext.SaveChangesAsync();
            responseApi.Escorrecto = true;
            responseApi.Valor = TableApartamentoVisita.Strcodigo;

           
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

[HttpDelete]
[Route("Eliminar/{Strcodigo}")]
public async Task<IActionResult> Eliminar(String Strcodigo)
{
    var responseApi = new ResponseAPI<String>();

    try
    {

        var TableApartamentoVisita = await _dbContext.TableApartamentoVisita.FirstOrDefaultAsync(e => e.Strcodigo == Strcodigo);
        await _dbContext.SaveChangesAsync();

        if (TableApartamentoVisita != null)
        {
            
            _dbContext.TableApartamentoVisita.Update(TableApartamentoVisita);
            await _dbContext.SaveChangesAsync();

            responseApi.Escorrecto = true;
           
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
    }
}
