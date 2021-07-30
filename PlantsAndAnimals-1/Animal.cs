using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsAndAnimals
{
    public abstract class Animal:Item
    {
        public bool PlantEater = true;
        private const int StepSize = 4000;
        public Animal(Point start) {

            position = start;
        }

        public Animal() { }

        public int GetStepSize()
        {
            if (Health == 0) return 0;
            return StepSize / Health;
        }

        public override bool IsDead()
        {
            if (Health <= 0) //starved
            {
                return true;
            }
            return Eaten;
        }
        public void LockAttack(Item victim)
        {
            if (position.X == victim.position.X && position.Y == victim.position.Y)
            {
                int damage = (Health / 2) + 1;
                if (victim.Health < damage) //victim died
                { 
                    victim.Health = 0;
                victim.reporoduce = false;
            }
            
            else
                {
                    victim.Health -= damage;
                }

            }
        }
        public void Eat(Item food)
        {
            if (position.X == food.position.X && position.Y == food.position.Y)
            {
                int damage = Min(Health + 1, MaxHealth - Health);
                if (food.Health < damage) //victim died
                {
                    Health += food.Health;
                    food.Health = 0;
                    food.reporoduce = false;
                    food.Eaten = true;
                }
                else
                {
                    food.Health -= damage;
                    Health += damage;
                }
            }
        }
        public void SetPostion(int x, int y)
        {
            //check to see if the move is larger than allowed.  If so, don't move.
            int DelX, DelY;
            DelX = position.X - x;
            DelY = position.Y - y;
            double change = Math.Sqrt((DelX * DelX + DelY * DelY));
            if (change <= GetStepSize())
            {
                position.X = x;
                position.Y = y;
            }
        }
             int Min(int a, int b)
            {
                if (a < b) return a;
                return b;
            }
        }
    
}

    

