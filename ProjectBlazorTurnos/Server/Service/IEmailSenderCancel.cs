namespace ProjectBlazorTurnos.Server.Service
{
    public interface IEmailSenderCancel
    {
        Task SendEmail(string STRCODIGORESERVA, string? STREMAIL);
    }
}
