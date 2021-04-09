using labMIET3_290321;
using System;
using System.Linq;

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

        
        public interface IDateAndCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }

        static void Main(string[] args)
        {
            // Лабораторная работа №3

            //        1. Создать объект типа StudentCollection. Добавить в коллекцию несколько
            //        различных элементов типа Student и вывести объект StudentCollection.

            StudentCollection studentCollection = new StudentCollection();
            studentCollection.AddStudents(
                    TestCollections.GetStudent(5),
                    TestCollections.GetStudent(2),
                    TestCollections.GetStudent(1),
                    TestCollections.GetStudent(3),
                    TestCollections.GetStudent(4)
                );



            /*  2. Для созданного объекта StudentCollection вызвать методы,
                выполняющие сортировку списка List<Student> по разным критериям, и
                после каждой сортировки вывести данные объекта.Выполнить
                сортировку:
                - по фамилии студента; 
                - по дате рождения;
                - по среднему баллу
                
            3. Вызвать методы класса StudentCollection, выполняющие операции со
            списком List<Student>, и после каждой операции вывести результат
            операции. Выполнить
            - вычисление максимального значения среднего балла для элементов списка;
            - фильтрацию списка для отбора студентов с формой обучения
            Education.Specialist;
            - группировку элементов списка по значению среднего балла;
            вывести все группы элементов.
            
            4. Создать объект типа TestCollections. Вызвать метод для поиска в
            коллекциях первого, центрального, последнего и элемента, не
            входящего в коллекции. Вывести значения времени поиска для всех
            четырех случаев. Вывод должен содержать информацию о том, к какой
            коллекции и к какому элементу относится данное значение.*/
             
             
             

            studentCollection.SortByName();
            Console.WriteLine("Sorted by Name: \n {0}\n", string.Join(" ; ", studentCollection.Students.Select(x => x.GetName()).ToArray()));
            studentCollection.SortByDate();
            Console.WriteLine("Sorted by Date: \n {0}\n", string.Join(" ; ", studentCollection.Students.Select(x => x.GetName()).ToArray()));
            studentCollection.GetMaxMiddleScore();
            Console.WriteLine("Sorted by miiddle : \n {0}\n", string.Join(" ; ", studentCollection.Students.Select(x => x.GetName()).ToArray()));
            Console.WriteLine("Maximum middle Score: {0}\n", studentCollection.GetMaxMiddleScore());
            Console.WriteLine("Person with Education = Master :\n {0}\n", string.Join(" ; ", studentCollection.GetMasterStudents().Select(x => x.GetName()).ToArray()));



            int value = 3;
            Console.WriteLine("Students with middle Score more then {0}:\n {1}\n", value,
                string.Join(" ; ", studentCollection.AverageMarkGroup(value).Select(x => x.GetName()).ToArray()));

            TestCollections test = new TestCollections(1);
            Console.WriteLine("Searching time:");
            test.MeasureTime();
            Console.ReadKey();


        }


    }
}
