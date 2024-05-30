using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprout__gradeBook
{
    public static class UserInput__Validator
    {

        public static bool ValidateNotEmpty(string input, string fieldLabel)
        {
            return string.IsNullOrEmpty(input) || input != fieldLabel;
        }


        public static bool ValidateEmail(string email)
        {
            return email.Contains("@gmail.com");

        }

        public static bool ContainsLowercase(string password)
        {
            return password.Any(char.IsLower);
        }


        public static bool ContainsUppercase(string password)
        {
            return password.Any(char.IsUpper);
        }


        public static bool ContainsDigit(string password)
        {
            return password.Any(char.IsDigit);
        }


        public static bool ValidateLength(string input, int minLength, int maxLength)
        {
            return input.Length >= minLength && input.Length <= maxLength;
        }


        public static string trimInput(string input)
        {
            return input.Trim();
        }


        public static bool ValidateAlphabetic(string input)
        {
            return input.All(char.IsLetter);
        }
    }
}

