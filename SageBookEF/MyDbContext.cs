using System.Data.Entity;
using SageBookEF.model;

namespace SageBookEF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("conStr")
        {
        }

        public virtual DbSet<Sage> Sages { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
