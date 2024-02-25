using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.Entity.VinilVenda;

namespace VinilProjeto.Repository;

public class DataBaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("User ID=andre0;Host=localhost;Port=5432;DataBase=vinildb;Password=123;Include Error Detail=True");
        
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
            .OwnsOne(x => x.telefone).Property(x => x);


        modelBuilder.Entity<UsuarioComprador>()
            .OwnsOne(x => x.endereco).Property(x => x);

        modelBuilder.Entity<Vinil>(user =>
        {
            user.ToTable("Vinil");
        });
        modelBuilder.Entity<Vinil>()
            .Property(x => x.estiloMusical)
            .HasConversion(x => x.ToString(),
                x => (EstiloMusical)Enum.Parse(typeof(EstiloMusical), x))
            .HasColumnName("text");
    }
    
    public DbSet<Admin> adminDB { get; set; }
    public DbSet<UsuarioComprador> UsuarioCompradorDB { get; set; }
    public System.Data.Entity.DbSet<Vinil> VinilDB { get; set; }
}