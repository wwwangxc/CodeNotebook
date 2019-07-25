using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace CodeNotebook.Util
{
    /// <summary>
    /// 拼音工具类
    /// 依赖：
    ///     1. NPinyin
    ///     2. PinYinConverter
    /// </summary>
    public static class SpellUtil
    {
        /// <summary>
        /// 将指定汉字转换为拼音
        /// </summary>
        /// <param name="str">汉字字符串</param>
        /// <param name="toUpper">true：转大写，false：转小写</param>
        /// <returns></returns>
        public static string ToAllSpell(string str, bool toUpper = true)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            var sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append(Char2Spell(str[i]));
            }

            return toUpper ? sb.ToString().ToUpper() : sb.ToString().ToLower();
        }

        /// <summary>
        /// 汉字转拼音首字母
        /// </summary>
        /// <param name="str">汉字</param>
        /// <param name="toUpper">true：转大写，false：转小写</param>
        /// <returns></returns>
        public static string ToFirstSpell(string str, bool toUpper = true)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            var sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append(Char2Spell(str[i])[0]);
            }

            return toUpper ? sb.ToString().ToUpper() : sb.ToString().ToLower();
        }

        private static string Char2Spell(char chr)
        {
            var coverchr = NPinyin.Pinyin.GetPinyin(chr);
            if (ChineseChar.IsValidChar(coverchr[0]))
            {
                foreach (string value in new ChineseChar(coverchr[0]).Pinyins)
                {
                    if (!string.IsNullOrEmpty(value)) return value.Remove(value.Length - 1, 1);
                }
            }
            return coverchr;
        }
    }
}
