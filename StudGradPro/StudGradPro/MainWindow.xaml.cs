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
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Holds instances of UniversityDataManager to retrieve and update Student record
        /// </summary>
        /// <value>
        /// The data manager.
        /// </value>
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
        /// Interpolation Search instance
        /// </summary>
        private InterpolationSearch interpolationSearch = new InterpolationSearch();
 
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
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            gridStudents.ItemsSource = Students;
        }

        /// <summary>
        /// Disable Default Sorting functionality of DataGrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridSortingEventArgs"/> instance containing the event data.</param>
        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Load dropdown for 'Sort By' option
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cmbSortBy_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSortBy.ItemsSource = Student.SortableColumns;
        }

        /// <summary>
        /// Invoke appropriate Sort algorithm on selection of 'Sort By' option
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cmbSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColumn = (sender as ComboBox).SelectedItem as string;

            IStudent[] ResultedStudent;

            if (selectedCourse == null)
            {
                if (selectedColumn == "FirstName")
                {
                    ResultedStudent = quickSort.quickSortByFirstName(StudentArray, 0, StudentArray.Length - 1);
                }
                else if (selectedColumn == "LastName")
                {
                    ResultedStudent = quickSort.quickSortByLastName(StudentArray, 0, StudentArray.Length - 1);
                }
                else if (selectedColumn == "Status")
                {
                    ResultedStudent = quickSort.quickSortByStatus(StudentArray, 0, StudentArray.Length - 1);
                }
                else
                {
                    ResultedStudent = quickSort.quickSortById(StudentArray, 0, StudentArray.Length - 1);
                }
                gridStudents.ItemsSource = null;

                gridStudents.ItemsSource = ResultedStudent as Student[];
                return;
            }
            else
            {
                var studByCourses = DataManager.StudentsByCourse(Students, selectedCourse.Id);

                if (selectedColumn == "GPA/TotalGrade/LetterGrade")
                {
                    Heap heap = new Heap() { HeapSize = studByCourses.Length, SortedStudent = studByCourses };
                    heapSort.Sort(studByCourses.Length, heap);

                    gridStudents.ItemsSource = studByCourses;
                }
                else
                {
                    if (selectedColumn == "FirstName")
                    {
                        ResultedStudent = quickSort.quickSortByFirstName(studByCourses, 0, StudentArray.Length - 1);
                    }
                    else if (selectedColumn == "LastName")
                    {
                        ResultedStudent = quickSort.quickSortByLastName(studByCourses, 0, StudentArray.Length - 1);
                    }
                    else if (selectedColumn == "Status")
                    {
                        ResultedStudent = quickSort.quickSortByStatus(studByCourses, 0, StudentArray.Length - 1);
                    }
                    else
                    {
                        ResultedStudent = quickSort.quickSortById(studByCourses, 0, StudentArray.Length - 1);
                    }

                    gridStudents.ItemsSource = ResultedStudent as StudentByCourse[];
                }
            }
        }

        /// <summary>
        /// Load dropdown for 'Search By' option
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cmbSearchBy_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSearchBy.ItemsSource = Student.SearchableColumns;
        }

        /// <summary>
        /// Load available courses to Course dropdown control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cmbCourse_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCourse.ItemsSource = DataManager.AvailableCourses;
        }

        /// <summary>
        /// Load approriate Students record on selection of Course
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var selectedColumn = cmbSearchBy.SelectedValue as string;

            IStudent[] sortedStudent;
            IStudent[] searchResultStudents = null;

            if (selectedCourse == null)
            {
                if (selectedColumn == "FirstName")
                {
                    sortedStudent = quickSort.quickSortByFirstName(StudentArray, 0, StudentArray.Length - 1);
                    searchResultStudents = binarySearch.SearchByFirstName(sortedStudent, searchText.Text);
                }
                else if (selectedColumn == "LastName")
                {
                    sortedStudent = quickSort.quickSortByLastName(StudentArray, 0, StudentArray.Length - 1);
                    searchResultStudents = binarySearch.SearchByLastName(sortedStudent, searchText.Text);
                }
                else if (selectedColumn == "Status")
                {
                    sortedStudent = quickSort.quickSortByStatus(StudentArray, 0, StudentArray.Length - 1);
                    searchResultStudents = binarySearch.SearchByStatus(sortedStudent, searchText.Text);
                }
                else if (selectedColumn == "Id")
                {
                    sortedStudent = quickSort.quickSortById(StudentArray, 0, StudentArray.Length - 1);
                    searchResultStudents = interpolationSearch.SearchById(sortedStudent, Int32.Parse(searchText.Text));
                }
                if (searchResultStudents == null)
                {
                    MessageBox.Show("Search string not found", "Search", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                gridStudents.ItemsSource = null;
                gridStudents.ItemsSource = searchResultStudents as Student[];
            }
            else
            {
                var studByCourses = DataManager.StudentsByCourse(Students, selectedCourse.Id);

                if (selectedColumn == "GPA/TotalGrade/LetterGrade")
                {
                    Heap heap = new Heap() { HeapSize = studByCourses.Length, SortedStudent = studByCourses };
                    heapSort.Sort(studByCourses.Length, heap);

                    //searchResultStudents = binarySearch.SearchBy(studByCourses, searchText.Text);

                    //gridStudents.ItemsSource = studByCourses;
                }
                else
                {
                    if (selectedColumn == "FirstName")
                    {
                        sortedStudent = quickSort.quickSortByFirstName(studByCourses, 0, StudentArray.Length - 1);
                        searchResultStudents = binarySearch.SearchByFirstName(sortedStudent, searchText.Text);
                    }
                    else if (selectedColumn == "LastName")
                    {
                        sortedStudent = quickSort.quickSortByLastName(studByCourses, 0, StudentArray.Length - 1);
                        searchResultStudents = binarySearch.SearchByLastName(sortedStudent, searchText.Text);
                    }
                    else if (selectedColumn == "Status")
                    {
                        sortedStudent = quickSort.quickSortByStatus(studByCourses, 0, StudentArray.Length - 1);
                        searchResultStudents = binarySearch.SearchByStatus(sortedStudent, searchText.Text);
                    }
                    else if(selectedColumn == "Id")
                    {
                        sortedStudent = quickSort.quickSortById(studByCourses, 0, StudentArray.Length - 1);
                        searchResultStudents = interpolationSearch.SearchById(sortedStudent, Int32.Parse(searchText.Text));
                    }
                }

                if (searchResultStudents == null)
                {
                    MessageBox.Show("Search string not found", "Search", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                gridStudents.ItemsSource = null;
                gridStudents.ItemsSource = searchResultStudents as StudentByCourse[];
            }
        }

        /// <summary>
        /// On double-click in data grid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
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
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
        /// Handles the Click event of the btnFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(selectedCourse == null)
                {
                    MessageBox.Show("Please select course to filter by grade", "Filter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                if(string.IsNullOrWhiteSpace(filterMin.Text))
                {
                    MessageBox.Show("Please enter correct Range", "Filter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (string.IsNullOrWhiteSpace(filterMax.Text))
                {
                    MessageBox.Show("Please enter correct Range", "Filter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                int from = Int32.Parse(filterMin.Text);
                int to = Int32.Parse(filterMax.Text);

                var studByCourses = DataManager.StudentsByCourse(Students, selectedCourse.Id);
                Heap heap = new Heap() { HeapSize = studByCourses.Length, SortedStudent = studByCourses as StudentByCourse[] };

                Heapsort hs = new Heapsort();
                hs.Sort(studByCourses.Length, heap);

                var filteredStudents = binarySearch.SearchRange(heap.SortedStudent, from, to);

                if(filteredStudents == null)
                {
                    return;
                }

                if(filteredStudents.Count == 0)
                {
                    MessageBox.Show("No student found", "Filter", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                gridStudents.ItemsSource = filteredStudents;
            }
            catch
            {
                MessageBox.Show("Error", "Filter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Clear results in data grid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
