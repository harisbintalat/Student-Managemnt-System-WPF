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
    /// Interaction logic for Student_Management.xaml
    /// </summary>
    public partial class Student_Management : Window
    {
        StudentManagementEntities db = new StudentManagementEntities();
        public Student_Management()
        {
            InitializeComponent();
           

            var stud =  from d in db.StudentCourses
                       select new
                       {
                           student = d.Student.Name,
                           Registration = d.Student.RegNo,
                           course = d.Course.Name
                       };
            this.reglistbox.ItemsSource = stud.ToList();
        }

        private void btnAnswer6_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new Courses();
            Page2.Show();
            this.Close();
        }

        private void btnAnswer7_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new Students();
            Page2.Show();
            this.Close();

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var Page2 = new NotAssignedCourses();
            Page2.Show();
            this.Close();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var Page2 = new NotAssignedStudents();
            Page2.Show();
            this.Close();
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            string name = this.txtboxsearch.Text;
            if(txtboxsearch.Text!=null)
            {
                if (radiocourse.IsChecked==true)
                {
                    var crs = from d in db.Courses
                                where d.Name == name
                                select new
                                {
                                    bindveriable1 = d.Code,
                                    bindveriable2 = d.Name
                                };
                    this.searchlist.ItemsSource = crs.ToList();
                }
                else if (radiostudent.IsChecked==true)
                {
                    var std = from d in db.Students
                              where d.Name == name
                              select new
                              {
                                  bindveriable1 = d.Name,
                                  bindveriable2 = d.RegNo
                              };
                    this.searchlist.ItemsSource = std.ToList();
                }
          
            }
            else if(txtboxsearch.Text =="")
            {
                MessageBox.Show("Please input data",
                "Error",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error,
                 MessageBoxResult.Cancel);
            }
        }
    }
}
