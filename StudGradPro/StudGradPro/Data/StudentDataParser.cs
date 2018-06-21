/*
 Authors Name    : Karthikeyan Nagarajan & Bharath Kumar Pidapa
 
 File Name      :   StudentDataParser.cs
 Description    :   Class Retrieves and Stores Student record in JSON file
*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    /// <summary>
    /// Class Serializes/Deserializes Student record
    /// </summary>
    class StudentDataParser
    {
        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns></returns>
        public Student[] GetStudents()
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"data\students.json"))
            {
                string json = r.ReadToEnd();
                Student[] students = JsonConvert.DeserializeObject<List<Student>>(json).ToArray();
                return students;
            }
        }

        /// <summary>
        /// Updates student from external JSON file
        /// </summary>
        /// <param name="students">The students.</param>
        public void UpdateStudents(Student[] students)
        {
            using (StreamWriter w = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"data\students.json"))
            {
                w.Write(JsonConvert.SerializeObject(students));
            }
        }
    }
}
