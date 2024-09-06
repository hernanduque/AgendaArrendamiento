using System.Net.Mail;
using System.Net;
using System.Web;

namespace ProjectBlazorTurnos.Server.Service
{
    public class EmailSenderCancel : IEmailSenderCancel
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSenderCancel(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }


        public async Task SendEmail(string? STRCODIGORESERVA, string? stremailcliente)
        {
            MailAddress to = new MailAddress(stremailcliente);
            MailAddress from = new MailAddress(_emailConfig.From, "Alerta del sistema de reservas PQRS EMVARIAS");
            using (MailMessage mm = new MailMessage(from, to))
            {
                MailAddress copy = new MailAddress(_emailConfig.cc);
                mm.CC.Add(copy);
                mm.Subject = "Cancelacion Citas PQRS Emvarias";
                mm.Body = HttpUtility.HtmlDecode("Señor Usuario:  <br /><br />  *Usted a cancelado la reserva que tenia para ser atendido por EMVARIAS GRUPO EPM: '" + STRCODIGORESERVA + "'<br /><br />");
                mm.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = _emailConfig.SmtpServer;
                smtp.EnableSsl = _emailConfig.EnableSsl;
                NetworkCredential networkCred = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                smtp.UseDefaultCredentials = _emailConfig.UseDefaultCredentials;
                smtp.Credentials = networkCred;
                smtp.Port = _emailConfig.Port;
                smtp.Send(mm);
            }
        }
    }
}
