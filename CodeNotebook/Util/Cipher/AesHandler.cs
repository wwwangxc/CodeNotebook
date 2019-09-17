using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CodeNotebook.Util.Cipher
{
    public class AesHandler : ICipherHandler
    {
        public string Decrypt(string arg) => Decrypt(arg, KEY);

        public string Decrypt(string arg, string key)
        {
            var fullCipher = Convert.FromBase64String(arg);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);

            using (var aes = Aes.Create())
            {
                using (var decryptor = aes.CreateDecryptor(Encoding.UTF8.GetBytes(key), iv))
                {
                    var ret = string.Empty;
                    using (var memoryStream = new MemoryStream(cipher))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (var streamReader = new StreamReader(cryptoStream))
                            {
                                ret = streamReader.ReadToEnd();
                            }
                        }
                    }

                    return ret;
                }
            }
        }

        public string Encrypt(string arg) => Encrypt(arg, KEY);

        public string Encrypt(string arg, string key)
        {
            using (var aes = Aes.Create())
            {
                using (var encryptor = aes.CreateEncryptor(Encoding.UTF8.GetBytes(key), aes.IV))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor,
                            CryptoStreamMode.Write))

                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(arg);
                        }

                        var decryptedContent = memoryStream.ToArray();
                        var ret = new byte[aes.IV.Length + decryptedContent.Length];
                        Buffer.BlockCopy(aes.IV, 0, ret, 0, aes.IV.Length);
                        Buffer.BlockCopy(decryptedContent, 0, ret, aes.IV.Length, decryptedContent.Length);
                        return Convert.ToBase64String(ret);
                    }
                }
            }
        }

        private const string KEY = "031fd7211421480bb359ed3365f1c682";
    }
}
