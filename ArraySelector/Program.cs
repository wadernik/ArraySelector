using System;
using System.Collections;
using System.Collections.Generic;

namespace ArraySelector
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    public class DoublyLinkedList<T> : IEnumerable<T>  // двусвязный список
    {
        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }

        public void RemoveFront()
        {
            DoublyNode<T> current = head;

            if (current.Next != null)
            {
                current.Next.Previous = null;
            }

            head = current.Next;
            count--;
        }

        public void RemoveBack()
        {
            DoublyNode<T> current = head;
            
            tail = current.Previous;
            current.Previous.Next = current.Next;
            
            count--;
        }

        // удаление
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }

    class Program
    {
        // Начальный индекс
        public static int ix = 0;
        private static int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static Queue myQ = new Queue();

        static void Main(string[] args)
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();

            // добавление элементов
            linkedList.Add("Bob");
            linkedList.Add("Bill");
            linkedList.Add("Tom");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            linkedList.RemoveFront();
            linkedList.Add("Bob");
            linkedList.Add("Vova");
            linkedList.Add("Boba");

            Console.WriteLine("--------");
            Console.WriteLine();

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            linkedList.RemoveBack();
            linkedList.AddFirst("Boba");
            linkedList.AddFirst("Aasdd");

            Console.WriteLine("--------");
            Console.WriteLine();

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            

            // int picker = 0;

            // for (int i = 0; i < numbers.Length; i++)
            // {
            //    myQ.Enqueue(i);
            // }

            // Console.WriteLine();
            // Console.WriteLine("----------------");
            // printQueue();
            // Console.WriteLine("----------------");
            // Console.WriteLine();

            // rebuildQueue(ix);

            // Console.WriteLine();
            // Console.WriteLine("----------------");
            // printQueue();
            // Console.WriteLine("----------------");
            // Console.WriteLine();


            // Console.WriteLine("--------");
            // Console.WriteLine();
            // Console.WriteLine("Choose the action:");
            // Console.WriteLine("1: PickNext");
            // Console.WriteLine("2: PickPrevious");
            // Console.Write("_: ");

            // picker = Convert.ToInt32(Console.ReadLine());

            // // 1 - вывести наверх
            // // 2 - вывести вниз
            // // 3 - завершить прогу

            // while (picker != 3)
            // {
            //    if (picker == 1)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine("----------------");

            //        ix = (int)myQ.Peek();
            //        pickNext();

            //        Console.WriteLine("----------------");
            //        Console.WriteLine();
            //    }

            //    if (picker == 2)
            //    {
            //        pickPrevious();
            //    }

            //    Console.WriteLine("Choose the action:");
            //    Console.WriteLine("1: PickNext");
            //    Console.WriteLine("2: PickPrevious");
            //    Console.Write("_: ");

            //    picker = Convert.ToInt32(Console.ReadLine());
            // }
        }

        private static void pickNext()
        {
            int el = (int)myQ.Peek();
            moveUp(el);
            Console.Write("[ ");
            Console.Write(el);
            Console.Write(" ] - ");
            Console.WriteLine(numbers[el]);

            el = (int)myQ.Peek();
            moveUp(el);
            Console.Write("[ ");
            Console.Write(el);
            Console.Write(" ] - ");
            Console.WriteLine(numbers[el]);

            el = (int)myQ.Peek();

            Console.Write("[ ");
            Console.Write(el);
            Console.Write(" ] - ");
            Console.WriteLine(numbers[el]);
        }

        private static void pickPrevious()
        {
            rebuildQueue(3);

            Console.WriteLine();
            Console.WriteLine("----------------");
            printQueue();
            Console.WriteLine("----------------");
            Console.WriteLine();
            // pickNext();
        }

        private static void moveUp(int el)
        {
            myQ.Dequeue();
            myQ.Enqueue(el);
        }

        private static void rebuildQueue(int i)
        {
            int el = (int)myQ.Peek();

            while (el < i)
            {
                myQ.Dequeue();
                myQ.Enqueue(el);
                el = (int)myQ.Peek();
            }
        }

        private static void printQueue()
        {
            foreach (int el in myQ)
            {
                Console.Write("[ ");
                Console.Write(el);
                Console.Write(" ] ");
            }
            Console.WriteLine();
        }

        private static void printNumbers()
        {
            foreach (int el in numbers)
            {
                Console.Write("[ ");
                Console.Write(el);
                Console.Write(" ] ");
            }
            Console.WriteLine();
        }
    }
}
