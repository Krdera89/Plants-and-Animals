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
    public class Lion:Animal
    {
        public Lion() { image = Resources.Lion; }
       
        public Lion(Point start, object obj, List<Item> par) : base(start)
        {


            UIControl = obj;
            image = Resources.Lion;
            Parent = par;
            Health = 200;
            MaxHealth = 400;
            PlantEater = false;
        }

        public override void Turn()
        {
            Item closestFood = null;
            foreach (Item i in Parent)
            {
                if (i.GetType() == typeof(Plant))
                {
                    if (closestFood == null) { closestFood = i; }
                    else
                    {
                        if (Distance(i) < Distance(closestFood))
                        {
                            closestFood = i;
                        }
                        if (Health >= 200)
                        {
                            reporoduce = true;
                            
                        }
                    }
                }
            }
            if (closestFood != null) //move towards closest food
            {
                int x = position.X, y = position.Y;
                if (closestFood.position.X < position.X)
                {
                    x -= Min(GetStepSize() / 2, position.X - closestFood.position.X);
                }
                else
                {
                    x += Min(GetStepSize() / 2, closestFood.position.X - position.X);
                }
                if (closestFood.position.Y < position.Y)
                {
                    y -= Min(GetStepSize() / 2, position.Y - closestFood.position.Y);
                }
                else
                {
                    y += Min(GetStepSize() / 2, closestFood.position.Y - position.Y);
                }
                SetPostion(x, y);
                PictureBox pb = (PictureBox)UIControl;
                pb.Location = position;
            }
            if (closestFood != null && closestFood.position == position) //Eat
            {

               Eat(closestFood);

                reporoduce = true;
                Reproduce();
            }
            else
            {
                Health--;
            }
        }

        public void Reproduce()
        {
            if(Health >= 50)
            {
                reporoduce = true;

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

        public int Min(int a, int b)
        {
            if (a < b) return a;
            return b; }
           
        }
    
    }

