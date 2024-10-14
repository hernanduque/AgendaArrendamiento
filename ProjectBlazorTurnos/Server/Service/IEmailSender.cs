namespace ProjectBlazorTurnos.Server.Service
{
    public interface IEmailSender
    {
        Task SendEmail(string fecha, string horareserva, string Sede, string nombreasesor, string emailcliente, string codigoreserva);

    }
}
