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
            List<Student> ResultedStudent = new List<Student>();
            if (selectedColumn == "FirstName")
            {
                ResultedStudent = quickSortByFirstName(StudentArray, 0, StudentArray.Length - 1);
            }
            else if (selectedColumn == "LastName")
            {
                ResultedStudent = quickSortByLastName(StudentArray, 0, StudentArray.Length - 1);

            }
            else if(selectedColumn =="Status")
            {
                ResultedStudent = quickSortByStatus(StudentArray, 0, StudentArray.Length - 1);
            }
            else 
            {
                ResultedStudent = quickSortById(StudentArray, 0, StudentArray.Length - 1);
            }

            gridStudents.ItemsSource = ResultedStudent;
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
            Student[] sorted = selectionSort(StudentArray);
            Student search = binarySearch(sorted, "Suzanne");
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

        private static List<Student> quickSortByFirstName(Student[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].FirstName;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].FirstName.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].FirstName.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                swap(students, start, j);
                // sort left partition
                quickSortByFirstName(students, start, j - 1);
                // sort right partition
                quickSortByFirstName(students, j + 1, end);
            }
            return students.ToList();
        }

        private static List<Student> quickSortById(Student[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].Id.ToString();
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].Id.ToString().CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].Id.ToString().CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                swap(students, start, j);
                // sort left partition
                quickSortById(students, start, j - 1);
                // sort right partition
                quickSortById(students, j + 1, end);
            }
            return students.ToList();
        }

        private static List<Student> quickSortByStatus(Student[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].Status;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].Status.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].Status.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                swap(students, start, j);
                // sort left partition
                quickSortByStatus(students, start, j - 1);
                // sort right partition
                quickSortByStatus(students, j + 1, end);
            }
            return students.ToList();
        }

        private static List<Student> quickSortByLastName(Student[] students, int start, int end)
        {
            // index for the "left-to-right scan"
            int i = start;
            // index for the "right-to-left scan"
            int j = end;

            // only examine arrays of 2 or more elements.
            if (j - i >= 1)
            {
                // The pivot point of the sort method is arbitrarily set to the first element int the array.
                String pivot = students[i].LastName;
                // only scan between the two indexes, until they meet.
                while (j > i)
                {
                    // from the left, if the current element is lexicographically less than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the right or an element that is lexicographically greater than the pivot String.
                    while (students[i].LastName.CompareTo(pivot) <= 0 && i < end && j > i)
                    {
                        i++;
                    }
                    // from the right, if the current element is lexicographically greater than the (original)
                    // first element in the String array, move on. Stop advancing the counter when we reach
                    // the left or an element that is lexicographically less than the pivot String.
                    while (students[j].LastName.CompareTo(pivot) >= 0 && j > start && j >= i)
                    {
                        j--;
                    }
                    // check the two elements in the center, the last comparison before the scans cross.
                    if (j > i)
                        swap(students, i, j);
                }
                // At this point, the two scans have crossed each other in the center of the array and stop.
                // The left partition and right partition contain the right groups of numbers but are not
                // sorted themselves. The following recursive code sorts the left and right partitions.

                // Swap the pivot point with the last element of the left partition.
                swap(students, start, j);
                // sort left partition
                quickSortByLastName(students, start, j - 1);
                // sort right partition
                quickSortByLastName(students, j + 1, end);
            }

            return students.ToList();
        }

        private static void swap(Student[] students, int i, int j)
        {
            var temp = students[i];
            students[i] = students[j];
            students[j] = temp;
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
        public Student binarySearch(Student[] students, string item)
        {
            int n = students.Length - 1;
            int lowerbound = 0;
            int upperbound = n - 1;
            int mid = (lowerbound + upperbound) / 2;
            int ctr = 1;
            while ((string.Compare(item, students[mid].FirstName) != 0) && (lowerbound <= upperbound))
            {
                if (string.Compare(item, students[mid].FirstName) > 0)
                    lowerbound = mid + 1;
                else
                    upperbound = mid - 1;
                mid = (lowerbound + upperbound) / 2;
                ctr++;
            }
            if (string.Compare(item, students[mid].FirstName) == 0)
                return students[mid];
            else
                return null;
        }//end of binary search method


    }
}
