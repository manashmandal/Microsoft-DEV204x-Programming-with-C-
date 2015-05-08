using System;

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
