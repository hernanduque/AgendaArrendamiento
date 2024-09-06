using ProjectBlazorTurnos.Shared;

namespace ProjectBlazorTurnos.Server.Repositories
{
    public interface IServicioCliente
    {
        Task<IEnumerable<ModelsCancelaciones>> GetAllConsultaServicioCliente();
    }
}
