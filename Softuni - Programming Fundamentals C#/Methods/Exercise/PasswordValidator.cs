using System;

namespace PasswordValidator
{
    class PasswordValidator
    {
        static void Main()
        {
            string password = Console.ReadLine();
            bool isValid = true;
            bool isValid1 = true;
            bool isValid2 = true;
            isValid = IsBetween6And10Chars(password);
            isValid1 = ContainsOnlyLettersAndDigits(password);
            isValid2 = HasAtLeast2Digits(password);
            if (isValid && isValid1 && isValid2)
            {
                Console.WriteLine("Password is valid");
            }
        }
        
        static bool IsBetween6And10Chars(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
            return true;
        }

        static bool ContainsOnlyLettersAndDigits(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return false;
                }
            }
            return true;
        }

        static bool HasAtLeast2Digits(string password)
        {
            int digitCount = 0;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }
            if (digitCount < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }
            return true;
        }
    }
}
