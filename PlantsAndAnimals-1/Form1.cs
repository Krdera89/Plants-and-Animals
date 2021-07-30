using PlantsAndAnimals.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantsAndAnimals
{
    public partial class Form1 : Form
    {
        public Random r = new Random();
        public List<Item> items = new List<Item>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //NewItem
        {
            if (items.Count < 20)
            {
                PictureBox newItem = new PictureBox();
                Item i;
                if (r.Next() % 2 == 1)
                {
                    i = new Plant(new Point(r.Next(0, 875), r.Next(25, 500)), newItem, items);
                }
                else
                {
                    i = new Lion(new Point(r.Next(0, 875), r.Next(25, 500)), newItem, items);
                }

                newItem.Image = i.image;
                newItem.Location = i.position;
                newItem.Size = new Size(100, 100);
                items.Add(i);
                this.Controls.Add(newItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)//Step
        {
            foreach (Item i in items)
            {
                i.Turn();
            }
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].IsDead())
                {
                    this.Controls.Remove((PictureBox)items[i].UIControl);
                    items.Remove(items[i]);
                }
                else if (items[i].reporoduce)
                {
                    if (items[i].GetType() == typeof(Plant))
                    {
                        PictureBox newPic = new PictureBox();
                        Item newItem = new Plant(new Point(r.Next(0, 875), r.Next(25, 500)), newPic, items);
                        newPic.Image = newItem.image;
                        newPic.Location = newItem.position;
                        newPic.Size = new Size(100, 100);
                        items.Add(newItem);
                        this.Controls.Add(newPic);

                        newItem.Health = items[i].Health / 2;
                        items[i].Health /= 2;
                        items[i].reporoduce = false;
                    }

        
                }
            }
        }
    }
}
