using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class EnergyBar
    {
        private System.Windows.Forms.TextBox bar;
        private int value;

        public EnergyBar(int value = 0)
        {
            bar = new System.Windows.Forms.TextBox();
            this.value = value;
            bar.Text = this.value.ToString();
            bar.BackColor = Color.Green;
            bar.Width = this.value * 10;
        }
        public void addEnergy(int value)
        {
            this.value += value;
            if (this.value < 0) this.value = 0;
            else if(this.value > 100) this.value = 100;
            bar.Text = this.value.ToString();
            bar.Width = this.value * 2;
        }
        public int getValue()
        {
            return value;
        }
        public void setLabel(ref System.Windows.Forms.TextBox target)
        {
            this.bar = target;
        }
    }
}
