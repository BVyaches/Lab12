using System.Diagnostics.CodeAnalysis;

namespace ChallengeLibrary
{
    public class Person: IInit
    {
        private Random random = new Random();
        private string[] possibleNames = new string[] { "Вася", "Петя", "Иван", "Толик" };
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string name = "NoName")
        {
            this.name = name;
        }


        [ExcludeFromCodeCoverage]
        public virtual void Init()
        {
            Console.WriteLine("Введите имя:");
            Name = Console.ReadLine();
        }

        [ExcludeFromCodeCoverage]
        public virtual void RandomInit()
        {
            Name = possibleNames[random.Next(possibleNames.Length)];
        }

        [ExcludeFromCodeCoverage]
        public void ToBase(ref object obj)
        {
            throw new NotImplementedException();
        }
    }
}
