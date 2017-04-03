using System.Data.Entity.ModelConfiguration;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.ClasseMapper
{
    public class TecnicoMapper : EntityTypeConfiguration<Tecnico>
    {
        public TecnicoMapper()
        {
            ToTable("Tecnico");
            HasKey(j => j.Id);
            Property(j => j.InicioContrato).IsRequired();
            Property(j => j.FinalContrato).IsRequired();
            Property(j => j.Nome).IsRequired()
                .HasMaxLength(100);
            Property(j => j.Salario).IsRequired()
                .HasMaxLength(16);

        }
    }
}