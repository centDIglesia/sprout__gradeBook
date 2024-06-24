using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sprout__gradeBook
{
    public static class UserInput__Validator
    {
        public static bool ValidateNotEmpty(string input, string fieldLabel)
        {
            return !string.IsNullOrEmpty(input) && input != fieldLabel;
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
            return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public static bool ValidateTimeFormat(string time)
        {
            // Regular expression pattern for HH:MM AM/PM format
            string pattern = @"^(0[1-9]|1[0-2]):[0-5][0-9] (AM|PM)$";

            // Check if the input matches the pattern
            return Regex.IsMatch(time, pattern);
        }

        public static bool ValidateEndTimeAfterStartTime(string startTime, string endTime)
        {
            // Parse start and end times
            DateTime startDateTime = DateTime.ParseExact(startTime, "hh:mm tt", CultureInfo.InvariantCulture);
            DateTime endDateTime = DateTime.ParseExact(endTime, "hh:mm tt", CultureInfo.InvariantCulture);

            // Compare start and end times
            return endDateTime > startDateTime;
        }


    }
}

