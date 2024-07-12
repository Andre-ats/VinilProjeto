using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.GetVinisFavoritosUsuarioComprador;

public class IGetVinisFavoritosUsuarioCompradorUseCaseOutput : IUseCaseOutput
{
    public List<Vinil> listaVinisFavoritos;
}