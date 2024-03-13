using VinilProjeto.Factory.Entity.Usuario;

namespace Testes.Domain.EntityTestes.Admin;

public class CreateAdminFactoryTest
{
    [Test]
    public void construcaoObjAdmin()
    {
        AdminFactory adminFactory = new AdminFactory();
        var admin = adminFactory
            .setEmail("teste")
            .setSenha("teste")
            .build();

        var admin2 = adminFactory
            .setEmail("teste02")
            .setSenha("teste02")
            .build();
        
        Assert.AreNotSame(admin.email, admin2.email);
    }
}