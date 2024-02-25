namespace WebAPIs.DTO;

public class UsuarioToken
{
    public string email { get; set; }
    public string senha { get; set; }
    public Guid id { get; set; }
    public string role { get; set; }
}