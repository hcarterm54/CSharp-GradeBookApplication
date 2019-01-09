using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Requires minimum 5 students.");
            }

            // determine the cutoff number for each grade drop
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            // Sort the students by the student's average grade in ascending order
            var grades = Students.OrderByDescending(e => e.AverageGrade)
                .Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[threshold*2 - 1] <= averageGrade)
                return 'B';
            else if (grades[threshold*3 - 1] <= averageGrade)
                return 'C';
            else if (grades[threshold*4 - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
