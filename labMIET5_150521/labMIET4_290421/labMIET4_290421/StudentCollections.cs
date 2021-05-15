using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static labMIET4_290421.Program;

namespace labMIET4_290421
{
    delegate void StudentListHandler(object source, StudentListHandlerEventArg args);

    class StudentCollection
    {
        private List<Student> Students;
        public event StudentListHandler StudentCountChange;
        public event StudentListHandler StudentReferenceChange;

        public void AddDefaults(Student student)
        {
            Students = new List<Student>();
            StudentCountChange?.Invoke(this, new StudentListHandlerEventArg(CollectionName, "Add element", student));
            Students.Add(student);
        }

        public void AddStudents(Student[] students)
        {
            Students = new List<Student>(students.Length);
            for (int i = 0; i < students.Length; i++)
            {
                StudentCountChange?.Invoke(this, new StudentListHandlerEventArg(CollectionName, "Add element", students[i]));
            }
            Students.AddRange(students);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Students.Count; i++)
            {
                result += Students[i].ToString() + "|";
            }
            return result;
        }

        public string ToShortString()
        {
            string result = "";
            for (int i = 0; i < Students.Count; i++)
            {
                result += Students[i].ToShortString() + Students[i].TestList.Count + " " + Students[i].ExamList + " " + "|";
            }
            return result;
        }

        public void SurnameSort()
        {
            Student[] students = Students.ToArray();
            Array.Sort(students);
            Students.Clear();
            Students.AddRange(students);
        }

        public void BirthDateSirt()
        {
            Students.Sort(new Person());
        }

        public void AverageMarkSort()
        {
            Students.Sort(new StudentComparer());
        }

        public double MaxAverageMark
        {
            get
            {
                if (Students.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return Students.Max(n => n.AverageScore);
                }
            }
        }

        public IEnumerable<Student> Master
        {
            get
            {
                return Students.Where(n => n.Educations == Education.Specialist);
            }
        }

        public List<Student> AverageMarkGroup(double value)
        {
            var list = Students.Where(n => n.AverageScore == value).GroupBy(n => n.Educations);
            List<Student> students = new List<Student>();
            foreach (var n in list)
            {
                students.Add((Student)n);
            }
            return students;
        }

        public string CollectionName { get; set; }

        public bool Remove(int j)
        {
            if (j >= Students.Count || j < 0)
            {
                return false;
            }
            StudentCountChange?.Invoke(this, new StudentListHandlerEventArg(CollectionName, "Remove element", Students[j]));
            Students.RemoveAt(j);
            return true;
        }

        public Student this[int index]
        {
            get
            {
                return Students[index];
            }
            set
            {
                Students[index] = value;
                StudentReferenceChange?.Invoke(this, new StudentListHandlerEventArg(CollectionName, "Change element", value));
            }
        }

    }
}
