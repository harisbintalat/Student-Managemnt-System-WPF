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
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : Window
    {
        StudentManagementEntities db = new StudentManagementEntities();
        public Courses()
        {
            InitializeComponent();
            var crs = from d in db.Courses
                      select d;
                       
            this.listitems.ItemsSource = crs.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new Student_Management();
            Page2.Show();
            this.Close();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Course obj = new Course();
            {

                obj.Name = txtboxstd.Text;
                obj.Code = txtboxcourseno.Text;

                MessageBox.Show("Record Added",
                 "Add Record",
                 MessageBoxButton.OK,
                 MessageBoxImage.Information,
                 MessageBoxResult.OK);
            };
            db.Courses.Add(obj);
            db.SaveChanges();
            this.listitems.ItemsSource = db.Courses.ToList();
        }
    }
}
