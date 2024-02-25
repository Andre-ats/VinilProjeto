namespace WebAPIs.Service.LoginService;

public class UsuarioLoginOutput
{
    public string token { get; init; }
    public DateTime expiration { get; init; }

    public UsuarioLoginOutput(string token, DateTime horas)
    {
        this.token = token;
        this.expiration = horas;
    }
}