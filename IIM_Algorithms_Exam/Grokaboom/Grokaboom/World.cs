using System;
using System.Collections.Generic;

/* https://en.wikipedia.org/wiki/Quadtree */

namespace Grokaboom
{
    public class World
    {
        private List<Unit> units = new List<Unit>();
        private const int MAX_UNITS = 2500;
        private const double MAP_SIZE = 1000.0f;
        private const int MAX_DAMAGE = 20;
        private const int MAX_BOMB_RADIUS = 150;

        private QuadTree quadTree = new QuadTree();

        public World()
        {
        }

        public class QuadTree 
        {
            public const int capacite = 4;

            public List<Unit> units;

            public QuadTree nW;
            public QuadTree nE;
            public QuadTree sW;
            public QuadTree sE;

            void Ajout(Unit unit)
            {

            }
        }

        public void Initialize()
        {
            Random random = new Random();
            units.Clear();

            for (int i = 0; i < MAX_UNITS; ++i)
            {
                Unit unit = new Unit(random.NextDouble() * MAP_SIZE, random.NextDouble() * MAP_SIZE);
                units.Add(unit);
            }
        }

        public void Grokaboooom()
        {
            //Generate a new random explosion
            Random random = new Random();
            double positionX = random.NextDouble() * MAP_SIZE;
            double positionY = random.NextDouble() * MAP_SIZE;
            double bombRadius = random.NextDouble() * MAX_BOMB_RADIUS;
            int damage = 1 + random.Next(MAX_DAMAGE);

            Circle circle = new Circle(positionX, positionY, bombRadius);

            int nbDamagedUnits = 0;
            int nbDeadUnits = 0;
            for(int i = 0; i < units.Count;)
            {
                Unit unit = units[i];
                //Check if unit is within explosion radius 
                if(circle.IsInside(unit))
                {
                    unit.InflictDamage(damage);
                    ++nbDamagedUnits;
                }
                //Remove unit if dead, otherewise increment counter to next unit
                if (unit.IsDead())
                {
                    units.Remove(unit);
                    ++nbDeadUnits;
                }
                else
                {
                    ++i;
                }
            }
            Console.WriteLine("Explosion at {0:0.00} - {1:0.00} inflicing {2} damages within a radius of {3:0.00}: {4} units damaged, {5} killed ({6} remains).",
                  positionX, positionY, damage, bombRadius, nbDamagedUnits, nbDeadUnits, units.Count);
        }
    }
}
