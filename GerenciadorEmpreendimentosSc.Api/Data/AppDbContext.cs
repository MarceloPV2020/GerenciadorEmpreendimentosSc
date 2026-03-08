using GerenciadorEmpreendimentosSc.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorEmpreendimentosSc.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Empreendimento> Empreendimentos => Set<Empreendimento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var e = modelBuilder.Entity<Empreendimento>();
        e.HasIndex(x => x.Municipio);
        e.HasIndex(x => x.Status);
        e.HasIndex(x => x.Segmento);
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        UpdateAtualizado();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAtualizado();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAtualizado()
    {
        foreach (var entry in ChangeTracker.Entries<Empreendimento>().Where(x => x.State == EntityState.Modified))
        {
            entry.Entity.Atualizado = DateTimeOffset.UtcNow;
        }
    }
}