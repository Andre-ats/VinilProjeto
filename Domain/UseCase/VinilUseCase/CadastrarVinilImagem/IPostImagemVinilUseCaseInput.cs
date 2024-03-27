using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public class IPostImagemVinilUseCaseInput: IUseCaseInput
{
    public string nome { get; set; }
    public Guid vinilId { get; set; }
    public MemoryStream Stream { get; set; }
    public string path { get; set; }
    
}