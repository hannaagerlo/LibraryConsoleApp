using System;
using System.Collections.Generic;
using System.Linq;

namespace DbBiblotekSlutuppgift
{
    class Program
    {
        static DataAccess dataAccess = new DataAccess();
        static void Main(string[] args)
        {
            //dataAccess.RecreateDatabase();
            bool runProgram = true;
            while (runProgram)
            {
                Console.WriteLine("=======Bibloteket=======");
                Console.WriteLine("[1]Add new book.");
                Console.WriteLine("[2]Add new author.");
                Console.WriteLine("[3]Add new Member.");
                Console.WriteLine("[4]Delete book.");
                Console.WriteLine("[5]Delete author.");
                Console.WriteLine("[6]Delete member.");
                Console.WriteLine("[7]Rent book");
                Console.WriteLine("[8]Return book");
                Console.WriteLine("[9]Exit");
                int input = InputHelper.GetInt();

                switch (input)
                {
                    case 1:
                        CreateBook();
                        break;
                    case 2:
                        CreateAuthor();
                        break;
                    case 3:
                        CreateMember();
                        break;
                    case 4:
                        DeleteChosenBook();
                        break;
                    case 5:
                        DeleteChosenAuthor();
                        break;
                    case 6:
                        DeleteChosenMember();
                        break;
                    case 7:
                        LoanBook();
                        break;
                    case 8:
                        ReturnBook();
                        break;
                    case 9:
                        runProgram = false;
                        break;
                    default:
                        ErrorMessage();
                        break;
                }

            }

        }
        static void ReturnBook()
        {
            List<Book> checkedOutBooks = dataAccess.GetBooks();
            checkedOutBooks.FindAll(b => b.IsBorowed);
            if (checkedOutBooks.Count > 0)
            {
                Console.WriteLine("Book list: ");
                foreach (Book book in checkedOutBooks)
                {
                    Console.WriteLine(book.BookId + " " + book);
                }
                Console.WriteLine("Enter the Id of the book you want to return to the library: ");
                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    Book chosenBook = checkedOutBooks.First(b => b.BookId == input);
                    chosenBook.IsBorowed = false;
                    dataAccess.UpdateChosenBook(chosenBook);
                    Console.WriteLine("The book has been retuned to the library.");
                }
                else
                {
                    ErrorMessage();
                }
            }
            else
            {
                Console.WriteLine("No books to return.");
            }


        }
        static void LoanBook()
        {
            List<Book> books = dataAccess.GetBookWithAuthor();
            books.FindAll(b => !b.IsBorowed);
            Loan bookRenting = new Loan();
            if (books.Count > 0)
            {
                Console.WriteLine("Book list: ");
                foreach (Book book in books)
                {
                    Console.WriteLine(book.BookId + " " + book);

                }
                Console.Write("Rent the book by entering the books id number: ");
                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    Book chosenBook = books.First(b => b.BookId == input);
                    chosenBook.IsBorowed = true;
                    bookRenting.LoanDate = DateTime.Now;
                    bookRenting.ReturnDate = DateTime.Now.AddDays(14);
                    DateTime rentDate = DateTime.Now;
                    DateTime returnDate = DateTime.Now.AddDays(14);
                    Console.WriteLine("Loan date: " + rentDate.ToString("yyyy/MM/dd"));
                    Console.WriteLine("Return date: " + returnDate.ToString("yyyy/MM/dd"));
                    dataAccess.UpdateChosenBook(chosenBook);
                    //bookRenting.Book.Add(chosenBook);
                    dataAccess.RentBook(bookRenting);
                    Console.WriteLine("The chosen book has been rented");

                }
                else
                {
                    ErrorMessage();
                }
            }
            else
            {
                Console.WriteLine("No books in the inventory too rent..");
            }



