using System.Data.Entity.ModelConfiguration;
using appfutebol.Dominio;

namespace appfutebol.Repositorio.ClasseMapper
{
    public class JogoMapper : EntityTypeConfiguration<Jogo>
    {
        public JogoMapper()
        {
            ToTable("Jogo");
            HasKey(j => j.Id);
            Property(j => j.Vitoria).IsRequired();
            Property(j => j.GolsFeito).IsRequired();
            Property(j => j.GolsSofrido).IsRequired();


        }
    }
}