using System;
namespace Grokaboom
{
    public class Unit
    {
        public double posX { get; private set; }
        public double posY { get; private set; }
        public int pv { get; private set; }

        public Unit()
        {
            this.posX = 0.0f;
            this.posX = 0.0f;
            this.pv = 10;
        }

        public Unit(double x, double y)
        {
            this.posX = x;
            this.posY = y;
            this.pv = 10;
        }

        public bool IsDead()
        {
            return pv <= 0;
        }

        public void InflictDamage(int damage)
        {
            this.pv -= damage;
        }
    }
}
