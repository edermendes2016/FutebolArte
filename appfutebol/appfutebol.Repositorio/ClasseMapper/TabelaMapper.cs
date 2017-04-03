using System.Data.Entity.ModelConfiguration;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.ClasseMapper
{
    public class TabelaMapper : EntityTypeConfiguration<Tabela>
    {
        public TabelaMapper()
        {
            ToTable("Tabela");
            HasKey(t => t.Id);

            // 1 -- N 
           

        }
    }
}