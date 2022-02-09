using KataPassword5._0;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace KataPassword5._0Test
{
    public class Tests
    {

        private CheckerPassword _cheker;
        private ResultValidation resultValidation;

        [SetUp]
        public void Setup()
        {
            _cheker = new CheckerPassword();
            resultValidation = new ResultValidation { ErrorDescription = new List<string>(), IsValid = true };
        }

        [Test]
        public void TestAtLeast8char_valid()
        {
            var result = _cheker.Validate("Pbcpks12!");

            Assert.IsTrue(result.IsValid);
            Assert.IsEmpty(result.ErrorDescription);

        }

        [Test]
        public void TestAtLeast8char_NotValid()
        {
            var result = _cheker.Validate("abc");

            var expected = new List<string>()
            {
                "Password must be at least 8 characters",
                "The password must contain at least 2 numbers",
                "password must contain at least one capital letter",
                "password must contain at least one special character"
            };


            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(expected, result.ErrorDescription);

        }


        [Test]
        public void TestAtLeast8charAndAtLeast2Numbers_NotValid()
        {
            var result = _cheker.Validate("Pbcabcabc1!");

            var expected = new List<string>()
            {
                "The password must contain at least 2 numbers"
            };


            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(expected, result.ErrorDescription);

        }

        [Test]
        public void TestCapitalLette_NotValid()
        {
            var result = _cheker.Validate("pbcabcabc12!");
            Assert.IsFalse(result.IsValid);
            Assert.Contains("password must contain at least one capital letter", result.ErrorDescription);
        }



        [Test]
        public void TestSpecialChar_NotValid()
        {
            var result = _cheker.Validate("Pbcabcabc12");
            Assert.IsFalse(result.IsValid);
            Assert.Contains("password must contain at least one special character", result.ErrorDescription);
        }


        [Test]
        public void TestSpecialChar_Valid()
        {
            var result = _cheker.Validate("Pbcabcabc12!");
            Assert.IsTrue(result.IsValid);
        }

        [TestCase("Password23!", ExpectedResult = true)]
        [TestCase("pAssword23*", ExpectedResult = true)]
        [TestCase("Ciao4K!1254", ExpectedResult = true)]


        public bool TestValidPassword(string input) => _cheker.Validate(input).IsValid;
        

        [TearDown]
        public void Destroy()
        {
            _cheker = null;
            GC.Collect();
        }

    }
}