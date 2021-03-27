# Лабораторная работа 1
## Вариант 1. Требования к программе

## Требования к программе, общие для всех вариантов

0. [Определить класс Person](#Определить класс Person)
1. [В классе Person определить конструкторы](#В классе Person определить конструкторы)
2. [В классе Person определить свойства c методами get и set](#В классе Person определить свойства c методами get и set)
3. [В классе Person определить дополнительно](#В классе Person определить)
4. [Определить тип Education - перечисление(enum)](#Определить тип Education - перечисление(enum))
5. [Определить класс Exam](#Определить класс Exam)
5. [Задния варианта 1](#Задния варианта 1)

    
## Определить класс Person

Определить класс Person, который имеет
- закрытое поле типа string, в котором хранится имя;
- закрытое поле типа string, в котором хранится фамилия;
- закрытое поле типа System.DateTime для даты рождения.

-----------------

## В классе Person определить конструкторы

- конструктор c тремя параметрами типа string, string, DateTime для
инициализации всех полей класса;
- конструктор без параметров, инициализирующий все поля класса
некоторыми значениями по умолчанию.

-----------------

## В классе Person определить свойства c методами get и set

- свойство типа string для доступа к полю с именем;
- свойство типа string для доступа к полю с фамилией;
- свойство типа DateTime для доступа к полю с датой рождения;
- свойство типа int c методами get и set для получения информации(get) и
изменения (set) года рождения в закрытом поле типа DateTime, в котором
хранится дата рождения.

-----------------

## В классе Person определить

- перегруженную(override) версию виртуального метода string ToString() для
формирования строки со значениями всех полей класса;
- виртуальный метод string ToShortString(), который возвращает строку,
содержащую только имя и фамилию.

-----------------


____
### Далее выполнялись задания варианта 1


## Определить класс Exam

- свойство типа string, в котором хранится название предмета;
- свойство типа int, в котором хранится оценка;
- свойство типа System.DateTime для даты экзамена.


-----------------


## Определить класс Exam

- свойство типа string, в котором хранится название предмета;
- свойство типа int, в котором хранится оценка;
- свойство типа System.DateTime для даты экзамена.


-----------------

## Задния варианта 1

### В классе Exam определить:
- конструктор с параметрами типа string, int и DateTime для инициализации
всех свойств класса;
- конструктор без параметров, инициализирующий все свойства класса
некоторыми значениями по умолчанию;
- перегруженную(override) версию виртуального метода string ToString() для
формирования строки со значениями всех свойств класса.

### Определить класс Student, который имеет
- закрытое поле типа Person, в котором хранятся данные студента;
- закрытое поле типа Education для информации о форме обучения;
- закрытое поле типа int для номера группы;
- закрытое поле типа Exam *+ для информации об экзаменах, которые сдал
студент.

### В классе Student определить конструкторы:
- конструктор c параметрами типа Person, Education, int для инициализации
соответствующих полей класса;
- конструктор без параметров, инициализирующий поля класса значениями
по умолчанию.

### И так далее