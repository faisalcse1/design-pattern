using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            employee.FirstName = "Md";
            employee.LastName = "Faisal";
            employee.Email = "test@gmail.com";
            employee.MobileNo = "0170000000";

            Address address = new Address();
            address.RoadNo = "12345";
            address.HourseNo = "34";
            employee.Address = address;

            Employee cloneEmployee=employee.Clone() as Employee;

            cloneEmployee.MobileNo = "019870000";

            cloneEmployee.Address.RoadNo = "2546";

            var deepClone=employee.DeepCopy() as Employee;

            deepClone.Address.RoadNo = "455";

            Console.WriteLine(employee.MobileNo);
            Console.WriteLine(cloneEmployee.MobileNo);

            Console.ReadKey();
        }
    }
}
