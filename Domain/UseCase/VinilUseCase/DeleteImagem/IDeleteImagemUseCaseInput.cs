using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteImagem;

public class IDeleteImagemUseCaseInput : IUseCaseInput
{
    public Guid id { get; set; }
    public string fileName { get; set; }
    public string path { get; set; }
}