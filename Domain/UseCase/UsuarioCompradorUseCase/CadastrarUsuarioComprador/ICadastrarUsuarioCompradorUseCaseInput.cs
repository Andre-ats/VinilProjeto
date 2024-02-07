using VinilProjeto.Entity.Usuario.Endereco;
using VinilProjeto.Entity.Usuario.Telefone;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

public class ICadastrarUsuarioCompradorUseCaseInput : IUseCaseInput
{
    public string email;
    public string senha;
    public Telefone Telefone;
    public Endereco Endereco;
}