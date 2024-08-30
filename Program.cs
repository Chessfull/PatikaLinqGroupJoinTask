using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaLinqGroupJoinTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ▼ Creating table of students ▼ 
            var students = new[]
            {
                new { StudentID = 1, StudentName = "Mert", ClassID = 1 },
                new { StudentID = 2, StudentName = "Ahmet", ClassID = 2 },
                new { StudentID = 3, StudentName = "Mehmet", ClassID = 3 },
                new { StudentID = 4, StudentName = "Gözde", ClassID = 1 },
                new { StudentID = 4, StudentName = "Gizem", ClassID = 2 },
            };

            // ▼ Creating table of classes ▼ 
            var classes = new[]
            {
                new { ClassID = 1, ClassName = "Türkçe"},
                new { ClassID = 2, ClassName = "Matematik"},
                new { ClassID = 3, ClassName = "İngilizce"},
            };

            // ▼ Linq method way group join classes with students group on ClassID ▼
            var groupClasses = classes.GroupJoin(students,
                @class => @class.ClassID, student => student.ClassID, (@class, studentGroup) => new
                {
                    ClassName = @class.ClassName,
                    Students = studentGroup
                });

            // ▼ Query method way group join classes with students group on ClassID ▼
            var groupClassesQuery = from @class in classes
                                    join student in students
                                    on @class.ClassID equals student.ClassID
                                    into studentGroup
                                    select new { ClassName = @class.ClassName, Students = studentGroup };

            // ▼ Printing class name and each students ▼
            foreach (var @class in groupClasses)
            {
                Console.WriteLine(@class.ClassName);
                foreach (var student in @class.Students)
                {
                    Console.WriteLine(student.StudentName);
                }
            }

            foreach (var @class in groupClassesQuery)
            {
                Console.WriteLine(@class.ClassName);
                foreach (var student in @class.Students)
                {
                    Console.WriteLine(student.StudentName);
                }
            }
        }
    }
}
