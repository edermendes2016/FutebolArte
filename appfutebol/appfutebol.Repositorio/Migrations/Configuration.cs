namespace appfutebol.Repositorio.Migrations
{
    using Infraestrutura;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<appfutebol.Repositorio.Infraestrutura.FutebolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        public class SchoolDBInitializer : CreateDatabaseIfNotExists<FutebolContext>
        {
            protected override void Seed(FutebolContext context)
            {
                base.Seed(context);
            }
        }

    }
}
