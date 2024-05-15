using System.Net;
using System.Net.Mail;

namespace VinilProjeto.Helpers.Email;

public class Email
{

    public string sendEmail(string emailEnviar)
    {

        var config = new EmailConfig();

        Random random = new Random();

        int numeroAleatorio = random.Next(1000, 10000);
        
        try
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(config.email);
            email.To.Add(new MailAddress(emailEnviar));
            email.Subject = "Código de verificação";
            email.Body = "" + numeroAleatorio;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(config.email, config.senha),
                EnableSsl = true,
            };

            smtpClient.Send(email);

            return "" + random;
        }
        catch (Exception ex)
        {
            throw new Exception("" + ex);
        }
    }


}