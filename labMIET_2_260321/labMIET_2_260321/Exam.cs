using System;
using System.Collections.Generic;
using System.Text;
using static labMIET_2_260321.Program;

namespace labMIET_2_260321
{
    class Exam : IDateAndCopy
        {
            // создаём закрытые поля 

            string examName;
            int examMark;
            DateTime examDate;

            // реализуем метод Date интерфейса
            public DateTime Date { get { return examDate; } set { examDate = new DateTime(1970, 01, 01); } }

            // создаём два конструктора 
            public Exam(string examName, int examMark, DateTime examDate)
            {
                this.examName = examName;
                this.examMark = examMark;
                this.examDate = examDate;
            }

            public Exam()
            {
                examName = "None";
                examMark = 0;
                examDate = new DateTime(1970, 01, 01);
            }

            public override string ToString()
            {
                return string.Format("Имя: {0}, Фамилия: {1}, Дата рождения: {2}", examName, examMark, examDate.ToString());
            }

            public int getExamMark()
            {
                return examMark;
            }

            // реализуем метод интерфейса 
            public object DeepCopy()
            {
                Exam exam2 = new Exam();
                exam2.examName = examName;
                exam2.examMark = examMark;
                exam2.examDate = examDate;
                return exam2;
            }
        }

}

