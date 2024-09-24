using LifeRoutine.Domain.Entities;
using LifeRoutine.Infra.FluentMapping;
using Microsoft.EntityFrameworkCore;

namespace LifeRoutine.Infra.Context;

public class LifeRoutineDbContext(DbContextOptions<LifeRoutineDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<FichaCorporal> FichasCorporais {get;set;}
    public DbSet<FichaExercicio> FichasExercicios {get;set;}
    public DbSet<FichaAlimentacao> FichasAlimentacoes { get; set; }
    public DbSet<Refeicao> Refeicoes { get; set; }
    public DbSet<Alimento> Alimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMapping());
        modelBuilder.ApplyConfiguration(new FichaAlimentacaoMapping());
        modelBuilder.ApplyConfiguration(new RefeicaoMapping());
        modelBuilder.ApplyConfiguration(new AlimentoMapping());
        modelBuilder.ApplyConfiguration(new FichaCorporalMapping());
        modelBuilder.ApplyConfiguration(new FichaExercicioMapping());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LifeRoutineV1");
    }
}                                              