using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Ivanov_WPF_EF_Employees
{
    public partial class ShowEmployee : Window
    {
        public ShowEmployee(string photo, int id, string fname, string lname, int age, string e_address)
        {
            InitializeComponent();
            if (photo.Contains("."))
                actorImage.Source = new BitmapImage(new Uri(photo));
            employee_idTB.Text = id.ToString();
            fnameTB.Text = fname;
            lnameTB.Text = lname;
            ageTB.Text = age.ToString();
            e_addressTB.Text = e_address;
        }
    }
}
