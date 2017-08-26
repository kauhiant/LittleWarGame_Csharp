using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class ValueBar
    {
        private int maxValue;
        private int value;
        private System.Windows.Forms.PictureBox bar;

        public ValueBar(int maxValue , int value)
        {
            if (value > maxValue) value = maxValue;

            this.maxValue = maxValue;
            this.value = value;

            this.bar = new System.Windows.Forms.PictureBox();
            this.bar.BackColor = Color.Green;
            this.bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bar.Height = 10;
            this.bar.Width = Const.pictureWidth;

            this.bar.Top = Const.mainLineHeight;
        }
        public int getValue()   {   return value;   }
        public System.Windows.Forms.PictureBox getBarPictureBox() { return bar; }

        public bool isZero() { return value == 0; }
        public void setTop(int val) {   this.bar.Top = val; }
        public void fixPositionLeft(int val) {   this.bar.Left = val;  }
        public void reset() { value = 0; }

        public void addValue(int val)
        {
            this.value += val;

            if (this.value > this.maxValue)
                this.value = this.maxValue;
            else if (this.value < 0)
                this.value = 0;

            double tmpValue = this.value;
            double tmpMax = this.maxValue;
            bar.Width =Convert.ToInt32( Convert.ToDouble(Const.pictureWidth) * (tmpValue / tmpMax));
        }
    }
}
