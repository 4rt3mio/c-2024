using System.Collections;
using Task.Exeptions;
using Task.Interfaces;

namespace Task.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head; // Указатель на первый элемент
        private Node current; // Указатель на текущий элемент
        private int count; // Количество элементов в коллекции

        public MyCustomCollection()
        {
            head = null;
            current = null;
            count = 0;
        }

        // Индексатор коллекции
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                Node node = head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node.Data;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                Node node = head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                node.Data = value;
            }
        }

        public void Reset()
        {
            current = head;
        }

        public void Next()
        {
            if (current != null)
            {
                current = current.Next;
            }
        }

        public T Current()
        {
            if (current == null)
            {
                throw new InvalidOperationException("Cursor is out of bounds.");
            }
            return current.Data;
        }

        // Свойство, возвращающее количество элементов в коллекции
        public int Count => count;

        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
            count++;
        }

        public void Remove(T item)
        {
            Node currentNode = head;
            Node previousNode = null;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    if (previousNode == null)
                    {
                        head = currentNode.Next;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;
                    }
                    count--;
                    return;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            throw new ItemNotFoundException("Item not found in the collection.");
        }
        public T RemoveCurrent()
        {
            if (current == null)
            {
                throw new InvalidOperationException("Cursor is out of bounds.");
            }

            T itemToRemove = current.Data;

            if (head == current)
            {
                head = head.Next;
            }
            else
            {
                Node previousNode = head;
                while (previousNode.Next != current)
                {
                    previousNode = previousNode.Next;
                }
                previousNode.Next = current.Next;
            }

            current = current.Next;
            count--;

            return itemToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}