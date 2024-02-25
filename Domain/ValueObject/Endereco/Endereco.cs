namespace VinilProjeto.Entity.Usuario.Endereco;

[Serializable]
public class Endereco
{
    public virtual string cep { get; protected set; }
    public virtual string logradouro { get; protected set; }
    public virtual string numero { get; protected set; }
    public virtual string complemento { get; protected set; }
    public virtual string referencia { get; protected set; }
    public virtual string bairro { get; protected set; }
    public virtual string cidade { get; protected set; }
    public virtual string estado { get; protected set; }

    public Endereco(){}
    
    public static Endereco createEndereco(string cep, string logradouro, string numero, string complemento, string referencia, string bairro, string cidade, string estado)
    {
        Endereco endereco = new Endereco()
        {
            cep = cep,
            logradouro = logradouro,
            numero = numero,
            complemento = complemento,
            referencia = referencia,
            bairro = bairro,
            cidade = cidade,
            estado = estado,
        };
        return endereco;
    }
}