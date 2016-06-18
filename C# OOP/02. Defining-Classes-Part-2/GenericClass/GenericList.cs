using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DSpace;

namespace GenericClass
{
    public class GenericList<T> where T : IComparable
    {
        private T[] elements;
        private int counter = 0;

        public GenericList(int size)
        {
            this.elements = new T[size];
        }

        public int Count
        {
            get
            {
                return this.counter;
            }
        }

        public void Add(T element)
        {
            if (this.counter == this.elements.Length)
            {
                this.AutoGrow();
            }

            this.elements[counter] = element;
            this.counter++;
        }

        public void Clear()
        {
            this.elements = new T[this.elements.Length];
            this.counter = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index > this.counter - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                return this.elements[index];
            }

            private set
            {
                this.elements[index] = value;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index >= this.counter)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }

            for (int i = index; i < this.elements.Length - 2; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.counter--;
            this.elements[counter] = default(T);
        }

        public void InsertAtGivenPosition(int index, T element)
        {
            if (this.counter == this.elements.Length)
            {
                this.AutoGrow();
            }

            for (int i = this.elements.Length - 1; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
            this.counter++;
        }

        public T Min()
        {
            if (this.counter == 0)
            {
                throw new ArgumentException("No elements in the GenericList");
            }

            T min = this.elements[0];
            foreach (T item in this.elements)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.counter == 0)
            {
                throw new ArgumentException("No elements in the GenericList");
            }

            T max = this.elements[0];
            foreach (T item in this.elements)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        private void AutoGrow()
        {
            var newSize = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newSize[i] = this.elements[i];
            }

            this.elements = newSize;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < this.counter; i++)
            {
                result.AppendLine(string.Format("[{0}] -> {1} ", i, elements[i]));
            }

            return result.ToString().TrimEnd();
        }
    }
}
