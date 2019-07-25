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
        /// <summary>
        /// 判断指定条件是否为true，如果该条件为false，则引发一个异常
        /// </summary>
        /// <exception cref="Exception">条件为false时抛出</exception>
        /// <param name="condition">表达式</param>
        /// <param name="message">错误信息</param>
        public static void IsTrue(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
        }

        /// <summary>
        /// 判断指定对象是否非null，如果为null，则引发一个异常
        /// </summary>
        /// <exception cref="Exception">条件为false时抛出</exception>
        /// <param name="obj">预期非null的对象</param>
        /// <param name="message">错误信息</param>
        public static void IsNotNull(object obj, string message)
        {
            if (obj == null) throw new Exception(message);
        }
    }
}
