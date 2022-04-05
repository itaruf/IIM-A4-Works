using Sort;
using System;
using System.Linq;

/* https://en.wikipedia.org/wiki/Sorting_algorithm */
namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort.SortArray sortArray = new Sort.SortArray();

            Console.WriteLine("\n\n1-1 Tri Comptage\n");
            sortArray.Init(20);
            TriComptage(sortArray);
            sortArray.Display();

            Console.WriteLine("\n\n1-2 Tri Gnome\n");
            sortArray.Init(20);
            TriGnome(sortArray);
            sortArray.Display();

            Console.WriteLine("\n\n1-2 Tri Cocktail\n");
            sortArray.Init(20);
            TriCocktail(sortArray);
            sortArray.Display();

            Console.WriteLine("\n\n1-2 Tri Peigne\n");
            sortArray.Init(20);
            TriPeigne(sortArray);
            sortArray.Display();

            Console.WriteLine("\n\n2 Listes chaînées\n");
            LinkedList linkedList = new LinkedList();

            linkedList.Init(5);
            Console.WriteLine(linkedList);

            linkedList.Remove(linkedList.first.next);
            Console.WriteLine(linkedList);

            LinkedList.LinkedListElement elementToInsert = new LinkedList.LinkedListElement(10);
            linkedList.InsertAfter(elementToInsert, linkedList.first.next.next);
            Console.WriteLine(linkedList);

            linkedList.Remove(elementToInsert);
            Console.WriteLine(linkedList);

            Console.WriteLine("\n\n2-1 Tri Sélection\n");
            linkedList.Init(20);
            linkedList.TriSelection();
            Console.WriteLine(linkedList);

            Console.WriteLine("\n\n2-2 Tri à bulles\n");
            linkedList.Init(20);
            linkedList.TriBulles();
            Console.WriteLine(linkedList);
        }

        public static void TriComptage(SortArray sortArray)
        {
            // On construit un tableau temporaire de la taille de la valeur la plus haute de la liste à trier
            int[] array = new int[sortArray.array.Max() + 1];

            // On compte le nombre d'occurrences
            for (int i = 0; i <= sortArray.Length - 1; i++)
                array[sortArray[i]] = array[sortArray[i]] + 1;

            // On parcourt tout le tableau temporaire
            int pos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                while (array[i] > 0) // Tant que le nombre d'occurrences d'un élément est > 0
                {
                    sortArray[pos] = i; // Dans notre tableau à la pos étudiée, on affecte i qui correspond à la valeur dont le nombre d'occurrences > 0
                    pos++; // On passe à la position suivante dans notre tableau résultat
                    array[i]--; // On décrémente le nombre d'occurrences de 1
                }
                // Sinon si le nombre d'occurrences d'un élément <= 0, on ne fait rien
            }
        }

        public static void TriGnome(SortArray sortArray)
        {
            int pos = 0;

            // On parcourt toute la structure
            while (pos < sortArray.Length)
            {
                if (pos == 0) // On évite les index négatifs
                    pos++;

                if (sortArray[pos] < sortArray[pos - 1]) // On compare l'élément actuel avec le précédent
                {
                    // Si la condition match, on échange les contenus
                    sortArray.Swap(pos, pos - 1);
                    pos--;
                }
                else // Sinon on passe à l'élément suivant
                    pos++;
            }
        }

        private static void TriCocktail(SortArray sortArray)
        {
            for (int i = sortArray.Length - 1; i > 0; i--)
            {
                // Parcours vers la droite, la plus grande valeur est déplacée vers la fin de liste
                bool hasSwap = false;
                for (int j = 1; j <= i; j++)
                {
                    if (sortArray[j - 1] > sortArray[j])
                    {
                        hasSwap = true; // Au moins un échange a été effectué
                        sortArray.Swap(j - 1, j); // On échange les données
                    }
                }

                if (!hasSwap) // La structure est triée, on met fin à la fonction
                    return;

                // Parcours vers la gauche, la plus petite valeur est déplacée vers la tête de liste
                for (int j = sortArray.Length - 1; j >= i; j--)
                {
                    if (sortArray[j - 1] > sortArray[j])
                    {
                        hasSwap = true; // Au moins un échange a été effectué
                        sortArray.Swap(j - 1, j); // On échange les données
                    }
                }
                if (!hasSwap) // La structure est triée, on met fin à la fonction
                    return;
            }
        }

        private static void TriPeigne(SortArray sortArray)
        {
            int ecart = sortArray.Length; // l'écart vaut la taille de la structure

            for (int i = sortArray.Length - 1; i > 0; i--)
            {
                bool hasSwap = false;
                ecart = (int)(ecart / 1.3f); // à chaque itération, on réduit l’écart

                for (int j = 1; j < sortArray.Length - ecart; j++) // Tri à bulles classiques
                {
                    if (sortArray[j - 1] > sortArray[j + ecart])
                    {
                        hasSwap = true; // Au moins un échange a été effectué
                        sortArray.Swap(j - 1, j + ecart); // On échange les données
                    }
                }

                if (!hasSwap) // La structure est triée, on met fin à la fonction
                    return;
            }
        }
    }
}