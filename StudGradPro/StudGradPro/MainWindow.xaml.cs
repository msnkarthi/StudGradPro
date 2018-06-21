/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   Student.cs
 Description    :   Class implements UI design and functionalities
*/
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
        /// <summary>
        /// Holds instances of UniversityDataManager to retrieve and update Student record
        /// </summary>
        public static UniversityDataManager DataManager { private set; get; }

        /// <summary>
        /// Students Record 
        /// </summary>
        public List<Student> Students;

        /// <summary>
        /// Holds Selected Course after selecting course
        /// </summary>
        private Course selectedCourse = null;

        /// <summary>
        /// The student array
        /// </summary>
        public Student[] StudentArray;

        /// <summary>
        /// Quick Sort instance
        /// </summary>
        private Quicksort quickSort = new Quicksort();

        /// <summary>
        /// Heap Sort instance
        /// </summary>
        private Heapsort heapSort = new Heapsort();

        /// <summary>
        /// Binary Search instance
        /// </summary>
        private BinarySearch binarySearch = new BinarySearch();

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataManager = new UniversityDataManager();
            Students = DataManager.Students.ToList();
            StudentArray = DataManager.Students.ToArray();
        }

        /// <summary>
        /// Load Datagrid with Students record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            gridStudents.ItemsSource = Students;
        }

        /// <summary>
        /// Disable Default Sorting functionality of DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Load dropdown for 'Sort By' option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSortBy_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSortBy.ItemsSource = Student.SortableColumns;
        }

        /// <summary>
        /// Invoke appropriate Sort algorithm on selection of 'Sort By' option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            var studByCourses = DataManager.StudentsByCourse(Students, selectedCourse.Id);

            if (selectedColumn == "GPA/TotalGrade/LetterGrade")
            {
                Heap heap = new Heap() { HeapSize = studByCourses.Length, SortedStudent = studByCourses };

                Heapsort hs = new Heapsort();
                hs.Sort(studByCourses.Length, heap);

                gridStudents.ItemsSource = studByCourses;
            }

        }

        /// <summary>
        /// Load dropdown for 'Search By' option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSearchBy_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSearchBy.ItemsSource = Student.SearchableColumns;
        }

        /// <summary>
        /// Load available courses to Course dropdown control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCourse_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCourse.ItemsSource = DataManager.AvailableCourses;
        }

        /// <summary>
        /// Load approriate Students record on selection of Course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (sender as ComboBox).SelectedItem as Course;
            gridStudents.ItemsSource = DataManager.StudentsByCourse(Students, selectedCourse.Id);

            cmbSortBy.ItemsSource = StudentByCourse.SortableColumns;
            cmbSearchBy.ItemsSource = StudentByCourse.SearchableColumns;
        }

        /// <summary>
        /// On Search Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// On double-click in data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Stores Student records to JSON file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourse != null)
            {
                gridStudents.ItemsSource = DataManager.StudentsByCourse(Students, selectedCourse.Id);

                cmbSortBy.ItemsSource = StudentByCourse.SortableColumns;
                cmbSearchBy.ItemsSource = StudentByCourse.SearchableColumns;
            }
            DataManager.StoreStudents();
        }

        /// <summary>
        /// Invoke Filter & update result in datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var studByCourses = gridStudents.ItemsSource as StudentByCourse[];
                Heap heap = new Heap() { HeapSize = studByCourses.Length, SortedStudent = studByCourses };

                Heapsort hs = new Heapsort();
                hs.Sort(studByCourses.Length, heap);

                int from = Int32.Parse(filterMin.Text);
                int to = Int32.Parse(filterMax.Text);

                var filteredStudents = binarySearch.SearchRange(heap.SortedStudent, from, to);

                gridStudents.ItemsSource = filteredStudents;
            }
            catch
            {

            }
        }

        /// <summary>
        /// Selection sort
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
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

        }

        /// <summary>
        /// Clear results in data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourse != null)
            {
                gridStudents.ItemsSource = DataManager.StudentsByCourse(Students, selectedCourse.Id);

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
