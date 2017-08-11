using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleWarGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            a = new Sword();
            b = new Arrow();
        }
        private Warrior a;
        private Warrior b;
        private void Form1_Load(object sender, EventArgs e)
        {
            a.setValue(0);
            b.setValue(100);
        }
        private void show(ref Warrior obj1,ref Warrior obj2)
        {
            label1.Text = "HP = "+ obj1.getHP().ToString();
            label2.Text = "Power = " + obj1.getPower().ToString();
            label3.Text = "Speed  = " + obj1.getSpeed().ToString();
            label4.Text = "Value = " + obj1.getValue().ToString();
            label5.Text = "HP = " + obj2.getHP().ToString();
            label6.Text = "Power = " + obj2.getPower().ToString();
            label7.Text = "Speed  = " + obj2.getSpeed().ToString();
            label8.Text = "Value = " + obj2.getValue().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.moveTo(a);
            b.attack(a);
            a.moveTo(b);
            a.attack(b);
            show(ref a,ref b);
        }
    }
}
