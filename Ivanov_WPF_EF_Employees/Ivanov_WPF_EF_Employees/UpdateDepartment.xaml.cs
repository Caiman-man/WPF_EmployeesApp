using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ivanov_WPF_EF_Employees
{
    public delegate void UpdateDepartmentDelegate(string title, int h_id, string d_address, string phone);

    public partial class UpdateDepartment : Window
    {
        public event UpdateDepartmentDelegate PerformUpdateDepartment;
        string defaultTitle, defaultHeadId, defaultAddress, defaultPhone;

        public UpdateDepartment(string title, int h_id, string d_address, string phone)
        {
            InitializeComponent();
            titleTB.BorderBrush = Brushes.DimGray;
            headIDTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;
            phoneTB.BorderBrush = Brushes.DimGray;

            defaultTitle = titleTB.Text = title;
            defaultHeadId = headIDTB.Text = h_id.ToString();
            defaultAddress = addressTB.Text = d_address;
            defaultPhone = phoneTB.Text = phone;
        }

        //update
        private void updateB_Click(object sender, RoutedEventArgs e)
        {
            if (titleTB.Text == "" || 
                headIDTB.Text == "" || 
                addressTB.Text == "" || 
                phoneTB.Text == "" ||
                titleTB.BorderBrush == Brushes.Red ||
                headIDTB.BorderBrush == Brushes.Red ||
                phoneTB.BorderBrush == Brushes.Red) MessageBox.Show("All fields are required!");
            else
            {
                titleTB.BorderBrush = Brushes.DimGray;
                headIDTB.BorderBrush = Brushes.DimGray;
                phoneTB.BorderBrush = Brushes.DimGray;
                PerformUpdateDepartment?.Invoke(titleTB.Text, Convert.ToInt32(headIDTB.Text), addressTB.Text, phoneTB.Text);
                this.Close();
            }
        }

        //default
        private void defaultB_Click(object sender, RoutedEventArgs e)
        {
            titleTB.BorderBrush = Brushes.DimGray;
            headIDTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;
            phoneTB.BorderBrush = Brushes.DimGray;

            titleTB.Text = defaultTitle;
            headIDTB.Text = defaultHeadId;
            addressTB.Text = defaultAddress;
            phoneTB.Text = defaultPhone;
        }

        //cancel
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        //валидация полей
        private void titleTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(titleTB.Text, @"^\D+(\s*\D*)*$"))
                titleTB.BorderBrush = Brushes.DimGray;
            else if (titleTB.Text != "" && titleTB.Text != " Title")
                titleTB.BorderBrush = Brushes.Red;
        }

        private void headIDTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(headIDTB.Text, @"^\d+$"))
                headIDTB.BorderBrush = Brushes.DimGray;
            else if (headIDTB.Text != "" && headIDTB.Text != " Head ID")
                headIDTB.BorderBrush = Brushes.Red;
        }

        private void phoneTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(phoneTB.Text, @"^((\d{1,2}|\+\d{1,2})[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d]{3}[\- ]?[\d]{2}[\- ]?[\d]{2}$"))
                phoneTB.BorderBrush = Brushes.DimGray;
            else if (phoneTB.Text != "" && phoneTB.Text != " Phone")
                phoneTB.BorderBrush = Brushes.Red;
        }
    }
}