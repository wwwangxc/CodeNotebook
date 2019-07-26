using System;
using System.Collections.Generic;
using System.Text;
using CodeNotebook.Util;
using Xunit;

namespace CodeNotebook.Test
{
    public class EmptyUtilTest
    {
        [Fact]
        public void IsNullOrEmpty()
        {
            var strList1 = new List<string> { "1", "2" };
            var strList2 = new List<string>();
            List<string> strList3 = null;
            Assert.True(!EmptyUtil.IsNullOrEmpty(strList1));
            Assert.True(EmptyUtil.IsNullOrEmpty(strList2));
            Assert.True(EmptyUtil.IsNullOrEmpty(strList3));

            var intList1 = new List<int> { 1, 2 };
            var intList2 = new List<int>();
            List<int> intList3 = null;
            Assert.True(!EmptyUtil.IsNullOrEmpty(intList1));
            Assert.True(EmptyUtil.IsNullOrEmpty(intList2));
            Assert.True(EmptyUtil.IsNullOrEmpty(intList3));
        }
    }
}
