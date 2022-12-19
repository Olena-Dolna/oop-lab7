using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab7
{
    internal class Program
    {
        static Student[] ReadStudentsArray()
        {
            Console.WriteLine("Введіть кількість студентів: ");
            int studentsNumber = IntCorrect();
            Console.WriteLine("Введіть кількість предметів: ");
            int subjectsNumber = IntCorrect();
            Student[] student = new Student[studentsNumber];
            for(int i = 0; i < studentsNumber; i++)
            {
                
                Console.WriteLine($"\nСтудент N{i + 1}");
                Console.Write("Ім'я: ");
                string name = Console.ReadLine();
                Console.Write("Прізвище: ");
                string surname = Console.ReadLine();
                Console.Write("Шифр групи: ");
                string group = Console.ReadLine();
                Console.Write("Номер курсу: ");
                int year = IntCorrect();
                Result[] results = new Result[subjectsNumber];
                for(int j = 0; j < subjectsNumber; j++)
                {
                    Console.WriteLine($"\nПредмет N{j + 1}");
                    Console.Write("Назва предмета: ");
                    string subject = Console.ReadLine();
                    Console.Write("П.І.Б. викладача: ");
                    string teacher = Console.ReadLine();
                    Console.Write("Оцінка: ");
                    int points = IntCorrect();
                    results[j] = new Result(subject, teacher, points);
                }
                student[i] = new Student(name, surname, group, year, results);
            }
            return student;
        }
        static void PrintStudent(Student[] student, int n)
        {

            Console.WriteLine($"Ім'я: {student[n].GetName()}");
            Console.WriteLine($"Прізвище: {student[n].GetSurname()}");
            Console.WriteLine($"Шифр групи: {student[n].GetGroup()}");
            Console.WriteLine($"Номер курсу: {student[n].GetYear()}");
            for (int j = 0; j < student[n].GetResults().Length; j++)
            {
                Console.Write($"Назва предмета: {student[n].GetResults()[j].GetSubject()}");
                Console.Write($"\nП.І.Б. викладача: {student[n].GetResults()[j].GetTeacher()}");
                Console.Write($"\nОцінка: {student[n].GetResults()[j].GetPoints()}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void PrintStudents(Student[] student)
        {
            for (int i = 0; i < student.Length; i++)
            {
                Console.WriteLine($"\tСтудент N{i + 1}");
                Console.WriteLine($"Ім'я: {student[i].GetName()}");
                Console.WriteLine($"Прізвище: {student[i].GetSurname()}");
                Console.WriteLine($"Шифр групи: {student[i].GetGroup()}");
                Console.WriteLine($"Номер курсу: {student[i].GetYear()}");
                for (int j = 0; j < student[i].GetResults().Length; j++)
                {
                    Console.Write($"Назва предмета: {student[i].GetResults()[j].GetSubject()}");
                    Console.Write($"\nП.І.Б. викладача: {student[i].GetResults()[j].GetTeacher()}");
                    Console.Write($"\nОцінка: {student[i].GetResults()[j].GetPoints()}");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        static void GetStudentsInfo(Student[] student, out double minAveragePoint, out double maxAveragePoint)
        {
            minAveragePoint = 100;
            maxAveragePoint = 0;
            for(int i = 0; i < student.Length; i++)
            {
                if(student[i].GetAveragePoints() > maxAveragePoint)
                { 
                    maxAveragePoint = student[i].GetAveragePoints();
                }
                if(student[i].GetAveragePoints() < minAveragePoint)
                {
                    minAveragePoint = student[i].GetAveragePoints();
                }
            }
        }
        static int CompareByPoints(Student a, Student b)
        {
            double aAverage = a.GetAveragePoints(), bAverage = b.GetAveragePoints();
            if (aAverage > bAverage)
            {
                return 1;
            }
            else if (aAverage < bAverage)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        static int CompareByName(Student a, Student b)
        {
            string aSurname = a.GetSurname(), bSurname = b.GetSurname();
            if (String.Compare(aSurname, bSurname) > 0)
            {
                return 1;
            }
            else if(String.Compare(aSurname, bSurname) == 0)
            {
                string aName = a.GetName(), bName = b.GetName();
                if (String.Compare(aName, bName) > 0)
                {
                    return 1;
                }
                else if (String.Compare(aName, bName) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return -1;
            }
        }
        static Student[] SortStudentsByPoints(Student[] student)
        {
            Array.Sort(student, CompareByPoints);
            return student;
        }
        static Student[] SortStudentsByName(Student[] student)
        {
            Array.Sort(student, CompareByName);
            return student;
        }
        static int IntCorrect()
        {
            int n;
            bool isCorrect = false;
            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out n);
                if (isCorrect == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка введення значення! Будь ласка, повторіть введення ще раз!");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
            }while(!isCorrect);
            return n;
        }
        static void Menu()
        {
            Console.WriteLine("1 - Ввести інформацію про студентів");
            Console.WriteLine("2 - Вивести інформацію про студента за його номером");
            Console.WriteLine("3 - Вивести інформацію про всіх студентів");
            Console.WriteLine("4 - Назва предмета з найвищим балом для кожного студента");
            Console.WriteLine("5 - Назва предмета з найнижчим балом для кожного студента");
            Console.WriteLine("6 - Середній бал кожного студента");
            Console.WriteLine("7 - Найвищий та найнижчий середній бал");
            Console.WriteLine("8 - Сортування студентів за середнім балом");
            Console.WriteLine("9 - Сортування студентів за прізвищем");
            Console.WriteLine("0 - Вийти");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.Title = "Лабораторна робота N7";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Student[] student = null;
            int ch;

            do
            {
                Console.WriteLine("\nНатисніть будь-яку кнопку, щоб продовжити");
                Console.ReadKey();
                Console.Clear();
                Menu();
                ch = IntCorrect();
                switch (ch)
                {
                    case 1:
                        Console.Clear();
                        student = ReadStudentsArray();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nДані успішно записано");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;

                    case 2:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine($"Введіть номер студента (всього {student.Length} записи(-ів)) :");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Студент N");
                        int note = IntCorrect() - 1;
                        if (note > student.Length - 1 || note < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка введення значення! Будь ласка, повторіть введення ще раз!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            PrintStudent(student, note);
                            break;
                        }
                    case 3:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        PrintStudents(student);
                        break;
                    case 4:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        for (int i = 0; i < student.Length; i++)
                        {
                            Console.WriteLine($"\tСтудент N{i + 1}");
                            Console.WriteLine($"Ім'я: {student[i].GetName()}");
                            Console.WriteLine($"Прізвище: {student[i].GetSurname()}");
                            Console.WriteLine($"Найвищий бал з предмету {student[i].GetBestSubject()}");
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        for (int i = 0; i < student.Length; i++)
                        {
                            Console.WriteLine($"\tСтудент N{i + 1}");
                            Console.WriteLine($"Ім'я: {student[i].GetName()}");
                            Console.WriteLine($"Прізвище: {student[i].GetSurname()}");
                            Console.WriteLine($"Найнижчий бал з предмету {student[i].GetWorstSubject()}");
                            Console.WriteLine();
                        }
                        break;
                    case 6:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        for (int i = 0; i < student.Length; i++)
                        {
                            Console.WriteLine($"\tСтудент N{i + 1}");
                            Console.WriteLine($"Ім'я: {student[i].GetName()}");
                            Console.WriteLine($"Прізвище: {student[i].GetSurname()}");
                            Console.WriteLine($"Середній бал: {student[i].GetAveragePoints()}");
                            Console.WriteLine();
                        }
                        break;
                    case 7:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        GetStudentsInfo(student, out double minPoint, out double maxPoint);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Найвищий середній бал: {maxPoint}");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Найнижчий середній бал: {minPoint}");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 8:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        SortStudentsByPoints(student);
                        PrintStudents(student);
                        break;
                    case 9:
                        if (student == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Не знайдено інформації про студентів!");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        }
                        Console.Clear();
                        SortStudentsByName(student);
                        PrintStudents(student);
                        break;
                }
            } while (ch != 0);
        }
    }
}
