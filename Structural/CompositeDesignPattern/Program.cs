using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager ceo = new Manager("John Doe", "CEO");
            Manager devManager = new Manager("Jane Smith", "Development Manager");
            Employee developer = new Employee("Alice Johnson", "Developer");
            Employee designer = new Employee("Bob Brown", "Designer");

            devManager.AddSubordinate(developer);
            devManager.AddSubordinate(designer);
            ceo.AddSubordinate(devManager);

            ceo.DisplayDetails();

            Console.ReadKey();
        }
    }
}
