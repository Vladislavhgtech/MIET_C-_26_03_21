using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labMIET_1_1_260321
{
    class Student
    {
        Person person;
        Education education;
        int group;
        List<Exam> exams = new List<Exam>();

        public Student(Person person, Education education, int group)
        {
            this.person = person;
            this.education = education;
            this.group = group;
        }
        public Student()
        {
            person = new Person();
            education = Education.none;
            group = 0000;
        }

        public Person GetPerson()
        {
            return person;
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
            this.person = person;
        }
        public void SetEducation(Education education)
        {
            this.education = education;

        }
        public void SetGroup(int group)
        {
            this.group = group;
        }
        public void SetExams(List<Exam> exams)
        {
            this.exams.Concat(exams);
        }

        public double GetTotalMark(List<Exam> exams)
        {
            double totalMark = 0;
            int quantity = 1;
            foreach (Exam currentMark in exams)
            {
                totalMark += currentMark.getExamMark();
                quantity += 1;
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
        public void AddExam(List<Exam> exam)
        {
            exams = exam;
        }

        public override string ToString()
        {
            string result = " ФИО: ";
            string temp = " ";
            result += person.ToString() + " Образование ";
            result += education + " Группа  ";
            result += group.ToString() + " \n Список Экзаменов \n";
            foreach (Exam i in exams)
            {
                temp += i.ToString() + '\n';
            }
            result += temp;
            return result;
        }

        virtual public string ToShortString()
        {
            string result = "ФИО: ";
            result += person.ToString() + " Образование: ";
            result += education + " Группа:";
            result += group.ToString() + " Средний балл:";
            result += GetTotalMark(exams).ToString();
            return result;
        }

    }
}
