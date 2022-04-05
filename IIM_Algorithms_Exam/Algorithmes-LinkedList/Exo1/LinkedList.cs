using System;

/* https://en.wikipedia.org/wiki/Linked_list */
namespace Sort
{
    public class LinkedList
    {
        public LinkedListElement first { get; private set; } = null;

        public LinkedList()
        {
        }

        public void Init(int nbElements)
        {
            Random random = new Random();
            first = null;
            LinkedListElement lastCreated = null;
            for (int i = 0; i < nbElements; ++i)
            {
                LinkedListElement element = new LinkedListElement(random.Next() % 100);
                if (first == null)
                {
                    first = element;
                }
                else
                {
                    lastCreated.next = element;
                    element.previous = lastCreated;
                }
                lastCreated = element;
            }
        }

        public void Add(int value)
        {
            Add(new LinkedListElement(value));
        }

        public void Add(LinkedListElement element)
        {
            if (first == null)
            {
                first = element;
            }
            else
            {
                LinkedListElement last = first;
                while (last.next != null)
                {
                    last = last.next;
                }
                last.next = element;
            }
        }

        internal void TriBulles()
        {
            if (first == null)
                throw new ArgumentNullException();

            bool hasSwap = false;

            do
            {
               hasSwap = false;

                LinkedListElement x = first;

                while (x != null)
                {
                    if (x.next == null)
                        break;

                    if (x.value > x.next.value)
                    {
                        hasSwap = true;
                        Swap(x, x.next);
                    }

                    x = x.next;
                } 
            } 
            while (hasSwap); 
        }

        internal void TriSelection()
        {
            if (first == null)
                throw new ArgumentNullException();

            LinkedListElement pos = first;

            while (pos != null)
            {
                LinkedListElement minElement = pos;
                LinkedListElement x = pos.next;

                while (x != null)
                {
                    if (minElement.value > x.value)
                        minElement = x;

                    x = x.next;
                }

                if (minElement != pos)
                {
                    Swap(pos, minElement);
                    pos = minElement.next;

                }

                else
                    pos = pos.next;
            }
        }

        public override string ToString()
        {
            String ret = "";
            LinkedListElement element = first;
            while (element != null)
            {
                ret += element + " ";
                element = element.next;
            }
            return ret;
        }

        public void InsertAfter(LinkedListElement elementToInsert, LinkedListElement parentElement)
        {
            if (elementToInsert == null || parentElement == null || first == null)
                throw new ArgumentNullException();

            if (parentElement == first && first.next == null)
            {
                first.next = elementToInsert;
                elementToInsert.previous = first;
                return;
            }

            LinkedListElement x = first;

            while (x != null)
            {
                if (x == parentElement)
                {
                    LinkedListElement initialNextElement = parentElement.next;

                    parentElement.next = elementToInsert;

                    if (initialNextElement != null)
                        elementToInsert.next = initialNextElement;

                    if (initialNextElement != null)
                        initialNextElement.previous = elementToInsert;

                    elementToInsert.previous = parentElement;
                    break;
                }

                else
                    x = x.next;
            }
        }

        public void Remove(LinkedListElement element)
        {
            if (element == null || first == null)
                throw new ArgumentNullException();

            if (first.next == null)
            {
                first = null;
                return;
            }

            if (element == first)
            {
                first = first.next;
                first.next.previous = null;
                return;
            }

            LinkedListElement x = first; 

            while (x != null)
            {
                if (x.next == null && x != element)
                    break;

                if (x == element)
                {
                    LinkedListElement initialNextElement = element.next;

                    element.previous.next = initialNextElement;

                    if (element.next != null)
                        element.next.previous = element.previous;

                    break;
                }
                else
                    x = x.next;
            }
        }

        public void Swap(LinkedListElement element1, LinkedListElement element2)
        {
            if (element1 == null || element2 == null || first == null)
                throw new ArgumentNullException();

            if (element1 == first && element1.next == null)
                throw new ArgumentNullException();

            if (element2 == first && element2.next == null)
                throw new ArgumentNullException();

            if (element1 == first)
                first = element2;
            else if (element2 == first)
                first = element1;

            LinkedListElement x = element1.next;
            element1.next = element2.next;
            element2.next = x;

            if (element1.next != null)
                element1.next.previous = element1;
            if (element2.next != null)
                element2.next.previous = element2;

            x = element1.previous;
            element1.previous = element2.previous;
            element2.previous = x;

            if (element1.previous != null)
                element1.previous.next = element1;
            if (element2.previous != null)
                element2.previous.next = element2;
        }


        public class LinkedListElement
        {
            public int value { get; private set; }
            public LinkedListElement next = null;
            public LinkedListElement previous = null;

            public LinkedListElement(int value)
            {
                this.value = value;
                this.next = null;
            }

            public override string ToString()
            {
                return value.ToString();
            }
        }
    }
}