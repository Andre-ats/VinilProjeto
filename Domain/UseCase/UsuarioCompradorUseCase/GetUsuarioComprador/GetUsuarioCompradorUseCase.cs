using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;

public class GetUsuarioCompradorUseCase : IGetUsuarioCompradorUseCase
{
    public GetUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository) : base(usuarioCompradorRepository)
    {
    }

    protected override IGetUsuarioCompradorUseCaseOutput executeService(IGetUsuarioCompradorUseCaseInput _useCaseInput)
    {
        try
        {

            var outputs = new List<UsuarioCompradorFactory>();
            
            var usuarioComprador = _usuarioCompradorRepository.getUsuarioComprador() 
                                   ?? throw new Exception("Erro ao encontrar usuarios!");

            foreach (var usuario in usuarioComprador)
            {
                var usuarioCompradorFactory = new UsuarioCompradorFactory();
                usuarioCompradorFactory.setEmail(usuario.email)
                    .setSenha(usuario.senha)
                    .setEndereco(usuario.endereco)
                    .setTelefone(usuario.telefone)
                    .build();
                
                
                outputs.Add(usuarioCompradorFactory);
            }

            return new IGetUsuarioCompradorUseCaseOutput()
            {
                getUsuarioCompradorUseCaseOutputs = outputs
            };

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}