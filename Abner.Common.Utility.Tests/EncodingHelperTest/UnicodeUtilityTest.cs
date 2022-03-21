
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Abner.Common.Utility.Tests.EncodingHelper
{
    public class UnicodeUtilityTest
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        [Fact]
        public void Unicode()
        {
            var person = new Person { Name = "你好，earth!\r\n好<p>sda</p>", Age = 20 };

            var nameUnicode = UnicodeUtility.ToUnicode(person.Name);
            var origin = UnicodeUtility.UnEscapeUnicode(nameUnicode);
            Assert.Equal(person.Name, origin);

            var unicode = UnicodeUtility.ToJsonUnicode(person);
            var origino = UnicodeUtility.ToObject<Person>(unicode);
            Assert.Equal(person.Name, origino.Name);
            Assert.Equal(person.Age, origino.Age);

            //var unicode1 = UnicodeUtility.UnEscapeUnicode(unicode);
            //Assert.Equal(UnicodeUtility.ToJsonUnicode(person, Newtonsoft.Json.StringEscapeHandling.Default), unicode1);
        }
    }
}
