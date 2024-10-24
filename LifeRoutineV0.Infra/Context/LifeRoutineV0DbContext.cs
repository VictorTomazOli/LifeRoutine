using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LifeRoutineV0.Infra.Context;

public class LifeRoutineV0DbContext(DbContextOptions<LifeRoutineV0DbContext> options) : DbContext(options)
{
    public DbSet<Alimento> Alimentos { get; set; }
    public DbSet<FichaAlimentacao> FichaAlimentacaos { get; set; }
    public DbSet<Refeicao> Refeicoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlimentoMapping());
        modelBuilder.ApplyConfiguration(new FichaAlimentacaoMapping());
        modelBuilder.ApplyConfiguration(new RefeicaoMapping());
        modelBuilder.ApplyConfiguration(new UsuarioMapping());
    }
}