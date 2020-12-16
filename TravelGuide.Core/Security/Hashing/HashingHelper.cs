using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Core.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)//out keywordu değerlerin değişeceği için kullanıldı
        {
            using (var shaHash=new HMACSHA512())
            {
                passwordSalt = shaHash.Key;
                passwordHash = shaHash.ComputeHash(buffer: Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt)
        {
            using (var shaHash=new HMACSHA512(passwordSalt))
            {
                var computedHash = shaHash.ComputeHash(buffer: Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
