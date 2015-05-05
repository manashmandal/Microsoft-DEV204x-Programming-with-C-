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

        //Grade Stack Generic Collection
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
        
        //Generic List of Student
        private List<Student> course_students = new List<Student>();
     
        Teacher courseTeacher;

        public Course(List<Student> courseStudents, string courseName)
        {
            this.courseName = courseName;

            this.course_students = courseStudents;
            this.length = this.course_students.Count;

            this.teacherInit();
        }

        public void ListStudents()
        {
            int x = 0;
            //Printing Student Names
            foreach(Student studs in this.course_students){
                x++;
                switch (x)
                {
                    case 1:
                        Console.WriteLine("{0}st Student", x);
                        break;
                    case 2:
                        Console.WriteLine("{0}nd Student", x);
                        break;
                    case 3:
                        Console.WriteLine("{0}rd Student", x);
                        break;
                }
                Console.WriteLine("First Name: {0} Last Name: {1}", studs.FirstName, studs.LastName);
                Console.WriteLine();
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


            //Adding Grades at Random
            for (int i = 0; i < 5; i++)
            {
                manash.addGrade((float)i);
                tomal.addGrade((float)(i + .1));
                ishfaq.addGrade((float)(i + .2));
            }

            //Creating Generic List and adding students
            List<Student> generic_student_list = new List<Student>();
            generic_student_list.Add(manash);
            generic_student_list.Add(tomal);
            generic_student_list.Add(ishfaq);


        
            //Adding Teacher
            Teacher teacher = new Teacher();

            //Course with argument ArrayList 
            Course course = new Course(generic_student_list, "Programming with C#");
            //Setting Course Teacher
            course.setTeacher(teacher);
            
            //Creating Degree Object
            Degree degree = new Degree("Bachelor of Science Degree");
            degree.setCourseObject(course);

            //Uprogram Object
            UProgram uprogram = new UProgram();
            uprogram.uProgramName = "Information Technology Program";
            uprogram.degree_uprog = degree;
            
            //Calling List Students Method
            course.ListStudents();
        }
    }
}
