using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinSMP1
{
    class Student
    {
        private string lName;
        private string fName;
        private string studentID;
        private List<Course> courses = new List<Course>();

        public Student(string lName, string fName, string studentID)
        {
            this.lName = lName;
            this.fName = fName;
            this.studentID = studentID;
        }

        public string GetLastName()
        {
            return lName;
        }

        public string GetFirstName()
        {
            return fName;
        }

        public string GetStudentID()
        {
            return studentID;
        }

        public int GetCourseCount()
        {
            return courses.Count;
        }

        public string GetDetails()
        {
            return Convert.ToString(lName + ", " + fName + " (" + studentID + ")");
        }

        public string GetCourseDisplay()
        {
            for (int i = 0; i < courses.Count; i++)
            {
                return Convert.ToString((i + 1) + ") " + courses[i].GetFullDetails());
            }

            //concerning
            return null;
        }

        public void AddCourse(Course course)
        {
            //MAKE MAX COURSES VARIABLE, only need default constructor; refer to encapsulationday1c
            courses.Add(course);
        }

        public bool RemoveCourse(int courseIndex)
        {
            if (courseIndex >= 0 && courseIndex < courses.Count)
            {
                courses.RemoveAt(courseIndex);
                return true;
            }

            return false;
        }
    }
}
