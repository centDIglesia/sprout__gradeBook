using System;
using System.IO;

public class Course
{
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public string StudentCourse { get; set; }
    public string StudentSection { get; set; }
    public int StudentYearLvl { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int StudentCount { get; set; }
    public string Department { get; set; }
    public string DayoftheWeek { get; set; }

    public Course(string courseName, string courseCode, string studentCourse, string studentSection, string startTime, string endTime, int studentCount, int studentYearLvl, string whatDay)
    {
        CourseName = courseName;
        CourseCode = courseCode;
        Department = studentCourse;
        StudentCount = studentCount;
        StartTime = startTime;
        EndTime = endTime;
        StudentCount = studentCount;
        StudentYearLvl = studentYearLvl;
        StudentSection = studentSection;
        DayoftheWeek = whatDay;

    }


    public string GetCourseSchedule()
    {
        return $"{StartTime} - {EndTime}";
    }

    public string GetYearAndSection()
    {
        return $"{StudentYearLvl}-{StudentSection}";
    }

    public void SaveCourse(string currentUser)
    {
        string directoryPath = "CourseInformations";
        string sectionFilePath = Path.Combine(directoryPath, $"{currentUser}.txt");

        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        using (StreamWriter courseWriter = new StreamWriter(sectionFilePath, true))
        {
            courseWriter.WriteLine($"Course Name: {CourseName}");
            courseWriter.WriteLine($"Course Code: {CourseCode}");
            courseWriter.WriteLine($"Student Department: {Department}");
            courseWriter.WriteLine($"Student year and section: {GetYearAndSection()}");
            courseWriter.WriteLine($"Course Schedule: {GetCourseSchedule()}");
            courseWriter.WriteLine($"Student Count: {StudentCount}");
            courseWriter.WriteLine($"Day of the Week: {DayoftheWeek}");
            courseWriter.WriteLine(new string('-', 40));
        }
    }

    public static int GetCourseCount(string currentUser)
    {
        string directoryPath = "CourseInformations";
        string[] files = Directory.GetFiles(directoryPath, $"{currentUser}.txt");

        int count = 0;

        foreach (string filePath in files)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Course Name:"))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    public static int GetSectionsCount(string currentUser)
    {
        // Construct the directory path
        string directoryPath = $"CourseInformations/{currentUser}";

        // Check if the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Directory does not exist.");
            return 0;
        }

        // Get all .txt files in the directory
        string[] textFiles = Directory.GetFiles(directoryPath, "*.txt");

        // Return the count of .txt files
        return textFiles.Length;
    }
}


