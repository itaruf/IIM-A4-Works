namespace Grokaboom
{
    //petite classe cercle pour centraliser les fonctions et simplifier l'écriture
    public class Circle
    {
        double centerX;
        double centerY;

        //opti pour les calculs
        double sqrRadius;

        public Circle(double centerX, double centerY, double radius)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.sqrRadius = radius * radius;
        }

        public bool IsInside(double positionX, double positionY)
        {
            //pythagore va nous donner la distance centre du cercle point, on aura juste à comparer
            //avec le rayon
            //opti: on compare les carrés pour pas avoir besoin de sqrt
            double sqrDistance = (positionX - centerX) * (positionX - centerX) + (positionY - centerY) * (positionY - centerY);
            return sqrDistance <= sqrRadius;
        }

        public bool IsInside(Unit unit)
        {
            return IsInside(unit.posX, unit.posY);
        }

    }
}
