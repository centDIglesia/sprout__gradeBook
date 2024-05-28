using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                writer.WriteLine($"Password: {user.Password}");
            }
        }

        public static bool UsernameExists(string username, string folderPath)
        {
            string filePath = Path.Combine(folderPath, $"{username}.txt");
            return File.Exists(filePath);
        }



    }
}
