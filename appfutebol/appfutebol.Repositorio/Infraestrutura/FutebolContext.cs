using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using appfutebol.Dominio;
using appfutebol.Repositorio.ClasseMapper;

namespace appfutebol.Repositorio.Infraestrutura
{
    public class FutebolContext : DbContext
    {
        public FutebolContext() :
            base("DefaultConnection")
        {
           
        }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Tabela> Tabela { get; set; }
        public DbSet<Clube> Clube { get; set; }
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Tecnico> Tecnico { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<FutebolContext>(new CreateDatabaseIfNotExists<FutebolContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

           
            modelBuilder.Configurations.Add(new ClubeMapper());
            modelBuilder.Configurations.Add(new JogadorMapper());
            modelBuilder.Configurations.Add(new JogoMapper());
            modelBuilder.Configurations.Add(new TabelaMapper());
            modelBuilder.Configurations.Add(new TecnicoMapper());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInclusao").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}

