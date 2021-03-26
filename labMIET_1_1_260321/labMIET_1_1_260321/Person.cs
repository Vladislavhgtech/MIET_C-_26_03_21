using System;
using System.Collections.Generic;
using System.Text;

namespace labMIET_1_1_260321
{
    class Person
    {
        // объявляем закрытые поля
        private string name;
        private string secondName;
        private DateTime birth = new DateTime();

        // объявляем конструктор с тремя параметрами
        public Person(string name, string secondName, DateTime birth)
        {
            this.name = name;
            this.secondName = secondName;
            this.birth = birth;
        }

        // объявляем конструктор без параметров
        public Person()
        {
            name = "";
            secondName = "";
            birth = new DateTime(1970, 01, 01);
        }

        // для каждого закрытого поля создаём методы Get и Set

        public string GetName()
        {
            return name;
        }
        public string GetSecondName()
        {
            return secondName;
        }
        public DateTime GetBirth()
        {
            return birth;
        }
        public int getYear()
        {
            return birth.Year;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetSecondName(string secondName)
        {
            this.secondName = secondName;
        }
        public void SetDate(DateTime birth)
        {
            this.birth = birth;
        }

        public void SetYear(int Year)
        {
            birth.AddYears(Year);
        }

        public override string ToString()
        {
            return string.Format("Имя: {0}, Фамилия: {1}, Дата рождения: {2}", name, secondName, birth.ToString());
        }
        virtual public string ToShortString()
        {
            return string.Format("Имя: {0}, Фамилия: {1}", name, secondName);
        }






    }



}
