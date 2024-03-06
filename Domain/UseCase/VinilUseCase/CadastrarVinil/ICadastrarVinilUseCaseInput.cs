using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public class ICadastrarVinilUseCaseInput : IUseCaseInput
{
    public string nomeVinil;
    public string descricaoVinil;
    public string precoVinil;
    public string quantiaVinil;
    public EstiloMusical estiloMusical;
    public StatusVinil statusVinil;
}