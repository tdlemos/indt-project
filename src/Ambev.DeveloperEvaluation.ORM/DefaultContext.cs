using Indt.Proposta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Indt.Proposta.ORM;

public class DefaultContext : DbContext
{
    public DbSet<PropostaEntity> Propostas { get; set; }
    public DbSet<BeneficiarioEntity> Beneficiarios { get; set; }
    public DbSet<CoberturaEntity> Coberturas { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PropostaEntity>().ToTable("Proposta");
        modelBuilder.Entity<PropostaEntity>()
            .HasIndex(u => new { u.Numero })
            .IsUnique()
            .Metadata.SetAnnotation(RelationalAnnotationNames.Filter, null);

        modelBuilder.Entity<BeneficiarioEntity>().ToTable("Beneficiario");
        modelBuilder.Entity<BeneficiarioEntity>()
            .HasIndex(u => new { u.PropostaId, u.Tipo })
            .IsUnique()
            .Metadata.SetAnnotation(RelationalAnnotationNames.Filter, null);

        modelBuilder.Entity<CoberturaEntity>().ToTable("Cobertura");
        modelBuilder.Entity<CoberturaEntity>()
            .HasIndex(u => new { u.PropostaId, u.Nome })
            .IsUnique()
            .Metadata.SetAnnotation(RelationalAnnotationNames.Filter, null);
    }
}

public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Indt.Proposta.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}