using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivanov_WPF_EF_Employees
{
    class MyEmployee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmployeeAddress { get; set; }
        public string Photo { get; set; }

        public MyEmployee() { }

        public MyEmployee(int e_id, string f, string l, int a, string e_adr, string p)
        {
            this.EmployeeID = e_id;
            this.FirstName = f;
            this.LastName = l;
            this.Age = a;
            this.EmployeeAddress = e_adr;
            this.Photo = p;
        }
    }
}
