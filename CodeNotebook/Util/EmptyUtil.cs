using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Util
{
    /// <summary>
    /// 判空工具类
    /// </summary>
    public static class EmptyUtil
    {
        /// <summary>
        /// 判断指定的集合是否为null或空集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(ICollection<T> collection) => 
            collection == null || collection.Count == 0;

        /// <summary>
        /// 判断指定的字符串是否为null、空或一连串的空白字符
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string str) =>
            string.IsNullOrWhiteSpace(str);
    }
}
