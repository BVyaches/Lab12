using BinTree;
using ChallengeLibrary;
using System.Data;

namespace TestCollections
{
    [TestClass]
    public class TestBinTree
    {
        
        [TestMethod]
        public void BinTree_Add_AddsElementToTree()
        {
            // Arrange
            var tree = new BinTree<Challenge>();

            // Act
            tree.Add(new Challenge());

            // Assert
            // You can assert the state of the tree after adding the element
            // For example, check if the height is increased or if the element exists in the tree
            Assert.AreEqual(1, tree.Height());
        }

        

        [TestMethod]
        public void BinTree_Height_ReturnsCorrectHeight()
        {
            // Arrange
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            tree.Add(challenge1);
            tree.Add(challenge2);
            tree.Add(challenge3);

            // Act
            int height = tree.Height();

            // Assert
            Assert.AreEqual(2, height);
        }

        [TestMethod]
        public void BinTree_Add_ThrowsExceptionForDuplicateValue()
        {
            // Arrange
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            tree.Add(challenge1);

            // Act & Assert
            // Adding the same value again should throw a DuplicateNameException
            Assert.ThrowsException<DuplicateNameException>(() => tree.Add(challenge1));
        }

        [TestMethod]
        public void BinTree_Clear_ResetsTreeToEmptyState()
        {
            // Arrange
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            tree.Add(challenge1);
            tree.Add(challenge2);
            tree.Add(challenge3);
            tree.Show();
            // Act
            tree.Clear();

            // Assert
            // After clearing the tree, the height should be 0 and the root should be null
            Assert.AreEqual(0, tree.Height());
        }

        [TestMethod]
        public void BinTree_RandomInit_GeneratesTreeWithSpecifiedLength()
        {
            // Arrange
            var tree = new BinTree<Challenge>();

            // Act
            tree.RandomInit(5);

            // Assert
            // After calling RandomInit with length 5, the tree should have 5 elements
            Assert.AreNotEqual(0, tree.Height());
        }

        [TestMethod]
        public void BinTree_RandomInit_GeneratesTreeWithZeroLength()
        {
            // Arrange
            var tree = new BinTree<Challenge>();

            // Act
            tree.RandomInit(-5);

            // Assert
            // After calling RandomInit with length 5, the tree should have 5 elements
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

            // Assert
            // After calling ToSearchTree, the tree should be transformed into a binary search tree
            // You can assert the expected state of the tree, such as checking if elements are ordered correctly
            Assert.IsTrue(tree.IsBinarySearchTree());
        }

        [TestMethod]
        public void BinTree_ToString_ReturnsExpectedStringRepresentation()
        {
            // Arrange
            var tree = new BinTree<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            tree.Add(challenge1);
            tree.Add(challenge2);
            tree.Add(challenge3);

            string expected = "   Испытание: Физика Время на прохождение: 10 Учитель: Василий\nИспытание: Математика Время на прохождение: 25 Учитель: Ирина\n   Испытание: История Время на прохождение: 10 Учитель: Дима\n";

            // Act
            string result = tree.ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BinTree_ToString_ReturnsEmptyStringForEmptyTree()
        {
            // Arrange
            var tree = new BinTree<Challenge>();

            // Act
            string result = tree.ToString();

            // Assert
            Assert.AreEqual("Похоже, дерево пустое", result);
        }
    }
}