using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Util
{
    public interface ICipherHandler
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        string Encrypt(string arg);
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        string Encrypt(string arg, string key);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        string Decrypt(string arg);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        string Decrypt(string arg, string key);
    }
}
