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
    public partial class ControlForm : Form
    {
        public class ItemPair
        {
            public enum key { hp ,speed ,power ,distance}
            public key item;
            public string title;
            public Label text;
            public Button add;
            public ItemPair(key item)
            {
                this.item = item;
                switch (item)
                {
                    case key.hp:
                        this.title = "生命:";
                        break;
                    case key.speed:
                        this.title = "速度:";
                        break;
                    case key.power:
                        this.title = "力量:";
                        break;
                    case key.distance:
                        this.title = "範圍:";
                        break;
                }
            }
            public void bind(Label text, Button add)
            {
                this.text = text;
                this.add = add;
            }
        }
        public class WarriorPanel : Panel
        {
            public WarriorList warrior;
            public PictureBox show;
            public ItemPair hp;
            public ItemPair speed;
            public ItemPair power;
            public ItemPair distance;
            public WarriorPanel(PictureBox show,WarriorList warrior)
            {
                this.show = show;
                this.warrior = warrior;
                this.hp = new ItemPair(ItemPair.key.hp);
                this.speed = new ItemPair(ItemPair.key.speed);
                this.power = new ItemPair(ItemPair.key.power);
                this.distance = new ItemPair(ItemPair.key.distance);
            }

            public void update()
            {
                this.hp.text.Text = this.hp.title + Program.playerData[(int)warrior - 1].hp.ToString();
                this.speed.text.Text = this.speed.title + Program.playerData[(int)warrior - 1].speed.ToString();
                this.power.text.Text = this.power.title + Program.playerData[(int)warrior - 1].power.ToString();
                this.distance.text.Text = this.distance.title + Program.playerData[(int)warrior - 1].distance.ToString();
            }
        }
        private WarriorList findWarriorFromItem(ItemPair obj)
        {
            foreach(WarriorPanel each in warriorsPanels)
            {
                if (each.hp == obj) return each.warrior;
                if (each.speed == obj) return each.warrior;
                if (each.power == obj) return each.warrior;
                if (each.distance == obj) return each.warrior;
            }
            return WarriorList.Castle;
        }
        private ItemPair findButtonIndex(Button obj)
        {
            foreach(WarriorPanel each in warriorsPanels)
            {
                if (each.hp.add == obj) return each.hp;
                if (each.speed.add == obj) return each.speed;
                if (each.power.add == obj) return each.power;
                if (each.distance.add == obj) return each.distance;
            }
            return null;
        }

        private Queue<string> message;
        private List<WarriorPanel> warriorsPanels;
        public ControlForm()
        {
            InitializeComponent();
            this.message = new Queue<string>();
            warriorsPanels = new List<WarriorPanel>();

            warriorsPanels.Add(new WarriorPanel(_warrior1, WarriorList.Sword));
            warriorsPanels.Add(new WarriorPanel(_warrior2, WarriorList.Arrow));
            warriorsPanels.Add(new WarriorPanel(_warrior3, WarriorList.Shield));
            warriorsPanels.Add(new WarriorPanel(_warrior4, WarriorList.Hatchet));
            warriorsPanels.Add(new WarriorPanel(_warrior5, WarriorList.Rocket));
            warriorsPanels.Add(new WarriorPanel(_warrior6, WarriorList.Wall));
            warriorsPanels.Add(new WarriorPanel(_warrior7, WarriorList.Rescue));

            warriorsPanels[0].hp.bind(label111,button111);
            warriorsPanels[0].speed.bind(label121, button121);
            warriorsPanels[0].power.bind(label131, button131);
            warriorsPanels[0].distance.bind(label141, button141);

            warriorsPanels[1].hp.bind(label211, button211);
            warriorsPanels[1].speed.bind(label221, button221);
            warriorsPanels[1].power.bind(label231, button231);
            warriorsPanels[1].distance.bind(label241, button241);

            warriorsPanels[2].hp.bind(label311, button311);
            warriorsPanels[2].speed.bind(label321, button321);
            warriorsPanels[2].power.bind(label331, button331);
            warriorsPanels[2].distance.bind(label341, button341);

            warriorsPanels[3].hp.bind(label411, button411);
            warriorsPanels[3].speed.bind(label421, button421);
            warriorsPanels[3].power.bind(label431, button431);
            warriorsPanels[3].distance.bind(label441, button441);

            warriorsPanels[4].hp.bind(label511, button511);
            warriorsPanels[4].speed.bind(label521, button521);
            warriorsPanels[4].power.bind(label531, button531);
            warriorsPanels[4].distance.bind(label541, button541);

            warriorsPanels[5].hp.bind(label611, button611);
            warriorsPanels[5].speed.bind(label621, button621);
            warriorsPanels[5].power.bind(label631, button631);
            warriorsPanels[5].distance.bind(label641, button641);

            warriorsPanels[6].hp.bind(label711, button711);
            warriorsPanels[6].speed.bind(label721, button721);
            warriorsPanels[6].power.bind(label731, button731);
            warriorsPanels[6].distance.bind(label741, button741);

            for (int i = 0; i < 7; i++)
            {
                warriorsPanels[i].show.Image = Const.imageList[i + 1][0][0];
            }

            _selectLevel.Text = "Level " + (Program.player.level + 1);
        }
        
        public void updata()
        {
            for (int i = 0; i < 7; i++)
            {
                warriorsPanels[i].update();
            }
            _coin.Text = "Coin:" + Program.player.coin;
            _superRocket.Text = "求救次數:" + Program.player.superRocket;
            this.Text = "小小戰爭 Level " + Program.player.level;
            _message.Text = "";
            _selectLevel.Text = "Level " + (Program.player.level + 1);
            message.Clear();
        }

        private void showMessage()
        {
            _message.Text = "";
            if (message.Count > 5)
            {
                for(int i =message.Count - 5; i > 0; i--)
                {
                    message.Dequeue();
                }
            }

            for (int i = 0; i < message.Count; ++i)
            {
                _message.Text += message.ElementAt(i) + Environment.NewLine;
            }

        }

        private void change(object sender, EventArgs e)
        {
            Button tmp = sender as Button;
            ItemPair obj = findButtonIndex(tmp);
            WarriorList warr = findWarriorFromItem(obj);
            int errValue = 0;

            switch (obj.item)
            {
                case ItemPair.key.hp:
                    errValue = Program.player.UpHp(warr);
                    break;
                case ItemPair.key.speed:
                    errValue = Program.player.UpSpeed(warr);
                    break;
                case ItemPair.key.power:
                    errValue = Program.player.UpPower(warr);
                    break;
                case ItemPair.key.distance:
                    errValue = Program.player.UpDistance(warr);
                    break;
            }

            if(errValue > 0)
            {
                _coin.Text = "Coin:" + Program.player.coin;
                warriorsPanels[(int)warr - 1].update();
              //  message
                message.Enqueue("消耗了 "+errValue+" Coin");
            }
            else if(errValue < 0)
            {
                message.Enqueue("你的錢不夠，需要"+(-errValue).ToString()+"Coin");
            }
            else
            {
                message.Enqueue("這項不能升級");
            }
            showMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.player.level >= level - 1)
            {
                Program.AI.set(Program.AIData, level);
                BattleForm tmp = new BattleForm(level);
                this.Hide();
                tmp.Show();
            }
            else
            {
                message.Enqueue("你的等級不夠");
            }
            showMessage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.player.saveToFile(@"./log/P0.txt");
        }

        private void _buySR_Click(object sender, EventArgs e)
        {
            if (Program.player.buySuperRocket())
            {
                _superRocket.Text = "求救次數:"+Program.player.superRocket;
                _coin.Text = "Coin:" + Program.player.coin;
                message.Enqueue("消耗了 500 Coin");
            }
            else
            {
                message.Enqueue ("你的錢不夠，需要500Coin");
            }
            showMessage();
        }
        private int level;
        private void _selectLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string levelstr = _selectLevel.Text;
            levelstr = levelstr.Split(' ').ElementAt(1);
            level = int.Parse(levelstr);
        }
    }
}
