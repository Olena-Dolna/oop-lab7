using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class Result
    {
        private string Subject { get; set; }
        private string Teacher { get; set; }    
        private int Points { get; set; }    
        public Result()
        {
            Subject = "-";
            Teacher = "-";
            Points = 0;
        }
        public Result(string subject, string teacher, int points)
        {
            Subject = subject;
            Teacher = teacher;
            Points = points;
        }
        public Result(string subject, int points)
        {
            Subject = subject;
            Teacher = "-";
            Points = points;
        }
        public Result(Result Duplicate)
        {
            Subject = Duplicate.Subject;
            Teacher = Duplicate.Teacher;
            Points = Duplicate.Points;
        }
        public string GetSubject()
        {
            return Subject;
        }
        public string GetTeacher()
        {
            return Teacher;
        }
        public int GetPoints()
        {
            return Points;
        }
    }
}
