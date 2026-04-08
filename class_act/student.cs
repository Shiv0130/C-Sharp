//student class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_act
{
    public class student
    {
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double AverageMark { get; set; }

        public student(string name, DateTime birthDate,double averageMark)
        {
            Name = name;
            BirthDate = birthDate;
            AverageMark = averageMark;
        }

        public int GetAge() 
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now < BirthDate.AddYears(age)) 
            {
                age--;
            }
            return age;
        }
        public bool CanWriteExam() 
        {
            return AverageMark >= 50 && DateTime.Now.DayOfWeek != DayOfWeek.Sunday;
        }

        public string GetLetterGrade()
        {
            return AverageMark switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                >= 50 => "E",
                _ => "F"
            };
        }
    }
}
