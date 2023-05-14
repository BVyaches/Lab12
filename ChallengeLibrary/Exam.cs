using System.Diagnostics.CodeAnalysis;

namespace ChallengeLibrary
{
    public class Exam: Challenge
    {
        private bool isPassed;
        public bool IsPassed
        {
            get
            {
                return isPassed;
            }
            set
            {
                isPassed = value;
            }
        }


        public Exam(string name="NoName", int timeToPass=0, string teacherName="NoName", bool isPassed = false) : base(name, timeToPass, teacherName)
        {
            IsPassed = isPassed;
        }

        // Вирутальный метод полуения вида испытания
        public override string GetKind()
        {
            return "Экзамен";
        }

        // Отображение экзамена
        [ExcludeFromCodeCoverage]
        public override void Show()
        {
            base.Show();
            string isPassedText = "Нет";
            if (IsPassed)
            {
                isPassedText = "Да";
            }
            Console.WriteLine($"Сдан успешно: {isPassedText}");
        }

        public override string ToString()
        {
            string isPassedText = "Нет";
            if (IsPassed)
            {
                isPassedText = "Да";
            }
            return base.ToString() + $" Сдан успешно: {isPassedText}";
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            IsPassed = ConsoleInteraction.GetBool(true, "Экзамен сдан успешно? Да/Нет");
        }

        [ExcludeFromCodeCoverage]
        public override void RandomInit()
        {
            base.RandomInit();
            IsPassed = ConsoleInteraction.GetBool(false);
        }

		public override object Clone()
		{
			return new Exam(this.Name, this.TimeToPass, teacher.Name, this.IsPassed);
		}


		public override bool Equals(object obj)
        {
            Exam? exam = obj as Exam;
            if (exam != null)
            {
                return this.Name == exam.Name && this.TimeToPass == exam.TimeToPass && this.teacher.Name == ((Exam)obj).teacher.Name && this.IsPassed == exam.IsPassed;
            }
            return false;
        }
    }
}
