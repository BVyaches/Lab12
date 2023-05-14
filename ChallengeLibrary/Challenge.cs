using System.Diagnostics.CodeAnalysis;

namespace ChallengeLibrary
{
    public class Challenge: IComparable, IInit, ICloneable, IComparable<Challenge>, IComparer<Challenge>
    {
        private Random random= new();
        private string[] possibleNames = new string[] { "Математика", "История", "Биология", "Русккий язык", "Информатика", "География", "Геометрия", "Физика", "Химия", "ИЗО", "Физра"};

        // Название испытания
        private string name = "";
        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            {
                if (value == "")
                {
                    name = "NoName";
                }
                else
                {
                    name = value;
                }
            }
        }

        public Person teacher = new();

        private int timeToPass;
        public int TimeToPass
        {
            get
            {
                return timeToPass;
            }
            set
            {
                if (value > 0)
                {
                    timeToPass = value;
                }
                else
                {
                    timeToPass = 0;
                }
            }
        }

        public Challenge()
        {
            Name = "NoName";
            TimeToPass = 0;
            teacher = new Person("NoName");
        }

        public Challenge(string name="NoName", int timeToPass = 0, string teacherName = "NoName")
        {
            Name = name;
            TimeToPass = timeToPass;
            teacher = new Person(teacherName);
        }

        public int CompareTo(Challenge? other)
        {
            Challenge? challenge = other as Challenge;
            if (challenge == null)
            {
                return 1;
            }

            int nameComparer = String.Compare(this.Name, challenge.Name);
            if (nameComparer != 0)
            {
                return nameComparer;
            }

            int timeToPassComparer = this.timeToPass - challenge.TimeToPass;
            if (timeToPassComparer != 0)
            {
                return timeToPassComparer;
            }

            return String.Compare(this.teacher.Name, challenge.teacher.Name);
        }

        public int Compare(Challenge? x, Challenge? y)
        {
            return x.CompareTo(y);

        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as Challenge);
        }

        // Вирутальный метод полуения вида испытания
        public virtual string GetKind()
        {
            return "Испытание";
        }

        // Отображение испытания
        [ExcludeFromCodeCoverage]
        public virtual void Show()
        {
            string nameText = $"{GetKind()}: {Name}";
            
            Console.WriteLine(nameText + $"\nВремя на прохождение: {Convert.ToString(TimeToPass)}" + $"\nУчитель: {teacher.Name}");
        }

        public override string ToString()
        {
            string nameText = $"{GetKind()}: {Name}";

            return nameText + $" Время на прохождение: {Convert.ToString(TimeToPass)}" + $" Учитель: {teacher.Name}";
        }

        [ExcludeFromCodeCoverage]
        public virtual void Init() 
        {
			Console.CursorVisible = true;
			Console.WriteLine("Введите название испытания:");
            Name = Console.ReadLine();
            TimeToPass = ConsoleInteraction.GetInt(true, true, "Сколько времени длится?");
            Console.WriteLine("Введите имя учителя");
            teacher.Init();
			Console.CursorVisible = false;
		}

        [ExcludeFromCodeCoverage]
        public virtual void RandomInit()
        {
            Name = possibleNames[random.Next(possibleNames.Length)];
            TimeToPass = ConsoleInteraction.GetInt(true, false);
            teacher.RandomInit();
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public virtual object Clone()
        {
            return new Challenge(this.Name, this.TimeToPass, teacher.Name);
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Challenge)obj).Name && this.TimeToPass == ((Challenge)obj).TimeToPass && this.teacher.Name == ((Challenge)obj).teacher.Name;
        }

        public override int GetHashCode()
        {
            // Метод для возврата ошибки 
            unchecked
            {
                int hash = TimeToPass;
                hash = hash * 16777619 + Name.GetHashCode();
                hash = hash * 16777619 + teacher.Name.GetHashCode();
                return hash;
            }
        }

        

        public void ToBase(ref object obj)
        {
            obj = new Challenge(Name, TimeToPass, teacher.Name);
        }
    }
}