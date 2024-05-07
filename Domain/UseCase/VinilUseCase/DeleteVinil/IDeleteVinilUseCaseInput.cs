using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteVinil;

public class IDeleteVinilUseCaseInput : IUseCaseInput
{
    public Guid vinilId;
    public string fileName;
}