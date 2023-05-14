using ChallengeLibrary;
using lab;
namespace lab.Tests
{
    [TestClass]
    public class TestTest
    {
        [TestMethod]
        public void TestConstructorAllProperties()
        {
            string expectedName = "История";
            int expectedTimeToPass = 10;
            string expectedTeacherName = "Ирина";
            int expectedScores = 90;

            Test test = new Test(expectedName, expectedTimeToPass, expectedTeacherName, expectedScores);

            Assert.AreEqual(expectedName, test.Name);
            Assert.AreEqual(expectedTimeToPass, test.TimeToPass);
            Assert.AreEqual(expectedTeacherName, test.teacher.Name);
            Assert.AreEqual(expectedScores, test.Score);
        }


        [TestMethod]
        public void TestConstructorDefaultsProperties()
        {
            Test test = new Test();

            Assert.AreEqual(test.Name, "NoName");
            Assert.AreEqual(test.TimeToPass, 0);
            Assert.AreEqual(test.teacher.Name, "NoName");
        }

        [TestMethod]
        public void TestScoresSetterWithNegativeValue()
        {
            Test test = new Test();

            test.Score = -10;

            Assert.AreEqual(0, test.Score);
        }

        [TestMethod]
        public void TestScoresSetterWithPositiveValue()
        {
            Test test = new Test();
            test.Score = 90;

            Assert.AreEqual(90, test.Score);
        }

        [TestMethod]
        public void TestGetKind()
        {
            string expectedKind = "Тест";
            Test test = new Test();
            Assert.AreEqual(expectedKind, test.GetKind());
        }

        [TestMethod]
        public void TestEqualsWithEqualObjects()
        {
            Test test1 = new Test("История", 25, "Ирина", 90);
            Test test2 = new Test("История", 25, "Ирина", 90);

            bool result = test1.Equals(test2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEqualsWithNotEqualObjects()
        {
            Test test1 = new Test("История", 25, "Ирина", 90);
            Test test2 = new Test("Математика", 10, "Дима", 80);

            bool result = test1.Equals(test2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEqualsWithDifferentObjects()
        {
            Test test = new Test("История", 25, "Ирина", 90);
            Challenge challenge = new Challenge("Математика", 4);

            bool result = test.Equals(challenge);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestToStringTest()
        {
            Test test = new Test("Математика", 25, "Ирина", 20);

            string expectedString = "Тест: Математика Время на прохождение: 25 Учитель: Ирина Количество баллов: 20";

            Assert.AreEqual(expectedString, test.ToString());
        }

        [TestMethod]
        public void TestCloneTest()
        {
            Test test1 = new Test("Математика", 60, "Иванов", 200);
            Test test2 = (Test)test1.Clone();

            Assert.AreEqual(test1, test2);
        }


        [TestMethod]
        public void TestBaseChallengeTest()
        {
            Test test = new Test("Математика", 25, "Ирина", 20);

            Challenge expectedChallenge = new Challenge("Математика", 25, "Ирина");

            Assert.AreEqual(test.BaseChallenge(), expectedChallenge);
        }


    }
}
