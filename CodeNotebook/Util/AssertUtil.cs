using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Util
{
    /// <summary>
    /// 条件判定工具类
    /// </summary>
    public static class AssertUtil
    {
        #region IsTrue
        /// <summary>
        /// 判断指定条件是否为true，如果该条件为false，则引发一个异常
        /// </summary>
        /// <exception cref="Exception">条件为false时抛出</exception>
        /// <param name="condition">表达式</param>
        /// <param name="message">错误信息</param>
        public static void IsTrue(bool condition, string message = null)
        {
            if (!condition) ThrowException(message);
        }

        /// <summary>
        /// 判断指定条件是否为true，如果该条件为false，则引发指定异常
        /// </summary>
        /// <param name="condition">表达式</param>
        /// <param name="exception">条件为false时引发的异常</param>
        public static void IsTrue(bool condition, Exception exception)
        {
            if (!condition) throw exception;
        }
        #endregion

        #region NotNull
        /// <summary>
        /// 判断指定对象是否非null，如果为null则引发一个异常
        /// </summary>
        /// <exception cref="Exception">对象为null时抛出</exception>
        /// <param name="target">目标对象</param>
        /// <param name="message">错误信息</param>
        public static void NotNull(object target, string message = null)
        {
            if (target == null) ThrowException(message);
        }

        /// <summary>
        /// 判断指定对象是否非null，如果为null则引发一个异常
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="exception">目标对象为null时引发的异常</param>
        public static void NotNull(object target, Exception exception)
        {
            if (target == null) throw exception;
        }

        /// <summary>
        /// 判断指定的字符串是否为null、空或一连串的空白字符，如果为null、空或一连串的空白字则引发一个异常
        /// </summary>
        /// <exception cref="Exception">指定字符串为null、空或一连串的空白字时抛出</exception>
        /// <param name="target">目标对象</param>
        /// <param name="message">错误信息</param>
        public static void NotNull(string target, string message = null)
        {
            if (string.IsNullOrWhiteSpace(target.ToString())) ThrowException(message);
        }

        /// <summary>
        /// 判断指定的字符串是否为null、空或一连串的空白字符，如果为null、空或一连串的空白字则引发一个异常
        /// </summary>
        /// <exception cref="Exception">指定字符串为null、空或一连串的空白字时抛出</exception>
        /// <param name="target">目标对象</param>
        /// <param name="exception">指定字符串为null、空或一连串的空白字时引发的异常</param>
        public static void NotNull(string target, Exception exception)
        {
            if (string.IsNullOrWhiteSpace(target.ToString())) throw exception;
        }

        /// <summary>
        /// 判断指定对象是否非null，如果为null或长度为0，则引发一个异常
        /// </summary>
        /// <exception cref="Exception">对象为null或长度为0时抛出</exception>
        /// <param name="target">目标对象</param>
        /// <param name="message">错误信息</param>
        public static void NotNull<T>(IEnumerable<T> target, string message = null)
        {
            if (target == null || !target.GetEnumerator().MoveNext()) ThrowException(message);
        }

        /// <summary>
        /// 判断指定对象是否非null，如果为null或长度为0，则引发一个异常
        /// </summary>
        /// <exception cref="Exception">对象为null或长度为0时抛出</exception>
        /// <param name="target">目标对象</param>
        /// <param name="exception">目标对象为null或长度为0时引发的异常</param>
        public static void NotNull<T>(IEnumerable<T> target, Exception exception)
        {
            if (target == null || !target.GetEnumerator().MoveNext()) throw exception;
        }
        #endregion

        private static void ThrowException(string message) => throw new Exception(message);
    }
}
