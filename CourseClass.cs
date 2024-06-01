using System;
using System.IO;

public class Course
{
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public string StudentCourse { get; set; }
    public string StudentSection { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int StudentCount { get; set; }


    public Course(string courseName, string courseCode, string studentCourse, string studentSection, TimeSpan startTime, TimeSpan endTime, int studentCount)
    {

        CourseName = courseName;
        CourseCode = courseCode;
        StudentCourse = studentCourse;
        StudentSection = studentSection;

        if (ValidateSchedule(startTime, endTime))
        {
            StartTime = startTime;
            EndTime = endTime;
        }
        else
        {
            throw new ArgumentException("EndTime must be greater than StartTime.");
        }

        StudentCount = studentCount;
    }

    public string GetCourseSchedule()
    {
        return $"{StartTime:hh\\:mm}-{EndTime:hh\\:mm}";
    }

    public static bool ValidateSchedule(TimeSpan startTime, TimeSpan endTime)
    {
        return startTime < endTime;
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
            courseWriter.WriteLine($"Student Course: {StudentCourse}");
            courseWriter.WriteLine($"Student Section: {StudentSection}");
            courseWriter.WriteLine($"Course Schedule: {GetCourseSchedule()}");
            courseWriter.WriteLine($"Student Count: {StudentCount}");
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
}
