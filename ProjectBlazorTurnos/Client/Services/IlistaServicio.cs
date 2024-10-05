using ProjectBlazorTurnos.Shared;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading.Tasks;

namespace ProjectBlazorTurnos.Client.Services
{
    public interface IlistaServicio
    {
        
        Task<IEnumerable<ModelsTipoPersona>> GetAllTipoPersona();
        Task<IEnumerable<ModelsTipoDocumento>> GetAllTipoDocumento();

        Task<IEnumerable<ModelsLugarAtencion>> GetAllLugarAtencion();

        Task<IEnumerable<MODELS_ASESOR_LUGAR>> GetAllLAsesorLugar(string? strcodigolugar);

        Task<IEnumerable<Models_Ocupacion>> GetAllLOCUPACION(Models_Parametros objparametros);
        Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaHorariosReservados(Models_Parametros objparametros);
        Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaServicioCliente();
        Task<IEnumerable<ModelsValidacionCliente>> GetUser(Models_Parametros objparametros);
    }
}
