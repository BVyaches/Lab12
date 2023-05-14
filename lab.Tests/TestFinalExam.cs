using ChallengeLibrary;
using lab;

namespace lab.Tests
{
    [TestClass]
    public class TestFinalExam
    {
        [TestMethod]
        public void FinalConstructorAllPropertiesTest()
        {
            string expectedName = "Математика";
            int expectedTimeToPass = 25;
            string expectedTeacherName = "Ирина";
            bool expectedIsPassed = true;
            bool expectedIsEnoughToPass = false;

            FinalExam finalExam = new FinalExam(expectedName, expectedTimeToPass, expectedTeacherName, expectedIsPassed, expectedIsEnoughToPass);

            Assert.AreEqual(expectedName, finalExam.Name);
            Assert.AreEqual(expectedTimeToPass, finalExam.TimeToPass);
            Assert.AreEqual(expectedTeacherName, finalExam.teacher.Name);
            Assert.AreEqual(expectedIsPassed, finalExam.IsPassed);
            Assert.AreEqual(expectedIsEnoughToPass, finalExam.IsEnougthToPass);
        }

        [TestMethod]
        public void FinalConstructorDefaultPropertiesTest()
        {
            FinalExam finalExam = new FinalExam();

            Assert.AreEqual("NoName", finalExam.Name);
            Assert.AreEqual(0, finalExam.TimeToPass);
            Assert.AreEqual("NoName", finalExam.teacher.Name);
            Assert.AreEqual(false, finalExam.IsPassed);
            Assert.AreEqual(false, finalExam.IsEnougthToPass);
        }

        [TestMethod]
        public void FinalConstructorIsEnoughSetTest()
        {
            FinalExam finalExam = new FinalExam(isEnoughToPass:true);

            Assert.AreEqual("NoName", finalExam.Name);
            Assert.AreEqual(0, finalExam.TimeToPass);
            Assert.AreEqual("NoName", finalExam.teacher.Name);
            Assert.AreEqual(false, finalExam.IsPassed);
            Assert.AreEqual(true, finalExam.IsEnougthToPass);
        }

        [TestMethod]
        public void FinalExamGetKindTest()
        {
            string expectedKind = "Выпускной экзамен";
            FinalExam finalExam = new FinalExam();

            Assert.AreEqual(expectedKind, finalExam.GetKind());
        }

		[TestMethod]
		public void FinalExamCloneTest()
		{
			FinalExam finalExam1 = new FinalExam("Математика", 60, "Иванов", true, true);
			FinalExam finalExam2 = (FinalExam) finalExam1.Clone();

			Assert.AreEqual(finalExam1, finalExam2);
		}

		[TestMethod]
        public void FinalExamEqualsWithEqualObjectsTest()
        {
            FinalExam finalExam1 = new FinalExam("Математика", 25, "Ирина", true, true);
            FinalExam finalExam2 = new FinalExam("Математика", 25, "Ирина", true, true);

            Assert.IsTrue(finalExam1.Equals(finalExam2));
        }

        [TestMethod]
        public void FinalExamEqualsWithNotEqualObjectsTest()
        {
            FinalExam finalExam1 = new FinalExam("Математика", 25, "Ирина", true, true);
            FinalExam finalExam2 = new FinalExam("Физика", 10, "Дмитрий", false, true);

            Assert.IsFalse(finalExam1.Equals(finalExam2));
        }

        [TestMethod]
        public void TestEqualsWithDifferentObjectsTest()
        {
            FinalExam finalExam = new FinalExam("Математика", 25, "Ирина", true, true);
            Challenge challenge = new Challenge("Математика", 5, "Юра");

            Assert.IsFalse(finalExam.Equals(challenge));
        }

        [TestMethod]
        public void FinalExamToStringTest()
        {
            FinalExam exam = new FinalExam("Математика", 25, "Ирина", true, true);

            string expectedString = "Выпускной экзамен: Математика Время на прохождение: 25" +
                " Учитель: Ирина Сдан успешно: Да Достаточно для поступления: Да";

            Assert.AreEqual(expectedString, exam.ToString());
        }
    }
}
