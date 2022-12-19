using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab7
{
    public class Student
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Group { get; set; }
        private int Year { get; set; }  
        private Result[] Results { get; set; }
        public Student()
        {
            Name = "-";
            Surname = "-";
            Group = "-";
            Year = 0;
            Results = new Result[0];
        }
        public Student(string name, string surname, string group, int year, Result[] results)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Year = year;
            Results = results;
        }
        public Student(string name, string surname, int year, Result[] results)
        {
            Name = name;
            Surname = surname;
            Group = "-";
            Year = year;
            Results = results;
        }
        public Student(Student Duplicate)
        {
            Name = Duplicate.Name;
            Surname = Duplicate.Surname;
            Group = Duplicate.Group;
            Year = Duplicate.Year;
            Results = Duplicate.Results;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetSurname()
        {
            return Surname;
        }
        public string GetGroup()
        {  
            return Group; 
        }
        public int GetYear()
        {
            return Year;
        }
        public Result[] GetResults()
        {
            return Results;
        }
        public double GetAveragePoints()
        {
            int total = 0;
            double average = 0;
            for( int i = 0; i < Results.Length; i++ )
            {
                total += Results[i].GetPoints();
            }
            average = (double) total / Results.Length;
            return average;
        }
        public string GetBestSubject()
        {
            int max = 0;
            string bestSubject = "";
            for (int i = 0; i < Results.Length; i++)
            {
                if (Results[i].GetPoints() > max)
                {
                    max = Results[i].GetPoints();
                    bestSubject = Results[i].GetSubject();
                }
            }
            return bestSubject;
        }
        public string GetWorstSubject()
        {
            int min = 100;
            string worstSubject = "";
            for (int i = 0; i < Results.Length; i++)
            {
                if (Results [i].GetPoints() < min)
                {
                    min = Results [i].GetPoints();
                    worstSubject = Results[i].GetSubject();
                }
            }
            return worstSubject;
        }
    }
}
