using labMIET_2_260321;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static labMIET_2_260321.Program;

namespace labMIET3_290321
{
    class StudentCollection
    {
        List<Student> students;

        public StudentCollection()
        {
            this.students = new List<Student>();

        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public void AddDefaults()
        {
            Students = new List<Student>();
            Student fullStudents = new Student(new Person("Xeniia", "Dolhan", DateTime.Now), 302, Education.Specialist,
              new List<Exam>
                {
                  new Exam("Art",4,DateTime.Now), new Exam("Science",5, DateTime.Now)

                },
                new List<Test>
                {
                    new Test("Gheography", 3), new Test("philosophy", 2)
                });
            Students.Add(fullStudents);
            Students.Add(new Student());
            Students.Add(fullStudents);
        }

        public void AddStudents(params Student[] students)
        {
            Students = new List<Student>();
            foreach (var student in students)
            {
                Students.Add(student);

            }
        }

        public override string ToString()
        {
            return string.Format("Students:\n{0}", string.Join("\n", Students.Select(x => x.ToString()).ToArray()));
        }

        public virtual string ToShortString()
        {
            return string.Format("Students:\n{0}", string.Join("\n", Students.Select(x => x.ToShortString()).ToArray()));
        }

        public void SortStudents()
        {

            students.Sort();

           
        }

        public void SortByName()
        {
            Students.Sort();
        }
        public void SortByDate()
        {
            Students.Sort(new Person().Compare);
        }
        public void SortByAvarage()
        {
            Students.Sort(new Сomparison().Compare);
        }

        public double GetMaxMiddleScore()
        {
            return Students.Count != 0 ? Students.Select(x => x.AverageScore).Max() : 0;
        }
        public IEnumerable<Student> GetMasterStudents()
        {
            return Students.Where(x => x.Educations == Education.Specialist);
        }
        public List<Student> AverageMarkGroup(double value)
        {
            return Students.Where(x => x.AverageScore >= value).ToList();

        }




       
    }
}
