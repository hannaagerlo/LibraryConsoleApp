using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBiblotekSlutuppgift
{
    class DataAccess
    {
        Context context = new Context();
        //public bool IsBorowed(int id)
        //{
        //    var result = context.Loan.Any(l => l.LoanId == id && l.ReturnDate != null);
        //    return result;
        //}
        public void RentBook(Loan bookRenting)
        {
            try
            {
                context.Loan.Add(bookRenting);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
        public void UpdateChosenBook(Book book)
        {
            context.Update(book);
            context.SaveChanges();
        }
        public List<Loan> RentedBooks()
        {
            return context.Loan.ToList();
        }

        public void CreateBok(Book book)
        {
            try
            {
                context.Book.Add(book);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
        public void CreateAuthor(Author author)
        {
            try
            {
                context.Author.Add(author);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
        public void CreateMember(Member member)
        {
            try
            {
                context.Member.Add(member);
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        public List<Book> GetBookWithAuthor()
        {
            return context.Book.Include(a => a.Author).ToList();
        }
        public List<Book> GetBooks()
        {
            return context.Book.ToList();
        }
        public List<Author> GetAuthors()
        {
            return context.Author.ToList();
        }
        public List<Member> GetMembers()
        {
            return context.Member.ToList();
        }
        public void DeleteChosenBook(Book book)
        {
            context.Remove(book);
            context.SaveChanges();
        }
        public void DeleteChosenAuthor(Author author)
        {
            context.Remove(author);
            context.SaveChanges();
        }
        public void DeleteChosenMember(Member member)
        {
            context.Remove(member);
            context.SaveChanges();
        }
    }
}
