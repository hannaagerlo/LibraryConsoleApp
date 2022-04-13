using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBiblotekSlutuppgift
{
    class Member
    {

        public ICollection<Loan> Loan { get; set; } = new List<Loan>();

        public Member(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public int MemberId { get; set; }
        [StringLength(50)]
        [DisallowNull]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public override string ToString()
        {
            return $"\nId: {MemberId} \nName: {Firstname} {Lastname}\n";
        }
    }
}
