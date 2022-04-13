using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBiblotekSlutuppgift
{
    class Book
    {

        public int BookId { get; set; }
        [StringLength(50)]
        [DisallowNull]
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string YearOfPublication { get; set; }
        public string Rating { get; set; }
        public bool IsBorowed { get; set; }

        public ICollection<Author> Author { get; set; } = new List<Author>();
        public ICollection<Loan> Loan { get; set; } = new List<Loan>();

        public Book(int bookId, string title, string isbn, string yearOfPublication, string rating, bool isBorowed)
        {
            BookId = bookId;
            Title = title;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;
            Rating = rating;
            IsBorowed = isBorowed;
        }

        public Book(string title, string isbn, string yearOfpublication, string rating, bool isBorowed)
        {
            Title = title;
            Isbn = isbn;
            YearOfPublication = yearOfpublication;
            Rating = rating;
            IsBorowed = isBorowed;
        }

        public override string ToString()
        {
            //{Authors.Firstname} {Authors.Lastname} Fungerar ej? Denna ska printa författaren till den specifika boken när programmet printar ut bok infoamtionen. Men det fungerar ej.  
            return $"\nId: {BookId}, \nAuthor: , \nTitle: {Title}, \nIsbn: {Isbn}, \nYear Of Publication: {YearOfPublication}, \nRating: {Rating}, \nThe book is {(IsBorowed ? "not available" : "available")} for renting \n";
        }
    }
}
