using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography; // Used for encryption and decryption


namespace NEA_project
{
    public static class Encrypter
    {
        private const int SaltSize = 16; // Sets the size of the salt
        private const int KeySize = 32;  // Sets the size of the key
        private const int Iterations = 100_000; // Number of iterations for the hashing algorithm

        public static string HashPassword(string password)
        {
            using (var randnum = RandomNumberGenerator.Create()) // Creates a new instance of a random number generator
            {
                byte[] salt = new byte[SaltSize];    // Uses an array to store the salt
                randnum.GetBytes(salt);              // Fills the salt array random bytes

                using (var PBKDF2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))  // Creates a new instance of the PBKDF2 hashing algorithm
                {
                    byte[] hash = PBKDF2.GetBytes(KeySize);   // Generates the hash from the password and salt annd stores it in an array
                    return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);  // Returns the salt and hash as a base64 string                         
                }
            }
        }

        public static bool VerifyPassword(string password_input, string password_stored) // Compares the entered password with the stored password
        {
            var parts = password_stored.Split(':');               // Splits the stored password into salt and hash parts
            var salt = Convert.FromBase64String(parts[0]);        // Converts the salt part from base64 string to byte array  
            var storedHash = Convert.FromBase64String(parts[1]);  // Converts the hash part from base64 string to byte array

            using (var PBKDF2 = new Rfc2898DeriveBytes(password_input, salt, Iterations, HashAlgorithmName.SHA256)) // Creates a new instance of the PBKDF2 hashing algorithm
            {
                byte[] computedHash = PBKDF2.GetBytes(KeySize);   // Generates the hash from the inputted password and salt
                return computedHash.SequenceEqual(storedHash);    // Compares the computed hash with the stored hash and returns true if they match   
            }
        }

    }
}
