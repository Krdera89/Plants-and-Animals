using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsAndAnimals
{
    public abstract class Item
    {
        public Point position;
        public Image image;
        public object UIControl;
        public List<Item> Parent;
        public bool Eaten = false;
        public int Health = 25;
        public int MaxHealth = 25;
        public bool reporoduce = false;
        public Item() { }


        public abstract void Turn();
        public virtual bool IsDead() { 
            return true; 
        }
        public double Distance(Item i)
        {
            double x = i.position.X - position.X;
            double y = i.position.Y - position.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
    }
}
