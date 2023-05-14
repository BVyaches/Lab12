using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeLibrary;
using lab;

namespace TestCollections
{
    [TestClass]
    public class TestLinkedNode
    {
        [TestMethod]
        public void LinkedNodeConstructorDataTest()
        {
            Challenge challenge = new("Физика", 20, "Ирина");

            LinkedNode<Challenge> linkedNode = new(challenge);

            Assert.AreEqual(challenge, linkedNode.Data);
        }

        [TestMethod]
        public void LinkedNodeNextTest()
        {
            Challenge challenge1 = new("Физика", 20, "Ирина");
            Challenge challenge2 = new("История", 50, "Иван");

            LinkedNode<Challenge> linkedNode = new(challenge1);
            LinkedNode<Challenge> linkedNodeNext = new(challenge2);
            linkedNode.Next = linkedNodeNext;

            Assert.AreEqual(linkedNodeNext, linkedNode.Next);
        }

        [TestMethod]
        public void LinkedNodePreviousTest()
        {
            Challenge challenge1 = new("Физика", 20, "Ирина");
            Challenge challenge2 = new("История", 50, "Иван");

            LinkedNode<Challenge> linkedNode = new(challenge1);
            LinkedNode<Challenge> linkedNodePrevious = new(challenge2);
            linkedNode.Previous = linkedNodePrevious;

            Assert.AreEqual(linkedNodePrevious, linkedNode.Previous);
        }
    }
}
