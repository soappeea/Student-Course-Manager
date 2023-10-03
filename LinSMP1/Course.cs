using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinSMP1
{
    class Course
    {
        private string courseName;
        private string courseCode;
        private int studentMark;

        public Course(int courseIndex, int mark)
        {
            courseName = Program.courseNames[courseIndex];
            courseCode = Program.courseCodes[courseIndex];
            studentMark = mark;
        }

        public string GetName()
        {
            return courseName;
        }

        public string GetCode()
        {
            return courseCode;
        }

        public int GetMark()
        {
            return studentMark;
        }

        public string GetDescription()
        {
            return String.Format(courseName + " (" + courseCode + ")");
        }

        public string GetFullDetails()
        {
            return String.Format(courseName + " (" + courseCode + "): " + studentMark + "%");
        }
    }
}
