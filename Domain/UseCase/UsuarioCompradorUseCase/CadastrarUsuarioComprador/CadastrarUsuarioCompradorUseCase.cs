using VinilProjeto.Entity.Usuario;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

public class CadastrarUsuarioCompradorUseCase : ICadastrarUsuarioCompradorUseCase
{
    public CadastrarUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository) : base(usuarioCompradorRepository)
    {
    }

    protected override ICadastrarUsuarioCompradorUseCaseOutput executeService(ICadastrarUsuarioCompradorUseCaseInput _useCaseInput)
    {
        try
        {
            UsuarioComprador usuarioComprador = new UsuarioCompradorFactory()
                .setEmail(_useCaseInput.email)
                .setSenha(_useCaseInput.senha)
                .setEndereco(_useCaseInput.Endereco)
                .setTelefone(_useCaseInput.Telefone)
                .build();

            _ = _usuarioCompradorRepository.createUsuario(usuarioComprador)
                ? true
                : throw new Exception("Erro criacao de usuario");

            return new ICadastrarUsuarioCompradorUseCaseOutput()
            {
                resposta = $"Usuario {usuarioComprador.email} criado!"
            };  
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}