            // add chosenBook (id) to Loan. 
            // add chosenMember (id) too Loan



        }
        static void CreateBook()
        {

            Console.WriteLine("Add a new book to the Library");
            Console.WriteLine("Choose author: ");
            List<Author> authors = dataAccess.GetAuthors();
            foreach (Author author in authors)
            {
                Console.WriteLine(author.AuthorId + " " + author);
            }
            Console.Write("Input Id of the author: ");
            if (Int32.TryParse(Console.ReadLine(), out int input))
            {

                Author chosenAuthor = authors.First(a => a.AuthorId == input);

                Console.WriteLine("Title: ");
                string title = Console.ReadLine().ToUpper();
                while (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title can't be emty. Try again. ");
                    title = Console.ReadLine().ToUpper();
                }


                Console.WriteLine("Isbn: ");
                string isbn = Console.ReadLine().ToUpper();
                while (string.IsNullOrEmpty(isbn) || string.IsNullOrWhiteSpace(isbn))
                {
                    Console.WriteLine("Isbn can't be emty. Try again. ");
                    isbn = Console.ReadLine().ToUpper();
                }
                Console.WriteLine("Year of publication: ");
                string yearOfpublication = Console.ReadLine().ToUpper();
                while (string.IsNullOrEmpty(yearOfpublication) || string.IsNullOrWhiteSpace(yearOfpublication))
                {
                    Console.WriteLine("Year Of Publication can't be emty. Try again. ");
                    yearOfpublication = Console.ReadLine().ToUpper();
                }
                Console.WriteLine("Rating: ");
                string rating = Console.ReadLine().ToUpper();
                while (string.IsNullOrEmpty(rating) || string.IsNullOrWhiteSpace(rating))
                {
                    Console.WriteLine("Rating can't be emty. Try again. ");
                    rating = Console.ReadLine().ToUpper();
                }
                bool isBorowed = false;
                Book book = new Book(title, isbn, yearOfpublication, rating, isBorowed);
                Console.WriteLine("The book as been added to the inventory!");
                book.Author.Add(chosenAuthor);
                dataAccess.CreateBok(book);
                Console.WriteLine("The new book has Id: " + book.BookId);
                Console.WriteLine("Press enter to go back to the start menu");
                Console.ReadLine();


            }
            else
            {
                ErrorMessage();
            }


        }
        static void ErrorMessage()
        {
            Console.WriteLine("Invalid input");
        }
        static void CreateAuthor()
        {

            Console.WriteLine("Add a new author.");
            Console.Write("Firstname: ");
            string firstname = Console.ReadLine().ToUpper();
            while (string.IsNullOrEmpty(firstname) || string.IsNullOrWhiteSpace(firstname))
            {
                Console.WriteLine("Firstname can't be emty. Try again. ");
                firstname = Console.ReadLine().ToUpper();
            }
            Console.Write("Lastname: ");
            string lastname = Console.ReadLine().ToUpper();
            while (string.IsNullOrEmpty(lastname) || string.IsNullOrWhiteSpace(lastname))
            {
                Console.WriteLine("Lastname can't be emty. Try again. ");
                lastname = Console.ReadLine().ToUpper();
            }
            Author author = new Author(firstname, lastname);
            Console.WriteLine("The author as been added to the inventory!");
            dataAccess.CreateAuthor(author);
            Console.WriteLine("The new author has Id: " + author.AuthorId);
            Console.WriteLine("Press enter to go back to the start menu");
            Console.ReadLine();
        }
        static void CreateMember()
        {
            Console.WriteLine("Add a new member.");
            Console.Write("Firstname: ");
            string firstname = Console.ReadLine().ToUpper();
            while (string.IsNullOrEmpty(firstname) || string.IsNullOrWhiteSpace(firstname))
            {
                Console.WriteLine("Firstname can't be emty. Try again. ");
                firstname = Console.ReadLine().ToUpper();
            }
            Console.Write("Lastname: ");
            string lastname = Console.ReadLine().ToUpper();
            while (string.IsNullOrEmpty(lastname) || string.IsNullOrWhiteSpace(lastname))
            {
                Console.WriteLine("Lastname can't be emty. Try again. ");
                lastname = Console.ReadLine().ToUpper();
            }
            Member member = new Member(firstname, lastname);
            Console.WriteLine("The new member has been added!");
            dataAccess.CreateMember(member);
            Console.WriteLine("The new member has Id: " + member.MemberId);
            Console.WriteLine("Press enter to go back to the start menu");
            Console.ReadLine();

        }
        static void DeleteChosenBook()
        {
            List<Book> books = dataAccess.GetBooks();
            if (books.Count > 0)
            {
                Console.WriteLine("Book list: ");
                foreach (Book book in books)
                {
                    Console.WriteLine(book.BookId + " " + book);
                }
                Console.Write("Delete by entering the id of the chosen book");
                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    Book chosenBook = books.First(b => b.BookId == input);
                    Console.WriteLine("The chosen book has been deleted from the inventory.");
                    dataAccess.DeleteChosenBook(chosenBook);
                }
                else
                {
                    ErrorMessage();
                }
            }
            else
                Console.WriteLine("No books in the inventory too delete.");


        }
        static void DeleteChosenAuthor()
        {
            List<Author> authors = dataAccess.GetAuthors();
            if (authors.Count > 0)
            {
                Console.WriteLine("List of Authors: ");
                foreach (Author author in authors)
                {
                    Console.WriteLine(author.AuthorId + " " + author);
                }
                Console.Write("Input the Id of the author that you want to delete from the library: ");
                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    Author chosenAuthor = authors.First(a => a.AuthorId == input);
                    Console.WriteLine("The chosen author has been deleted from the inventory.");
                    dataAccess.DeleteChosenAuthor(chosenAuthor);
                }
                else
                {
                    ErrorMessage();
                }
            }
            Console.WriteLine("No authors in the inventory too delete.");

        }
        static void DeleteChosenMember()
        {
            List<Member> members = dataAccess.GetMembers();
            if (members.Count > 0)
            {
                Console.WriteLine("List of Members: ");
                foreach (Member member in members)
                {
                    Console.WriteLine(member.MemberId + " " + member);

                }
                Console.Write("Input the Id of the member that you want to delete: ");

                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    Member chosenMember = members.First(m => m.MemberId == input);
                    Console.WriteLine("The chosen member has been deleted.");
                    dataAccess.DeleteChosenMember(chosenMember);
                }
                else
                {
                    ErrorMessage();
                }

            }
            else
                Console.WriteLine("No members too delete");

        }
    }
}
