using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace ProjectBlazorTurnos.Server.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmail(string fecha, string strhorareserva, string StrSede, string nombreasesor, string stremailcliente,string STRCODIGORESERVA)
        {
            try
            {
                //var configurationValue = ConfigurationManager.AppSettings["ConfigurationSettingName"];

                MailAddress to = new MailAddress(stremailcliente);
                MailAddress from = new MailAddress(_emailConfig.From, "Solicitud Reservas Citas PQRS Emvarias");
                using (MailMessage mm = new MailMessage(from, to))
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    MailAddress copy = new MailAddress(_emailConfig.cc);
                    mm.CC.Add(copy);
                    mm.Subject = "Solicitud Reservas Citas PQRS Emvarias";
                    mm.Body = HttpUtility.HtmlDecode("Señor Usuario Recuerde estar 15 Minutos antes:  <br /><br />  *Fecha de la Reserva: " + @fecha + "<br /> *Hora de la Reserva:  " + @strhorareserva + "<br /> *Lugar de la Reserva: " + @StrSede + "<br /> *Asesor: " + @nombreasesor + "<br /> *CodigoReserva: " + @STRCODIGORESERVA + "<br /><br /> Gracias por usar nuestros servicios. <br /><br />");
                    mm.IsBodyHtml= true;                       

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = _emailConfig.SmtpServer;
                    smtp.EnableSsl = _emailConfig.EnableSsl;
                    smtp.Port = _emailConfig.Port;
                    smtp.UseDefaultCredentials = _emailConfig.UseDefaultCredentials;
                    NetworkCredential networkCred = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                   
                    smtp.Credentials = networkCred;
                  
                    smtp.Send(mm);
                }
            }
            catch (Exception E)
            {

                throw E;
            }

        }

    }
}
