using System;

namespace Sort
{
    class SortArray
    {
        public int[] array { get; private set; }

        public int Length
        {
            get { return array.Length; }
        }

        public int this[int i]
        {
            get { return array[i]; }
            set { Set(i,value); }
        }


        private int[] lastDisplayedArray;
        private int step;

        //some display helper
        public bool stepByStepDisplay = false;
        public int firstDisplayedElement = -1;
        public int lastDisplayedElement = -1;

        public void Init(int nbElements)
        {
            Random random = new Random();
            array = new int[nbElements];
            for (int i = 0; i < nbElements; ++i)
            {
                array[i] = random.Next() % 100;
            }
            lastDisplayedArray = null;
            step = 0;
            ResetDisplayLimit();
            Display();
        }

        public void Init(int[] forcedValues)
        {
            array = new int[forcedValues.Length];
            Array.Copy(forcedValues, array, forcedValues.Length);
            lastDisplayedArray = null;
            step = 0;
            ResetDisplayLimit();
            Display();
        }

        public void Init(int[] forcedValues, int startIndex, int endIndex)
        {
            array = new int[endIndex - startIndex];
            Array.Copy(forcedValues, startIndex, array, 0, endIndex - startIndex);
            lastDisplayedArray = null;
            step = 0;
            ResetDisplayLimit();
            Display();
        }

        public void Swap(int pos1, int pos2)
        {
            if (pos1 < 0 || pos2 < 0 || pos1 >= Length || pos2 >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            int x = array[pos1];
            array[pos1] = array[pos2];
            array[pos2] = x;
            ++step;
            Display();
        }

        public void Set(int index, int value)
        {
            array[index] = value;
            ++step;
            Display();
        }

        public void Set(int index, int[] values, int count)
        {
            Array.Copy(values, 0, array, index, count);
            ++step;
        }

        public void SetDisplayLimit(int firstElement, int lastelement)
        {
            firstDisplayedElement = firstElement;
            lastDisplayedElement = lastelement;
        }

        public void ResetDisplayLimit()
        {
            firstDisplayedElement = 0;
            lastDisplayedElement = array.Length - 1;
        }

        public void Display(int highlightElement  = -1)
        {
            if(lastDisplayedArray == null)
            {
                lastDisplayedArray = new int[array.Length];
                Array.Copy(array, lastDisplayedArray, array.Length);
                Console.Write("New array: ");
            }else
            {
                Console.Write("Step {0,4}: ", step);
            }
            for(int i = 0; i < firstDisplayedElement; ++i)
            {
                Console.Write("   ");
            }
            for(int i = firstDisplayedElement; i <= lastDisplayedElement; ++i)
            {
                if(highlightElement == i)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }else
                {
                    Console.ForegroundColor = (array[i] == lastDisplayedArray[i] ? ConsoleColor.White : ConsoleColor.DarkGreen);
                }
                Console.Write("{0,2:D} ", array[i]);
                lastDisplayedArray[i] = array[i];
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (stepByStepDisplay)
                Console.ReadKey(true);
        }
    }
}
