using System.Collections.Generic;

namespace SageBookEF.model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }

        public ICollection<Sage> Sages { get; set; }

        public Book()
        {
            Sages = new List<Sage>();
        }
    }
}
