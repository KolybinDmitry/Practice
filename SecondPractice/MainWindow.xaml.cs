using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SecondPractice.TestDbDataSetTableAdapters;

namespace SecondPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        employeesTableAdapter Employees = new employeesTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            EmployeesDataGrid.ItemsSource = Employees.GetData();
        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            Employees.InsertQuery(Convert.ToInt32(NameTbx.Text), Convert.ToString(NameTbx1.Text), Convert.ToString(NameTbx2.Text), Convert.ToInt32(NameTbx3.Text));

            EmployeesDataGrid.ItemsSource = Employees.GetData();
        }

        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
           EmpDep  window1 = new EmpDep();
            window1.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object id = (EmployeesDataGrid.SelectedItem as DataRowView).Row[0];
            Employees.DeleteQuery(Convert.ToInt32(id));
            EmployeesDataGrid.ItemsSource = Employees.GetData();
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (EmployeesDataGrid.SelectedItem as DataRowView).Row[0];
            Employees.UpdateQuery(Convert.ToInt32(NameTbx.Text), NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(NameTbx3.Text),Convert.ToInt32(id));
            EmployeesDataGrid.ItemsSource = Employees.GetData();
        }
        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem as DataRowView != null)
            {
                NameTbx.Text = Convert.ToString((EmployeesDataGrid.SelectedItem as DataRowView).Row[0]);
                NameTbx1.Text = Convert.ToString((EmployeesDataGrid.SelectedItem as DataRowView).Row[1]);
                NameTbx2.Text = Convert.ToString((EmployeesDataGrid.SelectedItem as DataRowView).Row[2]);
                NameTbx3.Text = Convert.ToString((EmployeesDataGrid.SelectedItem as DataRowView).Row[3]);
            }
        }
    }
}
