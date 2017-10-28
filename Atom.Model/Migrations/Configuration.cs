namespace Atom.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Atom.Model.Concrete.Atom>
    {
        public Configuration()
        {
            //Database.SetInitializer<Atom.Model.Concrete.Atom> (new NullDatabaseInitializer<Atom.Model.Concrete.Atom>());
            AutomaticMigrationsEnabled = true;
            ContextKey = "Atom.Model.Concrete.Atom";
        }

        protected override void Seed(Atom.Model.Concrete.Atom context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
