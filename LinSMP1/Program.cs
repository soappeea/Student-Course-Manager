using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinSMP1
{
    class Program
    {
        public static string[] courseNames = new string[] { "Science", "Math", "Phys. Ed", "English", "History", "Geography" };
        public static string[] courseCodes = new string[] { "SNC", "MTH", "PPL", "ENG", "CHC", "CGC" };
        private static List<Student> students = new List<Student>();
        private static int totalAdded = 0;

        const int NO_OPTION = 0;
        const int ADD = 1;
        const int REMOVE = 2;
        const int DISPLAY = 3;
        const int EXIT = 4;

        private static void Main(string[] args)
        {
            int option = NO_OPTION;

            while (option != EXIT)
            {
                option = DisplayMenu();
                Console.Clear();

                switch (option)
                {
                    case ADD:
                        break;
                    case REMOVE:
                        break;
                    case DISPLAY:
                        break;
                }
            }
        }

        private static int DisplayMenu()
        {
            int option = NO_OPTION;

            while (option == NO_OPTION)
            {
                Console.Clear();
                Console.WriteLine("Student Course Manager\n======================\nChoose an option:\n");
                Console.WriteLine("1. Add a Student");
                Console.WriteLine("2. Remove a Student");
                Console.WriteLine("3. Display Student Data");
                Console.WriteLine("4. Exit");

                Int32.TryParse(Console.ReadLine(), out option);

                if (option == NO_OPTION)
                {
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                }
            }

            return option;
        }

        //private static int DisplayStudentMenu(int studentIndex)
        //{

        //}

        //Get the student index
        private static int GetStudentIndex()
        {
            int index = NO_OPTION;

            //ask for a student index if there is at least one 
            //if (rectMgr.GetNumRects() > 0)
            //{
            //    //Continue asking for an index until a valid option is entered
            //    while (index <= NO_OPTION || index > rectMgr.GetNumRects())
            //    {
            //        //Display all rectangles with an numbered index from 1 on
            //        Console.Clear();
            //        Console.WriteLine("Choose a Rectangle by its index on the left:\n");
            //        rectMgr.DisplayAllRectangleDimensions();

            //        //Retrieve the option and attempt to convert it to an int
            //        Int32.TryParse(Console.ReadLine(), out index);

            //        //Give failure feedback for impossible entries
            //        if (index <= NO_OPTION || index > rectMgr.GetNumRects())
            //        {
            //            Console.WriteLine("Sorry, that is an invalid index.\nPress <Enter> to continue.");
            //            Console.ReadLine();
            //        }
            //    }
            //}

            //Reduce the index by 1 to account for the fact the numbering on screen starts at 1
            return index - 1;
        }

        //static Student CreateStudent(string fName, string lName)
        //{
        //    Student student = new Student(lName, fName, ParseStudentID(totalAdded));
        //    totalAdded++;
        //    return student;
        //}

        //static int ChooseStudent(int number)
        //{
        //    //is number going to pass in?
        //    //validate number to totalAdded
        //    if (number > totalAdded) return -1;

        //    string studentID = ParseStudentID(number);
        //    return students.FindIndex(x => x.GetStudentID() == studentID);

        //}
        //static int ChooseNewCourse(string courseName)
        //{
        //    return Array.IndexOf(CourseNames, courseName);
        //}
        //static string ChooseCourse(int studentIndex)
        //{
        //    //check studentIndex is valid
        //    if (students.Count > studentIndex) return string.Empty;

        //    return students[studentIndex].GetCourseDisplay();
        //}
        //static bool HasCourse(int studentIndex, int courseIndex)
        //{
        //    return students[studentIndex].HasCourse(CourseNames[courseIndex]);
        //}
        //private static string ParseStudentID(int totalAdded)
        //{
        //    return totalAdded.ToString().PadLeft(8, '0');
        //}

        //Create getintinrange method for handling input values
    }
}