using System.IO;
using System.Security.Cryptography;

namespace Egz
{
    public class Password
    {
        protected string PasswordHash;
        public void SetHash(string passwd)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwd, Convert.FromBase64String("9mc2dzBkqQMkMryS+ydV9Q=="), 100000); //Simboliu eile yra salt
            byte[] hash = pbkdf2.GetBytes(20);
            PasswordHash = Convert.ToBase64String(hash);
        }
        public string GetHash()
        {
            return PasswordHash;
        }
        public void SaveHash()
        {
            File.WriteAllText("hash.txt", PasswordHash);
        }
        public bool CheckHash(string passwd)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwd, Convert.FromBase64String("9mc2dzBkqQMkMryS+ydV9Q=="), 100000); //Simboliu eile yra salt
            byte[] hash = pbkdf2.GetBytes(20);
            string passwd_hash = Convert.ToBase64String(hash);
            if (passwd_hash == PasswordHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
