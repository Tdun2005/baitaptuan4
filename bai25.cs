using System;
using System.Collections.Generic;

namespace University
{
    // Interface KPIEvaluator
    public interface KPIEvaluator
    {
        double CalculateKPI();
    }

    // Abstract class Person
    public abstract class Person : KPIEvaluator
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        protected string BankAccount { get; set; }

        public Person(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public abstract string GetRole();
        public abstract double CalculateKPI();
    }

    // Class TeachingAssistant
    public class TeachingAssistant : Person
    {
        public string EmployeeID { get; set; }
        private int NumberOfCourses { get; set; }

        public TeachingAssistant(string name, int age, string gender, string employeeID, int numberOfCourses)
            : base(name, age, gender)
        {
            EmployeeID = employeeID;
            NumberOfCourses = numberOfCourses;
        }

        public override string GetRole()
        {
            return "Teaching Assistant";
        }

        public override double CalculateKPI()
        {
            return NumberOfCourses * 5.0;
        }
    }

    // Class Lecturer
    public class Lecturer : Person
    {
        public string EmployeeID { get; set; }
        private int NumberOfPublications { get; set; }

        public Lecturer(string name, int age, string gender, string employeeID, int numberOfPublications)
            : base(name, age, gender)
        {
            EmployeeID = employeeID;
            NumberOfPublications = numberOfPublications;
        }

        public override string GetRole()
        {
            return "Lecturer";
        }

        public override double CalculateKPI()
        {
            return NumberOfPublications * 7.0;
        }
    }

    // Class Professor (sealed to prevent inheritance)
    public sealed class Professor : Lecturer
    {
        public static int CountProfessors = 0;
        private int NumberOfProjects { get; set; }

        public Professor(string name, int age, string gender, string employeeID, int numberOfPublications, int numberOfProjects)
            : base(name, age, gender, employeeID, numberOfPublications)
        {
            NumberOfProjects = numberOfProjects;
            CountProfessors++;
        }

        public override string GetRole()
        {
            return "Professor";
        }

        public override double CalculateKPI()
        {
            return base.CalculateKPI() + NumberOfProjects * 10.0;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            Console.Write("Nhập số lượng đối tượng (2 đến 10): ");
            int n = int.Parse(Console.ReadLine());

            while (n < 2 || n > 10)
            {
                Console.Write("Số lượng không hợp lệ. Vui lòng nhập lại (2 đến 10): ");
                n = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                Person person = CreatePerson();
                people.Add(person);
            }

            DisplayPeople(people);
            Console.WriteLine($"Số lượng Professors: {Professor.CountProfessors}");
        }

        static Person CreatePerson()
        {
            while (true)
            {
                Console.Write("Nhập loại đối tượng (ta, lec, gs): ");
                string type = Console.ReadLine().ToLower();

                Console.Write("Nhập tên: ");
                string name = Console.ReadLine();
                Console.Write("Nhập tuổi: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Nhập giới tính: ");
                string gender = Console.ReadLine();

                switch (type)
                {
                    case "ta":
                        Console.Write("Nhập Employee ID: ");
                        string taEmployeeID = Console.ReadLine();
                        Console.Write("Nhập số lượng khóa học hỗ trợ: ");
                        int numberOfCourses = int.Parse(Console.ReadLine());
                        return new TeachingAssistant(name, age, gender, taEmployeeID, numberOfCourses);

                    case "lec":
                        Console.Write("Nhập Employee ID: ");
                        string lecEmployeeID = Console.ReadLine();
                        Console.Write("Nhập số lượng bài báo đã xuất bản: ");
                        int numberOfPublications = int.Parse(Console.ReadLine());
                        return new Lecturer(name, age, gender, lecEmployeeID, numberOfPublications);

                    case "gs":
                        Console.Write("Nhập Employee ID: ");
                        string gsEmployeeID = Console.ReadLine();
                        Console.Write("Nhập số lượng bài báo đã xuất bản: ");
                        int gsNumberOfPublications = int.Parse(Console.ReadLine());
                        Console.Write("Nhập số lượng dự án đã chủ trì: ");
                        int numberOfProjects = int.Parse(Console.ReadLine());
                        return new Professor(name, age, gender, gsEmployeeID, gsNumberOfPublications, numberOfProjects);

                    default:
                        Console.WriteLine("Loại đối tượng không hợp lệ. Vui lòng nhập lại.");
                        break;
                }
            }
        }

        static void DisplayPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"Tên: {person.Name}, Tuổi: {person.Age}, Giới tính: {person.Gender}, Vai trò: {person.GetRole()}, KPI: {person.CalculateKPI()}");
            }
        }
    }
}
