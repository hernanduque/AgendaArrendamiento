namespace ProjectBlazorTurnos.Server.Service
{
    public interface IEmailSenderCancel
    {
        Task SendEmail(string codigoreserva, string? stremail);
    }
}
