using NUnit.Framework;
using NumberPuzzleWeb.Core.DomainModel;

namespace NumberPuzzleWeb.UnitTest
{
    public class Tests
    {
        
        [Test]
        public void TestIsNotSolved()
        {
            var gameModel = new GameModel(new[] {1, 2, 3, 4, 5, 6, 7, 0, 8});
            Assert.AreEqual(false, gameModel.IsSolved);
        }

        [Test]
        public void TestIsSolved()
        {
            var gameModel = new GameModel(new[] { 1, 2, 3, 4, 5, 6, 7, 0, 8 });
            Assert.AreEqual(false, gameModel.IsSolved);
        }
    }
}