using VinilProjeto.Entity.Usuario;

namespace VinilProjeto.Factory.Entity.Usuario;

public class AdminFactory
{
    private string _email { get; set; }
    private string _senha { get; set; }

    private void init()
    {
        _email = null;
        _senha = null;
    }

    private AdminFactory setEmail(string email)
    {
        this._email = email;
        return this;
    }

    private AdminFactory setSenha(string senha)
    {
        this._senha = senha;
        return this;
    }

    public bool validar()
    {
        _ = _email == null ? throw new Exception() : true;
        _ = _senha == null ? throw new Exception() : true;

        return true;
    }

    public Admin build()
    {
        _ = this.validar() ? true : throw new Exception();

        Admin admin = Admin.createAdmin(
            _email,
            _senha
        );
        
        this.init();

        return admin;
    }
}