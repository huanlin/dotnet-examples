using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MyLib;
using NUnit.Framework;

namespace MyLibTests
{
    [TestFixture]
    public class MyClassTests
    {
        [Test]
        public void Should_Add_Two_Numbers()
        {
            var sut = new MyClass();
            int result = sut.Add(10, 20);

            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Should_Add_Two_Numbers_Fluent()
        {
            var sut = new MyClass();
            int result = sut.Add(1, 20);
            result.Should().Be(30, "because 10+20=30.");
        }

        [Test]
        public void Should_Get_Hello_String_Fluent()
        {
            var sut = new MyClass();
            string result = sut.GetHelloString("Michael");

            result.Should().StartWith("Hello").And.EndWith("Michael");
        }

    }
}
