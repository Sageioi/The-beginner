/* So far I want to build a student/staff performance monitoring system employing the
 four pillars of object oriented programming
 1. Encapsulation
 2. Inheritance
 3. Polymorphism
 4. Absraction
 
Planning Method --> Practice Learning
*/

using System;
using static System.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace tegasharp
{
    // I made use of abstraction
    abstract class Model
    {
        public string Student;
        public static string StudentType;
        public string School;
        public const int HoursUsed = 8;
        public abstract int PMetrics { get; set; }

        public virtual string StudentInfo()
        {
            return "";

        }

        public virtual void StudentSum(params string[] a)
        {
            foreach (string i in a)
            {
                WriteLine("Student Names are {0}", a);
            }
        }

        public Model()
        {
            WriteLine("Student Records so far.");
        }

        public static void ModelCreator(string stype, string mtype)
        {
            StudentType = stype;
            if (StudentType == "Student")
            {
                WriteLine("Student Model has been created");
            }
            else if (StudentType == "Pupil")
            {
                WriteLine("Pupil Model has been created");
            }
        }

        public abstract void MetricsMap(int m);
    }

    class Primary : Model
    {
        private int pmetrics;

        public override string StudentInfo()
        {
            return "You are accessing the records of a primrary school student";
        }

        public override int PMetrics
        {
            get { return pmetrics; }
            set
            {
                if (value > 69)
                {
                    pmetrics = 1;
                }

                else if (value > 59)
                {
                    pmetrics = 2;
                }
                else if (value > 49)
                {
                    pmetrics = 3;

                }
                else
                {
                    pmetrics = 4;
                }
            }

        }

        public Primary(string student, string school) : base()
        {
            Student = student;
            School = school;
            WriteLine("Student Name is {0} of {1} school(s)", student, school);
        }

        public void StudentSum(string a)
        {
            WriteLine("Student Names are {0}\n", a);
            WriteLine("His performance is on grade {0}", pmetrics);
        }

        public override void MetricsMap(int metrics)
        {
            pmetrics = metrics;
            if (pmetrics == 1)
            {
                WriteLine("He / She is A / First Class Student.");
            }
            else if (pmetrics == 2)
            {
                WriteLine("He / She is B / Second Class Student.");
            }
            else if (pmetrics == 3)
            {
                WriteLine("He / She is C / Third Class Student.");
            }
            else if (pmetrics == 4)
            {
                WriteLine("He / She needs to improve.");
            }
            else
            {
                WriteLine("Metric Input Invalid.");
            }


        }
    }

    class Secondary : Model
    {
        private int ametrics;

        public override string StudentInfo()
        {
            return "You are accessing the records of a secondary school student\n";
        }

        public override int PMetrics
        {
            get { return ametrics; }
            set
            {
                if (value > 71)
                {
                    ametrics = 1;
                }

                else if (value > 61)
                {
                    ametrics = 2;
                }
                else if (value > 51)
                {
                    ametrics = 3;

                }
                else
                {
                    ametrics = 4;
                }
            }

        }

        public override void MetricsMap(int metrics)
        {
            ametrics = metrics;
            if (ametrics == 1)
            {
                WriteLine("He / She is a A / First Class Student.");
            }
            else if (ametrics == 2)
            {
                WriteLine("He / She is a B / Second Class Student.");
            }
            else if (ametrics == 3)
            {
                WriteLine("He / She is a C / Third Class Student.");
            }
            else if (ametrics == 4)
            {
                WriteLine("He / She needs to improve.");
            }
            else
            {
                WriteLine("Metric Input Invalid.");
            }
        }

        public Secondary(string student, string school) : base()
        {
            Student = student;
            School = school;
            WriteLine("Student Name is {0} of {1} College", student, school);
        }

        public override void StudentSum(params string[] a)
        {
            foreach (string i in a)
            {
                WriteLine("Student Names are {0}\n", i);
            }

            WriteLine("His performance is on grade {0}\n", ametrics);
        }
    }


    public interface ITeacher
    {
        string TeacherStatus(bool i);
        public int AverageAssess { get; set; }
        void ComputeRenum(int bonus, int allowance);

    }

    class Teacher : ITeacher
    {
        private int renum;
        private int Bonus;
        private int Allowance;
        private int tmetrics;

        public string TeacherStatus(bool active)
        {
            if (active)
            {
                return "Teacher is active";
            }
            else
            {
                return "Teacher is not active";
            }
        }

        public int AverageAssess
        {
            get { return tmetrics; }
            set
            {
                if (value > 51)
                {
                    tmetrics = 1;
                }
                else
                {
                    tmetrics = 0;
                }
            }
        }


        public void DeclareRenum()
        {
            WriteLine("Staff Renumeration is {0}", renum);
        }

        // Junior Level
        public void ComputeRenum(int bonus, int allowance)
        {
            Bonus = bonus;
            Allowance = allowance;
            renum = 12000 + Bonus + Allowance;
            DeclareRenum();
        }


        // Senior Level / Extraordinary and Valuable Staff
        public void ComputeRenum(int bonus, int allowance, int other)
        {
            Bonus = bonus;
            Allowance = allowance;
            renum = 12000 + Bonus + Allowance + other;
            DeclareRenum();
        }

    }

    // Assessment section
    class Assessment
    {
        public static int averagescore;

        public static int Grade(int ncourses, int tscores)
        {
            averagescore = tscores / ncourses;
            return averagescore;
        }

        public static int assessment(int rateA, int rateB, int rateC)
        {
            averagescore = rateA + rateB + rateC;
            return averagescore;
        }

        public Assessment(int rateA, int rateB, int rateC)
        {
        }

        public Assessment()
        {
        }
    }

    class TeacherAssess : Assessment
    {
        private bool assessment;

        public TeacherAssess(int paramA, int paramB, int paramC) : base(paramA, paramB, paramC)
        {
            WriteLine("Teacher Assessment Metrics are as follows\n");
            WriteLine("Behaviour Rating is {0}\n", paramB);
            WriteLine("Activity Rating is {0}\n", paramA);
            WriteLine("Composure Rating is {0}\n", paramC);
        }

    }

    class SchoolChild : Assessment
    {
        private List<int> password;
        private bool assessment;

        public SchoolChild(int sparamA, int sparamB)
        {
            WriteLine("Student Assessment Metrics are as follows");
            WriteLine("Total Score Rating is {0}", sparamA);
            WriteLine("Number of courses is {0}", sparamB);
        }

        public SchoolChild()
        {
        }
    }


    class Pupil : SchoolChild
    {
        public Pupil() : base()
        {
            WriteLine("This is a pupil's records");
        }

        public virtual void CreateCourses(string name, int units, int score)
        {
            WriteLine("Course {0} , {1} units , {2} possible score.", name, units, score);
        }
    }

    class Student : Pupil
    {
        public Student() : base()
        {
            WriteLine("This is a Student's records");
        }

        public override void CreateCourses(string name, int units, int score)
        {
            WriteLine("Course {0} , {1} units , {2} possible score.", name, units, score);
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            bool status = true;
            while (status)
            {
                // Main Program
                WriteLine("----------------------------------------------------------");
                WriteLine("Welcome to Staff and Student Information Management System");
                WriteLine("----------------------------------------------------------");
                WriteLine("Possible Case Types: Teacher or Student.");
                Write("Enter case type to create:");
                string casetype = ReadLine();
                int noOfCases;
                int noOfPrim;
                int noOfSec;
                if (casetype == "Teacher")
                {
                    WriteLine("How many case types do you want to create:");
                    noOfCases = ToInt32(ReadLine());
                    Teacher[] obj = new Teacher[noOfCases];
                    foreach (Teacher i in obj)
                    {
                        WriteLine("Enter Teacher Name: ");
                        string name = ReadLine();
                        Teacher Object = new Teacher();
                        Object.TeacherStatus(true);
                        WriteLine("Teacher Assessment Portal Activated.");
                        WriteLine("Enter Activity Rating Metrics (ARMs): ");
                        int arm = ToInt32(ReadLine());
                        WriteLine("Enter Behaviour Rating Metrics (BRMs): ");
                        int brm = ToInt32(ReadLine());
                        WriteLine("Enter Composure Rating Metrics (CRMs): ");
                        int crm = ToInt32(ReadLine());
                        Object.AverageAssess = Assessment.assessment(arm, brm, crm);
                        if (Object.AverageAssess == 1)
                        {
                            WriteLine("Teacher is performing well.");
                        }
                        else
                        {
                            WriteLine("Teacher needs to improve.");
                        }

                        TeacherAssess sum = new TeacherAssess(arm, crm, brm);
                        WriteLine("Enter J or S for Level.");
                        WriteLine("Teacher Renumeration Portal");
                        WriteLine("Enter Level of Teacher : ");
                        string level = ReadLine();
                        if (level == "J")
                        {
                            WriteLine("Enter Bonus: ");
                            int bonus = ToInt32(ReadLine());
                            WriteLine("Enter Allowance: ");
                            int allow = ToInt32(ReadLine());
                            Object.ComputeRenum(bonus, allow);
                        }

                        else if (level == "S")
                        {
                            WriteLine("Enter Bonus: ");
                            int bonus = ToInt32(ReadLine());
                            WriteLine("Enter Allowance: ");
                            int allow = ToInt32(ReadLine());
                            WriteLine("Enter Other Renum: ");
                            int rnum = ToInt32(ReadLine());
                            Object.ComputeRenum(bonus, allow, rnum);
                        }
                        else
                        {
                            WriteLine("Invalid input");
                        }

                    }
                    WriteLine("Do you wish to continue (Y for Yes or N for No): ");
                    string progress = ReadLine();
                    if (progress == "Y")
                    {
                        WriteLine("Okay,That's Great!");
                    }
                    if (progress == "N")
                    {
                        WriteLine("Bye Now!!");
                        status = false;
                    }


                }

                else if (casetype == "Student")
                {

                    WriteLine("How many case types do you want to create:");
                    noOfCases = ToInt32(ReadLine());
                    WriteLine("How many Primary student case types: ");
                    noOfPrim = ToInt32(ReadLine());
                    Primary[] PrimObj = new Primary[noOfPrim];
                    WriteLine("How many Secondary student case types: ");
                    noOfSec = ToInt32(ReadLine());
                    noOfCases -= noOfPrim;
                    Secondary[] SecObj = new Secondary[noOfCases];
                    foreach (Primary i in PrimObj)
                    {
                        WriteLine("Student Name: ");
                        string student = ReadLine();
                        WriteLine("School Name: ");
                        string school = ReadLine();
                        Primary obj = new Primary(student, school);
                        WriteLine(obj.StudentInfo());
                        WriteLine("Performance Assessment Portal.");
                        WriteLine("Enter Total Scores gained in all courses: ");
                        int totcores = ToInt32(ReadLine());
                        WriteLine("Enter Total Number of courses: ");
                        int ncourses = ToInt32(ReadLine());
                        obj.PMetrics = Assessment.Grade(ncourses, totcores);
                        obj.MetricsMap(obj.PMetrics);
                        SchoolChild gradesummary = new SchoolChild(ncourses, totcores);
                        obj.StudentSum(student);


                    }

                    foreach (Secondary i in SecObj)
                    {
                        WriteLine("Student Name: ");
                        string student = ReadLine();
                        WriteLine("School Name: ");
                        string school = ReadLine();
                        Secondary obj = new Secondary(student, school);
                        WriteLine(obj.StudentInfo());
                        WriteLine("Performance Assessment Portal.");
                        WriteLine("Enter Total Scores gained in all courses: ");
                        int totcores = ToInt32(ReadLine());
                        WriteLine("Enter Total Number of courses: ");
                        int ncourses = ToInt32(ReadLine());
                        obj.PMetrics = Assessment.Grade(ncourses, totcores);
                        obj.MetricsMap(obj.PMetrics);
                        SchoolChild gradesummary = new SchoolChild(ncourses, totcores);
                        obj.StudentSum(student);
                        


                    }
                    WriteLine("Do you wish to continue (Y for Yes or N for No): ");
                    string progress = ReadLine();
                    if (progress == "Y")
                    {
                        WriteLine("Okay,That's Great!");
                    }
                    if (progress == "N")
                    {
                        WriteLine("Bye Now!!");
                        status = false;
                    }
                }
                else
                {
                    WriteLine("Case Type does not exist.");
                    status = false;
                }
            }




        }
    }
}
    
   
    
