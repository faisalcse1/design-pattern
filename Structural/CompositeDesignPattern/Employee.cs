using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class Employee:IEmployee
    {
        private string name;
        private string jobTitle;

        public Employee(string name, string jobTitle)
        {
            this.name = name;
            this.jobTitle = jobTitle;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"{jobTitle}: {name}");
        }
    }
}
