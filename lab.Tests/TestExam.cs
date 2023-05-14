using ChallengeLibrary;
using lab;

namespace lab.Tests
{
    [TestClass]
    public class ExamTests
    {
        [TestMethod]
        public void ExamConstructorAllPropertiesTest()
        {
            string expectedName = "Математика";
            int expectedTimeToPass = 25;
            string expectedTeacherName = "Ирина";
            bool expectedIsPassed = true;

            Exam exam = new Exam(expectedName, expectedTimeToPass, expectedTeacherName, expectedIsPassed);

            Assert.AreEqual(expectedName, exam.Name);
            Assert.AreEqual(expectedTimeToPass, exam.TimeToPass);
            Assert.AreEqual(expectedTeacherName, exam.teacher.Name);
            Assert.AreEqual(expectedIsPassed, exam.IsPassed);
        }

        [TestMethod]
        public void ExamConstructorDefaultsPropertiesTest()
        {
            Exam exam = new Exam();

            Assert.AreEqual("NoName", exam.Name);
            Assert.AreEqual(0, exam.TimeToPass);
            Assert.AreEqual("NoName", exam.teacher.Name);
            Assert.AreEqual(false, exam.IsPassed);
        }

        [TestMethod]
        public void ExamGetKindTest()
        {
            string expectedKind = "Экзамен";
            Exam exam = new Exam();

            Assert.AreEqual(expectedKind, exam.GetKind());
        }

		[TestMethod]
		public void ExamCloneTest()
		{
			Exam exam1 = new Exam("Математика", 60, "Иванов", true);
			Exam exam2 = (Exam) exam1.Clone();

			Assert.AreEqual(exam1, exam2);
		}

		[TestMethod]
        public void ExamEqualsWithEqualObjectsTest()
        {
            Exam exam1 = new Exam("Математика", 25, "Ирина", true);
            Exam exam2 = new Exam("Математика", 25, "Ирина", true);

            bool result = exam1.Equals(exam2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEqualsWithNotEqualObjectsTest()
        {
            Exam exam1 = new Exam("Математика", 25, "Ирина", true);
            Exam exam2 = new Exam("История", 10, "Дмитрий", false);

            bool result = exam1.Equals(exam2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEqualsWithDifferentObjectsTest()
        {
            Exam exam = new Exam("Математика", 25, "Ирина", true);
            Challenge challenge = new Challenge("Математика", 50, "Дима");

            bool result = exam.Equals(challenge);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExamToStringTest()
        {
            Exam exam = new Exam("Математика", 25, "Ирина", true);

            string expectedString = "Экзамен: Математика Время на прохождение: 25 Учитель: Ирина Сдан успешно: Да";

            Assert.AreEqual(expectedString, exam.ToString());
        }
    }
}
