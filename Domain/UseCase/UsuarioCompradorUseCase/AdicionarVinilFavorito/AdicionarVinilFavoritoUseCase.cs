using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.AdicionarVinilFavorito;

public class AdicionarVinilFavoritoUseCase : IAdicionarVinilFavoritoUseCase
{
    public AdicionarVinilFavoritoUseCase(IUsuarioCompradorRepository usuarioCompradorRepository) : base(usuarioCompradorRepository)
    {
    }

    protected override IAdicionarVinilFavoritoUseCaseOutput executeService(IAdicionarVinilFavoritoUseCaseInput _useCaseInput)
    {
        try
        {
            var usuarioComprador = _compradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId());
            usuarioComprador.AdicionarVinilFavorito(_useCaseInput.vinilId);
            
            _compradorRepository.PutUsuarioComprador(usuarioComprador);

            return new IAdicionarVinilFavoritoUseCaseOutput()
            {
                mensagem = "Vinil Adicionado com sucesso!"
            };

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}