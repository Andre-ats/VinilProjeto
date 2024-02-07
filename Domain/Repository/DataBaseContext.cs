using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VinilProjeto.Entity.Usuario;

namespace VinilProjeto.Repository;

public class DataBaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("User ID=Vinil;Host=localhost;Port=5432;DataBase=testes;Password=VinilDB;Include Error Detail=True");
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admin>(user =>
        {
            user.ToTable("Admin");
        });

        modelBuilder.Entity<UsuarioComprador>(user =>
        {
            user.ToTable("UsuarioComprador");
        });

        modelBuilder.Entity<UsuarioComprador>()
            .OwnsOne(x => x.telefone);

        modelBuilder.Entity<UsuarioComprador>()
            .OwnsOne(x => x.endereco);
    }
    
    public DbSet<Admin> adminDB { get; set; }
    public DbSet<UsuarioComprador> UsuarioCompradorDB { get; set; }
}