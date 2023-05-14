using System.Diagnostics.CodeAnalysis;

namespace ChallengeLibrary
{
    [ExcludeFromCodeCoverage]
    public class ConsoleInteraction
    {
        static Random rand = new Random();
        static private ConsoleColor selectedColor = ConsoleColor.Blue;
        static private ConsoleColor notSelectedColor = ConsoleColor.DarkGray;

        /// <summary>
        /// Получение числа
        /// </summary>
        /// <param name="isForLength">Вызов для получения длины</param>
        /// <param name="isManual">Ручная генерация</param>
        /// <param name="textForManual">Текст для подсказки при ручной генерации</param>
        /// <returns>Целое число</returns>
        public static int GetInt(bool isForLength, bool isManual, string textForManual = "")
        {
            int num;
            
            if (isManual)
            {
                Console.CursorVisible = true;
                if (textForManual != "")
                    Console.WriteLine(textForManual);
                bool isConvertNum;
                do
                {
                    isConvertNum = int.TryParse(Console.ReadLine(), out num);
                    // Проверяем, введено ли число
                    if (!isConvertNum)
                        Console.WriteLine("Введите целое число, допустимое для int");
                    // Если введено целое число и при этом оно введено для обозначени длины
                    // проверяем, является ли оно неотрицательным
                    else
                    {
                        if (isForLength && num <= 0)
                        {
                            Console.WriteLine("Введите целое число, большее 0");
                            isConvertNum = false;
                        }
                    }
                } while (!isConvertNum);
                Console.CursorVisible = false;
            }
            // Рандомно генерируем число
            else
            {
                if (isForLength)
                    num = rand.Next(1, 1000);
                else
                    num = rand.Next(-100, 100);
            }
            
            return num;
        }

        /// <summary>
        /// Получение true или false
        /// </summary>
        /// <param name="isManual">Ручная генерация</param>
        /// <param name="textForManual">Текст для подсказки при ручной генерации</param>
        /// <returns>True или false</returns>
        public static bool GetBool(bool isManual, string textForManual="")
        {
            bool result = false;
            if (isManual)
            {
				Console.CursorVisible = true;
				if (textForManual != "")
                    Console.WriteLine(textForManual);
                bool isBool = false;
                
                do
                {
                    string isEasyInput = Console.ReadLine().ToLower();
                    if (isEasyInput == "да" || isEasyInput == "нет")
                    {
                        if (isEasyInput == "да")
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                        isBool = true;
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, ответьте Да или Нет");
                    }

                } while (!isBool);
				Console.CursorVisible = false;
			}
            else
            {
                result = Convert.ToBoolean(rand.Next(0, 2));
            }
            return result;
        }

        /// <summary>
        /// Вывод пунктов меню с окрашиванием выбранного
        /// </summary>
        /// <param name="cursorPosition">Позиция курсора в меню</param>
        /// <param name="menuPosition">Выбранное подменю</param>
        static void PrintMenu(int cursorPosition, int menuPosition, ref int menuLength, int type=0)

