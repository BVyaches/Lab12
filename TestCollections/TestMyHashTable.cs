using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeLibrary;

namespace TestCollections
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyHashTable;
    using System;

    [TestClass]
    public class MyHashTableTests
    {
        [TestMethod]
        public void MeHashTableConstructorFromAnotherTest()
        {
            MyHashTable<Challenge> hashtable = new();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            hashtable.Add(challenge1);

            MyHashTable<Challenge> hashtable2 = new(hashtable);

            Assert.IsTrue(hashtable2.Contains(challenge1));
        }

        [TestMethod]
        public void MyHashTableAddValidDataItemAddedTest()
        {
            MyHashTable<Challenge> hashtable = new();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            hashtable.Add(challenge1);

            Assert.IsTrue(hashtable.Count == 1);
        }

        [TestMethod]
        public void MyHashTableAddNullDataItemNotAddedTest()
        {
            MyHashTable<Challenge> hashtable = new();

            hashtable.Add(null);

            Assert.IsTrue(hashtable.Count == 0);
        }

        [TestMethod]
        public void MyHashTableAddSameDataTest()
        {
            MyHashTable<Challenge> hashtable = new(3);
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            hashtable.Add(challenge1);
            hashtable.Add(challenge1);

            Assert.IsTrue(hashtable.Count == 2);
        }

        [TestMethod]
        public void MyHashTableRemoveExistingItemItemRemovedTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            hashtable.Add(challenge1);

            hashtable.Remove(challenge1);

            Assert.IsFalse(hashtable.Contains(challenge1));
        }

        [TestMethod]
        public void MyHashTableRemoveNonExistingItemNoChangeTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            hashtable.Add(challenge1);

            bool result = hashtable.Remove(new Challenge());

            Assert.IsTrue(!result && hashtable.Contains(challenge1));
        }

        [TestMethod]
        public void MyHashTableClearEmptyTableTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);

            hashtable.Clear();

            Assert.IsTrue(0 == hashtable.Count && !hashtable.Contains(challenge1) && !hashtable.Contains(challenge2));
        }

        [TestMethod]
        public void MyHashTableEnumeratorEnumeratesItemsTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            int expectedSum = 45;
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);


            int sum = 0;
            foreach (Challenge item in hashtable)
            {
                sum += item.TimeToPass;
            }

            Assert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void MyHashTableFindPointExistingDataTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            bool result = hashtable.FindPoint(challenge2, out Challenge foundElement, out int foundIndex);

            Assert.IsTrue(result);
            Assert.AreEqual(challenge2, foundElement);
        }

        [TestMethod]
        public void MyHashTableFindPointNonExistingDataTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            bool result = hashtable.FindPoint(new Challenge(), out Challenge foundElement, out int foundIndex);

            Assert.IsFalse(result);
            Assert.AreEqual(null, foundElement);
            Assert.AreEqual(-1, foundIndex);
        }

        [TestMethod]
        public void MyHashTableCountEmptyTableReturnsZeroTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();

            int count = hashtable.Count;

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void MyHashTableIsEmptyEmptyTableReturnsTrueTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();

            bool isEmpty = hashtable.IsEmpty();

            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void MyHashTableIsReadOnlyAlwaysReturnsFalseTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();

            bool isReadOnly = hashtable.IsReadOnly;

            Assert.IsFalse(isReadOnly);
        }

        [TestMethod]
        public void MyHashTableCopyToValidArrayCopiesElementsTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = new Challenge[3];

            
            hashtable.CopyTo(array, 0);
            bool result = true;
            foreach (Challenge challenge in array)
            {
                result &= hashtable.Contains(challenge);
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MyHashTableCopyToWrongSizeTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = new Challenge[2];

            Assert.ThrowsException<ArgumentException>(() => hashtable.CopyTo(array, 0));
        }

        [TestMethod]
        public void MyHashTableCopyToNullArrayTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = null;

            Assert.ThrowsException<ArgumentNullException>(() => hashtable.CopyTo(array, 0));
        }

        [TestMethod]
        public void MyHashTableCopyToWrongIndexTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = new Challenge[5];

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hashtable.CopyTo(array, 10));
        }

        [TestMethod]
        public void MyHashTableCopyToIndexBelowZeroTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = new Challenge[5];

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hashtable.CopyTo(array, -10));
        }

        [TestMethod]
        public void MyHashTableCloneTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            hashtable.Add(challenge1);
            MyHashTable<Challenge> clone = hashtable.Clone();
            Challenge[] array = new Challenge[1];

            hashtable.TestCopyClone();
            hashtable.CopyTo(array, 0);
            bool result = true;
            foreach (Challenge item in clone)
            {
                result = item.Equals(array[0]);
            }

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MyHashTableShallowCopyTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            hashtable.Add(challenge1);
            MyHashTable<Challenge> copy = hashtable.ShallowCopy();
            Challenge[] array = new Challenge[1];

            hashtable.TestCopyClone();
            hashtable.CopyTo(array, 0);

            bool result = true;
            foreach (Challenge item in copy)
            {
                result = item.Equals(array[0]);
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MyHashTableToStringNullTest()
        {
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            string expected = "Похоже, таблица пустая";

            Assert.AreEqual(expected, hashtable.ToString());
        }

        [TestMethod]
        public void MyHashTableToStringNotEmptyTest() 
        { 
            MyHashTable<Challenge> hashtable = new(1);
            string expected = "\n0 : Испытание: Математика Время на прохождение: 25 Учитель: Ирина:\n    Испытание: Математика Время на прохождение: 25 Учитель: Ирина\n";
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            hashtable.Add(challenge1);

            Assert.AreEqual(expected, hashtable.ToString());
        }
    }
}
