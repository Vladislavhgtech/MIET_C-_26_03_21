using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using static labMIET4_290421.Program;

namespace labMIET4_290421
{
	class Student : Person
	{
		private int _groupNumber;
		private Education _education;
		private List<Exam> _examList;
		private List<Test> _testList;
		private DateTime BirthDate;

	

		public Student(Person student, int groupNumber, Education education, List<Exam> examList, List<Test> testList)
			: base(student._Name, student._Surname, student._Birth)
		{
			//_student = student;
			_groupNumber = groupNumber;
			_education = education;
			_examList = examList;
			_testList = testList;
		}

		public Student(Person info, Education degree, int groupnumber)
		{
			Name = info.Name;
			Surname = info.Surname;
			BirthDate = info.Birth;
			_education = degree;
			_groupNumber = groupnumber;
			_testList = new List<Test>();
			_examList = new List<Exam>();
		}

		public Student() : this(new Person(), 302, Education.Specialist, new List<Exam> { new Exam() }, new List<Test> { new Test() })
		{ }
		public List<Test> TestList
		{
			get { return _testList; }
			set { _testList = value; }
		}
		public List<Exam> ExamList
		{
			get { return _examList; }
			set { _examList = value; }
		}
		public int GroupNumber
		{
			get { return _groupNumber; }
			set
			{
				if (value <= 100 || value > 699)
				{

					throw new Exception("Group number must be between 100 and 699");

				}
			}
		}


		public List<Exam> Examss
		{
			get
			{
				return _examList;
			}
			set
			{
				_examList = value;
			}
		}

		public List<Test> Testss
		{
			get
			{
				return _testList;
			}
			set
			{
				_testList = value;
			}
		}

		public Education Educations
		{
			get { return _education; }
			set { _education = value; }
		}

		public double AverageScore
		{
			get
			{
				double allScore = 0;
				foreach (Exam examsPass in ExamList)
				{
					allScore += examsPass._Score;
				}
				return allScore / ExamList.Count;
			}
		}

		public bool this[Education education]
		{
			get { return _education == education; }
		}



		public override string ToString()
		{
			string result = Name + ";" + Surname + ";" + BirthDate.ToString() + ";" + Educations.ToString() + ";" + GroupNumber + ";";
			for (int i = 0; i < TestList.Count; i++)
			{
				result += _testList[i].ToString();
			}
			for (int i = 0; i < ExamList.Count; i++)
			{
				result += _examList[i].ToString();
			}
			result += "|";
			return result;
		}


		public virtual string ToShortString()
		{
			return string.Format(" Students: {0} \n Educations: {1} \n  Group Number: {2} \n  Average score: {3}",/* Students,*/ Educations, GroupNumber, AverageScore);
		}


		public override object DeepCopy()
		{
			Student other = (Student)MemberwiseClone();
			other.TestList = new List<Test>();
			other.ExamList = new List<Exam>();
			foreach (Exam exam in ExamList)
				other.ExamList.Add((Exam)exam.DeepCopy());
			foreach (Test test in TestList)
				other.TestList.Add((Test)test.DeepCopy());
			return other;

		}

		// метод копирования с использованием сериализации
		public Student TDeepCopy()
		{
			if (!typeof(Student).IsSerializable)
			{
				throw new ArgumentException("The type must be serializable.", "source");
			}

			if (Object.ReferenceEquals(this, null))
			{
				return default(Student);
			}

			IFormatter formatter = new BinaryFormatter();
			Stream stream = new MemoryStream();
			using (stream)
			{
				formatter.Serialize(stream, this);
				stream.Seek(0, SeekOrigin.Begin);
				return (Student)formatter.Deserialize(stream);
			}
		}

		// Метод сохранения данных объекта с помощью сериализации
		public bool Save(string filename)
		{
			if (!(File.Exists(filename)))
			{
				Console.WriteLine("File does not exist");
				Console.WriteLine("File was created");
			}

			if (!typeof(Student).IsSerializable)
			{
				return false;
			}

			if (Object.ReferenceEquals(this, null))
			{
				return false;
			}

			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
			{
				try
				{
					formatter.Serialize(stream, this);
				}
				catch
				{
					return false;
				}
			}

			return true;
		}





		protected bool Equals(Student other)
		{
			return _education == other._education &&
				_groupNumber == other._groupNumber &&
				Equals(_examList, other._examList) &&
				Equals(_testList, other._testList);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Student)obj);
		}


		public static bool operator ==(Student left, Student right)
		{
			return ReferenceEquals(left, right);
		}

		public static bool operator !=(Student left, Student right)
		{
			return !ReferenceEquals(left, right);
		}

		public void AddExam(params Exam[] exam)
		{
			if (exam != null)
			{
				ExamList.AddRange(exam);
			}

		}
		public void AddTest(params Test[] test)
		{
			if (test != null)
			{
				TestList.AddRange(test);
			}

		}
		public IEnumerable GetExamMoreThan(double value)
		{

			foreach (Exam ex in ExamList)
			{
				if (ex._Score > value)
				{
					yield return ex;
				}
			}
		}

		public IEnumerable IfExamAndTestPass()
		{

			foreach (Exam ex in ExamList)
			{
				if (ex._Score > 2)
				{
					yield return ex;
				}
			}
			foreach (Test test in TestList)
			{
				if (test._ifPass > 2)
				{
					yield return test;
				}
			}
		}

		public IEnumerable GetTestAndExam()
		{
			foreach (Exam exam in ExamList)
			{
				yield return exam;
			}
			foreach (Test test in TestList)
			{
				yield return test;
			}
		}
		public Person PersonBase
		{
			get { return new Person(_Name, _Surname, _Birth); }
			set
			{
				_Name = value._Name;
				_Surname = value._Surname;
				_Birth = value._Birth;
			}
		}


		public bool Load(string filename)
		{
			if (!(File.Exists(filename)))
			{
				Console.WriteLine("File does not exist");
				Console.WriteLine("File was created");
			}

			if (!typeof(Student).IsSerializable)
			{
				return false;
			}

			if (Object.ReferenceEquals(this, null))
			{
				return false;
			}

			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
			{
				try
				{
					Student student = (Student)formatter.Deserialize(stream);
					Name = student.Name;
					Surname = student.Surname;
					BirthDate = student.BirthDate;
					_education= student._education;
					GroupNumber = student.GroupNumber;
					_testList = student.Testss;
					_examList = student.Examss;
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		// метод добавления в один из списков класса нового элемента с консоли
		public bool AddFromConsole()
		{
			Console.Write("Input Exam info (Format: Math;95;27.03.2000): ");
			string info = Console.ReadLine();

			try
			{
				string[] vs = info.Split(new char[] { ';' });

				Exam exam = new Exam();
				exam._ObjectName = vs[0];
				exam._Score = Convert.ToInt32(vs[1]);

				string[] vs1 = vs[2].Split(new char[] { '.' });
				exam.Date = new DateTime(Convert.ToInt32(vs1[2]), Convert.ToInt32(vs1[1]), Convert.ToInt32(vs1[0]));

				Examss.Add(exam);
			}
			catch
			{
				return false;
			}

			return true;
		}
	}




}

