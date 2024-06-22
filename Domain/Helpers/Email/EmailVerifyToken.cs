using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Caching.Memory;
using VinilProjeto.Helpers.Email.EmailHTML;

namespace VinilProjeto.Helpers.Email;

public class EmailVerifyToken
{
    private readonly IMemoryCache _cache;

    public EmailVerifyToken(IMemoryCache cache)
    {
        _cache = cache;
    }

    public string emailVerificacao(string emailEnviar)
    {
        var config = new EmailConfig();
        Random random = new Random();
        int numeroAleatorio = random.Next(1000, 10000);
        var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(45));
        _cache.Set(emailEnviar, numeroAleatorio.ToString(), cacheEntryOptions);

        try
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(config.email);
            email.To.Add(new MailAddress(emailEnviar));
            email.Subject = "Código de verificação";
            email.Body = EmailVerificacaoBody.EmailVerificacao(numeroAleatorio.ToString());
            email.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(config.email, config.senha),
                EnableSsl = true,
            };

            smtpClient.Send(email);

            return numeroAleatorio.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao enviar o email: " + ex.Message);
        }
    }

    public bool verificarToken(string email, string codigo)
    {
        if (_cache.TryGetValue(email, out string storedCodigo))
        {
            return storedCodigo == codigo;
        }

        return false;
    }
}