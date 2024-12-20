using System;
using System.Security.Cryptography;
using System.Text;

namespace AgendaApp.Domain.Helpers
{
    public class SHA256Helper
    {
        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), "Value cannot be null or empty.");

            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                var hashBytes = sha256.ComputeHash(bytes); 
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
