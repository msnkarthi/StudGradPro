using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Student grading system is fine. Some comments:

1. Make sure that your system will load an initial list of students from a file and provide that file to load with your project. It should have at least 100 students that can be loaded.
2. Your student records need multiple fields so in addition to grade and id there should be some other fields such as first and last name.
2. It is not very efficient to have to move data around into too many different data structures just so you can run algorithms against it. If you use a linked list for your storage, you can make it ordered list as you insert and then you can use binary search on it. 
3. For comparison you cannot compare linear search with binary search. 
Linear search is not much of an algorithm and you need to compare algorithms we discussed in class. 
Instead, you should add a functionality to request a list of students based on some criteria, for example using grade as key and some filtering value (e.g. all students with 80+ or < 80 or 70-80, etc.). 
Then you would need a search functionality to return a list of records that match that criteria. 
This sublist could be stored in another data structure and you should allow functionality for that list to be sorted using merge sort and another sort such as quicksort or heapsort for comparison. 
You need to allow multiple sorting options for example by id or by last name where user decides how they want the data sorted to be displayed.
*/
namespace StudGradPro.Data
{
    public class Student
    {
        public int Id {  set; get; }
        public string FirstName {  set; get; }
        public string LastName {  set; get; }
        public string Address {  set; get; }
        public string Gender { set; get; }
        public string EMail { set; get; }
        public string Status { set; get; }
        public Course[] CoursesEnrolled;

        public static List<string> SortableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "Status"
        };

        public static List<string> SearchableColumns = new List<string>()
        {
            "Id", "FirstName", "LastName", "Status"
        };

        public Student()
        {
            GradeItem item1 = new GradeItem { Id = 501, Item = "Assignment1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item2 = new GradeItem { Id = 502, Item = "Assignment2", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item3 = new GradeItem { Id = 503, Item = "Assignment3", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item4 = new GradeItem { Id = 504, Item = "Quiz", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };
            GradeItem item5 = new GradeItem { Id = 505, Item = "Project", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 101 };

            GradeItem item6 = new GradeItem { Id = 506, Item = "Forum1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item7 = new GradeItem { Id = 507, Item = "Quiz1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item8 = new GradeItem { Id = 508, Item = "Assignment1", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item9 = new GradeItem { Id = 509, Item = "Quiz2", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };
            GradeItem item10 = new GradeItem { Id = 510, Item = "FinalAssignment", WeightPerc = 20.0, Feedback = "NA", Grade = 0, CourseId = 102 };

            GradeItem[] Course1GradeItems = new GradeItem[5] { item1, item2, item3, item4, item5 };
            GradeItem[] Course2GradeItems = new GradeItem[5] { item6, item7, item8, item9, item10 };

            Course course1 = new Course { Id = 101, Name = "Software Engineering", Plan = Course1GradeItems, ProfessorFullName = "John Smith" };
            Course course2 = new Course { Id = 102, Name = "Big Data Architectures", Plan = Course2GradeItems, ProfessorFullName = "Jesse Michael" };

            this.Id = 10001;
            this.LastName = "";
            this.FirstName = "";
            this.Address = "";
            this.Gender = "Male";
            this.EMail = "";
            this.Status = "";

            CoursesEnrolled = new Course[2]
            {
                course1, course2
            };
         }
    }
}
