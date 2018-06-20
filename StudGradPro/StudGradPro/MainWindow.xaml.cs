using StudGradPro.Algorithms;
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
        public string SearchText;
        /// <summary>
        /// The student array
        /// </summary>
        public Student[] StudentArray;

        private Quicksort quickSort = new Quicksort();
        private Heapsort heapSort = new Heapsort();
        private BinarySearch binarySearch = new BinarySearch();

        public MainWindow()
        {
            InitializeComponent();
            dataManager = new UniversityDataManager();
            Students = dataManager.Students.ToList();
            StudentArray = dataManager.Students.ToArray();
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
			Student[] ResultedStudent;
            if (selectedColumn == "FirstName")
            {
                ResultedStudent = quickSort.quickSortByFirstName(StudentArray, 0, StudentArray.Length - 1);
            }
            else if (selectedColumn == "LastName")
            {
                ResultedStudent = quickSort.quickSortByLastName(StudentArray, 0, StudentArray.Length - 1);

            }
            else if(selectedColumn =="Status")
            {
                ResultedStudent = quickSort.quickSortByStatus(StudentArray, 0, StudentArray.Length - 1);
            }
            else 
            {
                ResultedStudent = quickSort.quickSortById(StudentArray, 0, StudentArray.Length - 1);
            }
            gridStudents.ItemsSource = null;
            gridStudents.ItemsSource = ResultedStudent;
			
            if(selectedCourse == null)
            {
                return;
            }
            var studByCourses = dataManager.StudentsByCourse(Students, selectedCourse.Id);

            if (selectedColumn == "GPA/TotalGrade/LetterGrade")
            {
                Heap heap = new Heap() { HeapSize = studByCourses.Length, SortedStudent = studByCourses };

                Heapsort hs = new Heapsort();
                hs.Sort(studByCourses.Length, heap);

                gridStudents.ItemsSource = studByCourses;
            }

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
            var selected = cmbSearchBy.SelectedValue as string;

            Student[] sorted = selectionSort(StudentArray);
            Student search = null;

            if (selected == "FirstName")
            {
                search = binarySearch.Search(sorted, searchText.Text);
            }

            if(search == null)
            {
                MessageBox.Show("Search String Not Found", "Search", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            gridStudents.ItemsSource = new List<Student>() { search };

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

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        

        public Student[] selectionSort(Student[] students)
        {
            int n = students.Length - 1;
            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (string.Compare(students[j].FirstName, students[min].FirstName) < 0)
                    {
                        min = j;
                    }

                }
                Student temp = students[i];
                students[i] = students[min];
                students[min] = temp;

            }

            return students;

        }//end of selection sort

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourse != null)
            {
                gridStudents.ItemsSource = dataManager.StudentsByCourse(Students, selectedCourse.Id);

                cmbSortBy.ItemsSource = StudentByCourse.SortableColumns;
                cmbSearchBy.ItemsSource = StudentByCourse.SearchableColumns;
            }
            else
            {
                gridStudents.ItemsSource = Students;
            }
        }
    }
}
