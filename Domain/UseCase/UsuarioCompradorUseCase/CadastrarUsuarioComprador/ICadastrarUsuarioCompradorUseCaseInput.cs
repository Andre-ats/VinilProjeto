using VinilProjeto.Entity.Usuario;
using VinilProjeto.Repository.DTO.ValueObject;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

public class ICadastrarUsuarioCompradorUseCaseInput : IUseCaseInput
{
    public string email;
    public string senha;
    public string token;
    public TelefoneDTO telefone;
    public EnderecoDTO endereco;
}