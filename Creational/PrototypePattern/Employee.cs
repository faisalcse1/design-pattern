using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Employee:IPrototype
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string MobileNo {  get; set; }

        public Address Address { get; set; }

        public IPrototype Clone()
        {
            return this.MemberwiseClone() as IPrototype;
        }

        public IPrototype DeepCopy()
        {
            Employee employee = this.MemberwiseClone() as Employee;
            employee.Address = new Address()
            {
                RoadNo=employee.Address.RoadNo,
                HourseNo=employee.Address.HourseNo
            };
            return employee;
        }
    }
}
