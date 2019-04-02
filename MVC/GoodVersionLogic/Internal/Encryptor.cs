using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MVC_ReleaseDateSite.Logic {
    internal static class Encryptor {
        public static string Hash(string rawData) {
            if (!string.IsNullOrEmpty(rawData)) {
                using (var sha256Hash = SHA256.Create()) {
                    var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                    var builder = new StringBuilder();
                    foreach (var t in bytes) {
                        builder.Append(t.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            return null;
        }

        public static string GenerateSalt() {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
    }
}
