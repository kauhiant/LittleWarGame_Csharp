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
        private BattleLine mainLine;

        public Form1()
        {
            InitializeComponent();
            mainLine = new BattleLine(1,1,this);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void show(ref Warrior obj1,ref Warrior obj2)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainLine.nextStep();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainLine.AFieldPushWarrior(new Sword());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainLine.BFieldPushWarrior(new Arrow());
        }
    }
}
