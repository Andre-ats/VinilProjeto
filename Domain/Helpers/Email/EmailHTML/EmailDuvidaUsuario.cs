namespace VinilProjeto.Helpers.Email.EmailHTML;

public class EmailDuvidaUsuario
{
    public static string EmailDuvida(string content, string email)
    {
        string imagePath = "https://storage.googleapis.com/sgdiscos/Icone/";

        return $@"
            <html>
                <body>
                    <table align='center' width='600' cellpadding='0' cellspacing='0' border='0' style='margin: 0 auto;'>
                        <tr>
                            <td bgcolor='#f2d95f' style='padding: 20px; text-align: center;'>
                                <table width='100%' cellpadding='0' cellspacing='0' border='0' style='width: 100%;'>
                                    <tr>
                                        <td style='text-align: left; width: 50px;'>
                                            <img src=""{imagePath}SgDiscosIcone.png"" alt=""Logo"" style='width: 75px; height: 75px;'>
                                        </td>
                                        <td style='text-align: right;'>
                                            <h2 style='margin: 0; font-size: 24px;'>Código de Verificação</h2>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor='#ffffff' style='padding: 20px; text-align: center;'>
                                <h3 style='margin: 0; font-size: 28px;'>{email}</h2>
                                <h2 style='margin: 0; font-size: 28px;'>{content}</h2>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor='#f2d95f' style='padding: 20px; text-align: center;'>
                                <p style='margin: 0; font-size: 18px;'>Este é um e-mail automático, por favor, não responda.</p>
                            </td>
                        </tr>
                    </table>
                </body>
            </html>";
    }
}