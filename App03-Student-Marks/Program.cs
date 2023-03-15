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
                            OutputGradeProfile();
                            break;
                        case 5:
                            Console.WriteLine("You are Quitting from the application");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

            } while (choice != 5);
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
        static void OutputMarks()
        {
            Console.WriteLine("Student marks:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Student {i + 1}: {marks[i]}");
            }
        }

        //This function is to calcualate stats which incoporates mean, median, maximum and minimum for the marks of 10 students
        static void OutputStats()
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

        //The below function is to divide the students into various grades category
        static void OutputGradeProfile()
        {
            if (count > 0)
            {
                int[] grades = new int[5];
                foreach (int mark in marks)
                {
                    if (mark >= 70 && mark <= 100)
                    {
                        grades[0]++;
                    }
                    else if (mark >= 60 && mark <= 69)
                    {
                        grades[1]++;
                    }
                    else if (mark >= 50 && mark <= 59)
                    {
                        grades[2]++;
                    }
                    else if (mark >= 40 && mark <= 49)
                    {
                        grades[3]++;
                    }
                    else
                    {
                        grades[4]++;
                    }
                }

                Console.WriteLine("Grade Profile:");
                Console.WriteLine($"First Class: {grades[0]}");
                Console.WriteLine($"Upper Second Class: {grades[1]}");
                Console.WriteLine($"Lower Second Class: {grades[2]}");
                Console.WriteLine($"Third Class: {grades[3]}");
                Console.WriteLine($"Fail: {grades[4]}");
            }
            else
            {
                Console.WriteLine("No marks entered yet.");
            }
        }
    }
}