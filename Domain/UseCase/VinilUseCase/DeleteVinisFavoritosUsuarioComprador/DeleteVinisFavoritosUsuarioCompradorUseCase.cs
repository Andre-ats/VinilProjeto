using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteVinisFavoritosUsuarioComprador;

public class DeleteVinisFavoritosUsuarioCompradorUseCase : IDeleteVinisFavoritosUsuarioCompradorUseCase
{
    public DeleteVinisFavoritosUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository) : base(usuarioCompradorRepository)
    {
    }

    protected override IDeleteVinisFavoritosUsuarioCompradorUseCaseOutput executeService(IDeleteVinisFavoritosUsuarioCompradorUseCaseInput _useCaseInput)
    {
        try
        {
            var usuario = _usuarioCompradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId())
                          ?? throw new Exception("Usuario nao encontrado");
            
            usuario.RemoverVinilFavorito(_useCaseInput.VinilDeleteID);
            _usuarioCompradorRepository.PutUsuarioComprador(usuario);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return new IDeleteVinisFavoritosUsuarioCompradorUseCaseOutput()
        {
            mensagem = "Vinil retirado dos favoritos com sucesso!"
        };
    }
}