using StudGradPro.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudGradPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static UniversityDataManager dataManager { private set; get; }
        public List<Student> Students;
        Course selectedCourse = null;

        public MainWindow()
        {
            InitializeComponent();
            dataManager = new UniversityDataManager();
            Students = dataManager.Students.ToList();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            gridStudents.ItemsSource = Students;
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbSortBy_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSortBy.ItemsSource = Student.SortableColumns;
        }

        private void cmbSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColumn = (sender as ComboBox).SelectedItem as string;
        }

        private void cmbSearchBy_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSearchBy.ItemsSource = Student.SearchableColumns;
        }

        private void cmbSearchBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColumn = (sender as ComboBox).SelectedItem as string;
        }

        private void cmbCourse_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCourse.ItemsSource = dataManager.AvailableCourses;
        }

        private void cmbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (sender as ComboBox).SelectedItem as Course;
            gridStudents.ItemsSource = dataManager.StudentsByCourse(Students, selectedCourse.Id);

            cmbSortBy.ItemsSource = StudentByCourse.SortableColumns;
            cmbSearchBy.ItemsSource = StudentByCourse.SearchableColumns;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gridStudents_Selected(object sender, RoutedEventArgs e)
        {
            //Student[] selectedStudent = (sender as DataGrid).SelectedItem as Student[];

            //controlStudent.DataContext = selectedStudent[0];
        }

        private void gridStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedStudent = gridStudents.SelectedItem as Student;
            controlStudent.DataContext = selectedStudent;

            if (selectedStudent == null)
            {
                var selectedStudentByCourse = gridStudents.SelectedItem as StudentByCourse;
                controlStudent.DataContext = selectedStudentByCourse;
            }
        }

        private void btnUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourse != null)
            {
                gridStudents.ItemsSource = dataManager.StudentsByCourse(Students, selectedCourse.Id);

                cmbSortBy.ItemsSource = StudentByCourse.SortableColumns;
                cmbSearchBy.ItemsSource = StudentByCourse.SearchableColumns;
            }
            dataManager.StoreStudents();
        }
    }
}
