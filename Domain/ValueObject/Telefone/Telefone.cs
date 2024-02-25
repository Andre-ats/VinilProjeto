namespace VinilProjeto.Entity.Usuario.Telefone;

[Serializable]
public class Telefone
{
    public virtual string codigo { get; protected set; } 
    public virtual string ddd { get; protected set; }
    public virtual string numero { get; protected set; }
    
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