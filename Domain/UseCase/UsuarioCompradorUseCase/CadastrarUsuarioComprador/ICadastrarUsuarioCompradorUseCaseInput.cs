using VinilProjeto.Entity.Usuario;
using VinilProjeto.Repository.DTO.ValueObject;
using VinilProjeto.UseCase.UseCaseInterfaces;
using VinilProjeto.ValueObject.Endereco;
using VinilProjeto.ValueObject.Telefone;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

public class ICadastrarUsuarioCompradorUseCaseInput : IUseCaseInput
{
    public string email;
    public string senha;
    public StatusUsuarioComprador statusUsuarioComprador;
    public TelefoneDTO telefone;
    public EnderecoDTO endereco;
}