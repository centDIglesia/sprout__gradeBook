using System;
using System.Linq;

namespace sprout__gradeBook
{
    public abstract class Users
    {
        private string schoolName;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; protected set; }
        public string SchoolName
        {
            get => schoolName;
            set => schoolName = value;
        }

        protected Users(string firstName, string lastName, string email, string username, string password, string school)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            SchoolName = school;
        }

        public abstract string GetFolder();

        public static Users CurrentUser { get; set; }

        protected string GetInitials(string schoolName)
        {
            if (string.IsNullOrEmpty(schoolName))
            {
                return string.Empty;
            }

            var initials = string.Concat(schoolName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(word => char.ToUpper(word[0])));
            return initials;
        }
    }

    public class Student : Users
    {
        public string StudentNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string MiddleName { get; set; }
        public string YearLevel { get; set; }
        public string Section { get; set; }
        public string Department { get; set; }
        public string School { get; set; }

        public Student(string studentNumber, string firstName, string middleName, string lastName, string email, string username, DateTime birthday, string gender, string yearLevel, string section, string department, string school)
            : base(firstName, lastName, email, username, "", school) // Pass the school name to the base constructor
        {
            StudentNumber = studentNumber;
            Birthday = birthday;
            Password = GeneratePassword(birthday, school); // Use the passed school name here
            Gender = gender;
            MiddleName = middleName;
            YearLevel = yearLevel;
            Section = section;
            Department = department;
            School = school; // Set the school name property directly
        }

        public string FullName
        {
            get { return $"{FirstName} {MiddleName} {LastName}"; }
        }

        public override string GetFolder()
        {
            return "StudentCredentials";
        }

        private string GeneratePassword(DateTime birthday, string school)
        {
            return birthday.ToString("yyyy-MM-dd") + school;
        }

        public string GetYearAndSection()
        {
            return $"{YearLevel}-{Section}";
        }

        public static string GetSchoolFromCurrentTeacher()
        {
            if (CurrentUser is Teacher teacher)
            {
                return teacher.SchoolName;
            }
            throw new InvalidOperationException("Current user is not a teacher.");
        }
    }

    public class Teacher : Users
    {
        public Teacher(string firstName, string lastName, string email, string username, string password, string school)
            : base(firstName, lastName, email, username, password, "")
        {
            SchoolName = GetInitials(school);
        }

        public override string GetFolder()
        {
            return "TeacherCredentials";
        }
    }
}
