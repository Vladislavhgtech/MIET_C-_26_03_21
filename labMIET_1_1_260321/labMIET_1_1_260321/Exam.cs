using System;
using System.Collections.Generic;
using System.Text;

namespace labMIET_1_1_260321
{
    class Exam
    {
        // создаём закрытые поля 

        string examName;
        int examMark;
        DateTime examDate;

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


    }
}
