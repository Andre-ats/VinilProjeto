namespace VinilProjeto.Entity.Usuario.Endereco;

public class Endereco
{
    public string cep { get; protected set; }
    public string logradouro { get; protected set; }
    public string numero { get; protected set; }
    public string complemento { get; protected set; }
    public string referencia { get; protected set; }
    public string bairro { get; protected set; }
    public string cidade { get; protected set; }
    public string estado { get; protected set; }

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