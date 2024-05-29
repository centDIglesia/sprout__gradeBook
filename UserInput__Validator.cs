using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprout__gradeBook
{
    public static class UserInput__Validator
    {

        public static bool ValidateNotEmpty(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

      
        public static bool ValidateEmail(string email)
        {
            return email.Contains("@gmail.com");

        }

        public static bool ValidatePassword(string password)
        {
         
            int minLength = 8;
            int maxLength = 20;

            if (password.Length < minLength || password.Length > maxLength)
            {
                return false;
            }

            
            if (!password.Any(char.IsLower))
            {
                return false;
            }

          
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

          
            return true;
        }


        public static bool ValidateLenght(string input,int minLength,int maxLength)
        {
           
            if(input.Length < minLength || input.Length > maxLength)
            { return false; }

            return true;

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

