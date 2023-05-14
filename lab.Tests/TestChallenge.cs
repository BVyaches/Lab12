using ChallengeLibrary;
using lab;
namespace lab.Tests
{
    [TestClass]
    public class TestChallenge
    {
        [TestMethod]
        public void ChallengeConstructorNameTest()
        {
            string name = "Математика";
            int timeToPass = 10;
            string teacherName = "Ирина";

            Challenge challenge = new Challenge(name, timeToPass, teacherName);

            Assert.AreEqual(challenge.Name, name);
        }

		[TestMethod]
		public void ChallengeConstructorTimeToPassTest()
		{
			string name = "Математика";
			int timeToPass = 10;
			string teacherName = "Ирина";

			Challenge challenge = new Challenge(name, timeToPass, teacherName);

			Assert.AreEqual(challenge.TimeToPass, timeToPass);
		}

		[TestMethod]
		public void ChallengeConstructorTeacherNameTest()
		{
			string name = "Математика";
			int timeToPass = 10;
			string teacherName = "Ирина";

			Challenge challenge = new Challenge(name, timeToPass, teacherName);

			Assert.AreEqual(challenge.teacher.Name, teacherName);
		}

		[TestMethod]
		public void ChallengeNoNameConstructorNameTest()
		{
			string name = "NoName";

			Challenge challenge = new Challenge();

			Assert.AreEqual(challenge.Name, name);
		}

		[TestMethod]
		public void ChallengeNoNameConstructorTimeToPassTest()
		{
			int timeToPass = 0;

			Challenge challenge = new Challenge();

			Assert.AreEqual(challenge.TimeToPass, timeToPass);
		}

		[TestMethod]
		public void ChallengeNoNameConstructorTeacherNameTest()
		{
			string teacherName = "NoName";

			Challenge challenge = new Challenge();

			Assert.AreEqual(challenge.teacher.Name, teacherName);
		}

		[TestMethod]
        public void ChallengeNamePropertyTest()
        {
            Challenge challenge = new Challenge();
            string name = "Математика";

            challenge.Name = name;

            Assert.AreEqual(challenge.Name, name);
        }

        [TestMethod]
        public void ChallengeEmptyNamePropertyTest()
        {
            Challenge challenge = new Challenge();
            string name = "";

            challenge.Name = name;

            Assert.AreEqual(challenge.Name, "NoName");
        }

        [TestMethod]
        public void ChallengeIsEasyPropertyTest()
        {
            Challenge challenge = new Challenge();
            string teacherName = "Ирина";

            challenge.teacher.Name = teacherName;

            Assert.AreEqual(challenge.teacher.Name, teacherName);
        }

        [TestMethod]
        public void ChallengeGetKindTest()
        {
            string expectedKind = "Испытание";
            Challenge challenge = new Challenge();

            Assert.AreEqual(expectedKind, challenge.GetKind());
        }

		[TestMethod]
		public void ChallengeCompareToDifferentObjTest()
		{
			Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
			Person person = new Person("Дима");
			int expectedCompareResult = 1;

			Assert.AreEqual(expectedCompareResult, challenge1.CompareTo(person));
		}

		[TestMethod]
        public void ChallengeCompareToDifferentNamesTest()
        {
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            int expectedCompareResult = -1;

            Assert.AreEqual(expectedCompareResult, challenge2.CompareTo(challenge1));
        }

		[TestMethod]
		public void ChallengeCompareToEqualNamesDifferentTimesTest()
		{
			Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
			Challenge challenge2 = new Challenge("Математика", 10, "Дима");

			Assert.IsTrue(challenge1.CompareTo(challenge2) > 0);
		}

		[TestMethod]
		public void ChallengeCompareToEqualNamesEqualTimesTest()
		{
			Challenge challenge1 = new Challenge("Математика", 10, "Арина");
			Challenge challenge2 = new Challenge("Математика", 10, "Дима");

			int expectedCompareResult = -1;

			Assert.AreEqual(expectedCompareResult, challenge1.CompareTo(challenge2));
		}

        [TestMethod]
        public void ChallengeCompareTest()
        {
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");
            int expectedCompareResult = -1;

            Assert.AreEqual(expectedCompareResult, challenge2.Compare(challenge2, challenge1));
        }


		[TestMethod]
        public void TestShallowCopy()
        {
            Challenge challenge1 = new Challenge("Математика", 60);
            Challenge challenge2 = (Challenge)challenge1.ShallowCopy();

            Assert.AreEqual(challenge1, challenge2);
        }

        [TestMethod]
        public void ChallengeCloneTest()
        {
            Challenge challenge1 = new Challenge("Математика", 60, "Иванов");
            Challenge challenge2 = (Challenge)challenge1.Clone();

            Assert.AreEqual(challenge1, challenge2);
        }



        [TestMethod]
        public void ChallengeEqualsMethodTest()
        {
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("Математика", 25, "Ирина");

            Assert.IsTrue(challenge1.Equals(challenge2));
        }

        [TestMethod]
        public void ChallengeNotEqualsMethodTest()
        {
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("История", 10, "Дима");

            Assert.IsFalse(challenge1.Equals(challenge2));
        }

        [TestMethod]
        public void ChallengeToStringTest()
        {
            Challenge challenge = new Challenge("Математика", 25, "Ирина");

            string expectedString = "Испытание: Математика Время на прохождение: 25 Учитель: Ирина";

            Assert.AreEqual(expectedString, challenge.ToString());
        }

        [TestMethod]
        public void ChallengeGetHashCodeGivesSameForSameObjectsCodeTest()
        {
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("Математика", 25, "Ирина");

            Assert.AreEqual(challenge1.GetHashCode(), challenge2.GetHashCode());
        }


        [TestMethod]
        public void ChallengeGetHashCodeGivesNotSameForNotSameObjectsCodeTest()
        {
            Challenge challenge1 = new Challenge("Математика", 25, "Ирина");
            Challenge challenge2 = new Challenge("Физика", 10, "Василий");

            Assert.AreNotEqual(challenge1.GetHashCode(), challenge2.GetHashCode());
        }

        [TestMethod]
        public void ChallengeToBaseTest()
        {
            Challenge challenge = new Challenge("Математика", 25, "Ирина");
            object obj = new();

            challenge.ToBase(ref obj);

            Assert.AreEqual(challenge, obj);
        }
    }
}