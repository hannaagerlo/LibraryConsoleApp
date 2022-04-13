using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBiblotekSlutuppgift
{
    class Loan
    {
        public int LoanId { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }

        [AllowNull]
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
