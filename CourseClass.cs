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
    public string department { get; set; }



    public Course(string courseName, string courseCode, string studentCourse, string studentSection, string startTime, string endTime, int studentCount, int studentYearLvl)
    {
        CourseName = courseName;
        CourseCode = courseCode;
        department = studentCourse;
        StudentCount = studentCount;
        StartTime = startTime;
        EndTime = endTime;
        StudentCount = studentCount;
        StudentYearLvl = studentYearLvl;
        StudentSection = studentSection;


    }


    public string GetCourseSchedule()
    {
        return $"{StartTime}-{EndTime}";
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
            courseWriter.WriteLine($"Student Department: {department}");
            courseWriter.WriteLine($"Student year and section: {GetYearAndSection()}");
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
