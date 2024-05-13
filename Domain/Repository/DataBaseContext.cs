using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.ValueObject.Vinil;

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

        modelBuilder.Entity<Vinil>(user =>
        {
            user.ToTable("Vinil");
        });
        
        modelBuilder.Entity<Vinil>()
            .Property<EstiloMusical>("EstiloMusical")
            .HasConversion(
                v => v.ToString(),
                v => (EstiloMusical)Enum.Parse(typeof(EstiloMusical), v)
            );

        modelBuilder.Entity<Vinil>()
            .Property<TipoAlbum>("TipoDoAlbum")
            .HasConversion(
                v => v.ToString(),
                v => (TipoAlbum)Enum.Parse(typeof(TipoAlbum), v)
            );

        modelBuilder.Entity<Vinil>()
            .Property<TipoDeEmbalagem>("TipoDaEmbalagem")
            .HasConversion(
                v => v.ToString(),
                v => (TipoDeEmbalagem)Enum.Parse(typeof(TipoDeEmbalagem), v)
            );



        modelBuilder.Entity<Vinil>()
            .OwnsMany(x => x.VinilImagem);

        modelBuilder.Entity<Vinil>()
            .OwnsOne(x => x.caracteristicasPrincipais);
        
        modelBuilder.Entity<Vinil>()
            .OwnsOne(x => x.outrasCaracteristicas);
        
        modelBuilder.Entity<UsuarioComprador>()
            .OwnsOne(x => x.telefone);


        modelBuilder.Entity<UsuarioComprador>()
            .OwnsOne(x => x.endereco);
    }
    
    public DbSet<Admin> adminDB { get; set; }
    public DbSet<UsuarioComprador> UsuarioCompradorDB { get; set; }
    public DbSet<Vinil> VinilDB { get; set; }
}