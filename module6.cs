using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevXCSharp
{
   public  class Person
    {
        public static int personCount = 0;
        string firstName;
        string lastName;
        string address;
        string city;
        string country;

        public void printInfo()
        {
            Console.WriteLine("First Name: {0}", this.firstName);
            Console.WriteLine("Last Name: {0}", this.lastName);
            Console.WriteLine("Address: {0}", this.address);
            Console.WriteLine("City: {0}", this.city);
            Console.WriteLine("Country: {0}", this.country);
        }

        public string Country{ get{ return country;} set {this.country = value;}}
        public string Address { get { return address; } set { this.address = value; } }
        public string City { get { return city; } set { this.city = value; } }
        public string LastName { get { return lastName; } set { this.lastName = value; } }
        public string FirstName { get { return firstName; } set { this.firstName = value; } }


        public Person(string fn, string ln, string addr, string city, string country)
        {
            this.country = country;
            this.firstName = fn;
            this.lastName = ln;
            this.address = addr;
            this.city = city;
            personCount++;
        }

        public Person()
        {
            personCount++;
        }

    }

    public class Student : Person
    {
        private float Grade;
        private string studentID;
        
        public void takeTest(string subject)
        {
            Console.WriteLine("Taking test on {0}", subject);
        }

        public float getGraded { get { return Grade; } set { this.Grade = value; } }
        public string StudentID { get { return studentID; } set { this.studentID = value; } }

    }

    public class Teacher : Person
    {
        private string degree;
        private string subject;

        public void GradeTest(string studentId)
        {
            Console.WriteLine("Grading examination script of {0} Id'd student", studentId);
        }

        public string getSetDegree { get { return degree; } set { this.degree = value; } }
        public string getSetSubject { get { return subject; } set { this.subject = value; } }

    }


    class Course
    {
        public static int i = 0;
        int length;
        public string courseName;
        Student[] courseStudents;
        Teacher courseTeacher;

        public Course(int len, string courseName)
        {
            this.courseName = courseName;
            this.length = len;
            this.studentInit();
            this.teacherInit();
        }

        void studentInit()
        {
            courseStudents = new Student[length];

            for (int l = 0; l < length; l++)
            {
                courseStudents[l] = new Student();
            }
        }

        void teacherInit()
        {
            courseTeacher = new Teacher();
        }

        public void setStudents(Student student)
        {
            this.courseStudents[i] = student;
            i++;
        }

        public void setTeacher(Teacher t)
        {
            this.courseTeacher = t;
        }

        public Student getStudent(int index)
        {
            if (index < i && index > 0) return this.courseStudents[index];
            else return null;
        }


    }

    class Degree
    {
        string degreeName;
        public Course courseObject;

        public Degree(string degreeName)
        {
            this.degreeName = degreeName;
        }

        public void setCourseObject(Course course)
        {
            this.courseObject = course;
        }

        public string getDegreeName()
        {
            return degreeName;
        }
    }

    class UProgram
    {
        private string uprogramName;
        Degree uprog_degree;

        public string uProgramName
        {
            get
            {
                return uprogramName;
            }

            set
            {
                uprogramName = value;
            }
        }

        public Degree degree_uprog
        {
            get
            {
                return uprog_degree;
            }

            set
            {
                uprog_degree = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[3];
            Teacher teacher = new Teacher();
            Course course = new Course(students.Length, "Programming with C#");
            course.setTeacher(teacher);
            for (int i = 0; i < students.Length; i++)
            {
                course.setStudents(students[i]);
            }

            Degree degree = new Degree("Bachelor of Science Degree");
            degree.setCourseObject(course);

            UProgram uprogram = new UProgram();
            uprogram.uProgramName = "Information Technology Program";
            uprogram.degree_uprog = degree;

            Console.WriteLine("The {0} contains the {1}\n", uprogram.uProgramName, uprogram.degree_uprog.getDegreeName());
            Console.WriteLine("The {0} contains the course {1}\n", degree.getDegreeName(), degree.courseObject.courseName);
            Console.WriteLine("The {0} contains {1} student(s)", degree.courseObject.courseName, Course.i);

        }
    }
}
