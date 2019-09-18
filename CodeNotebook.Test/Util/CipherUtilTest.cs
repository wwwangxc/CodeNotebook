using System;
using System.Collections.Generic;
using System.Text;
using CodeNotebook.Util;
using Xunit;
using Xunit.Abstractions;

namespace Util
{
    public class CipherUtilTest
    {
        private ITestOutputHelper Output { get; }
        public CipherUtilTest(ITestOutputHelper tempOutput)
        {
            Output = tempOutput;
        }

        [Fact]
        public void MD5()
        {
            var str = "CodeNotebook";
            this.Output.WriteLine($"MD5加密前：{str}");

            var encryptStr = CipherUtil.MD5.Encrypt(str);
            Output.WriteLine($"MD5加密后：{encryptStr}");

            Output.WriteLine(string.Empty);
            var key = Guid.NewGuid().ToString("N");
            Output.WriteLine($"Key：{key}");

            this.Output.WriteLine($"MD5加密前：{str}");

            encryptStr = CipherUtil.MD5.Encrypt(str, key);
            Output.WriteLine($"MD5加密后：{encryptStr}");
        }

        [Fact]
        public void AES()
        {
            var str = "CodeNotebook";
            this.Output.WriteLine($"AES加密前：{str}");

            var encryptStr = CipherUtil.AES.Encrypt(str);
            Output.WriteLine($"AES加密后：{encryptStr}");

            var decryptStr = CipherUtil.AES.Decrypt(encryptStr);
            Output.WriteLine($"AES解密后：{decryptStr}");

            Output.WriteLine(string.Empty);
            var key = Guid.NewGuid().ToString("N");
            Output.WriteLine($"Key：{key}");

            this.Output.WriteLine($"AES加密前：{str}");

            encryptStr = CipherUtil.AES.Encrypt(str, key);
            Output.WriteLine($"AES加密后：{encryptStr}");

            decryptStr = CipherUtil.AES.Decrypt(encryptStr, key);
            Output.WriteLine($"AES解密后：{decryptStr}");
        }

        [Fact]
        public void SHA1()
        {
            var str = "CodeNotebook";
            this.Output.WriteLine($"SHA1加密前：{str}");

            var encryptStr = CipherUtil.MD5.Encrypt(str);
            Output.WriteLine($"SHA1加密后：{encryptStr}");

            Output.WriteLine(string.Empty);
            var key = Guid.NewGuid().ToString("N");
            Output.WriteLine($"Key：{key}");

            this.Output.WriteLine($"SHA1加密前：{str}");

            encryptStr = CipherUtil.MD5.Encrypt(str, key);
            Output.WriteLine($"SHA1加密后：{encryptStr}");
        }
    }
}
