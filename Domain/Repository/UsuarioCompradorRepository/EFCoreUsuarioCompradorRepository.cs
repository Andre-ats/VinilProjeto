using Microsoft.EntityFrameworkCore;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.ValueObject.Telefone;

namespace VinilProjeto.Repository.UsuarioCompradorRepository;

public class EFCoreUsuarioCompradorRepository : IUsuarioCompradorRepository
{

    private DataBaseContext _dataBaseContext;

    public EFCoreUsuarioCompradorRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    public bool createUsuario(UsuarioComprador usuarioComprador)
    {
        _dataBaseContext.UsuarioCompradorDB.Add(usuarioComprador);
        return _dataBaseContext.SaveChanges() > 0;
    }

    public List<UsuarioComprador> getUsuarioComprador()
    {
       return _dataBaseContext.UsuarioCompradorDB.ToList();
    }

    public UsuarioComprador GetUsuarioCompradorByEmail(string email)
    {
        return _dataBaseContext.UsuarioCompradorDB.SingleOrDefault(x => x.email.Equals(email));
    }

    public void PutUsuarioCompradorTelefone(UsuarioComprador usuarioComprador)
    {
        _dataBaseContext.Update(usuarioComprador);
        _dataBaseContext.SaveChanges();
    }

    public UsuarioComprador GetUsuarioCompradorById(Guid id)
    {
        return _dataBaseContext.UsuarioCompradorDB.SingleOrDefault(x => x.id.Equals(id)) ?? null;
    }
}