using System.Collections;

namespace ChampionsLeague.Entity
{
    internal class ListEnumerator : IEnumerator
    {
        private LinkedList.NodeList first;
        private LinkedList.NodeList next;
        private bool start = true;
        public object Current => next.Data;

        public ListEnumerator(LinkedList.NodeList first)
        {
            this.first = first;
        }

        public bool MoveNext()
        {
            if (start == true)
            {
                next = first;
                start = false;
            }
            else {
                next = next.Next;
            }
            return next != null;
        }

        public void Reset()
        {
            next = first;
        }
    }
}