// Author: Sophia Lin
// File Name: Program.cs
// Project Name: Student Course Manager
// Creation Date: October 1, 2023
// Modified Date: October 6, 2023
// Description: This program is built to manage students and their courses in school
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

        //GENERAL DISPLAY
        const int MAIN_MENU = 1;
        const int STUDENT_MENU = 2;

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
            return DisplayGeneralMenu(MAIN_MENU, 1, 4, 0);
        }

        private static int DisplayStudentMenu(int studentIndex)
        {
            return DisplayGeneralMenu(STUDENT_MENU, 1, 3, studentIndex);
        }

        private static int DisplayGeneralMenu(int menuScreen, int indexMin, int indexMax, int studentIndex)
        {
            int option = NO_OPTION;
            int currentLineCursor = Console.CursorTop;

            while (option == NO_OPTION)
            {
                switch (menuScreen)
                {
                    case MAIN_MENU:
                        Console.Clear();
                        Console.WriteLine("STUDENT MANAGER\n================\n");
                        Console.WriteLine("1) Add a Student");
                        Console.WriteLine("2) Remove a Student");
                        Console.WriteLine("3) Display Student Data");
                        Console.WriteLine("4) Exit\n");
                        break;
                    case STUDENT_MENU:
                        ClearLines(currentLineCursor, 11);
                        Console.WriteLine("STUDENT MENU\n=============\n");
                        Console.WriteLine("1) Add a Course");
                        Console.WriteLine("2) Remove a Course");
                        Console.WriteLine("3) Return to Menu\n");
                        break;
                }

                Console.Write("Choose an option: ");

                Int32.TryParse(Console.ReadLine(), out option);


                if (option == NO_OPTION || option > indexMax || option < indexMin)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                    option = NO_OPTION;
                    Console.ResetColor();
                }

                switch (menuScreen)
                {
                    case MAIN_MENU:
                        if (students.Count <= 0 && (option == REMOVE || option == DISPLAY))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No students found. Add a student first!\nPress ENTER to continue.");
                            Console.ReadLine();
                            option = NO_OPTION;
                            Console.ResetColor();
                        }
                        break;
                    case STUDENT_MENU:
                        if (students[studentIndex].GetCourseCount() <= 0 && option == REMOVE_COURSE)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No courses found. Add a course first!\nPress ENTER to continue.");
                            option = NO_OPTION;
                            Console.ReadLine();
                            Console.ResetColor();
                        }
                        break;
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

        private static int ChooseStudent()
        {
            int index = NO_OPTION;

            if (students.Count > 0)
            {
                while (index <= NO_OPTION || index > students.Count)
                {
                    Console.Clear();

                    Console.WriteLine("STUDENT SELECTION\n=================\n");

                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + students[i].GetDetails());
                    }

                    Console.WriteLine("");
                    Console.Write("Choose a student: ");

                    Int32.TryParse(Console.ReadLine(), out index);

                    if (index <= NO_OPTION || index > students.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid student choice.\nPress ENTER to continue.");
                        Console.ReadLine();
                        Console.ResetColor();
                    }
                }
            }

            return index - 1;
        }

        private static int ChooseNewCourse(int studentIndex)
        {
            int courseChoice = NO_OPTION;
            int currentLineCursor = Console.CursorTop;


            while (courseChoice == NO_OPTION)
            {
                ClearLines(currentLineCursor, 14);
                Console.WriteLine("NEW COURSE SELECTION\n=====================");

                for (int i = 0; i < courseNames.Length; i++)
                {
                    Console.WriteLine((i + 1) + ") " + courseNames[i] + " (" + courseCodes[i] + ")");
                }

                Console.Write("");
                Console.Write("Choose a course to add: ");

                Int32.TryParse(Console.ReadLine(), out courseChoice);

                if (courseChoice == NO_OPTION || courseChoice > courseNames.Length || courseChoice < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                    Console.ResetColor();
                    courseChoice = NO_OPTION;
                }
                else if (HasCourse(studentIndex, courseChoice - 1) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Student already has this course.\nPress ENTER to continue.");
                    Console.ReadLine();
                    courseChoice = NO_OPTION;
                    Console.ResetColor();
                }
            }

            return (courseChoice - 1);
        }

        private static int ChooseCourse(int studentIndex, int choice)
        {
            int currentLineCursor = Console.CursorTop;

            while (choice == NO_OPTION)
            {
                Console.Clear();
                Console.WriteLine("COURSE SELECTION (REMOVAL)\n===========================");
                Console.WriteLine(students[studentIndex].GetCourseDisplay());
                Console.WriteLine("");


                Console.Write("");
                Console.Write("Choose a course to remove: ");
                Int32.TryParse(Console.ReadLine(), out choice);

                if (choice == NO_OPTION || choice > students[studentIndex].GetCourseCount() || choice < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid menu option.\nPress ENTER to continue.");
                    Console.ReadLine();
                    Console.ResetColor();
                    choice = NO_OPTION;
                }
            }

            return choice - 1;
        }

        private static bool HasCourse(int studentIndex, int courseIndex)
        {
            return students[studentIndex].HasCourse(courseNames[courseIndex]);
        }

        private static void AddNewCourse(int studentIndex)
        {
            int courseChoice = ChooseNewCourse(studentIndex);
            int courseMark = -1;

            while (courseMark < 0 || courseMark > 100)
            {
                courseMark = -1;
                int currentLineCursor = Console.CursorTop;
                Console.Write("Enter mark in course (0 - 100): ");

                Int32.TryParse(Console.ReadLine(), out courseMark);

                if (courseMark < 0 || courseMark > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mark is out of range.\nPress ENTER to continue.");
                    Console.ReadLine();
                    Console.ResetColor();
                    ClearLines(currentLineCursor, 5);
                }
            }

            students[studentIndex].AddCourse(new Course(courseChoice, courseMark));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New course added.\nPress ENTER to continue.");
            Console.ResetColor();
        }

        private static void RemoveCourse(int studentIndex)
        {
            int courseChoice = NO_OPTION;
            courseChoice = ChooseCourse(studentIndex, courseChoice);

            students[studentIndex].RemoveCourse(courseChoice);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student successfully removed.\nPress ENTER to continue.");
            Console.ResetColor();
        }

        private static void AddStudent()
        {
            string lName = "";
            string fName = "";
            Console.WriteLine("STUDENT CREATION\n=================\n");

            int currentLineCursor = Console.CursorTop;

            while (lName.Trim().Length <= 0)
            {
                Console.Write("Last Name: ");
                lName = Console.ReadLine();

                if (lName.Trim().Length <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name must be at least 1 character.\nPress ENTER to continue.");
                    Console.ReadLine();
                    ClearLines(currentLineCursor, 3);
                    Console.ResetColor();
                }
            }

            currentLineCursor = Console.CursorTop;

            while (fName.Trim().Length <= 0)
            {
                Console.Write("First Name: ");
                fName = Console.ReadLine();

                if (fName.Trim().Length <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name must be at least 1 character.\nPress ENTER to continue.");
                    Console.ReadLine();
                    ClearLines(currentLineCursor, 3);
                    Console.ResetColor();
                }
            }

            students.Add(CreateStudent(lName, fName));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student successfully added.\nPress ENTER to continue.");
            Console.ResetColor();
            Console.ReadLine();

        }

        private static void RemoveStudent(int studentIndex)
        {
            students.RemoveAt(studentIndex);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student successfully removed.\nPress ENTER to continue.");
            Console.ReadLine();
            Console.ResetColor();
        }

        private static void DisplayStudent(int studentIndex)
        {
            int option = NO_OPTION;
            while (option != RETURN_MENU)
            {
                Console.WriteLine("STUDENT INFORMATION\n===================\n");
                Console.WriteLine(students[studentIndex].GetDetails());
                Console.WriteLine(students[studentIndex].GetCourseDisplay());
                Console.WriteLine("");

                option = DisplayStudentMenu(studentIndex);

                switch (option)
                {
                    case ADD_COURSE:
                        if (!students[studentIndex].RestrictCourses())
                        {
                            Console.Clear();
                            AddNewCourse(studentIndex);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Student has every course! No more can be added.\nPress ENTER to continue.");
                            Console.ResetColor();
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case REMOVE_COURSE:
                        Console.Clear();
                        RemoveCourse(studentIndex);
                        Console.ReadLine();
                        Console.Clear();
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
                        Console.WriteLine("");
                        DisplayStudent(studentIndex);
                        break;
                }
            }
        }

        private static string ParseStudentID()
        {
            return totalAdded.ToString().PadLeft(8, '0');
        }

        private static void ClearLines(int currentLineCursor, int lines)
        {
            int consoleLines = lines;

            Console.SetCursorPosition(0, currentLineCursor);

            for (int i = 0; i < consoleLines; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}