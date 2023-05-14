using System.Diagnostics.CodeAnalysis;

namespace ChallengeLibrary
{
    public class FinalExam: Exam
    {
        private bool isEnoughToPass;
        public bool IsEnougthToPass
        {
            get
            {
                return isEnoughToPass;
            }
            set
            {
                isEnoughToPass = value;
            }
        }
        public FinalExam(string name = "NoName", int timeToPass = 0, string teacherName = "NoName",
            bool isPassed = false, bool isEnoughToPass = false) : base(name, timeToPass, teacherName, isPassed)
        {
            IsEnougthToPass = isEnoughToPass;
        }

        // Вирутальный метод полуения вида испытания
        public override string GetKind()
        {
            return "Выпускной экзамен";
        }

        // Отображение выпускного экзамена
        [ExcludeFromCodeCoverage]
        public override void Show()
        {
            base.Show();
            string isEnougthToPassText = "Нет";
            if (IsEnougthToPass)
            {
                isEnougthToPassText = "Да";
            }
            Console.WriteLine($"Достаточно для поступления: {isEnougthToPassText}");
        }

        public override string ToString()
        {
            string isEnougthToPassText = "Нет";
            if (IsEnougthToPass)
            {
                isEnougthToPassText = "Да";
            }
            return base.ToString() + $" Достаточно для поступления: {isEnougthToPassText}";
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            IsEnougthToPass = ConsoleInteraction.GetBool(true, "Результатов сдачи достаточно для поступления?");
        }

        [ExcludeFromCodeCoverage]
        public override void RandomInit()
        {
            base.RandomInit();
            IsEnougthToPass = ConsoleInteraction.GetBool(false);
        }

		public override object Clone()
		{
			return new FinalExam(this.Name, this.TimeToPass, teacher.Name, this.IsPassed, this.IsEnougthToPass);
		}

		public override bool Equals(object obj)
        {
            FinalExam finalExam = obj as FinalExam;
            if (finalExam != null)
            {
                return this.Name == finalExam.Name && this.TimeToPass == finalExam.TimeToPass 
                    && this.teacher.Name == ((FinalExam)obj).teacher.Name 
                    && this.IsPassed == finalExam.IsPassed && this.IsEnougthToPass == finalExam.IsEnougthToPass;
            }
            return false;
        }
    }
}
