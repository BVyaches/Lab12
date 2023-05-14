using ChallengeLibrary;
using System.Diagnostics.CodeAnalysis;
using CI = ChallengeLibrary.ConsoleInteraction;
using BinTree;
using System.Data;

namespace lab
{
    [ExcludeFromCodeCoverage]
    internal class SecondMenu
    {
        static void Main2(string[] args)
        {
            int[] parameters;
            int currentMenu = 0, currentFunc = 0;
            BinTree<Challenge> tree = new();
            tree.RandomInit(0);

            while (currentFunc!=10)
            {
                parameters = CI.ChooseMenu(currentMenu, 2);
                currentMenu = parameters[0];
                currentFunc = parameters[1];

                switch (currentFunc)
                {
                    // Создание дерева
                    case 0:
                        {
                            int length = CI.GetInt(true, true, "Введите длину дерева для генерации");
                            try
                            {
                                tree.RandomInit(length);
                                Console.WriteLine("Дерево успешно создано:");
                                tree.Show();
                            }
                            catch (DuplicateNameException)
                            {
                                Console.WriteLine("Похоже, в дереве создались дубликаты. " +
                                    "Пожалуйста, создайте ещё раз.");

                            }
                            break;
                        }


                    // Добавление элемента
                    case 1:
                        {
                            Console.WriteLine("Вы работаете со списком:");
                            tree.Show();
                            Console.WriteLine();

                            Console.WriteLine("Создайте элемент для добавления:");
                            Challenge challenge = CI.ManualChallenge(tree.ToString());
                            try
                            {
                                tree.Add(challenge);
                                Console.WriteLine("\nЭлемент успешно добавлен:");
                                tree.Show();
                            }
                            catch (DuplicateNameException)
                            {
                                Console.WriteLine("Похоже, в дерево добавлен дубликат. " +
                                    "Пожалуйста, создайте ещё раз.");

                            }
                            break;
                        }

                    // Высота дерева
                    case 2:
                        {
                            Console.WriteLine("Текущее дерево:");
                            tree.Show();
                            int height = tree.Height();
                            if (height != 0)
                            {
                                Console.WriteLine($"Высота дерева: {height}");
                            }
                            
                            break;

                        }
                    // Печать дерева
                    case 3:
                        {
                            Console.WriteLine("Вы работаете с деревом:");
                            tree.Show();
                            // Проверка Queue и Stack
                            //Console.WriteLine();
                            //tree.Test1();
                            //Console.WriteLine();
                            //tree.Test2();
                            break;
                        }

                    
                    // Удаление дерева целиком
                    case 4:
                        {
                            if (tree.Height() == 0)
                            {
                                Console.WriteLine("Похоже, дерево и так пустое, нечего очищать");
                            }
                            else
                            {
                                tree.Clear();
                                Console.WriteLine("Дерево успешно очищено");
                            }
                            
                            break;
                        }

                    // Завершение работы
                    case 10:
                        {
                            Console.WriteLine("Хорошего дня!");
                            break;
                        }
                }
                Console.WriteLine("\n\nНажмите любую клавишу для возвращения в меню");
                Console.ReadLine();

            }

        }
    }
}
