using VinilProjeto.Entity.Usuario;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;

public class GetUsuarioCompradorUseCase : IGetUsuarioCompradorUseCase
{
    public GetUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository) : base(usuarioCompradorRepository)
    {
    }

    protected override IGetUsuarioCompradorUseCaseOutput executeService(IGetUsuarioCompradorUseCaseInput _useCaseInput)
    {
        try
        {

            var outputs = new List<UsuarioComprador>();
            
            outputs = _usuarioCompradorRepository.getUsuarioComprador() 
                                   ?? throw new Exception("Erro ao encontrar usuarios!");

            return new IGetUsuarioCompradorUseCaseOutput()
            {
                getUsuarioCompradorUseCaseOutputs = outputs
            };

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}