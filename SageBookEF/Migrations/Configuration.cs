using SageBookEF.model;

namespace SageBookEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SageBookEF.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SageBookEF.MyDbContext context)
        {
            var sage = new Sage() { Name = "John", Age = 54 };
            var book = new Book() { Title = "Javascript", Pages = 303 };

            context.Books.Add(book);
            context.Sages.Add(sage);
            context.SaveChanges();
        }
    }
}
