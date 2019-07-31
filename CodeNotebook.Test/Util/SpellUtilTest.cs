using System;
using System.Collections.Generic;
using System.Text;
using CodeNotebook.Util;
using Xunit;

namespace Util
{
    public class SpellUtilTest
    {
        [Fact]
        public void ToAllSpell()
        {
            var dict = new Dictionary<string, Tuple<string, string>>() {
                { "梅钰", new Tuple<string,string>( "meiyu","MEIYU") },
                { "张洺", new Tuple<string,string>( "zhangming","ZHANGMING") },
                { "王玥", new Tuple<string,string>( "wangyue","WANGYUE") },
                { "王思琪", new Tuple<string,string>( "wangsiqi","WANGSIQI") },
                { "董云强", new Tuple<string,string>( "dongyunqiang","DONGYUNQIANG") },
                { "宋红培", new Tuple<string,string>( "songhongpei","SONGHONGPEI") },
                { "石磊", new Tuple<string,string>( "shilei","SHILEI") }
            };

            foreach (var item in dict)
            {
                var name = item.Key;
                var spell1 = item.Value.Item1;
                var spell2 = item.Value.Item2;

                Assert.Equal(SpellUtil.ToAllSpell(name, false), spell1);
                Assert.Equal(SpellUtil.ToAllSpell(name), spell2);
            }
        }

        [Fact]
        public void ToFirstSpell()
        {
            var dict = new Dictionary<string, Tuple<string, string>>() {
                { "梅钰", new Tuple<string,string>( "my","MY") },
                { "张洺", new Tuple<string,string>( "zm","ZM") },
                { "王玥", new Tuple<string,string>( "wy","WY") },
                { "王思琪", new Tuple<string,string>( "wsq","WSQ") },
                { "董云强", new Tuple<string,string>( "dyq","DYQ") },
                { "宋红培", new Tuple<string,string>( "shp","SHP") },
                { "石磊", new Tuple<string,string>( "sl","SL") }
            };

            foreach (var item in dict)
            {
                var name = item.Key;
                var spell1 = item.Value.Item1;
                var spell2 = item.Value.Item2;

                Assert.Equal(SpellUtil.ToFirstSpell(name, false), spell1);
                Assert.Equal(SpellUtil.ToFirstSpell(name), spell2);
            }
        }
    }
}
