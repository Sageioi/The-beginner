using System;
using static System.Console;
/*
Hello Guys, This is the first class I created in C#.
This has been an exciting moment for me.
I am a non-tech student implementing my first class in a language you can call (JAVA + C++).
The Class I created employs the use of fields, methods, a property,a constructor.
It makes use of overriding and overloading.
*/
namespace TryingOut
{
    class Student
    {
        // Declaring fields
        private string nameOfStudent;
        private const int schoolHours = 8;
        private int hoursUsed;
        
        // using a Property
        public int HoursUsed
        {
            get
            {
                return hoursUsed;
            }
            set
            {
                if (value > 0)
                {
                    hoursUsed = value;
                }
                else
                {
                    hoursUsed = 0;
                }
            }
        }
        
        // Using methods
        public void Comment()
        {
            WriteLine("Teacher's Comment");
        }
        public string DetrHours(int hours)
        {
            Comment();
            hoursUsed = hours; 
            if (hoursUsed <= schoolHours && hoursUsed >= 6)
            {
                return "Student is serious and commited today.";
            }
            else if (hoursUsed <= 5 && hoursUsed >= 3)
            {
                return "Student is committing fairly well today.";
            }
            else
            {
                return "Student is not serious today.";
            }
        }
        // Overloading
        // * Due for experiments
        public string DetrHours(int hours, int fruitfulHours)
        {
            Comment();
            hoursUsed = hours - fruitfulHours;
            if (hoursUsed <= schoolHours && hoursUsed >= 6)
            {
                return "Student is serious and commited today.";
            }
            else if (hoursUsed <= 5 && hoursUsed >= 3)
            {
                return "Student is committing fairly well today.";
            }
            else
            {
                return "Student is not serious today.";
            }
        }
        // Overriding
        public override string ToString()
        {
            return "Student Name is " +nameOfStudent+ ", Hours used is "+hoursUsed;
        }
        
        // Constructor

        public Student(string name)
        {
            nameOfStudent = name;
            WriteLine("Student Name is {0}",nameOfStudent);
            
        }

        public Student(string firstname, string secondname)
        {
            nameOfStudent = firstname + "" + secondname;
            WriteLine("Student Name is {0}",nameOfStudent);
        }
        
        
    }

    class RealWorld
    {
        public static void Main(string[] args)
        {
            Write("Please Note: The maximum hours a student can spend in a school is 8.\n");
            Write("Student Name: ");
            string sname = ReadLine(); 
            Write("Hours Spent in School: ");
            string hour = ReadLine();
            int shour = Convert.ToInt32(hour);
            Student model = new Student(sname);
            model.HoursUsed = shour;
            string hours = model.DetrHours(model.HoursUsed);
            WriteLine(hours);
            WriteLine(model.ToString());
        }
    }
}