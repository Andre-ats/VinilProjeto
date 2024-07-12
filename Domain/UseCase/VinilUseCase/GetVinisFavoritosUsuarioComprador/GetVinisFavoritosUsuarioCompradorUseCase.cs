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
        List<Vinil> vinisList = new List<Vinil>();
        List<Guid> vinisNaoExistentes = new List<Guid>();

        var usuarioConsumidor = _usuarioCompradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId())
                                ?? throw new Exception("Usuario nao encontrado!");

        foreach (var i in usuarioConsumidor.listaVinisFavoritos)
        {
            var vinilbyid = _vinilRespository.getVinilByID(i);
            if (vinilbyid != null)
            {
                vinisList.Add(vinilbyid);
            }
            else
            {
                vinisNaoExistentes.Add(i);
            }
        }

        foreach (var i in vinisNaoExistentes)
        {
            usuarioConsumidor.RemoverVinilFavorito(i);
            _usuarioCompradorRepository.PutUsuarioComprador(usuarioConsumidor);
        }

        return new IGetVinisFavoritosUsuarioCompradorUseCaseOutput()
        {
            listaVinisFavoritos = vinisList
        };
    }
}