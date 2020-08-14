using CryptSharp;

namespace PlayWithMe.Service
{
    public class PasswordService
    {
        public static string Encrypt(string senha)
        {
            return Crypter.MD5.Crypt(senha);
        }
        public static bool Compare(string password, string hash)
        {
            return Crypter.CheckPassword(password, hash);
        }
    }
}
