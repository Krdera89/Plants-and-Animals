using PlantsAndAnimals.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantsAndAnimals
{
    public class Bunny:Animal
    {
        
        public Bunny() { }
        public Bunny(Point start, object obj, List<Item> par):base(start)
        {

            
            UIControl = obj;
            image = Resources.Bunny;
            Parent = par;
            Health = 50;
            MaxHealth = 50;
        }

        public override void Turn()
        {
            Item closestFood = null;
            foreach(Item i in Parent)
            {
                if(i.GetType() == typeof(Plant))
                {
                    if(closestFood == null) { closestFood = i; }
                    else
                    {
                        if(Distance(i) < Distance(closestFood))
                        {
                            closestFood = i;
                        }
                    }
                }
            }
            if(closestFood != null) //move towards closest food
            {
                int x = position.X, y = position.Y;
                if(closestFood.position.X < position.X)
                {
                    x -= Min(GetStepSize(), position.X - closestFood.position.X);
                }
                else
                {
                    x += Min(GetStepSize(), closestFood.position.X - position.X);
                }
                if (closestFood.position.Y < position.Y)
                {
                    y -= Min(GetStepSize(), position.Y - closestFood.position.Y);
                }
                else
                {
                    y += Min(GetStepSize(), closestFood.position.Y - position.Y);
                }
                SetPostion(x, y);
                PictureBox pb = (PictureBox)UIControl;
                pb.Location = position;
            }
            if(closestFood != null && closestFood.position == position) //Eat
            { 
                int toEat = MaxHealth - Health; //Want to eat maximum
                toEat = Min(toEat, closestFood.Health); //Amount we can eat
                Health+=toEat;
                closestFood.Health -= toEat;
                closestFood.Eaten = true;
            }
            else
            {
                Health--;
            }
        }


        public override bool IsDead()
        {
            if (Health <= 0) //starved
            {
                return true;
            }
            return Eaten;
        }

        int Min(int a, int b)
        {
            if(a < b) return a;
            return b;
        }
    }
}
