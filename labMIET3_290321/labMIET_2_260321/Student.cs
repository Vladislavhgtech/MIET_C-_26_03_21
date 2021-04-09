using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static labMIET_2_260321.Program;


namespace labMIET_2_260321
{
    class Student : Person
    {
        Education education;
        int group;
        List<Test> offsets = new List<Test>(); //список зачётов
        List<Exam> exams = new List<Exam>(); // список экзаменов
        int capacity = 0;
        char key_for_stop_adding;
        //List<Exam> exams = new List<Exam>();



        public Student(Person person, Education education, int group)
        {
            name = person.GetName();
            secondName = person.GetSecondName();
            birth = person.Date;
            this.education = education;
            try
            {
                if (group < 100 || group > 600)
                    throw new Exception("Введенное число не корректно с лимитом группы");
                this.group = group;
            }
            catch (Exception)
            {
                this.group = 101;
            }
        }
        public Student()
        {
            Person person = new Person();
            name = person.GetName();
            secondName = person.GetSecondName();
            birth = person.Date;
            education = Education.none;
            group = 101;
        }

        public Student(Person student, int groupNumber, Education education, List<Exam> examList, List<Test> testList)              
        {
            //_student = student;
            group = groupNumber;
            this.education = education;
            exams = examList;
            offsets = testList;
        }
        public Person GetPerson()
        {
            Person p1 = new Person();
            p1.SetName(name);
            p1.SetSecondName(secondName);
            p1.Date = birth;
            return p1;
        }

        public Education Educations
        {
            get { return education; }
            set { education = value; }
        }

        public Person PersonBase
        {
            get { return new Person(name,secondName, birth); }
            set
            {
                name = value.GetName();
                secondName = value.GetSecondName();
                birth = value.GetBirth();
            }
        }


        public Education GetEducation()
        {
            return education;
        }
        public int GetGroup()
        {
            return group;
        }
        public List<Exam> GetExam()
        {
            return exams;
        }
        public void SetPerson(Person person)
        {

            name = person.GetName();
            secondName = person.GetSecondName();
            birth = person.Date;
        }
        public void SetEducation(Education education)
        {
            this.education = education;

        }
        public void SetGroup(int group)
        {
            this.group = group;
        }
        public void AddOffsets()
        {
            do
            {
                bool state = false;
                key_for_stop_adding = 't';
                Console.Write("Enter the name of offset: ");
                string tempname = Console.ReadLine();
                Console.Write("\nEnter state (1 passed, 0 unpassed): ");
                char tempstate = Char.Parse(Console.ReadLine());
                if (tempstate == '1')
                    state = true;
                else
                    state = false;
                //b tempmark = Convert.ToInt32(Console.ReadLine());
                Test offset = new Test(tempname, state);
                offsets.Add(offset);
                Console.WriteLine("\n if you want to stop addint press n, else press any key");
                key_for_stop_adding = char.Parse(Console.ReadLine());
            } while (key_for_stop_adding != 'n');
        }

        public void AddExam()
        {
            Console.WriteLine("Enter the list of Exams\n");
            do
            {

                Console.Write("Enter the name of exam: ");
                string tempname = Console.ReadLine();
                Console.Write("\nEnter the mark of exam: ");
                int tempmark = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter the date of exam (format //year//mount//day): ");
                DateTime tempDate = new DateTime(int.Parse("2021"), int.Parse("03"), int.Parse("27"));
                Console.WriteLine("\n if you want to stop addint press n, else press any key");
                Exam temp = new Exam(tempname, tempmark, tempDate);
                exams.Add(temp);
                key_for_stop_adding = char.Parse(Console.ReadLine());
            } while (key_for_stop_adding != 'n');
            //this.exams.AddRange(exams);
        }
        public static double GetTotalMark(List<Exam> exams)
        {
            Exam temp = new Exam();
            double totalMark = 0;
            int quantity = 1;
            foreach (object o in exams)
            {
                temp = (Exam)o;
                totalMark += temp.getExamMark();
                quantity++;
            }
            if (quantity != 0)
                totalMark = totalMark / (quantity - 1);
            return totalMark;
        }
        public bool GetIndex(int index)
        {
            if (index == (int)education)
                return true;
            return false;
        }
        public void SetExam(List<Exam> exam)
        {
            exams = exam;
        }

        public List<Exam> Exams
        {
            get
            {
                return exams;
            }

            private set
            {
                exams = value;
            }
        }

        public double AverageScore
        {
            get
            {
                double allScore = 0;
                foreach (Exam examsPass in exams)
                {
                    allScore += examsPass.getExamMark();
                }
                return allScore / exams.Count;
            }
        }
        public new string ToString()
        {
            Exam temp1 = new Exam();
            string result = " ФИО: ";
            string temp = " ";
            result += name.ToString() + "  " + secondName.ToString() + " " + Date.ToString() + " Образование ";
            result += education + " Группа  ";
            result += group.ToString() + " \n Список Экзаменов \n";
            foreach (object i in exams)
            {
                temp1 = (Exam)i;
                temp += temp1.ToString() + '\n';
            }
            result += temp;
            temp = " ";
            Test test = new Test();
            foreach (object i in offsets)
            {
                test = (Test)i;
                temp += test.ToString() + '\n';
            }
            result += temp;
            return result;
        }
        public new string ToShortString()
        {
            string result = "ФИО: ";
            result += name.ToString() + "  " + secondName.ToString() + " " + Date.ToString() + " Образование: ";
            result += education + " Группа:";
            result += group.ToString() + " Средний балл:";
            result += GetTotalMark(exams).ToString();
            return result;
        }
        //public override object DeepCopy()
        //{
        //    Student a = new Student();
        //    a.SetName(name);
        //    a.SetSecondName(secondName);
        //    a.birth = birth;
        //    a.education = education;
        //    a.group = group;
        //    a.offsets = offsets;
        //    a.exams = exams;
        //    return a;
        //}
        public IEnumerator GetEnumerator()
        {
            foreach (object o in offsets)
            {
                yield return o;
            }
            foreach (object o in exams)
            {
                yield return o;
            }

        }
        public IEnumerable GetEnumarator(int MarkBorder)
        {
            foreach (Exam current in exams)
            {
                int temp = current.getExamMark();
                if (MarkBorder < temp)
                {
                    yield return current;
                }
            }
        }

      
    }

}
