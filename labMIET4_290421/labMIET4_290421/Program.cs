using System;
using System.IO;
using System.Linq;

namespace labMIET4_290421
{
    class Program
    {
        public enum Education
        {
            Specialist,
            Bachelor,
            SecondEducation,
            none
        };


        public interface IDateAndCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }

        static void Main(string[] args)
        {

            StudentCollection studentCollection1 = new StudentCollection();
            studentCollection1.CollectionName = "Students1";

            StudentCollection studentCollection2 = new StudentCollection();
            studentCollection2.CollectionName = "Students2";

            Student[] students1 = new Student[]
            {
                new Student(new Person("Serhiy", "Pityk", new DateTime(2000, 3, 27)), Education.Bachelor, 312),
                new Student(new Person("Artem", "Shtefanesa", new DateTime(1999, 2, 10)), Education.Bachelor, 312),
                new Student(new Person("Margarita", "Boiko", new DateTime(2000, 3, 23)), Education.Bachelor, 302)
            };

            Student[] students2 = new Student[]
            {
                new Student(new Person("Ksenia", "Dolgan", new DateTime(1999, 12, 1)), Education.Bachelor, 302),
                new Student(new Person("Irina", "Zhizhiyan", new DateTime(2000, 5, 25)), Education.Bachelor, 302),
                new Student(new Person("Elisabet", "Moiseenko", new DateTime(2000, 7, 3)), Education.Bachelor, 312)
            };

            studentCollection1.AddStudents(students1);
            studentCollection2.AddStudents(students2);

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            studentCollection1.StudentCountChange += journal1.ProcessStudentCountChange;
            studentCollection2.StudentReferenceChange += journal2.ProcessStudentReferenceChange;

            studentCollection2.StudentCountChange += journal2.ProcessStudentCountChange;
            studentCollection2.StudentReferenceChange += journal2.ProcessStudentReferenceChange;

            studentCollection1[1] = new Student(new Person("Vladislav", "Garvasiuk", new DateTime(2000, 5, 15)), Education.Bachelor, 302);
            studentCollection2[1] = new Student(new Person("Serhiy", "Kosovchich", new DateTime(2000, 8, 9)), Education.Bachelor, 312);

            studentCollection1.AddStudents(new Student[] { new Student(new Person("Andriy", "Drobot", new DateTime(2000, 10, 6)), Education.Bachelor, 302) });
            studentCollection2.AddStudents(new Student[] { new Student(new Person("Kristyan", "Morarash", new DateTime(2000, 2, 20)), Education.Bachelor, 312) });

            studentCollection1.Remove(0);
            studentCollection2.Remove(0);

            Console.WriteLine(journal1.ToString());
            Console.WriteLine(students1.ToString());
            Console.WriteLine(journal2.ToString());
        }


    }
}








