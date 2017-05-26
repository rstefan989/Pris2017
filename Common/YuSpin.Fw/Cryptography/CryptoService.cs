using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YuSpin.Fw.Cryptography
{
    public class CryptoService
    {
        /// <summary>
        /// Generates random hash string of specific size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GenerateSalt(int size = 12)
        {
            // Generate a cryptographic random number.
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// Generates salted hash string. It's useful for password hashing.
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string GenerateSaltedHash(string plainText, string salt)
        {
            // http://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            // Combine the two lists
            var plainTextWithSaltBytes = new List<byte>(plainTextBytes.Length + saltBytes.Length);
            plainTextWithSaltBytes.AddRange(plainTextBytes);
            plainTextWithSaltBytes.AddRange(saltBytes);

            // Produce 256-bit hashed value i.e. 32 bytes
            HashAlgorithm algorithm = new SHA256Managed();
            var byteHash = algorithm.ComputeHash(plainTextWithSaltBytes.ToArray());
            return Convert.ToBase64String(byteHash);
        }
    }
}
