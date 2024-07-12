using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.Repository.VinilRepository;

namespace VinilProjeto.UseCase.VinilUseCase.GetVinisFavoritosUsuarioComprador;

public class GetVinisFavoritosUsuarioCompradorUseCase : IGetVinisFavoritosUsuarioCompradorUseCase
{
    public GetVinisFavoritosUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository, IVinilRespository vinilRespository) : base(usuarioCompradorRepository, vinilRespository)
    {
    }

    protected override IGetVinisFavoritosUsuarioCompradorUseCaseOutput executeService(IGetVinisFavoritosUsuarioCompradorUseCaseInput _useCaseInput)
    {
        List<Vinil> vinilsList = new List<Vinil>();

        var usuarioConsumidor = _usuarioCompradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId())
                                ?? throw new Exception("Usuario nao encontrado!");

        foreach (var i in usuarioConsumidor.listaVinisFavoritos)
        {
            var vinilbyid = _vinilRespository.getVinilByID(i);
            vinilsList.Add(vinilbyid);
        }

        return new IGetVinisFavoritosUsuarioCompradorUseCaseOutput()
        {
            listaVinisFavoritos = vinilsList
        };
    }
}