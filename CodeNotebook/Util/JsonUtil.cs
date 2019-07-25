using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CodeNotebook.Util
{
    /// <summary>
    /// json工具类
    /// </summary>
    public static class JsonUtil
    {
        /// <summary>
        /// 将指定对象转换为json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">指定对象</param>
        /// <param name="encoding">编码格式，默认utf8</param>
        /// <returns></returns>
        public static string ToJson<T>(T obj, Encoding encoding = null)
        {
            if (obj == null) return string.Empty;

            using (var stream = new MemoryStream())
            {
                new DataContractJsonSerializer(obj.GetType())
                    .WriteObject(stream, obj);
                byte[] dataBytes = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(dataBytes, 0, (int)stream.Length);
                return encoding == null ?
                    Encoding.UTF8.GetString(dataBytes) : encoding.GetString(dataBytes);
            }
        }

        /// <summary>
        /// 将json字符串转换为指定对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">指定json字符串</param>
        /// <param name="encoding">编码格式，默认urf8</param>
        /// <returns></returns>
        public static T ToObject<T>(string json, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(json)) return default;
            var dataBytes = encoding == null ?
                Encoding.UTF8.GetBytes(json) : encoding.GetBytes(json);
            using (var stream = new MemoryStream(dataBytes))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(stream);
            }
        }
    }
}
