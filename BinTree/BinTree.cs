using ChallengeLibrary;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Xml.Linq;


namespace BinTree
{
    public class BinTree<T> where T : class, IInit, ICloneable, IComparable, new()
    {
        private BinNode<T>? root;
        
        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        /// <param name="Data">Элемент для добавления</param>
        public void Add(T Data)
        {
            BinNode<T> newItem = new BinNode<T>(Data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = AddHelper(root, newItem);
            }
        }

        /// <summary>
        /// Рекурсивная вспомогательная функция для добавления
        /// </summary>
        /// <param name="current">Текущий элемент</param>
        /// <param name="node">Обрабатываемый элемент</param>
        /// <returns>Элемент, являющийся корнем</returns>
        /// <exception cref="DuplicateNameException">Ошибка в случае добавления уже имеющегося элемента</exception>
        private BinNode<T> AddHelper(BinNode<T> current, BinNode<T> node)
        {
            if (current == null)
            {
                current = node;
                return current;
            }

            // Если добавляемый элемент уже есть в дереве, то выбрасываем ошибку
            if (current.Data.Equals(node.Data))
            {
                throw new DuplicateNameException();
            }

            // Добавляем элемент в соответствующее место 
            if (node.Data.CompareTo(current.Data) > 0)
            {
                current.Left = AddHelper(current.Left, node);
            }

            if (node.Data.CompareTo(current.Data) < 0)
            {
                current.Right = AddHelper(current.Right, node);
            }
            // Выполняем балансировку дерева
            current = Balance(current);
            return current;
        }

        /// <summary>
        /// Балансировка дерева
        /// </summary>
        /// <param name="current">Элемент, относительно которого выпоняется балансировка</param>
        /// <returns>Новый корень после балансировки</returns>
        private BinNode<T> Balance(BinNode<T> current)
        {
            // Вычисляем, в какую сторону перевес у дерева
            int balanceFactor = BalanceFactor(current);

            // Балансируем соответствующую ветку 
            if (balanceFactor > 1)
            {
                // Проверяем балансировку поддеревьев и если что балансируем их 
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (balanceFactor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        /// <summary>
        /// Получение высоты дерева
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            // Специальный вызов внутреннего метода от корня,
            // чтобы пользователь не заморачивался над тем, относительно чего вызывать метод
            return GetHeight(root);
        }


        /// <summary>
        /// Внутренний метод получения высоты дерева относительно указанного элемента
        /// </summary>
        /// <param name="current">Элемент для вычисления высоты</param>
        /// <returns>Высота выбранного поддерева</returns>
        private int GetHeight(BinNode<T> current)
        {
            int height = 0;

            if (current != null)
            {
                // Вычисляем максимальную высоту по каждому из поддеревьев
                int leftHeight = GetHeight(current.Left);
                int rightHeight = GetHeight(current.Right);
                int maxHeight = Math.Max(leftHeight, rightHeight);

                height = maxHeight + 1;
            }
            return height;
        }

        /// <summary>
        /// Проверка, в какую сторону нарушена балансировка дерева
        /// </summary>
        /// <param name="current">Вершина, относительно которой нужна проверкаё</param>
        /// <returns><0 еси перевес справа, >0 если перевес слева</returns>
        private int BalanceFactor(BinNode<T> current)
        {
            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            int balanceFactor = left - right;

            return balanceFactor;
        }

        //Поворот правого поддерева через право
        private BinNode<T> RotateRR(BinNode<T> parent)
        {
            BinNode<T> pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;

            return pivot;
        }

        // Поворот левого поддерева через лево
        private BinNode<T> RotateLL(BinNode<T> parent)
        {
            BinNode<T> pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;

            return pivot;
        }

        // Поворот левого поддерева через право
        private BinNode<T> RotateLR(BinNode<T> parent)
        {
            BinNode<T> pivot = parent.Left;
            parent.Left = RotateRR(pivot);

            return RotateLL(parent);
        }

        // Поворот правого поддерева через лево
        private BinNode<T> RotateRL(BinNode<T> parent)
        {
            BinNode<T> pivot = parent.Right;
            parent.Right = RotateLL(pivot);

            return RotateRR(parent);
        }


        /// <summary>
        /// Случайная генерация дерева заданной длины
        /// </summary>
        /// <param name="length">Длина нужного списка</param>
        public void RandomInit(int length)
        {
            // Очищаем текущее дерево
            Clear();
            // Если заданная длина меньше либо равна 0, то оставляем дерево пустым
            if (length <= 0)
            {
                return;
            }

            // Указанное количество раз добавляем случайно сгенерированные объекты
            for (int i = 0; i < length; i++)
            {
                T Data = new();
                Data.RandomInit();
                Add(Data);
            }
        }

        /// <summary>
        /// Очистка дерева
        /// </summary>
        public void Clear()
        {
            root = null;
            GC.Collect();
        }

        [ExcludeFromCodeCoverage]
        public void Show()
        {
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// Отображение дерева в виде строки
        /// </summary>
        /// <returns>Дерево в виде строки</returns>
        public override string ToString()
        {
            if (root == null)
            {
                return "Похоже, дерево пустое";
            }
            string result = "";
            ToStringHelper(root, 0, ref result);
            return result;
        }

        /// <summary>
        /// Внутрення рекурсивная функция для отображения дерева
        /// </summary>
        /// <param name="start">Откуда начать отображение</param>
        /// <param name="l">Отступ каждой ветки</param>
        /// <param name="result">Итоговая строка</param>
        private void ToStringHelper(BinNode<T>? start, int l, ref string result)
        {
            
            if (start!=null)
            {
                ToStringHelper(start.Left, l+3, ref result);
                for (int i = 0; i < l; i++)
                {
                    result += " ";

                }
                result+=start.Data.ToString() + "\n";

                ToStringHelper(start.Right, l+3, ref result);
            }
        }

        /// <summary>
        /// Проверка, является ли дерево деревом поиска. Для тестирования
        /// </summary>
        /// <returns>Является ли дерево деревом поиска</returns>
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTreeHelper(root);
        }


        /// <summary>
        /// Внутренняя функция проверкт, является ли дерево деревом поиска. Для тестирования
        /// </summary>
        /// <param name="node">Элемент, относительно которого проверка</param>
        /// <returns>Реузльтат проверки</returns>
        private bool IsBinarySearchTreeHelper(BinNode<T>? node)
        {
            if (node == null)
                return true;
            // Сравниваем каждую ноду с правой и левой
            if (node.Left != null && node.Left.Data.CompareTo(node.Data) < 0)
                return false;

            if (node.Right != null && node.Right.Data.CompareTo(node.Data) > 0)
                return false;

            return IsBinarySearchTreeHelper(node.Left) && IsBinarySearchTreeHelper(node.Right);
        }
    }
}