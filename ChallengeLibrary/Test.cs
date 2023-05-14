using System.Diagnostics.CodeAnalysis;

namespace ChallengeLibrary
{
    public class Test: Challenge
    {
        private int score;
        public int Score
        {
            get 
            { 
                return score; 
            } 
            set 
            { 
                if (value < 0)
                {
                    score = 0;
                }
                else
                {
                    score = value;
                }
            }
        }

        public Test(string name="NoName", int timeToPass = 0, string teacherName = "NoName", int scores=0): base(name, timeToPass, teacherName)
        {
            Score = scores;
        }

        // Вирутальный метод полуения вида испытания
        public override string GetKind()
        {
            return "Тест";
        }

        // Отображение теста
        [ExcludeFromCodeCoverage]
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество баллов: {Score}");
        }

        public override string ToString()
        {
            return base.ToString()+$" Количество баллов: {Score}";
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            Score = ConsoleInteraction.GetInt(true, true, "Введите количество полученных баллов:");
        }

        [ExcludeFromCodeCoverage]
        public override void RandomInit()
        {
            base.RandomInit();
            Score = ConsoleInteraction.GetInt(true, false);
        }

        public override object Clone()
        {
            return new Test(this.Name, this.TimeToPass, teacher.Name, this.Score);
        }


        public Challenge BaseChallenge()
        {
            return new Challenge(Name, TimeToPass, teacher.Name);
        }

        public override bool Equals(object obj)
        {
            Test test = obj as Test;
            if (test != null)
            {
                return this.Name == test.Name && this.TimeToPass == test.TimeToPass && this.teacher.Name == ((Test)obj).teacher.Name && this.Score == test.Score;
            }
            return false;
        }
    }
}
