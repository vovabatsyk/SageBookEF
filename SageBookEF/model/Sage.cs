using System.Collections.Generic;

namespace SageBookEF.model
{
    public class Sage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<Book> Books { get; set; }

        public Sage()
        {
            Books = new List<Book>();
        }

        public override string ToString()
        {
            return $"Name: {this.Name} - age: {this.Age}";
        }
    }
}
