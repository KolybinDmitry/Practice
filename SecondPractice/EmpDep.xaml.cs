using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using SecondPractice.TestDbDataSetTableAdapters;

namespace SecondPractice
{
    /// <summary>
    /// Логика взаимодействия для EmpDep.xaml
    /// </summary>
    public partial class EmpDep : Window
    {
        emp_deptTableAdapter empdep = new emp_deptTableAdapter();
        employeesTableAdapter Employees = new employeesTableAdapter();
        departmentsTableAdapter departments = new departmentsTableAdapter();


        public EmpDep()
        {
            InitializeComponent();
            EmpDepDataGrid.ItemsSource = empdep.GetData();
            EmployeeCbx.ItemsSource=Employees.GetData();
            EmployeeCbx.DisplayMemberPath = "emp_name";
            EmployeeCbx.SelectedValuePath = "emp_id";
            DepartmentCbx.ItemsSource = departments.GetData();
            DepartmentCbx.DisplayMemberPath = "dept_name";
            DepartmentCbx.SelectedValuePath = "dept_id";

        }



        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object id = (EmpDepDataGrid.SelectedItem as DataRowView).Row[0];
            empdep.DeleteQuery(Convert.ToInt32(id));
            EmpDepDataGrid.ItemsSource = empdep.GetData();
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (EmpDepDataGrid.SelectedItem as DataRowView).Row[0];
            object id1 = (EmpDepDataGrid.SelectedItem as DataRowView).Row[1];
            object id2 = (EmployeeCbx.SelectedItem as DataRowView).Row[0];
            object id3 = (DepartmentCbx.SelectedItem as DataRowView).Row[0];
            empdep.UpdateQuery(Convert.ToInt32(id2), Convert.ToInt32(id3), Convert.ToInt32(id), Convert.ToInt32(id1));
            EmpDepDataGrid.ItemsSource = empdep.GetData();
        }
        private void EmpDepDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmpDepDataGrid.SelectedItem as DataRowView != null)
            {
                EmployeeCbx.SelectedValue = Convert.ToInt32((EmpDepDataGrid.SelectedItem as DataRowView).Row[0]);
                DepartmentCbx.SelectedValue = Convert.ToInt32((EmpDepDataGrid.SelectedItem as DataRowView).Row[1]);
            }
           }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (EmployeeCbx.SelectedItem as DataRowView).Row[0];
            object id1 = (DepartmentCbx.SelectedItem as DataRowView).Row[0];
            empdep.InsertQuery(Convert.ToInt32(id), Convert.ToInt32(id1));
           EmpDepDataGrid.ItemsSource = empdep.GetData();
        }
    }
}
