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

        public string schoolName { get; set; }

        public Users(string firstName, string lastName, string email, string username, string password, string school)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            schoolName = school;
        }

        public abstract string GetFolder();
    }

    public class Student : Users
    {
        public int StudentNumber { get; set; }
        public DateTime Birthday { get; set; }

        public string Password { get; private set; }
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

