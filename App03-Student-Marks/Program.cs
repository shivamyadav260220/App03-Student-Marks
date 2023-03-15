using System;

namespace MarksConsoleApp
{
    class Program
    {
        static int[] marks = new int[10];
        static int count = 0;

        static void Main(string[] args)
        {
            int choice = 0;
            do
            {   
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Input Mark");
                Console.WriteLine("2) Output Marks");
                Console.WriteLine("3) Output Stats");
                Console.WriteLine("4) Output Grade Profile");
                Console.WriteLine("5) Quit");

                Console.Write("Enter your choice: ");
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
                            Console.WriteLine("Quitting program...");
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

        static void OutputMarks()
        {
            Console.WriteLine("Student marks:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Student {i + 1}: {marks[i]}");
            }
        }

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

        static void OutputGradeProfile()
        {
            if (count > 0)
            {
                int[] grades = new int[5];
                foreach (int mark in marks)
                {
                    if (mark >= 90)
                    {
                        grades[0]++;
                    }
                    else if (mark >= 80)
                    {
                        grades[1]++;
                    }
                    else if (mark >= 70)
                    {
                        grades[2]++;
                    }
                    else if (mark >= 60)
                    {
                        grades[3]++;
                    }
                    else
                    {
                        grades[4]++;
                    }
                }

                Console.WriteLine("Grade Profile:");
                Console.WriteLine($"A: {grades[0]}");
                Console.WriteLine($"B: {grades[1]}");
                Console.WriteLine($"C: {grades[2]}");
                Console.WriteLine($"D: {grades[3]}");
                Console.WriteLine($"F: {grades[4]}");
            }
            else
            {
                Console.WriteLine("No marks entered yet.");
            }
        }
    }
}