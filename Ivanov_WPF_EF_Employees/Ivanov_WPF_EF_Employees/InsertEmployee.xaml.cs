using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ivanov_WPF_EF_Employees
{
    public delegate void InsertEmployeeDelegate(string photo, string fname, string lname, int age, string address);

    public partial class InsertEmployee : Window
    {
        public event InsertEmployeeDelegate PerformInsertEmployee;
        string imagePath = System.AppDomain.CurrentDomain.BaseDirectory;

        public InsertEmployee()
        {
            InitializeComponent();
            employeeImage.Tag = $@"Images\Employees\default.png";
            fnameTB.BorderBrush = Brushes.DimGray;
            lnameTB.BorderBrush = Brushes.DimGray;
            ageTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;
        }

        //insert
        private void insertB_Click(object sender, RoutedEventArgs e)
        {
            if (fnameTB.Text == " First name" || 
                lnameTB.Text == " Last name" || 
                ageTB.Text == " Age" || 
                addressTB.Text == " Address" ||
                fnameTB.BorderBrush == Brushes.Red ||
                lnameTB.BorderBrush == Brushes.Red ||
                ageTB.BorderBrush == Brushes.Red) MessageBox.Show("All fields are required!");
            else
            {
                fnameTB.BorderBrush = Brushes.DimGray;
                lnameTB.BorderBrush = Brushes.DimGray;
                ageTB.BorderBrush = Brushes.DimGray;
                PerformInsertEmployee?.Invoke((string)employeeImage.Tag, fnameTB.Text, lnameTB.Text, Convert.ToInt32(ageTB.Text), addressTB.Text);
                this.Close();
            }
        }

        //clear
        private void clearB_Click(object sender, RoutedEventArgs e)
        {
            fnameTB.BorderBrush = Brushes.DimGray;
            lnameTB.BorderBrush = Brushes.DimGray;
            ageTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;

            employeeImage.Source = new BitmapImage(new Uri($@"{imagePath}Images\Employees\default.png"));
            employeeImage.Tag = $@"Images\Employees\default.png";
            fnameTB.Text = " First name";
            lnameTB.Text = " Last name";
            ageTB.Text = " Age";
            addressTB.Text = " Address";
        }

        //cancel
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        //установка картинки
        private void employeeImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = $@"{imagePath}Images\Employees\";
            dlg.FilterIndex = 2;
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                employeeImage.Tag = $@"Images\Employees\{dlg.SafeFileName}";
                employeeImage.Source = new BitmapImage(new Uri($@"{imagePath}Images\Employees\{dlg.SafeFileName}"));
            }
        }

        //при нажатии в пустом месте формы, проверить поля на заполнение
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
        }

        //при нажатии на любой textbox проверить остальные на заполнение и очистить его, если в нем стандартный текст
        private void fnameTB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (fnameTB.Text == " First name")
                fnameTB.Text = "";
        }

        private void lnameTB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (lnameTB.Text == " Last name")
                lnameTB.Text = "";
        }

        private void ageTB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (ageTB.Text == " Age")
                ageTB.Text = "";
        }

        private void addressTB_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (addressTB.Text == " Address")
                addressTB.Text = "";
        }

        //если поля пустые, то заполнить их стандартными названиями
        private void CheckFieldsEmpty()
        {
            if (fnameTB.Text == "")
                fnameTB.Text = " First name";
            if (lnameTB.Text == "")
                lnameTB.Text = " Last name";
            if (ageTB.Text == "")
                ageTB.Text = " Age";
            if (addressTB.Text == "")
                addressTB.Text = " Address";
        }

        //валидация полей
        private void fnameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(fnameTB.Text, @"^\D+$"))
                fnameTB.BorderBrush = Brushes.DimGray;
            else if (fnameTB.Text != "" && fnameTB.Text != " First name")
                fnameTB.BorderBrush = Brushes.Red;
        }

        private void lnameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(lnameTB.Text, @"^\D+$"))
                lnameTB.BorderBrush = Brushes.DimGray;
            else if (lnameTB.Text != "" && lnameTB.Text != " Last name")
                lnameTB.BorderBrush = Brushes.Red;
        }

        private void ageTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(ageTB.Text, @"^\d+$"))
                ageTB.BorderBrush = Brushes.DimGray;
            else if (ageTB.Text != "" && ageTB.Text != " Age")
                ageTB.BorderBrush = Brushes.Red;
        }
    }
}
