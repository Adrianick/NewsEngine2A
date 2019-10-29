using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewsEngine2A.Context.Config
{
    public sealed class Configuration : DbMigrationsConfiguration<NewsEngineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;

        }

        protected override void Seed(NewsEngineContext context)
        {
        }
    }
}