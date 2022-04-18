using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivanov_WPF_EF_Employees
{
    class MyDepartment
    {
        public int DepartmentID { get; set; }
        public string Title { get; set; }
        public int HeadID { get; set; }
        public string DepartmentAdress { get; set; }
        public string Phone { get; set; }

        public MyDepartment() { }

        public MyDepartment(int d_id, string t, int h_id, string da, string p)
        {
            this.DepartmentID = d_id;
            this.Title = t;
            this.HeadID = h_id;
            this.DepartmentAdress = da;
            this.Phone = p;
        }
    }
}
