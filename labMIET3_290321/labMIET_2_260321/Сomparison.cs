// Определить вспомогательный класс, реализующий интерфейс
// System.Collections.Generic.IComparer<Student>, который можно использовать
// для сравнения объектов типа Student по среднему баллу.

using labMIET_2_260321;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace labMIET3_290321
{
    class Сomparison : IComparer<Student>            //вспомогательный класс 
    {
        public int Compare([AllowNull] Student x, [AllowNull] Student y)
        {
            if (Student.GetTotalMark(x.Exams).Equals(Student.GetTotalMark(y.Exams)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
