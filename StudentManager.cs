using System;
using System.Collections.Generic;
using System.IO;

namespace sprout__gradeBook
{
    public class StudentInfo
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
    }

    public class StudentManager
    {
        public static List<StudentInfo> GetStudentsByDepartmentAndSection(string currentUserName, string department, string section)
        {
            List<StudentInfo> matchingStudents = new List<StudentInfo>();

            string directoryPath = $"StudentCredentials/{currentUserName}/";
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist.");
                return matchingStudents;
            }

            string[] studentCredentialFiles = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string studentCredentialFile in studentCredentialFiles)
            {
                string[] studentInfo = File.ReadAllLines(studentCredentialFile);

                string studentDepartment = "";
                string studentYearSection = "";

                foreach (string line in studentInfo)
                {
                    if (line.StartsWith("Department:"))
                    {
                        studentDepartment = line.Substring("Department:".Length).Trim();
                    }
                    else if (line.StartsWith("Year and Section:"))
                    {
                        studentYearSection = line.Substring("Year and Section:".Length).Trim();
                    }
                }

                if (studentDepartment == department && studentYearSection == section)
                {
                    string studentID = "";
                    string studentName = "";

                    foreach (string line in studentInfo)
                    {
                        if (line.StartsWith("Student ID:"))
                        {
                            studentID = line.Substring("Student ID:".Length).Trim();
                        }
                        else if (line.StartsWith("Student Name:"))
                        {
                            studentName = line.Substring("Student Name:".Length).Trim();
                        }
                    }

                    if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(studentName))
                    {
                        matchingStudents.Add(new StudentInfo { StudentID = studentID, StudentName = studentName });
                    }
                }
            }

            return matchingStudents;
        }
    }
}
