using System;
using System.Collections.Generic;
using System.Text;
using CodeNotebook.Util;
using Xunit;

namespace Util
{
    public class AssertUtilTest
    {
        [Fact]
        public void NotNull()
        {
            Assert.Throws<Exception>(() =>
            {
                AssertUtil.NotNull<object>(null, string.Empty);
            });

            Assert.Throws<Exception>(() =>
            {
                AssertUtil.NotNull(string.Empty, string.Empty);
            });

            Assert.Throws<Exception>(() =>
            {
                AssertUtil.NotNull("", string.Empty);
            });

            Assert.Throws<Exception>(() =>
            {
                AssertUtil.NotNull(" ", string.Empty);
            });

            Assert.Throws<Exception>(() =>
            {
                AssertUtil.NotNull(new string[0], string.Empty);
            });

            Assert.Throws<Exception>(() =>
            {
                AssertUtil.NotNull(new List<string>(), string.Empty);
            });

            Assert.Throws<Exception>(() =>
            {
                AssertUtil.NotNull(new Dictionary<string, object>(), string.Empty);
            });

            AssertUtil.NotNull("1", string.Empty);
            AssertUtil.NotNull(new string[1] { "1" }, string.Empty);
            AssertUtil.NotNull(new List<string> { "1" }, string.Empty);
            AssertUtil.NotNull(new Dictionary<string, object> { { "1", "1" } }, string.Empty);
        }
    }
}
