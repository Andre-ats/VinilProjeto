using VinilProjeto.Entity.Usuario;
using VinilProjeto.Entity.Usuario.Endereco;
using VinilProjeto.Entity.Usuario.Telefone;

namespace VinilProjeto.Factory.Entity.Usuario;

public class UsuarioCompradorFactory
{
    private string _email { get; set; }
    private string _senha { get; set; }
    private Telefone _telefone { get; set; }
    private Endereco _endereco { get; set; }

    private void init()
    {
        _email = null;
        _senha = null;
        _telefone = null;
        _endereco = null;
    }

    public UsuarioCompradorFactory setEmail(string email)
    {
        this._email = email;
        return this;
    }
    
    public UsuarioCompradorFactory setSenha(string senha)
    {
        this._senha = senha;
        return this;
    }
    
    public UsuarioCompradorFactory setTelefone(Telefone telefone)
    {
        this._telefone = telefone;
        return this;
    }
    
    public UsuarioCompradorFactory setEndereco(Endereco endereco)
    {
        this._endereco = endereco;
        return this;
    }

    public bool validar()
    {
        _ = _email == null ? throw new Exception() : true;
        _ = _senha == null ? throw new Exception() : true;
        _ = _telefone == null ? throw new Exception() : true;
        _ = _endereco == null ? throw new Exception() : true;

        return true;
    }

    public UsuarioComprador build()
    {
        _ = this.validar() ? true : throw new Exception();


        UsuarioComprador usuarioComprador = UsuarioComprador.createUsuarioComprador(
            _email,
            _senha,
            _telefone,
            _endereco
        );
        
        this.init();

        return usuarioComprador;
    }
    
}