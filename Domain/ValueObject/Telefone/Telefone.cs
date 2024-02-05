namespace VinilProjeto.Entity.Usuario.Telefone;

public class Telefone
{
    public string codigo { get; protected set; }
    public string ddd { get; protected set; }
    public string numero { get; protected set; }
    
    private Telefone(){}

    public Telefone(string codigo, string ddd, string numero)
    {
        this.codigo = codigo;
        this.ddd = ddd;
        this.numero = numero;
    }
}