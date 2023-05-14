using ChallengeLibrary;
using System.Diagnostics.CodeAnalysis;

namespace lab
{
    public class DoubleLinkedList<T> where T : class, IInit, ICloneable, new()
    {
        LinkedNode<T>? head;
        LinkedNode<T>? last;
        //Счётчик всех элементов в списке
        int length;

        // Свойство для получения доступа к чтению и изменению head
        // Главное, что есь доступ только к Data, т.е. поменять ссылки пользователь случайно не может
        public T? Head
        {
            get
            {
                return head.Data;
            }
            set
            {
                head.Data = value;
            }
        }

        // метод подсчета количества элементов в списке
        public int Length 
        {
            get
            {
                return length;
            }
        }

        
        /// <summary>
        /// Добавление элемента в список
        /// </summary>
        /// <param name="data">Информация для добавления в список</param>
        public void Add(T data)
        {
            // Создаём узел с заданной информацией
            LinkedNode<T> node = new(data);

            // Если список пустой, делаем узел головным
            if (head is null)
            {
                head = node;
            }
            // Иначе добавляем его как следующего после последнего, делая новым последним элементом
            else
            {
                last.Next = node;
                node.Previous = last;
            }
            last = node;
            length++;
        }


        /// <summary>
        /// Удаление всех элементов с заданной информацией
        /// </summary>
        /// <param name="data">Информация для удаления</param>
        /// <returns>Успешно ли удаление</returns>
        public bool Remove(Challenge data)
        {
            // Задаём текущий просматриваемый узел
            LinkedNode<T>? current = head;
            bool removed = false;

            // Перебираем все элементы
            while (current is not null)
            {
                // Если искомый элемент для удаления найден
                if (current.Data.Equals(data))
                {
                    // Если этот элемент не является последним, связываем следующий элемент и предыдуший найденному
                    if (current.Next is not null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    // Если же элемент последний, то заменяем значение последнего на предущий
                    else
                    {
                        last = current.Previous;
                    }

                    // Если элемент не первый, то связываем предыдущий элементо и следющий найденному
                    if (current.Previous is not null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    // Если же первый, то обновлям "головной" узел
                    else
                    {
                        head = current.Next;
                    }

                    length--;
                    removed = true;
                }
                // Перемещаемся на следующий элемент
                current = current.Next;
            }
            return removed;
        }


        public void Clear()
        {
            // Очищаем первый и последний элементы, соответственно ссылки на все элементы потеряны
            head = last = null;
            length = 0;
            // Вызываем уборщик мусора, чтобы сразу удалить "утерянные" и удаленные элементы
            GC.Collect();
        }

        /// <summary>
        /// Случайная генерация списка заданной длины
        /// </summary>
        /// <param name="length">Длина нужного списка</param>
        public void RandomInit(int length)
        {
            // Очищаем текущий список
            Clear();
            
            // Если заданная длина меньше либо равна 0, то оставляем список пустым
            if (length <= 0)
            {
                return;
            }

            // Указанное количество раз добавляем случайно сгенерированные объекты
            for (int i = 0; i < length; i++)
            {
                T data = new();
                data.RandomInit();
                Add(data);
            }
        }

        /// <summary>
        /// Отображение элементовсписка
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void Show()
        {
            if (length== 0)
            {
                Console.WriteLine("Похоже, данный список пустой");
                return;
            }

            LinkedNode<T>? current = head;
            while (current is not null )
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public override string ToString()
        {
            string result = "";
            if (length== 0)
            {
                result = "Похоже, данный список пустой";
                return result;
            }

            LinkedNode<T>? current = head;
            while (current is not null)
            {
                result += current.Data + "\n";
                
                current = current.Next;
            }
            return result;
        }


        /// <summary>
        /// Клонирование списка
        /// </summary>
        /// <returns>Клон списка</returns>
        public DoubleLinkedList<T> Clone()
        {
            DoubleLinkedList<T> clonedList = new();
            LinkedNode<T>? current = head; 
            // добавляем клон каждого элемента в новый список
            while (current is not null)
            {
                clonedList.Add((T) current.Data.Clone());
                current = current.Next;
            }
            return clonedList;
        }
    }
}
