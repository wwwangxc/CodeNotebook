using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Util.Cipher
{
    public class Sha1Handler : BaseCipherHandler
    {
        public override string Encrypt(string arg, string key)
        {
            var ret = string.Empty;
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                var bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(arg + key));
                ret = BitConverter.ToString(
                    sha1.ComputeHash(
                        Encoding.UTF8.GetBytes(
                            BitConverter.ToString(bytes).Replace("-", "0") + key)))
                    .Replace("-", string.Empty)
                    .ToLower();
            }
            return ret;
        }
    }
}
