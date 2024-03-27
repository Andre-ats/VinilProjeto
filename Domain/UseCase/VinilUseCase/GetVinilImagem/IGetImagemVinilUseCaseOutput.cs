using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.GetVinilImagem;

public class IGetImagemVinilUseCaseOutput : IUseCaseOutput
{
    public MemoryStream fileMemory;
    public string nome;
    
    public String getFileExtension()
    {
        if (!string.IsNullOrEmpty(this.nome))
        {
            string extensao = Path.GetExtension(this.nome);

            if (!string.IsNullOrEmpty(extensao) && extensao.StartsWith("."))
            {
                extensao = extensao.Substring(1);
            }

            return extensao;
        }

        throw new InvalidOperationException($"O arquivo {this.nome} não possui uma extensão válida!");
    }
}