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
        
        var usuarioComprador = _usuarioCompradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId()) 
                     ?? throw new Exception("Id nao encontrado");

        Telefone novoTelefone = new TelefoneFactory()
            .setNumero(_useCaseInput.numero)
            .setCodigo(_useCaseInput.codigo)
            .setDDD(_useCaseInput.ddd)
            .build();

        _usuarioCompradorRepository.PutUsuarioCompradorTelefone(novoTelefone);

        return new IPutUsuarioCompradorTelefoneUseCaseOutput()
        {
            mensagem = "Atualizacao realizada com sucesso!"
        };

    }
}