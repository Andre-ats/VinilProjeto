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
        
        optionsBuilder.UseNpgsql("User ID=andre;Host=localhost;Port=5432;DataBase=VinilDBTeste01;Password=andre;Include Error Detail=True");
        
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

        modelBuilder.Entity<Vinil>(user =>
        {
            user.ToTable("Vinil");
        });
        
        modelBuilder.Entity<Vinil>()
            .Property(x => x.estiloMusical)
            .HasConversion(x => x.ToString(),
                x => (EstiloMusical)Enum.Parse(typeof(EstiloMusical), x))
            .HasColumnName("EstiloMusical");

        modelBuilder.Entity<Vinil>()
            .OwnsMany(x => x.VinilImagem);
    }
    
    public DbSet<Admin> adminDB { get; set; }
    public DbSet<UsuarioComprador> UsuarioCompradorDB { get; set; }
    public DbSet<Vinil> VinilDB { get; set; }
    public DbSet<VinilImagem> VinilImagemDB { get; set; }
}