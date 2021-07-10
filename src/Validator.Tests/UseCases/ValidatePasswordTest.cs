using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Validator.Domain.UseCases;
using Validator.Domain.ValueObjects;

namespace Validator.Tests.UseCases
{
    [TestClass]
    public class ValidatePasswordTest
    {
        private readonly ValidatePassword _validatePassword;
        private readonly Mock<ILogger<ValidatePassword>> _mockLogger;

        public ValidatePasswordTest()
        {
            _mockLogger = new Mock<ILogger<ValidatePassword>>();
            _validatePassword = new ValidatePassword(_mockLogger.Object);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenPasswordIsValid()
        {
            string password = "AbTp9!fok";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenPasswordIsValidWithMoreThan9Characters()
        {
            string password = "AbTp9!fokey";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsEmpty()
        {
            string password = "";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern1()
        {
            string password = "aa";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern2()
        {
            string password = "AAAbbbCc";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern3()
        {
            string password = "AbTp9!foo";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern4()
        {
            string password = "AbTp9!foA";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern5()
        {
            string password = "AbTp9 fok";
            Password p = new Password(password);
            var result = _validatePassword.Execute(p);
            Assert.IsFalse(result);
        }
    }
}