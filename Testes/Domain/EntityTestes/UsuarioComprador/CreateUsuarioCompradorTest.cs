using VinilProjeto.Entity.Usuario;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.Factory.ValueObject.Endereco;
using VinilProjeto.Factory.ValueObject.Telefone;

namespace Testes.Domain.EntityTestes.UsuarioComprador;

public class CreateUsuarioCompradorTest
{
    [Test]
    public void construcaoObjUsuarioComprador()
    {
        var usuarioComprador01 = new UsuarioCompradorFactory()
            .setEmail("UsuarioCompradorTest")
            .setSenha("UsuarioCompradorTestSenha")
            .setEndereco(new EnderecoFactory()
                .setBairro("xxxxx")
                .setCep("xxxxx")
                .setCidade("xxxxx")
                .setComplemento("xxxxxxx")
                .setEstado("xxxxxx")
                .setLogradouro("xxxxxx")
                .setNumero("xxxxxx")
                .setReferencia("xxxxxx")
                .build()
            )
            .setTelefone(new TelefoneFactory()
                .setNumero("11111")
                .setCodigo("11111")
                .setDDD("11111")
                .build()
            )
            .setStatusUsuarioComprador(StatusUsuarioComprador.Ativo)
            .build();
        
        var usuarioComprador02 = new UsuarioCompradorFactory()
            .setEmail("UsuarioCompradorTest2")
            .setSenha("UsuarioCompradorTestSenha2")
            .setEndereco(new EnderecoFactory()
                .setBairro("xxxxx")
                .setCep("xxxxx")
                .setCidade("xxxxx")
                .setComplemento("xxxxxxx")
                .setEstado("xxxxxx")
                .setLogradouro("xxxxxx")
                .setNumero("xxxxxx")
                .setReferencia("xxxxxx")
                .build()
            )
            .setTelefone(new TelefoneFactory()
                .setNumero("31231")
                .setCodigo("123123")
                .setDDD("213123")
                .build()
            )
            .setStatusUsuarioComprador(StatusUsuarioComprador.Ativo)
            .build();
        
        Assert.AreNotSame(usuarioComprador01.email, usuarioComprador02.email);
        Assert.AreNotSame(usuarioComprador01.telefone.numero, usuarioComprador02.telefone.numero);
    }
}