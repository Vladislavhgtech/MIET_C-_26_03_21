using System;
using System.Collections.Generic;

namespace labMIET_1_1_260321
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation,
        none
    };

    class Program
    {
        static void Main(string[] args)
        {
            // проверяем работаспособность класса
            Person[] first = new Person[100];
            DateTime date = new DateTime(1985, 11, 20);


            // заполняем массив объектами класса
            for (int i = 0; i < first.Length; i++)
            {
                string name = "Andrei" + i;
                string surname = "Ivanov" + i;
                first[i] = new Person(name, surname, date);

            }

            //foreach (Person per in first)
            //{
            //    Console.WriteLine(per.ToString());
            //}

            // Заполняем квадратную матрицу

            Person[,] second = new Person[100, 100];
            for (int i = 0; i < 100; i++)
            {

                for (int j = 0; j < 100; j++)
                {
                    string name = "Semen" + i + j;
                    string surname = "Smirnov" + i + j;
                    second[i, j] = new Person(name, surname, date);
                }
            }

            //выделяем место под зубчатый массив и заполняем его

            Person[][] third = new Person[100][];
            int n = 10;
            for (int i = 0; i < 100; i++)
            {
                third[i] = new Person[n];
                n++;


            }
            n = 10;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string name = "Ivan" + i + j;
                    string surname = "Petrov" + i + j;
                    third[i][j] = new Person(name, surname, date);

                }
                n++;
            }
            //Определим время выполнения операций 
            int result1 = Environment.TickCount & Int32.MaxValue;


            Console.WriteLine(first[50].GetBirth());
            Console.WriteLine(first[62].GetName());
            Console.WriteLine(first[33].ToShortString());
            Console.WriteLine(first[56].ToString());
            first[66].SetYear(1955);
            for (int i = 20; i < 50; i++)
            {
                first[i].SetYear(1995);
            }
            Console.WriteLine("Время выполнения операций над одномерным массивом: {0}", (Environment.TickCount - result1));



            int result2 = Environment.TickCount & Int32.MaxValue;


            Console.WriteLine(second[50, 50].GetBirth());
            Console.WriteLine(second[62, 33].GetName());
            Console.WriteLine(second[33, 23].ToShortString());
            Console.WriteLine(second[56, 89].ToString());
            second[79, 99].SetYear(1945);
            for (int i = 20; i < 99; i++)
            {
                second[33, i].SetYear(1995);
            }
            Console.WriteLine("Время выполнения операций над матрицей: {0}", Environment.TickCount - result2);


            int result3 = Environment.TickCount & Int32.MaxValue;


            Console.WriteLine(third[50][23].GetSecondName());
            Console.WriteLine(third[22][5].GetName());
            Console.WriteLine(third[75][33].ToShortString());
            Console.WriteLine(third[89][23].ToString());
            third[79][17].SetYear(1955);
            for (int i = 0; i < 90; i++)
            {
                third[i][5].SetYear(1995);
            }
            Console.WriteLine("Время выполнения операций над матрицей: {0}", Environment.TickCount - result3);


            // Лабораторная работа №1 часть 2

            Student stud1 = new Student();
            Console.WriteLine(stud1.ToShortString());

            Education Bachelor = Education.Bachelor;
            Education SecondEducation = Education.SecondEducation;
            Education Specialist = Education.Specialist;
            Console.WriteLine("Индексы: \nБакалавр - " + (int)Bachelor +
                "\nВторое образование - " + (int)SecondEducation +
                               "\nСпециалист - " + (int)Specialist);

            Student stud2 = new Student(new Person("Владислав", "Московский", new DateTime(1985, 02, 11)), Bachelor, 762);
            Console.WriteLine(stud2.ToString());

            List<Exam> ex = new List<Exam>();
            ex.Add(new Exam("Информатика", 4, new DateTime(2021, 03, 20)));
            ex.Add(new Exam("Диффуры", 5, new DateTime(2021, 01, 27)));

            stud2.AddExam(ex);
            Console.WriteLine(stud2.ToString());
            Console.WriteLine(stud2.ToShortString());



        }
    }
}
