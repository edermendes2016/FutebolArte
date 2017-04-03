namespace appfutebol.Repositorio.Migrations
{
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

    }
}
