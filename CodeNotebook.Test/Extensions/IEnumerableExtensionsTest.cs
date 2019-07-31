using System;
using System.Collections.Generic;
using System.Text;
using CodeNotebook.Extensions;
using Xunit;

namespace Extensions
{
    public class IEnumerableExtensionsTest
    {
        [Fact]
        public void IEnumerableToString()
        {
            var list = new List<ClassA>();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(new ClassA
                {
                    Id = i,
                    Name = $"str{i}"
                });
            }
            
            var str = list.ToString(",", nameof(ClassA.Id));
            str = list.ToString(",", nameof(ClassA.Name));
            var a = 0;
        }
    }

    class ClassA
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
