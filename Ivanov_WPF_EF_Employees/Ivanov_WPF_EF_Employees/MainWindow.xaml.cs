using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ivanov_WPF_EF_Employees
{
    public partial class MainWindow : Window
    {
        Ivanov_EmployeesEntities context = new Ivanov_EmployeesEntities();

        //режимы активных таблиц
        enum TableMode { Default, Employees, Departments }
        TableMode currentMode;

        //получить полный путь к папке с картинками
        string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;

        public MainWindow()
        {
            InitializeComponent();
            showAllButton_Click((Button)showAll_B, new RoutedEventArgs());                       
        }

        //employees
        private void ShowEmployees()
        {
            //показываем колонки employee
            dataGrid1.Columns[0].Visibility = Visibility.Visible;
            dataGrid1.Columns[1].Visibility = Visibility.Visible;
            dataGrid1.Columns[2].Visibility = Visibility.Visible;
            dataGrid1.Columns[3].Visibility = Visibility.Visible;
            dataGrid1.Columns[4].Visibility = Visibility.Visible;
            dataGrid1.Columns[5].Visibility = Visibility.Visible;

            //скрываем колонки departments
            dataGrid1.Columns[6].Visibility = Visibility.Hidden;
            dataGrid1.Columns[7].Visibility = Visibility.Hidden;
            dataGrid1.Columns[8].Visibility = Visibility.Hidden;
            dataGrid1.Columns[9].Visibility = Visibility.Hidden;
            dataGrid1.Columns[10].Visibility = Visibility.Hidden;

            var result = from emp in context.Employees
                         select new MyEmployee
                         {
                             EmployeeID = emp.employee_id,
                             FirstName = emp.first_name,
                             LastName = emp.last_name,
                             Age = (int)emp.age,
                             EmployeeAddress = emp.e_address,
                             Photo = currentPath + emp.photo_path
                         };

            ObservableCollection<MyEmployee> observableCollection = new ObservableCollection<MyEmployee>(result);
            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };

            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = collection.View;
            currentMode = TableMode.Employees;
        }

        //departments
        private void ShowDepartments()
        {
            //скрываем колонки employee
            dataGrid1.Columns[0].Visibility = Visibility.Hidden;
            dataGrid1.Columns[1].Visibility = Visibility.Hidden;
            dataGrid1.Columns[2].Visibility = Visibility.Hidden;
            dataGrid1.Columns[3].Visibility = Visibility.Hidden;
            dataGrid1.Columns[4].Visibility = Visibility.Hidden;
            dataGrid1.Columns[5].Visibility = Visibility.Hidden;

            //показываем колонки departments
            dataGrid1.Columns[6].Visibility = Visibility.Visible;
            dataGrid1.Columns[7].Visibility = Visibility.Visible;
            dataGrid1.Columns[8].Visibility = Visibility.Visible;
            dataGrid1.Columns[9].Visibility = Visibility.Visible;
            dataGrid1.Columns[10].Visibility = Visibility.Visible;

            var result = from dep in context.Departments
                         select new MyDepartment
                         {
                             DepartmentID = dep.department_id,
                             Title = dep.title,
                             HeadID = (int)dep.head_id,
                             DepartmentAdress = dep.d_address,
                             Phone = dep.phone
                         };

            ObservableCollection<MyDepartment> observableCollection = new ObservableCollection<MyDepartment>(result);
            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };

            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = collection.View;
            currentMode = TableMode.Departments;
        }

        //show all
        private void showAllButton_Click(object sender, RoutedEventArgs e)
        {
            //показываем все колонки
            foreach (var col in dataGrid1.Columns)
                col.Visibility = Visibility.Visible;

            var result = from dep in context.Departments
                         join de in context.DepartmentsEmployees on dep.department_id equals de.department_id
                         join emp in context.Employees on de.employee_id equals emp.employee_id
                         select new GeneralClass
                         {
                             EmployeeID = emp.employee_id,
                             FirstName = emp.first_name,
                             LastName = emp.last_name,
                             Age = (int)emp.age,
                             EmployeeAddress = emp.e_address,
                             Photo = currentPath + emp.photo_path,

                             DepartmentID = dep.department_id,
                             Title = dep.title,
                             HeadID = (int)dep.head_id,
                             DepartmentAdress = dep.d_address,
                             Phone = dep.phone
                         };

            ObservableCollection<GeneralClass> observableCollection = new ObservableCollection<GeneralClass>(result);
            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Title"));

            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = collection.View;

            //включить стандартный режим
            currentMode = TableMode.Default;

            //выключить режим редактирования
            editMode_ToggleB.IsChecked = false;
            editMode_ToggleB_Unchecked(this, null);

            //заполнить combobox'ы
            var lnames = context.Employees.Select(a => a.last_name).Distinct();
            employeeFilter_CB.ItemsSource = lnames.ToList();
            var titles = context.Departments.Select(m => m.title).Distinct();
            departmentFilter_CB.ItemsSource = titles.ToList();
        }

        //employee filter
        private void employeeFilterB_Click(object sender, RoutedEventArgs e)
        {
            //показываем все колонки
            foreach (var col in dataGrid1.Columns)
                col.Visibility = Visibility.Visible;

            var result = (from dep in context.Departments
                         join de in context.DepartmentsEmployees on dep.department_id equals de.department_id
                         join emp in context.Employees on de.employee_id equals emp.employee_id
                         select new GeneralClass
                         {
                             EmployeeID = emp.employee_id,
                             FirstName = emp.first_name,
                             LastName = emp.last_name,
                             Age = (int)emp.age,
                             EmployeeAddress = emp.e_address,
                             Photo = currentPath + emp.photo_path,

                             DepartmentID = dep.department_id,
                             Title = dep.title,
                             HeadID = (int)dep.head_id,
                             DepartmentAdress = dep.d_address,
                             Phone = dep.phone
                         }).Where(n => n.LastName == employeeFilter_CB.Text);

            ObservableCollection<GeneralClass> observableCollection = new ObservableCollection<GeneralClass>(result);
            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };

            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = collection.View;

            currentMode = TableMode.Employees;
            editMode_ToggleB.IsChecked = false;
        }

        //department filter
        private void departmentFilterB_Click(object sender, RoutedEventArgs e)
        {
            //показываем все колонки
            foreach (var col in dataGrid1.Columns)
                col.Visibility = Visibility.Visible;

            var result = (from dep in context.Departments
                          join de in context.DepartmentsEmployees on dep.department_id equals de.department_id
                          join emp in context.Employees on de.employee_id equals emp.employee_id
                          select new GeneralClass
                          {
                              EmployeeID = emp.employee_id,
                              FirstName = emp.first_name,
                              LastName = emp.last_name,
                              Age = (int)emp.age,
                              EmployeeAddress = emp.e_address,
                              Photo = currentPath + emp.photo_path,

                              DepartmentID = dep.department_id,
                              Title = dep.title,
                              HeadID = (int)dep.head_id,
                              DepartmentAdress = dep.d_address,
                              Phone = dep.phone
                          }).Where(n => n.Title == departmentFilter_CB.Text);

            ObservableCollection<GeneralClass> observableCollection = new ObservableCollection<GeneralClass>(result);
            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };

            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = collection.View;

            currentMode = TableMode.Departments;
            editMode_ToggleB.IsChecked = false;
        }

        //при изменении режима toggle button, показываем нужные данные в data grid
        private void editMode_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = editMode_CB.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null)
            {
                var content = comboBoxItem.Content;
                if ((string)content == "Employees")
                    ShowEmployees();
                else if ((string)content == "Departments")
                    ShowDepartments();
            }
        }

        //toggle button on
        private void editMode_ToggleB_Checked(object sender, RoutedEventArgs e)
        {
            editMode_CB.IsEnabled = true;
            insert_B.IsEnabled = true;
            edit_B.IsEnabled = true;
            show_B.IsEnabled = true;
            delete_B.IsEnabled = true;

            if (editMode_CB.Text == "Employees" || editMode_CB.Text == "")
                ShowEmployees();
            else
                ShowDepartments();

            //разрешаем редактировать ячейки
            dataGrid1.IsReadOnly = false;
        }

        //toggle button off
        private void editMode_ToggleB_Unchecked(object sender, RoutedEventArgs e)
        {
            editMode_CB.IsEnabled = false;
            insert_B.IsEnabled = false;
            edit_B.IsEnabled = false;
            show_B.IsEnabled = false;
            delete_B.IsEnabled = false;

            //запрещаем редактировать ячейки
            dataGrid1.IsReadOnly = true;
        }

        //find
        private void find_B_Click(object sender, RoutedEventArgs e)
        {
            //если в textbox'e число, то вычисляем id и заполняем коллекцию
            int id = 0;
            if (Regex.IsMatch(find_TB.Text, @"^\d+$"))
                id = Convert.ToInt32(find_TB.Text);

            var result = (from emp in context.Employees
                          select new MyEmployee
                          {
                              EmployeeID = emp.employee_id,
                              FirstName = emp.first_name,
                              LastName = emp.last_name,
                              Age = (int)emp.age,
                              EmployeeAddress = emp.e_address,
                              Photo = currentPath + emp.photo_path
                          }).Where(n => n.EmployeeID == id);

            ObservableCollection<MyEmployee> observableCollection = new ObservableCollection<MyEmployee>(result);
            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };

            //если коллекция пуста, то предупреждаем пользователя
            if (observableCollection.Count == 0)
                MessageBox.Show("Singer not found!");
            else
            {
                //показываем колонки employee
                dataGrid1.Columns[0].Visibility = Visibility.Visible;
                dataGrid1.Columns[1].Visibility = Visibility.Visible;
                dataGrid1.Columns[2].Visibility = Visibility.Visible;
                dataGrid1.Columns[3].Visibility = Visibility.Visible;
                dataGrid1.Columns[4].Visibility = Visibility.Visible;
                dataGrid1.Columns[5].Visibility = Visibility.Visible;

                //скрываем колонки departments
                dataGrid1.Columns[6].Visibility = Visibility.Hidden;
                dataGrid1.Columns[7].Visibility = Visibility.Hidden;
                dataGrid1.Columns[8].Visibility = Visibility.Hidden;
                dataGrid1.Columns[9].Visibility = Visibility.Hidden;
                dataGrid1.Columns[10].Visibility = Visibility.Hidden;

                editMode_ToggleB.IsChecked = true;

                dataGrid1.ItemsSource = null;
                dataGrid1.ItemsSource = collection.View;
                currentMode = TableMode.Employees;
            }
        }

        //insert
        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == TableMode.Employees)
            {
                InsertEmployee emp = new InsertEmployee();
                emp.Owner = this;
                emp.PerformInsertEmployee += InsertEmployeeEvent;
                emp.ShowDialog();
            }
            else if (currentMode == TableMode.Departments)
            {
                InsertDepartment dep = new InsertDepartment();
                dep.Owner = this;
                dep.PerformInsertDepartment += InsertDepartmentEvent;
                dep.ShowDialog();
            }
            else
                MessageBox.Show("Choose table to insert!");
        }

        //event for insert employee
        private void InsertEmployeeEvent(string _photo, string _fname, string _lname, int _age, string _address)
        {
            Employees e = new Employees
            {
                photo_path = _photo,
                first_name = _fname,
                last_name = _lname,
                age = _age,
                e_address = _address
            };

            context.Employees.Add(e);
            context.SaveChanges();
            ShowEmployees();
        }

        //event for insert department
        private void InsertDepartmentEvent(string _title, int _head_id, string _address, string _phone)
        {
            Departments d = new Departments
            {
                title = _title,
                head_id = _head_id,
                d_address = _address,
                phone = _phone
            };

            context.Departments.Add(d);
            context.SaveChanges();
            ShowDepartments();
        }

        //show
        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == TableMode.Employees)
            {
                MyEmployee selectedRow = dataGrid1.SelectedItem as MyEmployee;
                string selectedPhoto = selectedRow.Photo;
                int selectedId = selectedRow.EmployeeID;
                string selectedFName = selectedRow.FirstName;
                string selectedLName = selectedRow.LastName;
                int selectedAge = selectedRow.Age;
                string selectedAddress = selectedRow.EmployeeAddress;

                string p = selectedPhoto;
                int i = selectedId;
                string fn = "";
                if (selectedFName != null)
                    fn = selectedFName;
                string ln = "";
                if (selectedLName != null)
                    ln = selectedLName;
                int ag = selectedAge;
                string ad = "";
                if (selectedAddress != null)
                    ad = selectedAddress;

                ShowEmployee actor = new ShowEmployee(p, i, fn, ln, ag, ad);
                actor.Owner = this;
                actor.ShowDialog();
            }
            else if (currentMode == TableMode.Departments)
            {
                MyDepartment selectedRow = dataGrid1.SelectedItem as MyDepartment;
                int selectedId = selectedRow.DepartmentID;
                string selectedTitle = selectedRow.Title;
                int selectedHeadId = selectedRow.HeadID;
                string selectedAddress = selectedRow.DepartmentAdress;
                string selectedPhone = selectedRow.Phone;

                int i = selectedId;
                string t = "";
                if (selectedTitle != null) 
                    t = selectedTitle;
                int h = selectedHeadId;
                string a = "";
                if (selectedAddress != null) 
                    a = selectedAddress;
                string p = "";
                if (selectedPhone != null) 
                    p = selectedPhone;

                ShowDepartment dep = new ShowDepartment(i, t, h, a, p);
                dep.Owner = this;
                dep.ShowDialog();
            }
            else
                MessageBox.Show("Choose table to show!");
        }

        //edit
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == TableMode.Employees)
            {
                MyEmployee selectedRow = dataGrid1.SelectedItem as MyEmployee;
                string selectedPhoto = selectedRow.Photo;
                int selectedId = selectedRow.EmployeeID;
                string selectedFName = selectedRow.FirstName;
                string selectedLName = selectedRow.LastName;
                int selectedAge = selectedRow.Age;
                string selectedAddress = selectedRow.EmployeeAddress;

                string p = selectedPhoto;
                int i = selectedId;
                string fn = "";
                if (selectedFName != null)
                    fn = selectedFName;
                string ln = "";
                if (selectedLName != null)
                    ln = selectedLName;
                int a = selectedAge;
                string ad = "";
                if (selectedAddress != null)
                    ad = selectedAddress;

                UpdateEmployee emp = new UpdateEmployee(p, fn, ln, a, ad);
                emp.Owner = this;
                emp.PerformUpdateEmployee += UpdateEmployeeEvent;
                emp.ShowDialog();
            }
            else if (currentMode == TableMode.Departments)
            {
                MyDepartment selectedRow = dataGrid1.SelectedItem as MyDepartment;
                int selectedId = selectedRow.DepartmentID;
                string selectedTitle = selectedRow.Title;
                int selectedHeadID = selectedRow.HeadID;
                string selectedAddress = selectedRow.DepartmentAdress;
                string selectedPhone = selectedRow.Phone;

                int i = selectedId;
                string t = "";
                if (selectedTitle != null)
                    t = selectedTitle;
                int h_id = selectedHeadID;
                string a = "";
                if (selectedAddress != null)
                    a = selectedAddress;
                string p = "";
                if (selectedPhone != null)
                    p = selectedPhone;

                UpdateDepartment movie = new UpdateDepartment(t, h_id, a, p);
                movie.Owner = this;
                movie.PerformUpdateDepartment += UpdateDepartmentEvent;
                movie.ShowDialog();
            }
            else
                MessageBox.Show("Choose table to update!");
        }

        //event for edit employee
        private void UpdateEmployeeEvent(string _photo, string _fname, string _lname, int _age, string _address)
        {
            MyEmployee selectedRow = dataGrid1.SelectedItem as MyEmployee;
            int id = selectedRow.EmployeeID;

            Employees emp = context.Employees.First(n => n.employee_id == id);
            emp.photo_path = _photo;
            emp.first_name = _fname;
            emp.last_name= _lname;
            emp.age = Convert.ToInt32(_age);
            emp.e_address = _address;

            context.SaveChanges();
            ShowEmployees();
        }

        //event for edit department
        private void UpdateDepartmentEvent(string _title, int _hid, string _address, string _phone)
        {
            MyDepartment selectedRow = dataGrid1.SelectedItem as MyDepartment;
            int id = selectedRow.DepartmentID;

            Departments dep = context.Departments.First(m => m.department_id == id);
            dep.title = _title;
            dep.head_id = Convert.ToInt32(_hid);
            dep.d_address = _address;
            dep.phone = _phone;

            context.SaveChanges();
            ShowDepartments();
        }

        //delete
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == TableMode.Employees)
            {
                MyEmployee selectedRow = dataGrid1.SelectedItem as MyEmployee;

                MessageBoxResult dialog = new MessageBoxResult();
                dialog = MessageBox.Show($"Are you sure you want to delete {selectedRow.FirstName} {selectedRow.LastName}?", "Deleting", MessageBoxButton.YesNo);
                if (dialog == MessageBoxResult.Yes)
                {
                    int selectedId = selectedRow.EmployeeID;

                    Employees emp = (from n in context.Employees
                                    where n.employee_id == selectedId
                                    select n).First();

                    context.Employees.Remove(emp);
                    context.SaveChanges();
                    ShowEmployees();
                }
            }
            else if (currentMode == TableMode.Departments)
            {
                MyDepartment selectedRow = dataGrid1.SelectedItem as MyDepartment;

                MessageBoxResult dialog = new MessageBoxResult();
                dialog = MessageBox.Show($"Are you sure you want to delete {selectedRow.Title}?", "Deleting", MessageBoxButton.YesNo);
                if (dialog == MessageBoxResult.Yes)
                {
                    int selectedId = selectedRow.DepartmentID;

                    Departments dep = (from d in context.Departments
                                 where d.department_id == selectedId
                                 select d).First();

                    context.Departments.Remove(dep);
                    context.SaveChanges();
                    ShowDepartments();
                }
            }
            else
                MessageBox.Show("Choose table to delete!");
        }

        //cell edit
        private void dataGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (currentMode == TableMode.Employees)
            {
                MyEmployee selectedRow = dataGrid1.SelectedItem as MyEmployee;
                int selectedId = selectedRow.EmployeeID;

                Employees selectedEmp = (from em in context.Employees
                                         where em.employee_id == selectedId
                                         select em).First();

                selectedEmp.employee_id = selectedRow.EmployeeID;
                selectedEmp.first_name = selectedRow.FirstName;
                selectedEmp.last_name = selectedRow.LastName;
                selectedEmp.age = selectedRow.Age;
                selectedEmp.e_address = selectedRow.EmployeeAddress;
                context.SaveChanges();
            }
            else if (currentMode == TableMode.Departments)
            {
                MyDepartment selectedRow = dataGrid1.SelectedItem as MyDepartment;
                int selectedId = selectedRow.DepartmentID;

                Departments selectedDep = (from dep in context.Departments
                                           where dep.department_id == selectedId
                                           select dep).First();

                selectedDep.department_id = selectedRow.DepartmentID;
                selectedDep.title = selectedRow.Title;
                selectedDep.head_id = selectedRow.HeadID;
                selectedDep.d_address = selectedRow.DepartmentAdress;
                selectedDep.phone = selectedRow.Phone;
                context.SaveChanges();
            }
        }

        //
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
