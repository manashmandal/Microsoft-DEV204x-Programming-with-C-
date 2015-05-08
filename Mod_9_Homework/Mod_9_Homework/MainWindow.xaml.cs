using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mod_9_Homework
{

    public class Student
    {
        private string firstName;
        private string lastName;
        private string city;

        public string FirstName
        {
            get { return firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { this.lastName = value; }
        }

        public string City
        {
            get { return city; }
            set { this.city = value; }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int iteration = -1;
        //Creating List of Students
        private List<Student> studentCollections = new List<Student>();
        
        //Adding Student to the collection
        void add(string first, string last, string city)
        {
            Student student = new Student();
            student.FirstName = first;
            student.LastName = last;
            student.City = city;
            studentCollections.Add(student);
            //For debugging purpose
            MessageBox.Show("Student Added\nFirst Name: " + student.FirstName + "\nLast Name: " + student.LastName + "\nCity: " + student.City);
        }

        //Clear Text Areas
        void clearTexts()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
        }

        //Iterate next student
        void next()
        {
            if (iteration + 1 < studentCollections.Count)
            {
                iteration++;
                txtFirstName.Text = studentCollections[iteration].FirstName;
                txtLastName.Text = studentCollections[iteration].LastName;
                txtCity.Text = studentCollections[iteration].City;
            }

            if (iteration + 1 == studentCollections.Count) iteration = -1;

        }
        
        //Iterate previous element
        void previous()
        {
           
                if (iteration < 0 ) iteration = studentCollections.Count - 1;
                //This Statement fix the problem with collection of one student
                if (studentCollections.Count == 1) iteration = 1;
                else if (iteration == 0) iteration = studentCollections.Count;
                iteration--;

                txtFirstName.Text = studentCollections[iteration].FirstName;
                txtLastName.Text = studentCollections[iteration].LastName;
                txtCity.Text = studentCollections[iteration].City;
            
        }

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            //Checking if any of the textarea is empty or has a white space in the beginning 
            bool is_firstName_Empty = string.IsNullOrWhiteSpace(txtFirstName.Text);
            bool is_lastName_Empty = string.IsNullOrWhiteSpace(txtLastName.Text);
            bool is_city_Empty = string.IsNullOrWhiteSpace(txtCity.Text);

            //If text areas are not empty then it will add the info
            if (!is_firstName_Empty && !is_lastName_Empty && !is_city_Empty)
            {
                add(txtFirstName.Text, txtLastName.Text, txtCity.Text);
                clearTexts();
            }

            else
            {
                //For A successful addition
                MessageBox.Show("One or more than One Text Area is Either empty or has white space");
            }
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            next();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            previous();
        }
    }
}
