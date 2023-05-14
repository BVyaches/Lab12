using ChallengeLibrary;
using System.Diagnostics.CodeAnalysis;
using CI = ChallengeLibrary.ConsoleInteraction;
using BinTree;

namespace lab
{
    [ExcludeFromCodeCoverage]
    internal class FirstMenu
    {
        static void Main1(string[] args)
        {
            int[] parameters;
            int currentMenu = 0, currentFunc=0;
            DoubleLinkedList<Challenge> list = new();
            list.RandomInit(0);

            while (currentFunc!=10)
            {
                parameters = CI.ChooseMenu(currentMenu);
                currentMenu = parameters[0];
                currentFunc = parameters[1];

                switch (currentFunc)
                {
                    // Создание списка
                    case 0:
                        {
                            int length = CI.GetInt(true, true, "Введите длину списка");
                            list.RandomInit(length);

                            Console.WriteLine("Список успешно создан:");
                            list.Show();
                            break;
                        }
                    // Добавление элемента
                    case 1:
                        {
                            Console.WriteLine("Вы работаете со списком:");
                            list.Show();
                            Console.WriteLine();

                            Console.WriteLine("Создайте элемент для добавления:");
                            Challenge challenge = CI.ManualChallenge(list.ToString());
                            list.Add(challenge);
                            Console.WriteLine("\nЭлемент успешно добавлен:");
                            list.Show();
                            break;
                        }

                    // Удаление
                    case 2:
                        {
                            if (list.Length == 0)
                            {
                                Console.WriteLine("Похоже, список пустой, попробуйте создать его!");
                            }
                            else
                            {
                                Console.WriteLine("Вы работаете со списком:");
                                list.Show();
                                Console.WriteLine();

                                Console.WriteLine("Создайте элемент для удаления");
                                Challenge challenge = CI.ManualChallenge(list.ToString());
                                bool result = list.Remove(challenge);
                                if (result)
                                {
                                    Console.WriteLine("Все заданные элементы удалены:");
                                    list.Show();
                                }
                                else
                                {
                                    Console.WriteLine("Данный элемент отсутствует в списке");
                                }
                            }
                            break;
                            
                        }
                    // Печать списка
                    case 3:
                        {
                            Console.WriteLine("Вы работаете со списком:");
                            list.Show();
                            break;
                        }

                    // Клонирование
                    case 4:
                        {
                            if (list.Length == 0)
                            {
                                Console.WriteLine("Похоже, список пустой, попробуйте создать его!");
                            }
                            else
                            {
                                // Клонирование списка
                                DoubleLinkedList<Challenge> clonedList = list.Clone();

                                Console.WriteLine("Исходный список:");
                                list.Show();
                                Console.WriteLine();
                                Console.WriteLine("Клон:");
                                clonedList.Show();
                                Console.WriteLine("\n");
                                // Изменение одного из полей
                                list.Head.Name = "Проверка на клонирование";
                                Console.WriteLine("После изменения: ");
                                Console.WriteLine("Исходный список:");
                                list.Show();
                                Console.WriteLine();
                                Console.WriteLine("Клон:");
                                clonedList.Show();
                            }

                            break;
                        }
                    // Удаление списка целиком
                    case 5:
                        {
                            list.Clear();
                            Console.WriteLine("Список успешно очищен");
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
