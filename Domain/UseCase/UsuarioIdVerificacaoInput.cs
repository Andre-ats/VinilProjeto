using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase;

public abstract class UsuarioIdVerificacaoInput : IUseCaseInput
{
    protected Guid usuarioId { get; set; }

    protected UsuarioIdVerificacaoInput(Guid usuarioId)
    {
        this.usuarioId = usuarioId;
    }

    public Guid getUsuarioId()
    {
        return usuarioId;
    }

    public void setUsuarioId(Guid userId)
    {
        this.usuarioId = userId;
    }
}