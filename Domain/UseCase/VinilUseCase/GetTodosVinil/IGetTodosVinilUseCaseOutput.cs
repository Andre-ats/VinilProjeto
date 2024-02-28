using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;

public class IGetTodosVinilUseCaseOutput : IUseCaseOutput
{
    public List<Vinil> vinilList = new List<Vinil>(){};
}