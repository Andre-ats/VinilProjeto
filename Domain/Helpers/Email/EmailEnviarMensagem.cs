using System.Net;
using System.Net.Mail;
using VinilProjeto.Helpers.Email.EmailHTML;

namespace VinilProjeto.Helpers.Email;

public class EmailEnviarMensagem
{
    public void EnviarDuvida(string emailEnviar, string emailUsuario)
    {
        var config = new EmailConfig();

        try
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(config.email);
            email.To.Add(new MailAddress(config.email));
            email.Subject = "Duvida Usuario";
            email.Body = EmailDuvidaUsuario.EmailDuvida(emailEnviar, emailUsuario);
            email.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(config.email, config.senha),
                EnableSsl = true,
            };

            smtpClient.Send(email);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao enviar o email: " + ex.Message);
        }
    }
}