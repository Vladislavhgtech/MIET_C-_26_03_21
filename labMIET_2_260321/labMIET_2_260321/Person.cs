using System;
using System.Collections.Generic;
using System.Text;
using static labMIET_2_260321.Program;

namespace labMIET_2_260321
{
    class Person : IDateAndCopy
    {

        // объявляем закрытые поля
        protected string name;
        protected string secondName;
        protected DateTime birth = new DateTime();


        // реализуем мететод Date интерфейса
        public DateTime Date { get { return birth; } set { birth = new DateTime(1970, 01, 01); } }


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

        // переопределяем метод Equals
        public override bool Equals(object obj)
        {
            Person person2 = new Person();
            person2 = (Person)obj;
            bool fl = false;
            if (name == person2.name && secondName == person2.secondName && birth == person2.birth)
                fl = true;
            return fl;
        }

        // перегружаем операторы == и !=

        public static bool operator ==(Person person2, Person person1)
        {
            bool fl = false;
            if (person1.name == person2.name &&
            person1.secondName == person2.secondName &&
            person1.birth == person2.birth)
                fl = true;
            return fl;
        }
        public static bool operator !=(Person person2, Person person1)
        {
            bool fl = true;
            if (person1.name == person2.name &&
                person1.secondName == person2.secondName &&
                person1.birth == person2.birth)
                fl = false;
            return fl;
        }

        // переопределяем метод GetHashCode()
        public override int GetHashCode()
        {
            int commonHashCode = 0;
            int temp = name.GetHashCode();
            commonHashCode += temp;
            temp = secondName.GetHashCode();
            commonHashCode += temp;
            temp = birth.GetHashCode();
            commonHashCode += temp;
            return commonHashCode;
        }

        public object DeepCopy()
        {
            Person person2 = new Person();
            person2.name = name;
            person2.secondName = secondName;
            person2.birth = birth;
            return person2;
        }
    }


}

