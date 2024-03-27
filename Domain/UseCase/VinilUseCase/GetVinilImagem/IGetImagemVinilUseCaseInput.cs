using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.GetVinilImagem;

public class IGetImagemVinilUseCaseInput : IUseCaseInput
{
    public Guid vinilId;
    public string nomeVinil;
    public string path;
}