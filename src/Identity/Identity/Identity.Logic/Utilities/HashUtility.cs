using System.Security.Cryptography;
using System.Text;

namespace Identity.Logic.Utilities
{
    public class HashUtility
    {
        public static string CreatePasswordHash(string password, string salt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (salt == null)
            {
                throw new ArgumentNullException(nameof(salt));
            }

            StringBuilder hash = new StringBuilder();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(salt);

            using (var hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(passwordBytes);

                foreach (var value in hashValue)
                {
                    hash.Append(value.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        public static bool VerifyPasswordHash(string password, string salt, string passwordHash)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (salt == null)
            {
                throw new ArgumentNullException(nameof(salt));
            }

            if (passwordHash == null)
            {
                throw new ArgumentNullException(nameof(passwordHash));
            }

            string hash = CreatePasswordHash(password, salt);

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != passwordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
