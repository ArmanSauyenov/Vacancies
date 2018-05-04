using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Company
{
    public struct Service
    {
        public List<Employees> emp;
        private Random rand;
        public void GenerateEmplyee()
        {
            emp = new List<Employees>();
            rand = new Random();
            Generator genr = new Generator();
            for (int i = 0; i < rand.Next(1, 100); i++)
            {
                Employees employe = new Employees();
                employe.FullName = genr.GenerateDefault((Gender)rand.Next(0, 2));
                employe.StartDate = DateTime.Now.AddMonths((rand.Next(1, 60)) * -1);
                employe.Salary = rand.Next(30000, 100000) / rand.Next(1, 100);
                employe.Position = (Vacancies)rand.Next(0, 4);
                emp.Add(employe);
            }

        }
        public void PrintInfo(List<Employees> empl)
        {
            if (empl != null)
                foreach (Employees item in empl)
                {
                    Console.WriteLine("Name: {0} ({1}) \t {2} \t {3}",
                        item.FullName, item.StartDate, item.Salary, item.Position);
                }
        }
        public void Report1(Vacancies vac)
        {
            double summSal = 0;
            int ClerkCount = 0;
            foreach (Employees item in emp)
            {
                if(item.Position == Vacancies.Clerk)
                {
                    summSal += item.Salary;
                    ClerkCount++;
                }
            }

            summSal = summSal / ClerkCount;
            List<Employees> list = new List<Employees>();
            foreach (Employees item in emp)
            {
                if(item.Position == vac && item.Salary > summSal)
                {
                    list.Add(item);
                }
            }
            Console.WriteLine("{0},  зарплата которых больше средней зарпаты {1} всех ({2}) клерков", vac.ToString(), summSal, ClerkCount);
            list = list.OrderBy(o => o.FullName).ToList();
            PrintInfo(list);
        }
        public void Report2()
        {
            Employees boss = new Employees();
            foreach (Employees item in emp)
            {
                if(item.Position == Vacancies.Boss)
                {
                    boss = item;
                    break;
                }
            }
            List<Employees> List2 = new List<Employees>(0);
            foreach (Employees item in emp)
            {
                if (item.StartDate < boss.StartDate)
                    List2.Add(item);
            }
            Console.WriteLine("информацию обо всех сотрудниках, "+ "принятых на работу позже босса - {0} - ({1})" , boss.FullName, boss.StartDate);
            PrintInfo(List2);
        }
    }
}
