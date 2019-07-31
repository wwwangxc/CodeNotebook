using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using CodeNotebook.Util;
using Xunit;

namespace Util
{
    public class JsonUtilTest
    {
        [Fact]
        public void Test()
        {
            var json = "{\"id\":1,\"name\":\"名称\",\"password\":\"密码\",\"groups\":[{\"id\":1,\"name\":\"组1\"},{\"id\":2,\"name\":\"组2\"}]}";
            var data = new ClassA
            {
                Id = 1,
                Name = "名称",
                Password = "密码",
                Groups = new List<ClassB>()
                {
                    new ClassB
                    {
                        Id = 1,
                        Name = "组1"
                    },
                    new ClassB
                    {
                        Id = 2,
                        Name = "组2"
                    }
                }
            };

            Assert.Equal(
                JsonUtil.ToJson(JsonUtil.ToObject<ClassA>(json)),
                JsonUtil.ToJson(data));
        }
    }

    [DataContract]
    class ClassA
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        public string Password { get; set; }
        [DataMember(Name = "groups")]
        public List<ClassB> Groups { get; set; }
    }

    [DataContract]
    class ClassB
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
