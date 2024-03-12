using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetPerfilUsuarioComprador;

public class GetPerfilUsuarioCompradorUseCase : IGetPerfilUsuarioCompradorUseCase
{
    public GetPerfilUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository) : base(usuarioCompradorRepository)
    {
    }

    protected override IGetPerfilUsuarioCompradorUseCaseOutput executeService(IGetPerfilUsuarioCompradorUseCaseInput _useCaseInput)
    {
        try
        {
            var output = _usuarioCompradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId())
                                                                             ?? throw new Exception("Usuario nao encontrado");

            return new IGetPerfilUsuarioCompradorUseCaseOutput()
            {
                usuarioComprador = output
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}