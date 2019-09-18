using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Util.Cipher
{
    public abstract class BaseCipherHandler : ICipherHandler
    {
        public string Decrypt(string arg) => Decrypt(arg, KEY);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual string Decrypt(string arg, string key) => throw new NotImplementedException();
        public string Encrypt(string arg) => Encrypt(arg, KEY);
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual string Encrypt(string arg, string key) => throw new NotImplementedException();
        private const string KEY = "031fd7211421480bb359ed3365f1c682";
    }
}
