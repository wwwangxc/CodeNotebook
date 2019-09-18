using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Util.Cipher
{
    public class Md5Handler : BaseCipherHandler
    {
        public override string Encrypt(string arg, string key)
        {
            var ret = string.Empty;
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var bytes = md5.ComputeHash(
                    Encoding.UTF8.GetBytes(arg + key));
                ret = BitConverter.ToString(
                    md5.ComputeHash(
                        Encoding.UTF8.GetBytes(
                            BitConverter.ToString(bytes).Replace("-", "0") + key)))
                    .Replace("-", string.Empty)
                    .ToLower();
            }
            return ret;
        }
    }
}
