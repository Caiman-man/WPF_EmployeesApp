using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ivanov_WPF_EF_Employees
{
    public delegate void InsertDepartmentDelegate(string title, int head_id, string d_address, string phone);

    public partial class InsertDepartment : Window
    {
        public event InsertDepartmentDelegate PerformInsertDepartment;

        public InsertDepartment()
        {
            InitializeComponent();
            titleTB.BorderBrush = Brushes.DimGray;
            headIDTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;
            phoneTB.BorderBrush = Brushes.DimGray;
        }

        //insert
        private void insertB_Click(object sender, RoutedEventArgs e)
        {
            if (titleTB.Text == " Title" || 
                headIDTB.Text == " Head ID" || 
                addressTB.Text == " Address" || 
                phoneTB.Text == " Phone" ||
                titleTB.BorderBrush == Brushes.Red ||
                headIDTB.BorderBrush == Brushes.Red ||
                phoneTB.BorderBrush == Brushes.Red) MessageBox.Show("All fields are required!");
            else
            {
                titleTB.BorderBrush = Brushes.DimGray;
                headIDTB.BorderBrush = Brushes.DimGray;
                phoneTB.BorderBrush = Brushes.DimGray;
                PerformInsertDepartment?.Invoke(titleTB.Text, Convert.ToInt32(headIDTB.Text), addressTB.Text, phoneTB.Text);
                this.Close();
            }
        }

        //clear
        private void clearB_Click(object sender, RoutedEventArgs e)
        {
            titleTB.BorderBrush = Brushes.DimGray;
            headIDTB.BorderBrush = Brushes.DimGray;
            addressTB.BorderBrush = Brushes.DimGray;
            phoneTB.BorderBrush = Brushes.DimGray;

            titleTB.Text = " Title";
            headIDTB.Text = " Head ID";
            addressTB.Text = " Address";
            phoneTB.Text = " Phone";
        }

        //cancel
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        //при нажатии в пустом месте формы, проверить поля на заполнение
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
        }

        //при нажатии на любой textbox проверить остальные на заполнение и очистить его, если в нем стандартный текст
        private void titleTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (titleTB.Text == " Title")
                titleTB.Text = "";
        }

        private void headIDTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (headIDTB.Text == " Head ID")
                headIDTB.Text = "";
        }

        private void addressTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (addressTB.Text == " Address")
                addressTB.Text = "";
        }

        private void phoneTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CheckFieldsEmpty();
            if (phoneTB.Text == " Phone")
                phoneTB.Text = "";
        }

        //если поля пустые, то заполнить их стандартными названиями
        private void CheckFieldsEmpty()
        {
            if (titleTB.Text == "")
                titleTB.Text = " Title";
            if (headIDTB.Text == "")
                headIDTB.Text = " Head ID";
            if (addressTB.Text == "")
                addressTB.Text = " Address";
            if (phoneTB.Text == "")
                phoneTB.Text = " Phone";
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