using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DevXCSharp
{
    #region Person
    public class Person
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

        public string Country { get { return country; } set { this.country = value; } }
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
    #endregion

    #region Student
    public class Student : Person
    {
        public static int studentCount = 0;
        private float Grade;
        private string studentID;
        
        //Grade Stack 
        private Stack<float> gradeStack = new Stack<float>();

        public void takeTest(string subject)
        {
            Console.WriteLine("Taking test on {0}", subject);
        }

        public Student(string firstName, string lastName, string studentID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.studentID = studentID;
            studentCount++;
        }

        public void printStudentInfo()
        {
            Console.WriteLine("First Name: {0}", FirstName);
            Console.WriteLine("Last Name: {0}", LastName);
            Console.WriteLine("Student ID: {0}", studentID);
        }

        public void addGrade(float grd)
        {
            this.gradeStack.Push(grd);
        }

        public float fetchGrade(int index)
        {
            float defaultVal = 0;
            if (index < 0) return defaultVal;
            else if (index > this.gradeStack.Count) return defaultVal;
            else return this.gradeStack.ElementAt(index);
        }

        public float getGraded { get { return Grade; } set { this.Grade = value; } }
        public string StudentID { get { return studentID; } set { this.studentID = value; } }

    }
    #endregion

    #region Teacher
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
    #endregion

    #region Course
    class Course
    {
        public static int i = 0;
        int length;
        public string courseName;
        public ArrayList courseStudents;
        //Student[] courseStudents;
        Teacher courseTeacher;

        public Course(ArrayList courseStudents, string courseName)
        {
            this.courseName = courseName;
          
            this.courseStudents = courseStudents;
            this.length = this.courseStudents.Count;

            this.teacherInit();
        }

        public void ListStudents()
        {
            int x = 0;
            foreach(Student studs in this.courseStudents){
                x++;
                Student tempStudent = (Student) studs;
                Console.WriteLine("{0} Student", x);
                Console.WriteLine("First Name: {0}", tempStudent.FirstName);
                Console.WriteLine("Last Name: {0}\n", tempStudent.LastName);
            }
        }

        void teacherInit()
        {
            courseTeacher = new Teacher();
        }


        public void setTeacher(Teacher t)
        {
            this.courseTeacher = t;
        }

        


    }
    #endregion

    #region Degree
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
    #endregion

    #region UProgram
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
    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            //Creating Three Students
            Student manash = new Student("Manash", "Mandal", "1203043");
            Student tomal = new Student("Mostaque Fahad","Joarder", "1203042");
            Student ishfaq = new Student("Ishfaq Bin Rafiq","Chowdhury", "1203040");


            //Adding Grades
            for (int i = 0; i < 5; i++)
            {
                manash.addGrade((float)i);
                tomal.addGrade((float)(i + .1));
                ishfaq.addGrade((float)(i + .2));
            }
            

            //Creating ArrayList
            ArrayList students = new ArrayList();
            students.Add(manash);
            students.Add(tomal);
            students.Add(ishfaq);

        
            //Adding Teacher
            Teacher teacher = new Teacher();

            //Course with argument ArrayList 
            Course course = new Course(students, "Programming with C#");

            course.setTeacher(teacher);
            

            Degree degree = new Degree("Bachelor of Science Degree");
            degree.setCourseObject(course);

            UProgram uprogram = new UProgram();
            uprogram.uProgramName = "Information Technology Program";
            uprogram.degree_uprog = degree;

            Console.WriteLine("The {0} contains the {1}\n", uprogram.uProgramName, uprogram.degree_uprog.getDegreeName());
            Console.WriteLine("The {0} contains the course {1}\n", degree.getDegreeName(), degree.courseObject.courseName);
            Console.WriteLine("The {0} contains {1} student(s)", degree.courseObject.courseName, Student.studentCount);


            course.ListStudents();
        }
    }
}
