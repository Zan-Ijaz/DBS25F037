using System.Text;

namespace skillhub.Common_Utility
{
    public class PasswordHasher
    {
        private static readonly char Key = 'K';  

        // Encode (XOR Encryption)
        public static string Encode(string plainText)
        {
            StringBuilder encoded = new StringBuilder();
            foreach (char c in plainText)
            {
                encoded.Append((char)(c ^ Key));  // XOR each character with the key
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(encoded.ToString()));
        }

        // Decode (XOR Decryption)
        public static string Decode(string encodedText)
        {
            byte[] bytes = Convert.FromBase64String(encodedText);
            string decodedString = Encoding.UTF8.GetString(bytes);

            StringBuilder originalText = new StringBuilder();
            foreach (char c in decodedString)
            {
                originalText.Append((char)(c ^ Key));  // XOR each character with the key again
            }
            return originalText.ToString();
        }

        // Verify if the entered password matches the stored encoded password
        public static bool VerifyPassword(string enteredPassword, string storedEncodedPassword)
        {
            // Decode the stored encoded password
            string decodedPassword = Decode(storedEncodedPassword);

            return enteredPassword == decodedPassword;
        }

        public static string HashPassword(string plainPassword)
        {
            
            return Encode(plainPassword);
        }
    }
}
