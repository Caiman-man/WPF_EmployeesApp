//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ivanov_WPF_EF_Employees
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            this.DepartmentsEmployees = new HashSet<DepartmentsEmployees>();
        }
    
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Nullable<int> age { get; set; }
        public string e_address { get; set; }
        public string photo_path { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentsEmployees> DepartmentsEmployees { get; set; }
    }
}
