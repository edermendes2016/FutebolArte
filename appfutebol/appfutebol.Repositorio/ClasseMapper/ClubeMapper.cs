using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.ClasseMapper
{
    public class ClubeMapper : EntityTypeConfiguration<Clube>
    {
        public ClubeMapper()
        {
            ToTable("Clube");
            HasKey(c => c.Id);
            Property(c => c.Nome).IsRequired()
                .HasMaxLength(100);

           

        }
    }
}
                          