        {
            // Массив со всеми списками меню
            string[][] menuArray =
            {
                new string[]
                {
                    "Создание списка заданной длины", "Добавление элемента", "Удаление заданного элемента", 
                    "Вывести список", "Клонирование", "Удаление списка", "Завершение работы"
                },
                new string[]
                {
                     "Испытание", "Тест", "Экзамен", "Выпускной экзамен" 
                },
                new string[]
                {
                    "Создание дерева заданной длины", "Добавление элемента", "Вычисление высоты дерева",
                    "Вывести дерево", "Преобразование в дерево поиска", "Удаление дерева", "Завершение работы"
                },
                new string[]
                {
                    "Создание таблицы заданного размера", "Добавление элемента", "Поиск элемента в таблице", "Вывести хэш-таблицу",
                    "Удаление элемента из таблицы", "Перебор элементов через foreach", "Клонирование и копирование", "Завершение работы"
                },
            };

            string[] menu = menuArray[type];
            menuLength = menu.Length;
            for (int index = 0; index < menuLength; index++)
            {
                // Если пункт является выбранным, окрашиваем его в зеленый
                if (index == cursorPosition)
                {
                    Console.ForegroundColor = selectedColor;
                    Console.WriteLine(menu[index]);
                    Console.ForegroundColor = notSelectedColor;
                }
                else
                    Console.WriteLine(menu[index]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Пермещение в подменю и меню
        /// </summary>
        /// <param name="menuPosition">Выбранное подменю</param>
        /// <returns>Выбранное подменю и пункт</returns>
        static public int[] ChooseMenu(int menuPosition, int type=0, string text="")
        {
            
            Console.Clear();
            if (text != "")
            {
                Console.WriteLine(text);
            }
            int currentPosition = 0;
            ConsoleKey enteredKey = ConsoleKey.Spacebar;
            int menuLength = 0;
            // Пользователь перемещается стрелками по меню, пока не нажмет Enter на нужном пункте
            while (enteredKey != ConsoleKey.Enter)
            {
                PrintMenu(currentPosition, menuPosition, ref menuLength, type);
                // Очищаем консоль после завершения работы с функцией
                enteredKey = Console.ReadKey().Key;
                Console.Clear();
                if (text != "")
                {
                    Console.WriteLine(text);
                }
                // Опускаем и поднимаем курсор в соответствии с нажатыми стрелками
                if (enteredKey == ConsoleKey.UpArrow)
                {
                    // Для перемещения вниз списка меню в случае выхода из него через "верх"
                    currentPosition = (menuLength + --currentPosition)%menuLength;
                }
                else if (enteredKey == ConsoleKey.DownArrow)
                {
                    // Используем остаток от деления для перемещения наверх при выходе из списка "вниз"
                    currentPosition = ++currentPosition%menuLength;
                }
            }
            // Рекурсивно вызываем функцию, пока пользователь не выберет пункт из подменю или решит завершить работу

            
            
            if (menuPosition == 0 && currentPosition != menuLength-1)
                return new int[2] { menuPosition, currentPosition };
            
            return new int[] { 10, 10 };
        }

        /// <summary>
        /// Задача настроек цветов и параметров консоли
        /// </summary>
        /// <param name="selectedColor">Цвет выбранного пункта</param>
        /// <param name="notSelectedColor">Цвет остальных пунктов</param>
        static void SetConsoleOptions()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = notSelectedColor;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Создание испытания любого типа пользователем
        /// </summary>
        /// <returns>Созданное испытание</returns>
        public static Challenge ManualChallenge(string text="")
        {
            Challenge newChallenge = new();
            int challengeType;

            Console.WriteLine("Какой тип испытания вы хотите создать? (напишите название)");
            challengeType = ChooseMenu(0, 1, text)[1];
            if (challengeType == 1)
            {
                newChallenge = new Test();
            }
            else if (challengeType == 2)
            {
                newChallenge = new Exam();
            }
            else if (challengeType == 3)
            {
                newChallenge = new FinalExam();
            }
            newChallenge.Init();
            return newChallenge;

        }

        /// <summary>
        /// Создание случайного испытания случайного типа
        /// </summary>
        /// <returns>Созданное испытание</returns>
        public static Challenge RandomChallenge()
        {
            Challenge[] challenges = new Challenge[] { new Challenge(), new Test(), new Exam(), new FinalExam() };
            Challenge challenge = challenges[new Random().Next(challenges.Length)];
            challenge.RandomInit();
            return challenge;
        }

        /// <summary>
        /// Отображение таблицы времен с форматированием
        /// </summary>
        /// <param name="results">Измерения времени</param>
        /// <param name="position">Какая позиция элемента рассматривалась</param>
        public static void ShowResultsTable(long[] results, string position)
        {
            Console.WriteLine(position+String.Format("|{0,-12}|{1,-14}|{2,-34}|{3,-34}|{4,-31}|{5,-31}|"
                , results[0], results[1], results[2], results[3], results[4], results[5]));
        }
    }
}