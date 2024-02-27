namespace VinilProjeto.Repository.DTO.ValueObject;

public class EnderecoDTO
{
    public string cep { get; set; }
    public string logradouro{ get; set; }
    public string numero{ get; set; }
    public string complemento{ get; set; }
    public string referencia{ get; set; }
    public string bairro{ get; set; }
    public string cidade{ get; set; }
    public string estado{ get; set; }
}