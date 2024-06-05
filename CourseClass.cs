using System;
using System.IO;

public class Course
{
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public string StudentCourse { get; set; }
    public string StudentSection { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int StudentCount { get; set; }
    public string courseAndSection { get; set; }

    public Course(string courseName, string courseCode, string studentCourse, string studentSection, string startTime, string endTime, int studentCount)
    {

        CourseName = courseName;
        CourseCode = courseCode;
        courseAndSection = studentCourse + studentSection;
        StudentCount = studentCount;
    }


    public string GetCourseSchedule()
    {
        return $"{StartTime}-{EndTime}";
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
            courseWriter.WriteLine($"Student Course and Section: {courseAndSection}");
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
