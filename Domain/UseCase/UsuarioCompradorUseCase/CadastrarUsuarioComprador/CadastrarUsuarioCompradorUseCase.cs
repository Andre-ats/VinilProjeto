using VinilProjeto.Entity.Usuario;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.Factory.ValueObject.Telefone;
using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

public class CadastrarUsuarioCompradorUseCase : ICadastrarUsuarioCompradorUseCase
{
    public CadastrarUsuarioCompradorUseCase(IUsuarioCompradorRepository repository) : base(repository)
    {
    }


    protected override ICadastrarUsuarioCompradorUseCaseOutput executeService(ICadastrarUsuarioCompradorUseCaseInput _useCaseInput)
    {
        try
        {
            UsuarioComprador user = new UsuarioCompradorFactory()
                .setEmail(_useCaseInput.email)
                .setSenha(_useCaseInput.senha)
                .setEndereco(_useCaseInput.endereco)
                .setTelefone(new TelefoneFactory()
                    .setCodigo(_useCaseInput.telefone.codigo)
                    .setDDD(_useCaseInput.telefone.ddd)
                    .setNumero(_useCaseInput.telefone.numero)
                    .build()
                )
                .build();

            _ = _compradorRepository.createUsuario(user) ? true : throw new Exception($"Erro ao criar Usuario");
            return new ICadastrarUsuarioCompradorUseCaseOutput()
            {
                resposta = $"Usuario {_useCaseInput.email} criado!"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}