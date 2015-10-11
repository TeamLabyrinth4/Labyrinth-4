namespace Labyrinth_Game.Tests
{    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    using Labyrinth.Model;

    [TestClass]
    public class ModelsTests
    {
        [TestMethod]
        public void TestMatrixAlwaysToCreateADiffrentMatrix()
        {
            var labyrinthOne = new LabyrinthMatrix().Matrix;
            Thread.Sleep(25);
            var labyrinthTwo = new LabyrinthMatrix().Matrix;
            var result = CompareTwoMatrix(labyrinthOne, labyrinthTwo);

            Assert.IsTrue(result, "Does not create different matrisies");
        }

        private bool CompareTwoMatrix(char[][] expected, char[][] actual)
        {
            for (int row = 10; row < expected.Length; row++)
            {
                for (int col = 10; col < expected[row].Length; col++)
                {
                    if (expected[row][col] != actual[row][col])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
