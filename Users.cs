using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprout__gradeBook
{
    public abstract class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Users(string firstName, string lastName, string email, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
        }

        public abstract string GetFolder();
    }

    public class Student : Users
    {
        public Student(string firstName, string lastName, string email, string username, string password)
            : base(firstName, lastName, email, username, password) { }

        public override string GetFolder()
        {
            return "studentCredentials";
        }
    }

    public class Teacher : Users
    {
        public Teacher(string firstName, string lastName, string email, string username, string password)
            : base(firstName, lastName, email, username, password) { }

        public override string GetFolder()
        {
            return "teacherCredentials";
        }
    }

}

