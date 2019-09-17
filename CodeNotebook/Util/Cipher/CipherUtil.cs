using System;
using System.Collections.Generic;
using System.Text;
using CodeNotebook.Util.Cipher;

namespace CodeNotebook.Util
{
    public class CipherUtil
    {
        #region Private
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
        #endregion

        public static ICipherHandler MD5 => GetHandler<Md5Handler>();
        public static ICipherHandler AES => GetHandler<AesHandler>();
    }
}
