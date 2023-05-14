using ChallengeLibrary;
using System.Diagnostics.CodeAnalysis;
using CI = ChallengeLibrary.ConsoleInteraction;
using System.Data;
using MyHashTable;
using System;

namespace lab
{
    [ExcludeFromCodeCoverage]
    public class ThirdPart
    {
        static void Main()
        {
            int[] parameters;
            int currentMenu = 0, currentFunc = 0;
            MyHashTable<Challenge> table = new();
            table.RandomInit(0);

            while (currentFunc!=10)
            {
                parameters = CI.ChooseMenu(currentMenu, 3);
                currentMenu = parameters[0];
                currentFunc = parameters[1];

                switch (currentFunc)
                {
                    // Создание таблицы
                    case 0:
                        {
                            int length = CI.GetInt(true, true, "Введите длину таблицы для генерации");
                            bool result = table.RandomInit(length);
                            if (result)
                            {
                                Console.WriteLine("Таблица успешно создана:");
                                table.Show();
                            }
                            else
                            {
                                Console.WriteLine("Похоже, дерево с заданным размером создать невозможно");

                            }
                            break;
                        }


                    // Добавление элемента
                    case 1:
                        {
                            if (table.Size == 0)
                            {
                                Console.WriteLine("Похоже, вы не создали таблицу");
                                break;
                            }

                            Console.WriteLine("Вы работаете со таблицей:");
                            table.Show();
                            Console.WriteLine();
                            
                            Console.WriteLine("Создайте элемент для добавления:");
                            Challenge challenge = CI.ManualChallenge(table.ToString() + "\nСоздайте элемент для добавления");
                            
                            table.Add(challenge);
                            Console.WriteLine("\nЭлемент успешно добавлен:");
                            table.Show();
                            break;
                        }

                    // Поиск элемента
                    case 2:
                        {
                            if (table.Size == 0)
                            {
                                Console.WriteLine("Похоже, вы не создали таблицу");
                                break;
                            }
                            Console.WriteLine("Текущая таблица:");
                            table.Show();

                            if (table.IsEmpty())
                            {
                                break;
                            }
                            Console.WriteLine("Какой элемент хотите удалить (ключ)?");
                            Challenge toFind = new();
                            toFind.Init();
                            
                            bool result = table.FindPoint(toFind, out Challenge found, out int foundIndex);
                            if (result)
                            {
                                Console.WriteLine("\nЭлемент успешно найден:");
                                
                                found.Show();
                            }
                            else
                            {
                                Console.WriteLine("Похоже, данный элемент отсутствует в хэштаблице");
                            }

                            break;

                        }
                    // Печать таблицы
                    case 3:
                        {
                            Console.WriteLine("Вы работаете с таблицей:");
                            table.Show();
                            break;
                        }

                    // Удаление элемента
                    case 4:
                        {
                            if (table.Size == 0)
                            {
                                Console.WriteLine("Похоже, вы не создали таблицу");
                                break;
                            }

                            Console.WriteLine("Текущая таблица:");

                            table.Show();

                            if (table.IsEmpty())
                            {
                                break;
                            }
                            Console.WriteLine("Какой элемент хотите удалить (ключ)?");
                            Challenge toFind = new();
                            toFind.Init();
                            
                            
                            bool result = table.Remove(toFind);
                            if (result)
                            {
                                Console.WriteLine("\nЭлемент успешно удалён:");
                                table.Show();
                            }
                            else
                            {
                                Console.WriteLine("Похоже, данный элемент отсутствует в хэштаблице");
                            }

                            break;
                        }

                    case 5:
                        {
                            foreach (var item in table)
                            {
                                Console.WriteLine(item.ToString());
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
