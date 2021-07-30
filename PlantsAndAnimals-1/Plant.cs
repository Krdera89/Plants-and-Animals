using PlantsAndAnimals.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsAndAnimals
{
    public class Plant:Item
    {
        
        public Plant() { Eaten = false; }
        public Plant(Point start, object obj, List<Item> par)
        {
            position = start;
            UIControl = obj;
            image = Resources.Plant;
            Parent = par;
            MaxHealth = 50;
        }
        public override void Turn()
        {
            Health++;
            if(Health > MaxHealth)
            {
                reporoduce = true;
            }

        }
        public override bool IsDead()
        {
            return Eaten;
        }
    }
}
