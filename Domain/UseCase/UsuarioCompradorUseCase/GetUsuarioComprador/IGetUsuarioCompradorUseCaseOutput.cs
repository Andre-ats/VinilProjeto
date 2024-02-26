using VinilProjeto.Entity.Usuario;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;

public class IGetUsuarioCompradorUseCaseOutput : IUseCaseOutput
{
    public List<UsuarioComprador> getUsuarioCompradorUseCaseOutputs = new List<UsuarioComprador>() { };
}