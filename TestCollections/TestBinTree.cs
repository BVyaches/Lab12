using BinTree;
using ChallengeLibrary;
using System.Data;

namespace TestCollections
{
    [TestClass]
    public class TestBinTree
    {
        
        [TestMethod]
        public void BinTreeAddAddsElementToTreeTest()
        {
            var tree = new BinTree<Challenge>();

            tree.Add(new Challenge());

            Assert.AreEqual(1, tree.Height());
        }

        

        [TestMethod]
        public void BinTreeHeightReturnsCorrectHeightTest()
        {
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            tree.Add(challenge1);
            tree.Add(challenge2);
            tree.Add(challenge3);

            int height = tree.Height();

            Assert.AreEqual(2, height);
        }

        [TestMethod]
        public void BinTreeAddThrowsExceptionForDuplicateValueTest()
        {
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            tree.Add(challenge1);

            Assert.ThrowsException<DuplicateNameException>(() => tree.Add(challenge1));
        }

        [TestMethod]
        public void BinTreeClearResetsTreeToEmptyStateTest()
        {
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            tree.Add(challenge1);
            tree.Add(challenge2);
            tree.Add(challenge3);

            tree.Clear();

            Assert.AreEqual(0, tree.Height());
        }

        [TestMethod]
        public void BinTreeRandomInitGeneratesTreeWithSpecifiedLengthTest()
        {
            var tree = new BinTree<Challenge>();

            tree.RandomInit(5);

            Assert.AreNotEqual(0, tree.Height());
        }

        [TestMethod]
        public void BinTreeRandomInitGeneratesTreeWithZeroLengthTest()
        {
            var tree = new BinTree<Challenge>();

            tree.RandomInit(-5);

            Assert.AreEqual(0, tree.Height());
        }



        [TestMethod]
        public void BinTreeAddRotationTest()
        {
            var tree = new BinTree<Challenge>();
            for (int i = 0; i < 50; i++) 
            {
                Challenge challenge = new Challenge();
                challenge.RandomInit();
                try
                { tree.Add(challenge); }
                catch(Exception) { }
                
            }

            Assert.IsTrue(tree.IsBinarySearchTree());
        }

        [TestMethod]
        public void BinTreeToStringTest()
        {
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            tree.Add(challenge1);
            tree.Add(challenge2);
            tree.Add(challenge3);

            string expected = "   Испытание: Физика Время на прохождение: 10 Учитель: Василий\nИспытание: Математика Время на прохождение: 25 Учитель: Ирина\n   Испытание: История Время на прохождение: 10 Учитель: Дима\n";

            string result = tree.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BinTreeToStringEmptyTest()
        {
            var tree = new BinTree<Challenge>();

            string result = tree.ToString();

            Assert.AreEqual("Похоже, дерево пустое", result);
        }
    }
}