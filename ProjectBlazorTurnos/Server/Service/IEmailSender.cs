namespace ProjectBlazorTurnos.Server.Service
{
    public interface IEmailSender
    {
        Task SendEmail(string fecha, string strhorareserva, string StrSede, string nombreasesor, string stremailcliente, string STRCODIGORESERVA);

    }
}
