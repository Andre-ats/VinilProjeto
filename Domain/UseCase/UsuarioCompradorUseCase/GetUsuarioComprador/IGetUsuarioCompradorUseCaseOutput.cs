using VinilProjeto.Entity.Usuario;
using VinilProjeto.Entity.Usuario.Endereco;
using VinilProjeto.Entity.Usuario.Telefone;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;

public class IGetUsuarioCompradorUseCaseOutput : IUseCaseOutput
{
    public List<UsuarioComprador> getUsuarioCompradorUseCaseOutputs = new List<UsuarioComprador>() { };
}