using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevXCSharp
{
    class Student
    {
        private string first_name, last_name, address, city, state, country, degree, course;
        public Student(string fn, string ln, string adr, string city, string st, string cntry, string deg, string crs)
        {
            this.first_name = fn;
            this.last_name = ln;
            this.address = adr;
            this.city = city;
            this.state = st;
            this.country = cntry;
            this.degree = deg;
            this.course = crs;
        }

        public Student()
        {

        }

        public void print_student_info()
        {
            Console.WriteLine("First Name: {0}\nLast Name: {1}\nAddress: {2}\nCity: {3}\nState: {4}\nDegree: {5}\nCourse: {6}" , first_name, last_name, address, city, state, degree, course);
        }
    }

    class Teacher
    {
        string firstName;
        string lastName;
        string subject;
        string degree;

        public Teacher()
        {

        }

        public Teacher(string fn, string ln, string sub, string deg)
        {
            this.firstName = fn;
            this.lastName = ln;
            this.subject = sub;
            this.degree = deg;
        }
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
