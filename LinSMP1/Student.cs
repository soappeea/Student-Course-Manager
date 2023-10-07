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
        private int maxCourses;
        private List<Course> courses = new List<Course>();

        public Student(string lName, string fName, string studentID)
        {
            this.lName = lName;
            this.fName = fName;
            this.studentID = studentID;
            maxCourses = 6;
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
            return String.Format(lName + ", " + fName + " (" + studentID + ")");
        }

        public string GetCourseDisplay()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < courses.Count; i++)
            {
                sb.AppendLine((i + 1) + ") " + courses[i].GetFullDetails());
            }

            return sb.ToString();
        }

        public void AddCourse(Course course)
        {
            if (courses.Count < maxCourses)
            {
                courses.Add(course);
            }
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

        public bool HasCourse(string courseName)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].GetName().Equals(courseName))
                {
                    return true;
                }
            }

            return false;
        }

        public bool RestrictCourses()
        {
            if (courses.Count < maxCourses)
            {
                return false;
            }

            return true;
        }
    }
}