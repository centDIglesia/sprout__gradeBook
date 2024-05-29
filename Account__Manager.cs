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
        public static void SaveUser(Users user)
        {
            string folderPath = user.GetFolder();

          
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (UsernameExists(user.Username, folderPath))
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
                writer.WriteLine($"Password: {HashPassword(user.Password)}"); // Hash the password before saving
            }
        }

        //check if username exist
        public static bool UsernameExists(string username, string folderPath)
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
             if (!File.Exists(folderPath))
            {
                return false;
            }
          
            foreach (var filePath in Directory.GetFiles(folderPath, "*.txt"))
            {
                string storedPassword = "";
                bool studentIdFound = false;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("Student ID:"))
                        {
                            string fileStudentId = line.Substring("Student ID:".Length).Trim();
                            if (fileStudentId == studentId)
                            {
                                studentIdFound = true;
                            }
                        }

                        if (line.StartsWith("Password:"))
                        {
                            storedPassword = line.Substring("Password:".Length).Trim();
                        }
                    }
                }

                if (studentIdFound)
                {
                    string hashedInputPassword = HashPassword(password);
                    return storedPassword == hashedInputPassword;
                }
            }

          
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
    }
}
