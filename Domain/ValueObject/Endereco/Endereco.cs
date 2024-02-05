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
    
    public Endereco(string cep, string logradouro, string numero, string complemento, string referencia, string bairro, string cidade, string estado)
    {
        this.cep = cep;
        this.logradouro = logradouro;
        this.numero = numero;
        this.complemento = complemento;
        this.referencia = referencia;
        this.bairro = bairro;
        this.cidade = cidade;
        this.estado = estado;
    }
}