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
    /// Interaction logic for NotAssignedStudents.xaml
    /// </summary>
    public partial class NotAssignedStudents : Window
    {
        public NotAssignedStudents()
        {
            InitializeComponent();
            StudentManagementEntities db = new StudentManagementEntities();

            var result = from d in db.Students
                         from f in d.StudentCourses.DefaultIfEmpty()
                         where d.Id != f.StudentID
                         select new
                         {
                             AName = d.Name,
                             ARegno = d.RegNo
                         };
            this.datalist.ItemsSource = result.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new Student_Management();
            Page2.Show();
            this.Close();
        }
    }
}
