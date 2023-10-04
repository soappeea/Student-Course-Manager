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
            //store in string
            for (int i = 0; i < courses.Count; i++)
            {
                sb.AppendLine(courses[i].GetFullDetails());
            }

            return sb.ToString();
        }

        public void AddCourse(Course course)
        {
            //need to validate course before adding
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

            //need to validate courseIndex before removing
            //if (courseIndex >= 0 && StudentManager.CourseCodes.Length >= courseIndex)
            //{
            //    //find course and remove if exists
            //    var courseCodeToRemove = this.courses.FirstOrDefault(x => x.GetCode() == StudentManager.CourseCodes[courseIndex]);
            //    if (courseCodeToRemove != null)
            //    {
            //        this.courses.Remove(courseCodeToRemove);
            //        result = true;
            //    }
            //}
            //return result;
        }

        public bool HasCourse(string courseName)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Equals(courseName))
                {
                    return true;
                }
            }

            return false;

            //bool result = false;
            //var courseCodeToFind = this.courses.FirstOrDefault(x => x.GetName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
            //if (courseCodeToFind != null)
            //{
            //    result = true;
            //}
            //return result;
        }
    }
}