using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace sprout__gradeBook
{
    public partial class teacher__mainDashboard : KryptonForm
    {
        private readonly string _currentUser;
        private List<string> _removedCourses = new List<string>();
        private const string MarkedCoursesFile = "MarkedCourses.txt";

        public teacher__mainDashboard(string currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            // Update counts on initialization
            UpdateCourseCount(currentUser);
            UpdateStudentCount(currentUser);
            UpdateSectionCount(currentUser);
            LoadMarkedCourses();
            populateCourses();
        }
        private void LoadMarkedCourses()
        {
            if (File.Exists(MarkedCoursesFile))
            {
                _removedCourses = File.ReadAllLines(MarkedCoursesFile).ToList();
            }
        }
        private void SaveMarkedCourses()
        {
            File.WriteAllLines(MarkedCoursesFile, _removedCourses);
        }


        // Update the displayed count of courses
        private void UpdateCourseCount(string currentUser)
        {
            int count = Course.GetCourseCount(currentUser);
            course__quantity.Text = count.ToString();
        }

        // Update the displayed count of students
        private void UpdateStudentCount(string currentUser)
        {
            int count = StudentManager.GetStudentCount(currentUser);
            student__quantity.Text = count.ToString();
        }

        // Update the displayed count of sections
        private void UpdateSectionCount(string currentUser)
        {
            int count = Course.GetSectionsCount(currentUser);
            sections__quantity.Text = count.ToString();
        }

        public void populateCourses()
        {

            string filePath = $"CourseInformations/{_currentUser}.txt";
            todayschedulePanel.Controls.Clear();

            if (File.Exists(filePath))
            {
                try
                {
                    string[] fileLines = File.ReadAllLines(filePath);

                    string courseCode = string.Empty;
                    string studentDepartment = string.Empty;
                    string studentYearAndSection = string.Empty;
                    string courseSchedule = string.Empty;
                    string courseDayofweek = string.Empty;
                    bool inCourseSection = false;
                    string courseName = string.Empty;
                    // Get current day as a string for comparison
                    string currentDay = DateTime.Now.DayOfWeek.ToString();

                    foreach (string line in fileLines)
                    {
                        if (line.StartsWith("Course Code:"))
                        {
                            courseCode = line.Split(':')[1].Trim();
                        }
                        else if (line.StartsWith("Course Name:"))
                        {
                            courseName = line.Split(':')[1].Trim();
                        }
                        else if (line.StartsWith("Student Department:"))
                        {
                            studentDepartment = line.Split(':')[1].Trim();
                        }
                        else if (line.StartsWith("Student year and section:"))
                        {
                            studentYearAndSection = line.Split(':')[1].Trim();
                            inCourseSection = true;
                        }
                        else if (line.StartsWith("Course Schedule:"))
                        {
                            courseSchedule = line.Split(new[] { ':' }, 2)[1].Trim();
                        }
                        else if (line.StartsWith("Day of the Week:"))
                        {
                            courseDayofweek = line.Split(new[] { ':' }, 2)[1].Trim();
                        }
                        else if (line.StartsWith("----------------------------------------"))
                        {
                            if (inCourseSection)
                            {

                                if (currentDay.Equals(courseDayofweek, StringComparison.OrdinalIgnoreCase))
                                {
                                    string courseSection = $"{studentDepartment}\n{studentYearAndSection}";

                                    // Create a new CoursesCARD object and populate its properties.
                                    todaysScheduleCARD card = new todaysScheduleCARD()
                                    {
                                        _schedSubectName = courseSection,
                                        _schedSection = courseCode,
                                        _schedRoomNumber = courseSchedule,
                                        IsMarkedAsDone = _removedCourses.Contains(courseCode)  // Check if course is marked as done
                                    };

                                    // Wire up the event handler
                                    card.MarkAsDoneClicked += Card_MarkAsDoneClicked;

                                    // Add the created card to the panel.
                                    todayschedulePanel.Controls.Add(card);
                                }

                                // Reset variables for the next course section.
                                inCourseSection = false;
                                courseCode = string.Empty;
                                studentDepartment = string.Empty;
                                studentYearAndSection = string.Empty;
                                courseSchedule = string.Empty;
                                courseDayofweek = string.Empty;
                            }
                        }
                    }

                    // Check if the last course section needs to be added
                    if (inCourseSection && currentDay.Equals(courseDayofweek, StringComparison.OrdinalIgnoreCase))
                    {
                        string courseSection = $"{studentDepartment}\n{studentYearAndSection}";

                        // Create and add the last CoursesCARD.
                        todaysScheduleCARD card = new todaysScheduleCARD()
                        {
                            _schedSubectName = courseSection,
                            _schedSection = courseCode,
                            _schedRoomNumber = courseSchedule,
                            IsMarkedAsDone = _removedCourses.Contains(courseCode)  // Check if course is marked as done
                        };

                        // Wire up the event handler
                        card.MarkAsDoneClicked += Card_MarkAsDoneClicked;

                        todayschedulePanel.Controls.Add(card);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}");
            }
        }

        private void Card_MarkAsDoneClicked(object sender, EventArgs e)
        {
            todaysScheduleCARD card = sender as todaysScheduleCARD;
            if (card != null)
            {
                // Toggle the state of marked courses
                if (card.IsMarkedAsDone)
                {
                    _removedCourses.Add(card._schedSection);  // Add to list if marking as done
                }
                else
                {
                    _removedCourses.Remove(card._schedSection);  // Remove from list if un-marking
                }

                SaveMarkedCourses();  // Save the updated marked courses list
            }
        }
    }
}
