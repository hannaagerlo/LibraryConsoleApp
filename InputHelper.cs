using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBiblotekSlutuppgift
{
    class InputHelper
    {
        public static int GetInt()
        {
            bool validInput = false;
            int result = 0;
            while (!validInput)
            {
                Console.Write("Please select an option: ");
                validInput = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
    }
}
