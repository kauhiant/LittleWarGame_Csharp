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
    public partial class FirstStepPassForm : Form
    {
        public FirstStepPassForm(bool about = false)
        {
            InitializeComponent();
            if (about)
            {
                label1.Text = "如果有任何問題請寫信或在FB通知我" + Environment.NewLine
                    + "kauhia3440@gmail.com" + Environment.NewLine
                    + "FB:黃靖硯(雲科大資工系)" + Environment.NewLine
                    +"感謝支持^_^)";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Icon = Const.icon;
        }
    }
}
