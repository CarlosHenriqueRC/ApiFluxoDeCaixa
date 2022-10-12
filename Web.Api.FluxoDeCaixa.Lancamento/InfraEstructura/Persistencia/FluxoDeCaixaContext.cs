using Microsoft.EntityFrameworkCore;


namespace Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia
{
    public class FluxoDeCaixaContext: DbContext
    {

        public DbSet<Conta> contas { get; set; }
        public DbSet<Lancamento> lancamentos { get; set; }

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

            modelBuilder.Entity<Lancamento>(entity =>
            {

                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                      .HasColumnName("Id")
                      .IsRequired(true);

                entity.Property(e => e.valor)
                      .HasColumnName("Valor")
                      .IsRequired(true);

                entity.Property(e => e.data)
                      .HasColumnName("Data")
                      .IsRequired(true);

                entity.Property(e => e.tipo)
                      .HasColumnName("Tipo")
                      .HasMaxLength(1)
                      .IsRequired(true);

                entity.HasOne(d => d.conta)
                      .WithMany(p => p.lancamentos)
                      .HasForeignKey(d => d.idConta);
            });


        }


    }
}
