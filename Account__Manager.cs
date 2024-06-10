using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public static class Account__Manager
    {

        //for saving teacherss information from sign up
        //creating folder
        public static void SaveUser(Users user)
        {
            string folderPath = user.GetFolder();


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (UserExists(user.Username, folderPath))
            {
                throw new Exception("Username already exists. Please choose a different username.");
            }

            // Save the credentials to a file in the selected folder
            string filePath = Path.Combine(folderPath, $"{user.Username}.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"First Name: {user.FirstName}");
                writer.WriteLine($"Last Name: {user.LastName}");
                writer.WriteLine($"Email: {user.Email}");
                writer.WriteLine($"Username: {user.Username}");
                writer.WriteLine($"School: {user.SchoolName}");
                writer.WriteLine($"Password: {HashPassword(user.Password)}");
            }




        }

        public static void SaveStudentUser(Users user, string currentUser)
        {
            string folderPath = $"{user.GetFolder()}/{currentUser}";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (UserExists(((Student)user).StudentNumber, folderPath))
            {
                MessageBox.Show("Student ID already exists.");
            }

            // Save the credentials to a file in the selected folder
            string filePath = Path.Combine(folderPath, $"{((Student)user).StudentNumber}.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Student ID: {((Student)user).StudentNumber}");
                writer.WriteLine($"Student Name: {((Student)user).FullName}");
                writer.WriteLine($"Email: {user.Email}");
                writer.WriteLine($"Username: {user.Username}");
                writer.WriteLine($"Birthday: {((Student)user).Birthday.ToShortDateString()}");
                writer.WriteLine($"School: {((Student)user).SchoolName}");
                writer.WriteLine($"Gender: {((Student)user).Gender}");
                writer.WriteLine($"Department: {((Student)user).Department}");
                writer.WriteLine($"Year and Section: {((Student)user).GetYearAndSection()}");
                writer.WriteLine($"Password: {HashPassword(user.Password)}");
            }
        }



        //check if username exist
        public static bool UserExists(string username, string folderPath)
        {
            string filePath = Path.Combine(folderPath, $"{username}.txt");
            return File.Exists(filePath);
        }


        //use to authenticate teachers log in credentials | username and Password |
        public static bool AuthenticateTeacherLogIn(string username, string password, string folderPath)
        {
            string filePath = Path.Combine(folderPath, $"{username}.txt");


            if (!File.Exists(filePath))
            {
                return false;
            }

            string storedPassword = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.StartsWith("Password:"))
                    {
                        storedPassword = line.Substring("Password:".Length).Trim();
                        break;
                    }
                }
            }

            string hashedInputPassword = HashPassword(password);
            return storedPassword == hashedInputPassword;
        }


        //use to authenticate student log in credentials | student ID and Password |
        public static bool AuthenticateStudentLogIn(string studentId, string password, string folderPath)
        {
            foreach (var filePath in Directory.GetFiles(folderPath, "*.txt"))
            {
                string storedStudentId = "";
                string storedPasswordHash = "";

                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("Student ID:"))
                        {
                            storedStudentId = line.Substring("Student ID:".Length).Trim();
                        }
                        else if (line.StartsWith("Password:"))
                        {
                            storedPasswordHash = line.Substring("Password:".Length).Trim();
                        }
                    }
                }

                if (storedStudentId == studentId)
                {
                    string hashedInputPassword = HashPassword(password);
                    return storedPasswordHash == hashedInputPassword;
                }
            }

            // Student ID not found
            return false;
        }


        //function for hashing pssword
        private static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }


        //funtion para ma get natin yung data na need natin sa loob ng file
        // ipapasa muna yung folder name, yung current username at yung kukuhanin natin halombawa yung first name 
        // loadUserData("teachersCredential",urrentUser", "First Name");

        public static string LoadUserData(string folderName, string currentUser, string dataToAccess)
        {
            string folderPath = folderName;
            string fullPath = Path.Combine(folderPath, currentUser + ".txt");

            if (File.Exists(fullPath))
            {
                string[] lines = File.ReadAllLines(fullPath);

                foreach (var line in lines)
                {
                    if (line.StartsWith(dataToAccess + ":"))
                    {
                        return line.Substring(dataToAccess.Length + 1).Trim();
                    }
                }
            }

            return null;
        }

    }
}
