using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Validator.Domain.Commands;
using Validator.Domain.Handlers;
using Validator.Domain.UseCases;

namespace Validator.Tests.Handlers
{
    [TestClass]
    public class ValidatorHandlerTest
    {
        private readonly ValidatorHandler _validatorHandler;
        private readonly Mock<ValidatePassword> _mockValidatePassword;
        private readonly Mock<ILogger<ValidatorHandler>> _mockLoggerValidatorHandler;
        private readonly Mock<ILogger<ValidatePassword>> _mockLoggerValidatePasswordUseCase;
        private const int NineCharactersLength = 9;

        public ValidatorHandlerTest()
        {
            _mockLoggerValidatePasswordUseCase = new Mock<ILogger<ValidatePassword>>();
            _mockValidatePassword = new Mock<ValidatePassword>(_mockLoggerValidatePasswordUseCase.Object);
            _mockLoggerValidatorHandler = new Mock<ILogger<ValidatorHandler>>();
            _validatorHandler = new ValidatorHandler(_mockValidatePassword.Object, _mockLoggerValidatorHandler.Object);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenPasswordIsValid()
        {
            string password = "AbTp9!fok";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            var result = _validatorHandler.Handle(command);
            Assert.IsTrue(result.Valid);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenPasswordIsValidWithMoreThan9Characters()
        {
            string password = "AbTp9!fokey";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            var result = _validatorHandler.Handle(command);
            Assert.IsTrue(result.Valid);
            Assert.IsTrue(password.Length > NineCharactersLength);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsEmpty()
        {
            string password = "";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => _validatorHandler.Handle(command));
            Assert.AreEqual("Command is null or empty (Parameter 'command')", exception.Message);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsNull()
        {
            string password = null;
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => _validatorHandler.Handle(command));
            Assert.AreEqual("Command is null or empty (Parameter 'command')", exception.Message);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern1()
        {
            string password = "aa";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            var result = _validatorHandler.Handle(command);
            Assert.IsFalse(result.Valid);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern2()
        {
            string password = "AAAbbbCc";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            var result = _validatorHandler.Handle(command);
            Assert.IsFalse(result.Valid);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern3()
        {
            string password = "AbTp9!foo";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            var result = _validatorHandler.Handle(command);
            Assert.IsFalse(result.Valid);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern4()
        {
            string password = "AbTp9!foA";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            var result = _validatorHandler.Handle(command);
            Assert.IsFalse(result.Valid);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenPasswordIsOutOfPattern5()
        {
            string password = "AbTp9 fok";
            ValidatePasswordCommand command = new ValidatePasswordCommand(password);
            var result = _validatorHandler.Handle(command);
            Assert.IsFalse(result.Valid);
        }
    }
}