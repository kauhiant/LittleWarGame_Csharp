using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LittleWarGame
{
    class myPictureBox
    {
        
        public System.Drawing.Point location;
        private Image img;

        public myPictureBox()
        {
            location = new System.Drawing.Point();
        }

        public Image Image
        {
            get { return this.img; }
            set { this.img = value; }
        }

        public void locateToRight()
        {
            location.X -= Const.pictureWidth;
        }

        public int Top { set { location.Y = value; } }
        public int Bottom { set { location.Y = value - Image.Height; } }
        public int Left { set { location.X = value; } }
        public int Right { set { location.X = value - Image.Width; } }
    }
}
