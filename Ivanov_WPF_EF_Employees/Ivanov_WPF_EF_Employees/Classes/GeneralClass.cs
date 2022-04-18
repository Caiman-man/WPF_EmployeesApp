using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivanov_WPF_EF_Employees
{
    class GeneralClass
    {
        public int DepartmentID { get; set; }
        public string Title { get; set; }
        public int HeadID { get; set; }
        public string DepartmentAdress { get; set; }
        public string Phone { get; set; }

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmployeeAddress { get; set; }
        public string Photo { get; set; }


        public GeneralClass()
        {
            MyDepartment department = new MyDepartment();
            MyEmployee employee = new MyEmployee();
        }
    }
}
