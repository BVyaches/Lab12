using ChallengeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab;

namespace TestCollections
{
    [TestClass]
    public class TestDoubleLinkedList
    {
        [TestMethod]
        public void DoubleLinkedListAddOneElementTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge = new("Физика", 100, "Ирина");

            list.Add(challenge);

            Assert.IsNotNull(list);
        }


        [TestMethod]
        public void DoubleLinkedListAddSomeElementsTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);

            Assert.AreEqual(2, list.Length);
        }

        [TestMethod]
        public void DoubleLinkedListRemoveOneTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);
            bool result = list.Remove(challenge2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoubleLinkedListRemoveSomeElementsAreRemovedTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);
            list.Add(challenge2);
            bool result = list.Remove(challenge2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoubleLinkedListRemoveAllElementsTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge2);
            list.Add(challenge2);
            bool result = list.Remove(challenge2);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void DoubleLinkedListRemoveSomeElementsCountTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);
            list.Add(challenge2);
            list.Remove(challenge2);

            Assert.AreEqual(1, list.Length);
        }

        [TestMethod]
        public void DoubleLinkedListClearCountTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);
            list.Clear();

            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void DoubleLinkedListClearNothingToRemoveTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);
            list.Clear();
            bool result = list.Remove(challenge1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DoubleLinkedListRandomInitNormalLengthTest()
        {
            DoubleLinkedList<Challenge> list = new();

            list.RandomInit(10);

            Assert.AreEqual(10, list.Length);
        }


        [TestMethod]
        public void DoubleLinkedListRandomInitBelowZeroLengthTest()
        {
            DoubleLinkedList<Challenge> list = new();

            list.RandomInit(-5);

            Assert.AreEqual(0, list.Length);
        }


        [TestMethod]
        public void DoubleLinkedListCloneTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);
            DoubleLinkedList<Challenge> clonedList = list.Clone();

            Assert.AreEqual(list.Length, clonedList.Length);
        }


        [TestMethod]
        public void DoubleLinkedListCloneDepthTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            list.Add(challenge1);
            list.Add(challenge2);
            DoubleLinkedList<Challenge> clonedList = list.Clone();
            list.Head.Name = "Проверка";

            Assert.AreNotEqual(list.Head, clonedList.Head);
        }

        [TestMethod]
        public void DoubleLinkedListToStringEmptyTest()
        {
            DoubleLinkedList<Challenge> list = new();
            string expected = "Похоже, данный список пустой";

            Assert.AreEqual(expected, list.ToString());
        }

        [TestMethod]
        public void DoubleLinkedListToStringNotEmptyTest()
        {
            DoubleLinkedList<Challenge> list = new();
            string expected = "Испытание: Физика Время на прохождение: 100 Учитель: Ирина\n";

            Challenge challenge1 = new("Физика", 100, "Ирина");
            list.Add(challenge1);

            Assert.AreEqual(expected, list.ToString());
        }

        [TestMethod]
        public void DoubleLinkedListHeadSetterTest()
        {
            DoubleLinkedList<Challenge> list = new();
            Challenge challenge1 = new("Физика", 100, "Ирина");
            Challenge challenge2 = new("История", 10, "Дима");

            list.Add(challenge1);
            list.Head = challenge2;

            Assert.AreEqual(list.Head, challenge2);
        }
    }
}
