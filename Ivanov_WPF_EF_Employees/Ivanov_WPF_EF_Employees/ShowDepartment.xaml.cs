using System.Windows;


namespace Ivanov_WPF_EF_Employees
{
    public partial class ShowDepartment : Window
    {
        public ShowDepartment(int id, string title, int head_id, string d_address, string phone)
        {
            InitializeComponent();
            department_idTB.Text = id.ToString();
            titleTB.Text = title;
            head_idTB.Text = head_id.ToString();
            d_addressTB.Text = d_address;
            phoneTB.Text = phone;
        }
    }
}
