﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name,isWeighted)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            var desc_Student_grades = Students.OrderByDescending(x => x.AverageGrade);
            List<double> Student_grades = new List<double>();
            foreach(var stud in desc_Student_grades)
            {

                Student_grades.Add(stud.AverageGrade);
            }

            var top20 = Convert.ToInt32(Students.Count * 0.2);
            if (Student_grades.IndexOf(averageGrade) > top20)
            {
                return 'A';
            }
            if (Student_grades.IndexOf(averageGrade) > 2*top20)
            {
                return 'B';
            }
            if (Student_grades.IndexOf(averageGrade) > 3*top20)
            {
                return 'C';
            }
            if (Student_grades.IndexOf(averageGrade) > 4*top20)
            {
                return 'D';
            }
            
                return 'F';
            
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students with grades in oredr to rpoperly calculate A student's overall grade.");
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students with grades in oredr to rpoperly calculate A student's overall grade.");
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
