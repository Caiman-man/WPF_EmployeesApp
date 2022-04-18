using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ivanov_WPF_EF_Employees
{
    public delegate void UpdateEmployeeDelegate(string photo, string fname, string lname, int age, string address);

    public partial class UpdateEmployee : Window
    {
        public event UpdateEmployeeDelegate PerformUpdateEmployee;
        string imagePath = System.AppDomain.CurrentDomain.BaseDirectory;
        string defaultPhoto, defaultFName, defaultLName, defaultAge, defaultAddress;

        public UpdateEmployee(string photo, string fname, string lname, int age, string address)
        {
            InitializeComponent();
            fnameTB.BorderBrush = Brushes.DimGray;
            lnameTB.BorderBrush = Brushes.DimGray;
            ageTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;

            if (photo.Contains("."))
            {
                defaultPhoto = photo;
                employeeImage.Source = new BitmapImage(new Uri(photo));
                employeeImage.Tag = $@"Images\Employees\{System.IO.Path.GetFileName(photo)}";
            }
            defaultFName = fnameTB.Text = fname;
            defaultLName = lnameTB.Text = lname;
            defaultAge = ageTB.Text = age.ToString();
            defaultAddress = addressTB.Text = address;
        }

        //update
        private void updateB_Click(object sender, RoutedEventArgs e)
        {
            if (fnameTB.Text == "" || 
                lnameTB.Text == "" || 
                ageTB.Text == "" || 
                addressTB.Text == "" ||
                fnameTB.BorderBrush == Brushes.Red ||
                lnameTB.BorderBrush == Brushes.Red ||
                ageTB.BorderBrush == Brushes.Red) MessageBox.Show("All fields are required!");
            else
            {
                fnameTB.BorderBrush = Brushes.DimGray;
                lnameTB.BorderBrush = Brushes.DimGray;
                ageTB.BorderBrush = Brushes.DimGray;
                PerformUpdateEmployee?.Invoke((string)employeeImage.Tag, fnameTB.Text, lnameTB.Text, Convert.ToInt32(ageTB.Text), addressTB.Text);
                this.Close();
            }
        }

        //установка картинки
        private void actorImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        //default
        private void defaultB_Click(object sender, RoutedEventArgs e)
        {
            fnameTB.BorderBrush = Brushes.DimGray;
            lnameTB.BorderBrush = Brushes.DimGray;
            ageTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;

            employeeImage.Source = new BitmapImage(new Uri(defaultPhoto));
            employeeImage.Tag = $@"Images\Employees\{System.IO.Path.GetFileName(defaultPhoto)}";
            fnameTB.Text = defaultFName;
            lnameTB.Text = defaultLName;
            ageTB.Text = defaultAge;
            addressTB.Text = defaultAddress;
        }

        //cancel
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        //валидация полей
        private void fnameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(fnameTB.Text, @"^\D+$"))
                fnameTB.BorderBrush = Brushes.DimGray;
            else if (fnameTB.Text != "" && ageTB.Text != defaultFName)
                fnameTB.BorderBrush = Brushes.Red;
        }

        private void lnameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(lnameTB.Text, @"^\D+$"))
                lnameTB.BorderBrush = Brushes.DimGray;
            else if (lnameTB.Text != "" && ageTB.Text != defaultLName)
                lnameTB.BorderBrush = Brushes.Red;
        }

        private void ageTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(ageTB.Text, @"^\d+$"))
                ageTB.BorderBrush = Brushes.DimGray;
            else if (ageTB.Text != "" && ageTB.Text != defaultAge)
                ageTB.BorderBrush = Brushes.Red;
        }
    }
}