using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    public class Manager:IEmployee
    {
        private List<IEmployee> subordinates = new List<IEmployee>();
        private string name;
        private string jobTitle;

        public Manager(string name, string jobTitle)
        {
            this.name = name;
            this.jobTitle = jobTitle;
        }

        public void AddSubordinate(IEmployee employee)
        {
            subordinates.Add(employee);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"{jobTitle}: {name}");
            foreach (var subordinate in subordinates)
            {
                subordinate.DisplayDetails();
            }
        }
    }
}
