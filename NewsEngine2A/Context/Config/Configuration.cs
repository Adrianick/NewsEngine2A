using System.Data.Entity.Migrations;

namespace NewsEngine2A.Context.Config
{
    public sealed class Configuration : DbMigrationsConfiguration<NewsEngineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(NewsEngineContext context)
        {
        }
    }
}