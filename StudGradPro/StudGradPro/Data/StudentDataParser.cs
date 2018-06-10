using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudGradPro.Data
{
    class StudentDataParser
    {
        public Student[] GetStudents()
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"data\students.json"))
            {
                string json = r.ReadToEnd();
                Student[] students = JsonConvert.DeserializeObject<List<Student>>(json).ToArray();
                return students;
            }
        }
    }
}
