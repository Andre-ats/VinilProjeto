using VinilProjeto.Factory.ValueObject.Telefone;
using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.ValueObject.Telefone;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarTelefone;

public class PutUsuarioCompradorTelefoneUseCase : IPutUsuarioCompradorTelefoneUseCase
{
    public PutUsuarioCompradorTelefoneUseCase(IUsuarioCompradorRepository _usuarioCompradorRepository) : base(_usuarioCompradorRepository)
    {
    }

    protected override IPutUsuarioCompradorTelefoneUseCaseOutput executeService(IPutUsuarioCompradorTelefoneUseCaseInput _useCaseInput)
    {
        
        var user = _usuarioCompradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId()) 
                     ?? throw new Exception("Id nao encontrado" + _useCaseInput.getUsuarioId());

        user.TelefoneAtualizar(Telefone.createTelefone(_useCaseInput.codigo, _useCaseInput.ddd, _useCaseInput.numero));
        
        _usuarioCompradorRepository.PutUsuarioCompradorTelefone(user);

        return new IPutUsuarioCompradorTelefoneUseCaseOutput()
        {
            mensagem = "Atualizacao realizada com sucesso!"
        };

    }
}