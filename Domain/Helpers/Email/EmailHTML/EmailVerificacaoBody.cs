namespace VinilProjeto.Helpers.Email.EmailHTML;

public class EmailVerificacaoBody
{
    public static string EmailVerificacao(string numeroAleatorio)
    {
        return $@"
        <html>
            <body>
                <div style='background-color: #f2d95f; padding: 20px; text-align: center; margin: 0 auto; width: 40%;'>
                    <h1 style='margin: 0;'>Código de Verificação</h1>
                </div>
                <div style='background-color: #ffffff; padding: 20px; text-align: center; margin: 0 auto; width: 40%;'>
                    <h2 style='margin: 0;'>{numeroAleatorio}</h2>
                </div>
                <div style='background-color: #f2d95f; padding: 20px; text-align: center; margin: 0 auto; width: 40%;'>
                    <p style='margin: 0;'>Este é um e-mail automático, por favor, não responda.</p>
                </div>
            </body>
        </html>";
    }
}