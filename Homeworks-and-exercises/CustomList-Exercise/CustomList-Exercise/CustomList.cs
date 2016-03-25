using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList_Exercise
{
    public class CustomList<T> where T : IComparable<T>
    {
        private T[] elements;
        private const int DefaultCapacity = 8;
        private int currentIndex;
        
        public CustomList(int initialCapacity = DefaultCapacity)
        {
            this.elements = new T[initialCapacity];
            this.currentIndex = 0;
        }

        public void Add(T elementToAdd)
        {
            if (this.currentIndex >= this.elements.Length)
            {
                this.ResizeCapacity();
            }
            this.elements[currentIndex] = elementToAdd;
            currentIndex++;
        }

        public int IndexOf(T elementToFind)
        {
            if (this.currentIndex == 0)
            {
                throw new ArgumentException("List is empty!");
            }

            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].Equals(elementToFind))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Remove(T elementToRemove)
        {
            int index = this.IndexOf(elementToRemove);

            if (index == -1)
            {
                throw new ArgumentException("Specified element was not found.");
            }

            for (int i = index; i < this.currentIndex - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.currentIndex--;
            this.elements[currentIndex] = default(T);
            
            //bool isFoundValue = false;
            //for (int i = 0; i < currentIndex; i++)
            //{
            //    if (i == this.currentIndex - 1)
            //    {
            //        if (this.elements[i].Equals(elementToRemove))
            //        {
            //            this.elements[currentIndex] = default(T);
            //            currentIndex--;
            //            isFoundValue = true;
            //            break;
            //        }
            //    }

            //    if (this.elements[i].Equals(elementToRemove))
            //    {
            //        for (int j = i; j < currentIndex - 1; j++)
            //        {
            //            this.elements[j] = this.elements[j + 1];
            //        }
            //        currentIndex--;
            //        isFoundValue = true;
            //        break;
            //    }
            //}

            //if (!isFoundValue)
            //{
            //    throw new ArgumentException("No such elementToAdd in the list!");
            //}
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= currentIndex)
                {
                    throw new IndexOutOfRangeException("Index was outside the boundaries of CustomList.");
                }

                return this.elements[i];
            }
            set
            {
                if (i < 0 || i >= currentIndex)
                {
                    throw new IndexOutOfRangeException("Index was outside the boundaries of CustomList.");
                }

                this.elements[i] = value;
            }
        }

        public T Min()
        {
            if (this.currentIndex == 0)
            {
                throw new ArgumentException("List is empty!");
            }

            T min = this.elements[0];

            for (int i = 1; i < this.currentIndex; i++)
            {
                if (this.elements[i].CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.currentIndex == 0)
            {
                throw new ArgumentException("List is empty!");
            }

            T max = this.elements[0];

            for (int i = 1; i < this.currentIndex; i++)
            {
                if (this.elements[i].CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            return String.Format("[{0}]", String.Join(", ", this.elements.Take(this.currentIndex)));
        }

        private void ResizeCapacity()
        {
            var newElements = new T[this.elements.Length * 2];
            for (int i = 0; i < this.currentIndex; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}
