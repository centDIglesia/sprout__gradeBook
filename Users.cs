using System;

namespace sprout__gradeBook
{
    public abstract class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; protected set; }
        public string SchoolName { get; set; }

        public Users(string firstName, string lastName, string email, string username, string password, string school)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            SchoolName = school;
        }

        public abstract string GetFolder();

        // Static property to store the current user
        public static Users CurrentUser { get; set; }
    }

    public class Student : Users
    {
        public int StudentNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }

        public Student(string firstName, string lastName, string email, string username, int studentNumber, DateTime birthday, string school, string gender)
            : base(firstName, lastName, email, username, "", school)
        {
            StudentNumber = studentNumber;
            Birthday = birthday;
            Password = GeneratePassword(birthday, school);
            Gender = gender;
        }

        public override string GetFolder()
        {
            return "studentCredentials";
        }

        private string GeneratePassword(DateTime birthday, string school)
        {
            return birthday.ToString("dd-MM-yy") + school;
        }
    }

    public class Teacher : Users
    {
        public Teacher(string firstName, string lastName, string email, string username, string password, string school)
            : base(firstName, lastName, email, username, password, school) { }

        public override string GetFolder()
        {
            return "teacherCredentials";
        }
    }
}
