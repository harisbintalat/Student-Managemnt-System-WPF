using System;
using System.Collections.Generic;
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

namespace LabAssignment4
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>    
    public partial class Students : Window
    {
        StudentManagementEntities db = new StudentManagementEntities();
        public Students()
        {
            InitializeComponent();
            var stud = from d in db.Students
                      select d;

            this.listitems.ItemsSource = stud.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new Student_Management();
            Page2.Show();
            this.Close();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Student obj = new Student();
            {

                obj.Name = txtboxstd.Text;
                obj.RegNo = txtboxRegno.Text;

                MessageBox.Show("Record Added",
                 "Add Record",
                 MessageBoxButton.OK,
                 MessageBoxImage.Information,
                 MessageBoxResult.OK);
            };
            db.Students.Add(obj);
            db.SaveChanges();
            this.listitems.ItemsSource = db.Students.ToList();

        }
    }
}
