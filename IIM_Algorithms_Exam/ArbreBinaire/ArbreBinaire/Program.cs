using System;

/* https://en.wikipedia.org/wiki/AVL_tree */
/* https://en.wikipedia.org/wiki/Tree_rotation */

namespace ArbreBinaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArbreBinaire arbreBinaire6 = new ArbreBinaire();

            arbreBinaire6.Ajout(5);
            arbreBinaire6.Ajout(3);
            arbreBinaire6.Ajout(6);
            arbreBinaire6.Ajout(1);
            arbreBinaire6.Ajout(4);
            arbreBinaire6.Ajout(0);
            arbreBinaire6.Ajout(2);

            /*Console.WriteLine("Recherche de 12: " + arbreBinaire6.Recherche(12));
            Console.WriteLine("Recherche de 4: " + arbreBinaire6.Recherche(4));
            Console.WriteLine("Recherche de 13: " + arbreBinaire6.Recherche(13));
            Console.WriteLine("Recherche de 100: " + arbreBinaire6.Recherche(100));
            Console.WriteLine("Recherche de 6: " + arbreBinaire6.Recherche(6));
            Console.WriteLine("Recherche de 0: " + arbreBinaire6.Recherche(0));*/

            Noeud noeud = arbreBinaire6.racine?.Recherche(0);

            /*Console.WriteLine(arbreBinaire6);
            arbreBinaire6.Supprimer(noeud.valeur);
            Console.WriteLine(arbreBinaire6);*/

            Console.WriteLine("\nAVANT : ");
            Console.WriteLine(arbreBinaire6);

            arbreBinaire6.Equilibrer(noeud);

            Console.WriteLine("\nAPRES : ");
            Console.WriteLine(arbreBinaire6);

            ArbreBinaire arbreBinaire = new ArbreBinaire();

            /*arbreBinaire.Supprimer(8);
            Console.WriteLine(arbreBinaire);
            arbreBinaire.Supprimer(1);
            Console.WriteLine(arbreBinaire);*/

            noeud = arbreBinaire.racine?.Recherche(0);

            Console.WriteLine("\n--------------------------------\n");

            arbreBinaire.Ajout(10);
            arbreBinaire.Ajout(11);
            arbreBinaire.Ajout(12);
            arbreBinaire.Ajout(1);
            arbreBinaire.Ajout(-1);
            arbreBinaire.Ajout(-2);
            arbreBinaire.Ajout(4);
            arbreBinaire.Ajout(5);
            arbreBinaire.Ajout(6);
            arbreBinaire.Ajout(15);
            arbreBinaire.Ajout(13);

            Console.WriteLine("\nAVANT : ");
            Console.WriteLine(arbreBinaire);

            noeud = arbreBinaire.racine?.Recherche(6);
            arbreBinaire.Equilibrer(noeud);

            Console.WriteLine("\nAPRES : ");
            Console.WriteLine(arbreBinaire);

            Console.WriteLine("\n--------------------------------\n");
            ArbreBinaire arbreBinaire2 = new ArbreBinaire();

            arbreBinaire2.Ajout(2);
            arbreBinaire2.Ajout(1);
            arbreBinaire2.Ajout(4);
            arbreBinaire2.Ajout(3);
            arbreBinaire2.Ajout(7);
            arbreBinaire2.Ajout(5);
            arbreBinaire2.Ajout(8);

            Console.WriteLine("\nAVANT : ");
            Console.WriteLine(arbreBinaire2);

            noeud = arbreBinaire2.racine?.Recherche(8);
            arbreBinaire2.Equilibrer(noeud);

            Console.WriteLine("\nAPRES : ");
            Console.WriteLine(arbreBinaire2);

            Console.WriteLine("\n--------------------------------\n");
            ArbreBinaire arbreBinaire3 = new ArbreBinaire();

            arbreBinaire3.Ajout(8);
            arbreBinaire3.Ajout(1);
            arbreBinaire3.Ajout(16);
            arbreBinaire3.Ajout(14);
            arbreBinaire3.Ajout(18);
            arbreBinaire3.Ajout(12);
            arbreBinaire3.Ajout(15);

            Console.WriteLine("\nAVANT : ");
            Console.WriteLine(arbreBinaire3);

            noeud = arbreBinaire3.racine?.Recherche(12);
            arbreBinaire3.Equilibrer(noeud);

            Console.WriteLine("\nAPRES : ");
            Console.WriteLine(arbreBinaire3);

            Console.WriteLine("\n--------------------------------\n");
            ArbreBinaire arbreBinaire4 = new ArbreBinaire();

            arbreBinaire4.Ajout(8);
            arbreBinaire4.Ajout(1);
            arbreBinaire4.Ajout(9);
            arbreBinaire4.Ajout(0);
            arbreBinaire4.Ajout(3);
            arbreBinaire4.Ajout(2);
            arbreBinaire4.Ajout(4);

            Console.WriteLine("\nAVANT : ");
            Console.WriteLine(arbreBinaire4);

            noeud = arbreBinaire4.racine?.Recherche(2);
            arbreBinaire4.Equilibrer(noeud);

            Console.WriteLine("\nAPRES : ");
            Console.WriteLine(arbreBinaire4);

            Console.WriteLine("\n--------------------------------\n");
            ArbreBinaire arbreBinaire5 = new ArbreBinaire();

            arbreBinaire5.Ajout(8);
            arbreBinaire5.Ajout(1);
            arbreBinaire5.Ajout(0);
            arbreBinaire5.Ajout(16);
            arbreBinaire5.Ajout(14);
            arbreBinaire5.Ajout(12);
            arbreBinaire5.Ajout(11);
            arbreBinaire5.Ajout(17);
            arbreBinaire5.Ajout(18);

            Console.WriteLine("\nAVANT : ");
            Console.WriteLine(arbreBinaire5);

            noeud = arbreBinaire5.racine?.Recherche(10);
            arbreBinaire5.Equilibrer(noeud);

            Console.WriteLine("\nAPRES : ");
            Console.WriteLine(arbreBinaire5);
        }
    }

    class ArbreBinaire
    {
        public Noeud racine = null;

        public void Ajout(int valeur)
        {
            Noeud noeud = new Noeud(valeur);
            if (racine == null)
            {
                racine = noeud;
            }
            else
            {
                Noeud current = racine;
                while (true)
                {
                    if (current.valeur > valeur)
                    {
                        if (current.elementGauche == null)
                        {
                            current.elementGauche = noeud;
                            noeud.parent = current;
                            break;
                        }
                        current = current.elementGauche;
                    } else
                    {
                        if (current.elementDroite == null)
                        {
                            current.elementDroite = noeud;
                            noeud.parent = current;
                            break;
                        }
                        current = current.elementDroite;
                    }
                }
            }
            racine.SetFacteur(racine);
            //Equilibrer(noeud);
        }

        public override string ToString()
        {
            if (racine != null)
                return racine.Prefix() + "\n" + racine.Suffix() + "\n" + racine.Infix() + "\n";
            return "";
        }

        public bool Recherche(int valeur)
        {
            return racine?.Recherche(valeur) != null;
        }

        public void Supprimer(int valeur)
        {
            Noeud noeudASupprimer = racine?.Recherche(valeur);
            if (noeudASupprimer != null)
            {
                //Suppression

                Noeud parent = noeudASupprimer.parent;
                //Cas feuille
                if (noeudASupprimer.EstUneFeuille())
                {
                    if (parent == null)
                        racine = null;
                    else if (parent.elementGauche == noeudASupprimer)
                        parent.elementGauche = null;
                    else
                        parent.elementDroite = null;
                    noeudASupprimer.parent = null;
                    racine.SetFacteur(racine);
                    /*Lancer la procédure d'équilibrage*/
                    return;
                }
                //Cas 1 seul enfant
                if (noeudASupprimer.elementGauche != null && noeudASupprimer.elementDroite == null)
                {
                    if (parent == null)
                        racine = noeudASupprimer.elementGauche;
                    else if (parent.elementGauche == noeudASupprimer)
                        parent.elementGauche = noeudASupprimer.elementGauche;
                    else
                        parent.elementDroite = noeudASupprimer.elementGauche;
                    noeudASupprimer.parent = null;
                    racine.SetFacteur(racine);
                    /*Lancer la procédure d'équilibrage*/
                    return;
                }

                if (noeudASupprimer.elementDroite != null && noeudASupprimer.elementGauche == null)
                {
                    if (parent == null)
                        racine = noeudASupprimer.elementDroite;
                    else if (parent.elementGauche == noeudASupprimer)
                        parent.elementGauche = noeudASupprimer.elementDroite;
                    else
                        parent.elementDroite = noeudASupprimer.elementDroite;
                    noeudASupprimer.parent = null;
                    racine.SetFacteur(racine);
                    /*Lancer la procédure d'équilibrage*/
                    return;
                }

                //cas 2 enfants
                //on prend l'enfant de droite
                Noeud nouvelleTete = noeudASupprimer.elementDroite;
                //on descend sur l'enfant le plus à gauche
                while (nouvelleTete.elementGauche != null)
                {
                    nouvelleTete = nouvelleTete.elementGauche;
                }
                //On raccroche les wagons

                //L'enfant de la nouvelle tete, qui serait perdu autrement, doit être raccroché au parent s'il ne
                //s'agit pas du noeud à suprimer
                if (noeudASupprimer.elementDroite != nouvelleTete)
                {
                    nouvelleTete.parent.elementGauche = nouvelleTete.elementDroite;
                    if (nouvelleTete.elementDroite != null)
                        nouvelleTete.elementDroite.parent = nouvelleTete.parent;
                }
                //on remplace le noeud à supprimer pas la nouvelle tête
                nouvelleTete.parent = noeudASupprimer.parent;
                if (parent == null)
                    racine = nouvelleTete;
                else if (parent.elementGauche == noeudASupprimer)
                    parent.elementGauche = nouvelleTete;
                else
                    parent.elementDroite = nouvelleTete;
                nouvelleTete.elementGauche = noeudASupprimer.elementGauche;
                nouvelleTete.elementDroite = noeudASupprimer.elementDroite;
                if (nouvelleTete.elementGauche != null)
                    nouvelleTete.elementGauche.parent = nouvelleTete;
                if (nouvelleTete.elementDroite != null)
                    nouvelleTete.elementDroite.parent = nouvelleTete;
                //cleanup
                noeudASupprimer.parent = null;
                noeudASupprimer.elementDroite = null;
                noeudASupprimer.elementGauche = null;

                racine.SetFacteur(racine);
                /*Lancer la procédure d'équilibrage*/
            }
        }

        public Noeud RotationGauche(Noeud racine)
        {
            Noeud pivot = racine.elementDroite;

            if (pivot != null)
            {
                if (pivot.elementGauche != null)
                    racine.elementDroite = pivot.elementGauche;
                else
                    racine.elementDroite = null; 

                pivot.elementGauche = racine;

                if (racine == this.racine)
                    this.racine = pivot;
                else
                {
                    pivot.parent = racine.parent;

                    if (pivot.parent == this.racine)
                        pivot.parent.elementGauche = pivot;
                    else pivot.parent.elementDroite = pivot;

                    pivot.elementGauche.parent = pivot;

                    if (racine.elementDroite != null)
                        racine.elementDroite.parent = racine;
                }
            }
            return pivot;
        }
        public Noeud RotationDroite(Noeud racine)
        {
            Noeud pivot = racine.elementGauche;

            if (pivot != null)
            {
                if (pivot.elementDroite != null)
                    racine.elementGauche = pivot.elementDroite;
                else
                    racine.elementGauche = null;

                pivot.elementDroite = racine;

                if (racine == this.racine)
                    this.racine = pivot;
                else
                {
                    pivot.parent = racine.parent;

                    if (pivot.parent == this.racine)
                        pivot.parent.elementDroite = pivot;
                    else pivot.parent.elementGauche = pivot;

                    if (pivot != null)
                        pivot.elementDroite.parent = pivot;

                    if (racine.elementGauche != null)
                        racine.elementGauche.parent = racine;
                }
            }
            return pivot;
        }

        public void Equilibrer(Noeud noeud)
        {
            if (noeud == null)
                return;

            Noeud current = noeud;
            Noeud racine = null; 

            while (current.parent != null)
            {
                if (!current.parent.isBalanced())
                {
                    racine = current.parent;
                    break;
                }
                current = current.parent;
            }

            if (racine == null)
                return;

            if (racine.elementGauche != null)
            {
                if (racine.facteur < -1 && noeud.valeur < racine.elementGauche.valeur)
                {
                    RotationDroite(racine);

                    this.racine.SetFacteur(this.racine);
                }

                else if (racine.facteur < -1 && noeud.valeur > racine.elementGauche.valeur)
                {
                    racine.elementGauche = RotationGauche(racine.elementGauche);

                    this.racine.SetFacteur(this.racine);

                    RotationDroite(racine);

                    this.racine.SetFacteur(this.racine);

                    return;
                }
            }

            if (racine.elementDroite != null)
            {
                if (racine.facteur > 1 && noeud.valeur > racine.elementDroite.valeur)
                {
                    RotationGauche(racine);

                    this.racine.SetFacteur(this.racine);
                }
                else if (racine.facteur > 1 && noeud.valeur < racine.elementDroite.valeur)
                {
                    racine.elementDroite = RotationDroite(racine.elementDroite);

                    this.racine.SetFacteur(this.racine);

                    RotationGauche(racine);

                    this.racine.SetFacteur(this.racine);
                }
            }
        }
}

    class Noeud
    {
        public Noeud parent;

        public Noeud elementGauche;
        public Noeud elementDroite;

        public int valeur;
        public int facteur;

        public Noeud(int valeur)
        {
            this.elementGauche = null;
            this.elementDroite = null;
            this.parent = null;
            this.valeur = valeur;
        }

        public bool EstUneFeuille()
        {
            return elementDroite == null && elementGauche == null;
        }
        public string Prefix()
        {
            string ret = valeur.ToString() + " - ";
            ret += elementGauche?.Prefix()??"";
            if(elementDroite != null)
                ret += elementDroite.Prefix();
            return ret;
        }

        public string Suffix()
        {
            string ret = "";
            ret += elementGauche?.Suffix() ?? "";
            if (elementDroite != null)
                ret += elementDroite.Suffix();
            ret += valeur.ToString() + " - ";
            return ret;
        }
        public string Infix()
        {
            string ret = "";
            ret += elementGauche?.Infix() ?? "";
            ret += valeur.ToString() + " - ";
            if (elementDroite != null)
                ret += elementDroite.Infix();
            return ret;
        }

        public Noeud Recherche(int valeur)
        {
            if (this.valeur == valeur)
                return this;

            if (this.valeur > valeur)
            {
                return elementGauche?.Recherche(valeur);
            }
            else
            {
                return elementDroite?.Recherche(valeur);
            }
        }

        public int SetFacteur(Noeud noeud)
        {
            if (noeud == null)
                return 0;
            else
            {
                int PGauche = SetFacteur(noeud.elementGauche);
                int PDroite = SetFacteur(noeud.elementDroite);

                noeud.facteur = PDroite - PGauche;

                if (PGauche > PDroite)
                    return (PGauche + 1);
                else
                    return (PDroite + 1);
            }
        }

        public bool isBalanced()
        {
            if (facteur >= 2 || facteur <= -2)
                return false;
            return true;
        }
    }
}
