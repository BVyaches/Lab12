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
        public void MyHashTable_Add_ValidData_ItemAdded()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");

            hashtable.Add(challenge1);

            // Assert
            Assert.IsTrue(hashtable.Count == 1);
        }

        [TestMethod]
        public void MyHashTable_Add_NullData_ItemNotAdded()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new();

            // Act
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
        public void MyHashTable_Remove_ExistingItem_ItemRemoved()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            hashtable.Add(challenge1);

            // Act
            bool result = hashtable.Remove(challenge1);

            // Assert
            Assert.IsFalse(hashtable.Contains(challenge1));
        }

        [TestMethod]
        public void MyHashTable_Remove_NonExistingItem_NoChange()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            hashtable.Add(challenge1);

            // Act
            bool result = hashtable.Remove(new Challenge());

            // Assert
            Assert.IsTrue(!result && hashtable.Contains(challenge1));
        }

        [TestMethod]
        public void MyHashTable_Clear_EmptyTable()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);

            // Act
            hashtable.Clear();

            // Assert
            Assert.IsTrue(0 == hashtable.Count && !hashtable.Contains(challenge1) && !hashtable.Contains(challenge2));
        }

        [TestMethod]
        public void MyHashTable_Enumerator_EnumeratesItems()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            int expectedSum = 45;
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);



            // Act
            int sum = 0;
            foreach (Challenge item in hashtable)
            {
                sum += item.TimeToPass;
            }

            // Assert
            Assert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void MyHashTable_FindPoint_ExistingData_ReturnsTrueAndIndex()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            // Act
            bool result = hashtable.FindPoint(challenge2, out Challenge foundElement, out int foundIndex);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(challenge2, foundElement);
        }

        [TestMethod]
        public void MyHashTable_FindPoint_NonExistingData_ReturnsFalseAndNegativeIndex()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            // Act
            bool result = hashtable.FindPoint(new Challenge(), out Challenge foundElement, out int foundIndex);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(null, foundElement);
            Assert.AreEqual(-1, foundIndex);
        }

        [TestMethod]
        public void MyHashTable_Count_EmptyTable_ReturnsZero()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();

            // Act
            int count = hashtable.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void MyHashTable_IsEmpty_EmptyTable_ReturnsTrue()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();

            // Act
            bool isEmpty = hashtable.IsEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void MyHashTable_IsReadOnly_Always_ReturnsFalse()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();

            // Act
            bool isReadOnly = hashtable.IsReadOnly;

            // Assert
            Assert.IsFalse(isReadOnly);
        }

        [TestMethod]
        public void MyHashTable_CopyTo_ValidArray_CopiesElements()
        {
            // Arrange
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

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MyHashTable_CopyToWrongSize()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = new Challenge[2];

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => hashtable.CopyTo(array, 0));
        }

        [TestMethod]
        public void MyHashTable_CopyToNullArray()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = null;

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => hashtable.CopyTo(array, 0));
        }

        [TestMethod]
        public void MyHashTable_CopyToWrongIndexTest()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = new Challenge[5];

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hashtable.CopyTo(array, 10));
        }

        [TestMethod]
        public void MyHashTable_CopyToIndexBelowZeroTest()
        {
            // Arrange
            MyHashTable<Challenge> hashtable = new MyHashTable<Challenge>();
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            Challenge challenge3 = new Challenge("Физика", 10, "Василий");

            hashtable.Add(challenge1);
            hashtable.Add(challenge2);
            hashtable.Add(challenge3);

            Challenge[] array = new Challenge[5];

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hashtable.CopyTo(array, -10));
        }

        [TestMethod]
        public void MyHashTable_CloneTest()
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
        public void MyHashTable_ShallowCopy_ReturnsNewInstanceWithSameElements()
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
