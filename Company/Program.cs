using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Service ser = new Company.Service();
            ser.GenerateEmplyee();
            ser.PrintInfo(ser.emp);
            Console.WriteLine("\n");
            ser.Report1(Vacancies.Manager);
            Console.WriteLine("\n");
            ser.Report2();
        }
    }
}
