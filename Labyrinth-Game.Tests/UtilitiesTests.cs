namespace Labyrinth_Game.Tests
{
    using Labyrinth.Common;
    using Labyrinth.Enums;
    using Labyrinth.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void TestIfMoveValidatorReturnsTrueWhitValidCommand()
        {
            bool result = MoveValidator.IsValidComandDir("d");
            Assert.IsTrue(result, "Incorrect false return of IsValidComandDir");
        }

        [TestMethod]
        public void TestIfMoveValidatorReturnsFalseWhitInvalidCommand()
        {
            bool result = MoveValidator.IsValidComandDir("Invalid");
            Assert.IsFalse(result, "Incorrect true return of IsValidComandDir");
        }

        [TestMethod]
        public void TestIfCommandValidatorReturnsTrueWhitValidCommand()
        {
            bool result = CommandValidator<CommandType>.IsValidCommand("D");
            Assert.IsTrue(result, "Incorrect true return of IsValidComandDir");
        }

        [TestMethod]
        public void TestIfCommandValidatorReturnsFalseWhitInvalidCommand()
        {
            bool result = CommandValidator<CommandType>.IsValidCommand("Invalid");
            Assert.IsFalse(result, "Incorrect true return of IsValidComandDir");
        }
    }
}
