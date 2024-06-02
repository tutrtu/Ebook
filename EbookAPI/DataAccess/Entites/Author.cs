using System;
using System.Collections.Generic;

namespace EbookAPI.DataAccess.Entites
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int AuthorId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string EmailAddress { get; set; } = null!;

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
