using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace LinSMP1
{
    class Program
    {
        public static string[] courseNames = new string[] { "Science", "Math", "Phys. Ed", "English", "History", "Geography" };
        public static string[] courseCodes = new string[] { "SNC", "MTH", "PPL", "ENG", "CHC", "CGC" };
        private static List<Student> students = new List<Student>();
        private static int totalAdded = 0;

        //STUDENT MENU
        const int NO_OPTION = 0;
        const int ADD = 1;
        const int REMOVE = 2;
        const int DISPLAY = 3;
        const int EXIT = 4;

        //COURSE MENU
        const int ADD_COURSE = 1;
        const int REMOVE_COURSE = 2;
        const int RETURN_MENU = 3;

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
                        AddStudent();
                        break;
                    case REMOVE:
                        StudentSelection(REMOVE);
                        break;
                    case DISPLAY:
                        StudentSelection(DISPLAY);
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
                Console.WriteLine("Student Manager\n======================\n");
                Console.WriteLine("1. Add a Student");
                Console.WriteLine("2. Remove a Student");
                Console.WriteLine("3. Display Student Data");
                Console.WriteLine("4. Exit\n");
                Console.Write("Choose an option: ");

                //Error handle if out of range for menu
                Int32.TryParse(Console.ReadLine(), out option);

                if (option == NO_OPTION || option > 4 || option < 1)
                {
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                }
                else if (students.Count <= 0 && (option == REMOVE || option == DISPLAY))
                {
                    Console.WriteLine("No students found\nPress ENTER to continue.");
                    Console.ReadLine();
                    option = NO_OPTION;
                }
            }

            return option;
        }

        private static int DisplayStudentMenu(int studentIndex)
        {
            int option = NO_OPTION;
            int currentLineCursor = Console.CursorTop;

            while (option == NO_OPTION)
            {
                ClearLines(currentLineCursor, 11);
                //Console.Clear();
                Console.WriteLine("Student Menu\n======================\n");
                Console.WriteLine("1. Add a Course");
                Console.WriteLine("2. Remove a Course");
                Console.WriteLine("3. Return to Menu\n");
                Console.Write("Choose an option: ");

                //Error handle if out of range for menu
                Int32.TryParse(Console.ReadLine(), out option);

                if (option == NO_OPTION || option > 3 || option < 1)
                {
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                }
                else if (students[studentIndex].GetCourseCount() <= 0 && option == REMOVE_COURSE)
                {
                    Console.WriteLine("No courses found\nPress ENTER to continue.");
                    option = NO_OPTION;
                    Console.ReadLine();
                }
            }

            return option;
        }

        private static Student CreateStudent(string fName, string lName)
        {
            Student student = new Student(lName, fName, ParseStudentID());
            totalAdded++;
            return student;
        }

        //Get the student index
        private static int ChooseStudent()
        {
            int index = NO_OPTION;

            //ask for a student index if there is at least one student
            if (students.Count > 0)
            {
                while (index <= NO_OPTION || index > students.Count)
                {
                    Console.Clear();

                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + students[i].GetDetails());
                    }

                    Console.WriteLine("");
                    Console.Write("Choose a student by the index on the left: ");

                    //Retrieve the option and attempt to convert it to an int
                    Int32.TryParse(Console.ReadLine(), out index);

                    //Give failure feedback for impossible entries
                    if (index <= NO_OPTION || index > students.Count)
                    {
                        Console.WriteLine("Sorry, that is an invalid index.\nPress ENTER to continue.");
                        Console.ReadLine();
                    }
                }
            }

            //Reduce the index by 1 to account for the fact the numbering on screen starts at 1
            return index - 1;
        }

        private static void AddNewCourse(int studentIndex)
        {
            int courseChoice = ChooseNewCourse();
            int courseMark = -1;

            while (courseMark < 0 || courseMark > 100)
            {
                courseMark = -1;
                int currentLineCursor = Console.CursorTop;
                Console.Write("Enter mark in course (0 - 100): ");

                Int32.TryParse(Console.ReadLine(), out courseMark);

                if (courseMark < 0 || courseMark > 100)
                {
                    Console.WriteLine("Mark is out of range.\nPress ENTER to continue.");
                    Console.ReadLine();
                    ClearLines(currentLineCursor, 5);
                }
            }

            students[studentIndex].AddCourse(new Course(courseChoice, courseMark));
            Console.WriteLine("New Course Added.\nPress ENTER to continue.");
        }
        
        private static void RemoveCourse(int studentIndex)
        {
            int courseChoice = NO_OPTION;
            int currentLineCursor = Console.CursorTop;

            while (courseChoice == NO_OPTION)
            {

                Console.WriteLine("COURSE SELECTION (REMOVAL)\n===========================");
                Console.WriteLine(students[studentIndex].GetCourseDisplay());
                Console.WriteLine("");


                Console.Write("");
                Console.Write("Choose a course to remove: ");
                Int32.TryParse(Console.ReadLine(), out courseChoice);

                if (courseChoice == NO_OPTION || courseChoice > students[studentIndex].GetCourseCount() || courseChoice < 1)
                {
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                    courseChoice = NO_OPTION;
                }
            }

            students[studentIndex].RemoveCourse(courseChoice - 1);
            Console.WriteLine("Course successfully removed!\nPress ENTER to continue.");
        }

        private static int ChooseNewCourse()
        {
            int courseChoice = NO_OPTION;
            int currentLineCursor = Console.CursorTop;


            while (courseChoice == NO_OPTION)
            {
                ClearLines(currentLineCursor, 14);
                Console.WriteLine("NEW COURSE SELECTION\n========================");

                for (int i = 0; i < courseNames.Length; i++)
                {
                    Console.WriteLine((i + 1) + ") " + courseNames[i] + " (" + courseCodes[i] + ")");
                }

                Console.Write("");
                Console.Write("Choose a course to add: ");
                //Error handle if out of range for menu
                Int32.TryParse(Console.ReadLine(), out courseChoice);

                if (courseChoice == NO_OPTION || courseChoice >  courseNames.Length || courseChoice < 1)
                {
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                    courseChoice = NO_OPTION;
                }
            }

            return (courseChoice - 1);
        }

        private static void ClearLines(int currentLineCursor, int lines)
        {
            //Store how many lines to clear in console
            int consoleLines = lines;

            Console.SetCursorPosition(0, currentLineCursor);

            //Clear the lines
            for (int i = 0; i < consoleLines; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, currentLineCursor);
        }

        private static void AddStudent()
        {
            string lName = "";
            string fName = "";
            Console.WriteLine("ADD STUDENT\n===============");

            int currentLineCursor = Console.CursorTop;

            while (lName.Trim().Length <= 0)
            {
                Console.Write("Last Name: ");
                lName = Console.ReadLine();

                if (lName.Trim().Length <= 0)
                {
                    Console.WriteLine("Name must be at least 1 character.\nPress ENTER to continue.");
                    Console.ReadLine();
                    ClearLines(currentLineCursor, 3);
                }
            }

            currentLineCursor = Console.CursorTop;

            while (fName.Trim().Length <= 0)
            {
                Console.Write("First Name: ");
                fName = Console.ReadLine();

                if (fName.Trim().Length <= 0)
                {
                    Console.WriteLine("Name must be at least 1 character.\nPress ENTER to continue.");
                    Console.ReadLine();
                    ClearLines(currentLineCursor, 3);
                }
            }


            students.Add(CreateStudent(lName, fName));
        }

        private static void RemoveStudent(int studentIndex)
        {
            Console.Clear();
            students.RemoveAt(studentIndex);
            Console.WriteLine("Remove succeeded\nPress ENTER to continue.");
            Console.ReadLine();
        }

        private static void DisplayStudent(int studentIndex)
        {
            int option = NO_OPTION;
            while (option != RETURN_MENU)
            {
                Console.Clear();
                Console.WriteLine(students[studentIndex].GetDetails());
                Console.WriteLine(students[studentIndex].GetCourseDisplay());
                Console.WriteLine("");

           
                option = DisplayStudentMenu(studentIndex);
                

                switch (option)
                {
                    case ADD_COURSE:
                        Console.Clear();
                        AddNewCourse(studentIndex);
                        Console.ReadLine();
                        break;
                    case REMOVE_COURSE:
                        Console.Clear();
                        RemoveCourse(studentIndex);
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void StudentSelection(int choice)
        {
            int studentIndex = ChooseStudent();

            if (studentIndex >= 0)
            {
                switch (choice)
                {
                    case REMOVE:
                        RemoveStudent(studentIndex);
                        break;
                    case DISPLAY:
                        DisplayStudent(studentIndex);
                        break;
                }
            }
        }

        //WIP
        private static bool HasCourse(int studentIndex, int courseIndex)
        {
            return students[studentIndex].HasCourse(courseNames[courseIndex]);
        }
        private static string ParseStudentID()
        {
            return totalAdded.ToString().PadLeft(8, '0');
        }

        //Create getintinrange method for handling input values
    }
}