using ProjectBlazorTurnos.Shared;

namespace ProjectBlazorTurnos.Client.Services
{
    public interface IgrabarClienteServicio
    {
        Task InsertClientes(Models_Clientes_Turnos ClientesTurnos);
        Task GrabarCita(Models_Clientes_Citas Models_Clientes_Citasx);
        Task DeleteReserva(Models_Parametros objparametros);
        Task ActualizacionAtencionCliente(Models_Parametros objparametros);
    }
}
