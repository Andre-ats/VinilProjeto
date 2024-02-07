namespace VinilProjeto.Entity.Usuario.Telefone;

public class Telefone
{
    public string codigo { get; protected set; } 
    public string ddd { get; protected set; }
    public string numero { get; protected set; }
    
    private Telefone(){}
    
    public static Telefone createTelefone(string codigo, string ddd, string numero)
    {
        Telefone telefone = new Telefone()
        {
            codigo = codigo,
            ddd = ddd,
            numero = numero
        };
        return telefone;
    }
}