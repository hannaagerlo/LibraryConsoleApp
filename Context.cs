using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBiblotekSlutuppgift
{
    internal class Context : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Loan> Loan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server= (localdb)\mssqllocaldb; Database = Biblotek; Trusted_Connection = true; User Id = biblotek; password=1234qwer;");
            }
        }
    }
}
