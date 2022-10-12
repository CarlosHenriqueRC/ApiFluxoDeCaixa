using Microsoft.EntityFrameworkCore;


namespace Web.Api.FluxoDeCaixa.Conta.InfraEstructura.Persistencia
{
    public class FluxoDeCaixaContext: DbContext
    {

        public DbSet<Conta> Contas { get; set; }

        public FluxoDeCaixaContext(DbContextOptions<FluxoDeCaixaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta> (entity =>
            {

                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                      .HasColumnName("Id")
                      .IsRequired(true);

                entity.Property(e => e.descricao)
                      .HasColumnName("Descricao")
                      .HasMaxLength(50)
                      .IsRequired(true)
                      .IsUnicode(true);

                entity.Property(e => e.ativa)
                      .IsRequired(true)
                      .IsUnicode(false);
            });

        }


    }
}
