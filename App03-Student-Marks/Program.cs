using System;
using System.Runtime.CompilerServices;

namespace MarksConsoleApp
{
    class Program
    {
        static int[] marks = new int[10];
        static int count = 0;

        static void Main(string[] args)
        {
            int choice = 0;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t App03 Student Marks");
            Console.WriteLine("\t\t\t Developed By Shivam Yadav");
            Console.WriteLine("--------------------------------------------------------------------------");
            do
            {   //Provide a menu to the user to select.
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Input Mark");
                Console.WriteLine("2) Output Marks");
                Console.WriteLine("3) Output Stats");
                Console.WriteLine("4) Output Grade Profile");
                Console.WriteLine("5) Quit");

                Console.Write("\n Enter your choice: ");

                //Call the required function depending upon the options selected by the User
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InputMarks();
                            break;
                        case 2:
                            OutputMarks();
                            break;
                        case 3:
                            OutputStats();
                            break;
                        case 4:
                            OutputGradeProfileDistribution();
                            break;
                        case 5:
                            Console.WriteLine("You are Quitting from the application");
                            break;
                        default:
                            Console.WriteLine("****Invalid choice. Please try again.****");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

            } while (choice != 5);
        }

        //This function get the count of student falling in each category
        private static void OutputGradeProfileDistribution()
        {
            Console.WriteLine("Grade 1: First Class");
            Console.WriteLine("Grade 2: Upper Second Class");
            Console.WriteLine("Grade 3: Lower Second Class");
            Console.WriteLine("Grade 4: Third Class");
            Console.WriteLine("Grade 5: Fail");
            if (marks[0] == 0)
            {
                Console.WriteLine("Please enter marks first.");
                return;
            }

            int[] gradeCounts = new int[5];
            foreach (int mark in marks)
            {
                int gradeIndex = GetGradeIndex(mark);
                gradeCounts[gradeIndex]++;
            }

            Console.WriteLine("Grade Profile:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Grade {i + 1}: {gradeCounts[i]}");
            }
        }

        //This function helps in distributing the grades depending upon the marks slab
        static int GetGradeIndex(int grade)
        {
            switch (grade)
            {
                case var g when g >= 70 && g <= 100:
                    return 0;
                case var g when g >= 60 && g <= 69:
                    return 1;
                case var g when g >= 50 && g <= 59:
                    return 2;
                case var g when g >= 40 && g <= 49:
                    return 3;
                default:
                    return 4;
            }
        }

        public static string OutputGradeProfile(int mark)
        {
            //The below function is to divide the students into various grades category
                if (mark >= 70 && mark <= 100)
                {
                    return "A";
                }
                else if (mark >= 60 && mark <= 69)
                {
                    return "B";
                }
                else if (mark >= 50 && mark <= 59)
                {
                    return "C";
                }
                else if (mark >= 40 && mark <= 49)
                {
                    return "D";
                }
                else
                {
                    return "F";
                }
            }

        //This method helps in displaying the statistics for the marks entered which include the mean, median, maximum and the minimums
        private static void OutputStats()
        {
            if (count > 0)
            {
                Array.Sort(marks);
                double median;
                if (count % 2 == 0)
                {
                    median = (marks[count / 2 - 1] + marks[count / 2]) / 2.0;
                }
                else
                {
                    median = marks[count / 2];
                }

                Console.WriteLine($"Mean: {marks.Average()}");
                Console.WriteLine($"Median: {median}");
                Console.WriteLine($"Maximum: {marks[count - 1]}");
                Console.WriteLine($"Minimum: {marks[0]}");
            }
            else
            {
                Console.WriteLine("No marks entered yet.");
            }
        }
        //This function is to ask user to enter marks for a single subject for 10 students
        static void InputMarks()
        {
            Console.WriteLine("Enter marks for 10 students:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter mark for student {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int mark))
                {
                    marks[i] = mark;
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    i--;
                }
            }
        }
        //This function is to display the marks for all the 10 students
        public static void OutputMarks()
        {
            if (marks.Length == 0)
            {
                Console.WriteLine("No marks input yet.");
                return;
            }
            Console.WriteLine("Student\tMark\tGrade");
            Console.WriteLine("------\t----\t-----");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"{i + 1}\t{marks[i]:F2}\t{OutputGradeProfile(marks[i])}");

            }
        }
    }
}