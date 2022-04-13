using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBiblotekSlutuppgift
{
    class Author
    {
        public ICollection<Book> Book { get; set; } = new List<Book>();
        public Author(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public int AuthorId { get; set; }
        [StringLength(50)]
        [DisallowNull]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public override string ToString()
        {
            return $"\nId: {AuthorId} \nName: {Firstname} {Lastname}\n";
        }
    }
}
