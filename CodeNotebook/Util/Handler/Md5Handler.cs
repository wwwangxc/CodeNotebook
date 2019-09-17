using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Util.Handler
{
    public class Md5Handler : ICipherHandler
    {
        public string Decrypt(string arg)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string arg)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var str = md5.ComputeHash(Encoding.UTF8.GetBytes(arg + SecretKey));
                var returnStr = BitConverter.ToString(
                    md5.ComputeHash(Encoding.UTF8.GetBytes(BitConverter.ToString(str).Replace("-", "0") + SecretKey)))
                    .Replace("-", string.Empty).ToLower();
                return returnStr;
            }
        }

        private const string SecretKey = "f2eb43bd8d5b42af95ce207cecb5934f";
    }
}
