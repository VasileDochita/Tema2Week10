using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10.Generics.App04
{
    internal class GenericList<T> where T : new()
    {
        private T[] array;

        private int size;

        public int count = 0;

        private int currentElemIdx;

        public GenericList(int size)
        {
            this.currentElemIdx = 0;
            this.size = size;
            this.array = new T[size];
        }


        public void Add(T value)
        {
            if (this.currentElemIdx == this.size)
            {
                Console.WriteLine("Size full!");
                return;
            }

            this.array[this.currentElemIdx] = value;
            this.currentElemIdx++;
        }

        public T GetAt(int idx)
        {
            return this.array[idx];
        }

        private void DoubleSize()
        {
            int newArray = this.array.Length * 2;
            T[] newList = new T[newArray];

            for (int i = 0; i < size; i++)
            {
                newList[i] = this.array[i];
            }

            this.array = newList;
            this.size = size * 2;

            if (count >= size)
            {
                DoubleSize();
            }
            count++;
        }
        public void Clear()
        {
            this.array = new T[size];
            this.count = 0;
            this.size = 0;
        }
        public T Min()
        {
            T min = this.array[0];
            for (int i = 0; i < count; i++)
            {
                if (this.array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }
            return min;
        }
        public T Max()
        {
            T max = this.array[0];
            for (int i = 0; i < count; i++)
            {
                if (this.array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                result.Append(array[i]);
                if (i < count - 1)
                {
                    result.Append(" , ");
                }
            }
            return result.ToString();

        }
        public void insertAtGivenPosition(int index, T element)
        {
            T[] result = new T[count - 1];

            for (int i = 0; i < count + 1; i++)
            {
                if (i == index)
                {
                    result[i] = element;
                }
                else if (i < index)
                {
                    result[i] = array[i];
                }
                else if (i > index)
                {
                    result[i] = array[i - 1];
                }
            }
            array = new T[count + 1];
            for (int i = 0; i < count; i++)
            {
                array[i] = result[i];
            }
        }
        public void removeByIndex(int index)
        {
            T[] result = new T[count - 1];

            for (int i = 0; i < index; i++)
            {
                result[i] = array[i];
            }
            for (int i = index + 1; i < count; i++)
            {
                result[i - 1] = array[i];
            }
            array = new T[count];
            count--;
            for (int i = 0; i < count; i++)
            {
                array[i] = result[i];
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            var stringList = new GenericList<string>(3);

            stringList.Add("123");
            stringList.Add("1234");
            stringList.Add("12345");


        }
    }
}