using System;

namespace labMIET_2_260321
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

        // определяем интерфейс из лабороторной работы №2
        public interface IDateAndCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }

        static void Main(string[] args)
        {
            // Лабораторная работа №2

            // Создать два объекта типа Person с совпадающими данными и проверить,
            //что ссылки на объекты не равны, а объекты равны, вывести значения хэшкодов для объектов.


            Person a = new Person("Владислав", "Московский", new DateTime(1985, 11, 02));
            Person b = new Person("Владислав", "Московский", new DateTime(1985, 11, 02));

            Console.WriteLine(" Object A: " + a.ToString() + " \n Object B: " + b.ToString());
            Console.WriteLine("\n Изменим имена объектов и сраним их \n");

            b.SetName("Серёжа");
            Console.WriteLine(" Object A: " + a.ToString() + " \n Object B: " + b.ToString());
            Console.WriteLine("\n Как видно адреса ссылок на объекты на совпадают\n" +
                "b.Изменим имя на Владислав и проверим значения\n");
            b.SetName("Владислав");
            if (a == b)
                Console.WriteLine("Объекты равны\n");
            else
                Console.WriteLine("Объекты не равны\n");

            Console.WriteLine("Hash Code of object A " + a.GetHashCode());
            Console.WriteLine("Hash Code of object B " + b.GetHashCode());

            // Создать объект типа Student, добавить элементы в список экзаменов и
            // зачетов, вывести данные объекта Student. 

            Student stud1 = new Student(new Person("Ольга", "Смирнова", new DateTime(1999, 06, 23)), Education.Bachelor, 762);
            Console.WriteLine(stud1.ToString());
            Person studperson = stud1.GetPerson();
            Console.WriteLine(studperson.ToString());


            // С помощью метода DeepCopy() создать полную копию объекта Student.
            // Изменить данные в исходном объекте Student и вывести копию и
            // исходный объект, полная копия исходного объекта должна остаться без
            // изменений.

            // В блоке try/catch присвоить свойству с номером группы некорректное
            // значение, в обработчике исключения вывести сообщение, переданное
            // через объект - исключение.
            // 6.С помощью оператора foreach для итератора, определенного в классе
            // Student, вывести список всех зачетов и экзаменов.
            //
            // 7.С помощью оператора foreach для итератора с параметром,
            // определенного в классе Student, вывести список всех экзаменов с
            // оценкой выше 3.

            Student stud2 = new Student();
            object stud3 = stud1.DeepCopy();
            Console.WriteLine(" first student" + stud1.ToString());
            Console.WriteLine(" second student" + stud3.ToString());
            Console.WriteLine("first and second student ofter changes\n");
            stud1.SetName("Екатерина");

            Console.WriteLine("We changed the name of first student and show both students\n");
            Console.WriteLine(" first student" + stud1.ToString());
            Console.WriteLine(" second student" + stud3.ToString());
            Console.WriteLine("Спиcок экзаменов и зачетов");
            foreach (object t in stud1)
            {
                if (t is Exam)
                {
                    Exam temp = (Exam)t;
                    Console.WriteLine(temp.ToString());
                }
                else
                {
                    Test temp = (Test)t;
                    Console.WriteLine(temp.ToString());
                }
            }
            Console.WriteLine("Список экзаменов у который оценка больше 3");
            foreach (object t in stud1.GetEnumarator(3))
            {
                Exam temp = (Exam)t;
                Console.WriteLine(temp.ToString());
            }

            Console.ReadLine();

        }



    }
}
