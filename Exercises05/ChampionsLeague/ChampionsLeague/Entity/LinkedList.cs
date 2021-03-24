using System;
using System.Collections;

namespace ChampionsLeague.Entity
{
    public class LinkedList : IEnumerable, ICollection, IList
    {
        NodeList first;
        NodeList last;
        int count;
        public int Count => count;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public class NodeList {
            public object Data { get; set; }
            public NodeList Next { get; set; }
            public NodeList Previous { get; set; }

            public NodeList(object data, NodeList next, NodeList previous) {
                Data = data;
                Next = next;
                Previous = previous;
            }
        }

        public object this[int index] {
            get {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (index == 0)
                {
                    return first.Data;
                }
                else if (index == count - 1)
                {
                    return last.Data;
                }
                else {
                    NodeList actual = first;
                    for (int i = 0; i < index; i++) {
                        actual = actual.Next;
                    }
                    return actual.Data;
                }
            }
            set => Insert(index, this); 
        }

        public int Add(object value)
        {
            if (first == null)
            {
                first = new NodeList(value, null, null);
                last = first;
            }
            else {
                NodeList tmp = new NodeList(value, null, last);
                last.Next = tmp;
                last = tmp;
            }
            return ++count;
        }

        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }

        public bool Contains(object value)
        {
            NodeList actual = first;
            while (actual.Next != null) {
                if (actual.Data == value) {
                    return true;
                }
                actual = actual.Next;
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            NodeList tmp = first;
            for (int i = 0; i < count; i++)
            {
                array.SetValue(tmp.Data, i);
                tmp = tmp.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ListEnumerator(first);
        }

        public int IndexOf(object value)
        {
            int index = 0;
            NodeList actual = first;
            while (actual.Next != null)
            {
                if (actual.Data == value)
                {
                    return index;
                }
                actual = actual.Next;
                index++;
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if (count < index || index < 0) {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                NodeList tmp = first;
                first = new NodeList(value, tmp, null);
                first.Next.Previous = first;
                count++;
            }
            else if (index == count)
            {
                Add(value);
            }
            else {
                NodeList actual = first;
                for (int i = 0; i < index; i++)
                {
                    actual = actual.Next;
                }

                NodeList tmp = actual;
                actual = new NodeList(value, tmp, tmp.Previous);
                tmp.Previous.Next = actual;
                tmp.Next.Previous = actual;
                count++;    
            }
        }

        public void Remove(object value)
        {
            if (first.Data == value && first.Next == null)
            {
                Clear();
            }
            else if (first.Data == value && first.Next != null)
            {
                first = first.Next;
                first.Previous = null;
                count--;
            }
            else if (last.Data == value)
            {
                last = last.Previous;
                last.Next = null;
                count--;
            }
            else {
                NodeList actual = first;
                while (actual != null) {
                    if (actual.Data == value) {
                        actual.Previous.Next = actual.Next;
                        actual.Next.Previous = actual.Previous;
                        count--;
                    }
                    actual = actual.Next;
                }
            
            }
            
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > count) {
                throw new IndexOutOfRangeException();
            }

            NodeList tmp = first;
            for (int i = 0; i < count; i++)
            {
                if (i == index) {
                    Remove(tmp.Data);
                }
                tmp = tmp.Next;
            }
        }
    }
}
