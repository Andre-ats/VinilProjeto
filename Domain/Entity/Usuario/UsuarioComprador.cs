using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.ValueObject.Endereco;
using VinilProjeto.ValueObject.Telefone;

namespace VinilProjeto.Entity.Usuario;

public enum StatusUsuarioComprador
{
    Ativo,
    Inativo,
    Vazio
}

[Serializable]
public class UsuarioComprador : IEntity
{
    public string email { get; protected set; }
    public string senha { get; protected set; }
    public StatusUsuarioComprador status { get; protected set; }
    public List<Guid> listaVinisFavoritos { get; protected set; }
    public Telefone telefone { get; protected set; }
    public Endereco endereco { get; protected set; }
    
    private UsuarioComprador(){}

    public static UsuarioComprador createUsuarioComprador(string email, string senha, Telefone telefone,
        Endereco endereco)
    {
        UsuarioComprador usuarioComprador = new UsuarioComprador()
        {
            id = Guid.NewGuid(),
            email = email,
            senha = senha,
            telefone = telefone,
            endereco = endereco,
        };

        return usuarioComprador;

    }

    public void TelefoneAtualizar(Telefone telefone)
    {
        this.telefone = telefone;
    }

    public void AtivarUsuario()
    {
        this.status = StatusUsuarioComprador.Ativo;
    }

    public void DesativarUsuario()
    {
        this.status = StatusUsuarioComprador.Inativo;
    }

    public void AdicionarVinilFavorito(Guid vinilID)
    {
        this.listaVinisFavoritos.Add(vinilID);
    }
}