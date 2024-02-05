namespace VinilProjeto.Entity.Usuario;

public class Admin : IEntity
{
    public string email { get; protected set; }
    public string senha { get; protected set; }
    
    public Admin(){}

    public static Admin createAdmin(string email, string senha)
    {
        Admin admin = new Admin()
        {
            id = Guid.NewGuid(),
            email = email,
            senha = senha
        };

        return admin;
        
    }
}