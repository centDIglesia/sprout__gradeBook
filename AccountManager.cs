using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace sprout__gradeBook
{
    public static class AccountManager
    {
        public static void SaveUser(Users user)
        {
            string folderPath = user.GetFolder();

            // Ensure the directory exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Check if the username already exists
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

        public static bool UsernameExists(string username, string folderPath)
        {
            string filePath = Path.Combine(folderPath, $"{username}.txt");
            return File.Exists(filePath);
        }

        public static bool AuthenticateUser(string username, string password, string folderPath)
        {
            string filePath = Path.Combine(folderPath, $"{username}.txt");

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // User not found
                return false;
            }

            // Read user credentials from the file
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

            // Hash the input password and compare with the stored hashed password
            string hashedInputPassword = HashPassword(password);
            return storedPassword == hashedInputPassword;
        }


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
