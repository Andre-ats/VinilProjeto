using VinilProjeto.Entity.Usuario;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.Factory.ValueObject.Endereco;
using VinilProjeto.Factory.ValueObject.Telefone;
using VinilProjeto.Helpers.Hash;
using VinilProjeto.Repository.DTO.ValueObject;
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

        var hash = Hash256.stringHash256(_useCaseInput.senha);

        if (_compradorRepository.GetUsuarioCompradorByEmail(_useCaseInput.email) != null)
        {
            throw new Exception("Usuario com esse endereço de email já existe");
        }
        
        try
        {
            UsuarioComprador user = new UsuarioCompradorFactory()
                .setEmail(_useCaseInput.email)
                .setSenha(hash)
                .setStatusUsuarioComprador(StatusUsuarioComprador.Inativo)
                .setToken(_useCaseInput.token)
                .setTelefone(new TelefoneFactory()
                    .setCodigo(_useCaseInput.telefone.codigo)
                    .setNumero(_useCaseInput.telefone.numero)
                    .setDDD(_useCaseInput.telefone.ddd)
                    .build()
                )
                .setEndereco(new EnderecoFactory()
                    .setNumero(_useCaseInput.endereco.numero)
                    .setBairro(_useCaseInput.endereco.bairro)
                    .setCep(_useCaseInput.endereco.cep)
                    .setCidade(_useCaseInput.endereco.cidade)
                    .setComplemento(_useCaseInput.endereco.complemento)
                    .setEstado(_useCaseInput.endereco.estado)
                    .setLogradouro(_useCaseInput.endereco.logradouro)
                    .setReferencia(_useCaseInput.endereco.referencia)
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