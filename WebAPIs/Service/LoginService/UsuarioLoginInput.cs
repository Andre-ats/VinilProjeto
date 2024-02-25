namespace WebAPIs.Service.LoginService;

public class UsuarioLoginInput
{
    public string email { get; set; }
    public string senha { get; set; }
    
    private UsuarioLoginInput(){}
}