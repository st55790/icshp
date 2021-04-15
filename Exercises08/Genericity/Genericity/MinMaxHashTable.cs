using System;
using System.Collections.Generic;
using System.Linq;

namespace Cv_08.HashTable
{
    class Node<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public Node<K, V> Next { get; set; }

        public Node(K key, V value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    public class MinMaxHashTable<K, V> where K : IComparable
    {
        private readonly Node<K, V>[] _hashTable;
        private K _minimum;
        private K _maximum;
        public K Maximum
        {
            get
            {
                if (Count == 0)
                    throw new InvalidOperationException("Maximum not set");

                return _maximum;
            }
            set
            {
                _maximum = value;
            }
        }

        public K Minimum
        {
            get
            {
                if (Count == 0)
                    throw new InvalidOperationException("Minimum not set");

                return _minimum;
            }
            set
            {
                _minimum = value;
            }
        }
        public int Count { get; set; }

        public IEnumerable<KeyValuePair<K, V>> this[K min, K max]
        {
            get
            {
                List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();

                for (int i = 0; i < _hashTable.Length; i++)
                {
                    Node<K, V> element = _hashTable[i];
                    while (element != null)
                    {
                        // key value is in range
                        if (element.Key.CompareTo(min) >= 0 && element.Key.CompareTo(max) <= 0)
                            list.Add(new KeyValuePair<K, V>(element.Key, element.Value));

                        element = element.Next;
                    }
                }
                return list;
            }
        }

        public MinMaxHashTable(int capacity)
        {
            _maximum = default(K);
            _minimum = default(K);
            _hashTable = new Node<K, V>[capacity];
            Count = 0;
        }

        public MinMaxHashTable() : this(20)
        {

        }

        public void Add(K key, V value)
        {
            if (Contains(key))
                throw new ArgumentException("Key already present in table");

            int index = GetIndex(key);

            Maximum = _maximum.CompareTo(key) > 0 ? _maximum : key;
            Minimum = _minimum.CompareTo(key) < 0 ? _minimum : key;

            Node<K, V> element = new Node<K, V>(key, value);
            InsertNodeToOrigin(element, index);

            Count++;
        }

        private void InsertNodeToOrigin(Node<K, V> inserted, int index)
        {
            Node<K, V> original = _hashTable[index];
            inserted.Next = original;
            _hashTable[index] = inserted;
        }

        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % _hashTable.Length);
        }

        private bool IsIndexInRange(int index)
        {
            return index < _hashTable.Length;
        }

        public bool Contains(K key)
        {
            // get the index
            int index = GetIndex(key);

            // do not bother if we're past the size of array
            if (!IsIndexInRange(index)) return false;

            Node<K, V> element = _hashTable[index];

            // Walk through the linked list
            while (element != null)
            {
                if (element.Key.Equals(key))
                    return true;

                element = element.Next;
            }

            return false;
        }

        public V Get(K key)
        {
            // get the index we're supposed to work at
            int index = GetIndex(key);
            // do not bother if the index makes no sense
            if (!IsIndexInRange(index))
                throw new KeyNotFoundException("No such key in collection");

            Node<K, V> element = _hashTable[index];

            while (element != null)
            {
                if (element.Key.Equals(key))
                    return element.Value;

                element = element.Next;
            }

            throw new KeyNotFoundException("No such key in collection");
        }

        public V Remove(K key)
        {
            if (!Contains(key))
                throw new KeyNotFoundException("No such key in collection");

            int index = GetIndex(key);

            Node<K, V> currentElement = _hashTable[index];
            Node<K, V> previousElement = currentElement;

            while (currentElement != null)
            {
                if (currentElement.Key.Equals(key))
                    return RemoveNode(currentElement, previousElement, index);

                previousElement = currentElement;
                currentElement = currentElement.Next;
            }

            throw new KeyNotFoundException("No such key in collection");
        }

        private V RemoveNode(Node<K, V> currentElement, Node<K, V> previousElement, int index)
        {
            V value = currentElement.Value;

            if (currentElement == _hashTable[index])
                _hashTable[index] = currentElement.Next;
            else
                previousElement.Next = currentElement.Next;

            Count--;

            return value;
        }

        public IEnumerable<KeyValuePair<K, V>> Range(K min, K max)
        {
            List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();

            for (int i = 0; i < _hashTable.Length; i++)
            {
                Node<K, V> element = _hashTable[i];
                while (element != null)
                {
                    // key value is in range
                    if (element.Key.CompareTo(min) >= 0 && element.Key.CompareTo(max) <= 0)
                        list.Add(new KeyValuePair<K, V>(element.Key, element.Value));

                    element = element.Next;
                }
            }
            return list;
        }

        public IEnumerable<KeyValuePair<K, V>> SortedRange(K min, K max)
        {
            return Range(min, max).OrderBy(x => x.Key);
        }
    }
}
