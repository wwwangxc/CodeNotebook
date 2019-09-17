using System;
using System.Collections.Generic;
using System.Text;
using CodeNotebook.Util.Handler;

namespace CodeNotebook.Util
{
    public class CipherUtil
    {
        private volatile static Dictionary<string, ICipherHandler> _handler = new Dictionary<string, ICipherHandler>();
        private readonly static object _sysLock = new object();
        private CipherUtil() { }
        private static ICipherHandler GetHandler<T>() where T : ICipherHandler, new()
        {
            ICipherHandler handler;
            var fullName = typeof(T).FullName;

            if (!_handler.TryGetValue(fullName, out handler))
            {
                lock (_sysLock)
                {
                    if (!_handler.TryGetValue(fullName, out handler))
                    {
                        handler = Activator.CreateInstance<T>();
                        _handler.Add(fullName, handler);
                    }
                }
            }

            return handler;
        }

        public ICipherHandler MD5 => GetHandler<Md5Handler>();

    }

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
