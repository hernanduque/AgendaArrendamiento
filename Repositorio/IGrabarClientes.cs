using ProjectBlazorTurnos.Shared;

namespace Repositorio
{
    public interface IGrabarClientes
    {
        Task<bool> InsertClientes(Models_Clientes_Turnos ClientesTurnos);
        Task<bool> GrabarCita(Models_Clientes_Citas Models_Clientes_Citasx);
        Task DeleteReserva(string? strcodigoreserva);
        Task ActualizacionAtencionCliente(string? strcodigoreserva, string? estado, string? mensaje);
    }
}
