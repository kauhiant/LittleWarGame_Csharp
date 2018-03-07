using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace LittleWarGame
{
    public enum Status { move, attack }
    public enum Warrior_Type { attacker, shielder, helper }
    public enum WarriorList { Castle, Sword, Arrow, Shield, Hatchet, Rocket, Wall, Rescue }
    public enum Data { hp, speed, power, distance }

    static class Const
    {
        static private int indexOf(WarriorList warrior)
        {
            return (int)warrior - 1;
        }

        static public GameTime gameTime = new GameTime();
        static public List<List<List<Image>>> imageList;
        static public Image background;
        static public Image mask;
        static public Image select;
        static public Icon icon;

        static public int pictureWidth = 50;
        static public int mainLineHeight = 100;
        static public int HPBarHeight = 150;

        static public int warriorHeight = 50;
        static public int castleHeight = 100;

        static public int AStartPoint = 100;
        static public int BStartPoint = 600;

        
        static public int[] WarriorEnergy = { 10, 15, 20, 30, 50, 50, 25 };
        static public int EnergyOf(WarriorList index)
        {
            return WarriorEnergy[(int)(index)-1];
        }

        static public class Part
        {
            static public int A = 0;
            static public int B = 1;
        }

        static public class Sound
        {
            static private SoundPlayer _click;
            static private SoundPlayer _attack;

            static public void SoundInit()
            {
                try
                {
                    Sound._click = new SoundPlayer(@"./audio/click.wav");
                    Sound._attack = new SoundPlayer(@"./audio/attack.wav");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "音效資源錯誤");
                }
            }
        }
        
        
        

        static public void ImageListInit()
        {
            int sizeOfWarriors = 8;

            imageList = new List<List<List<Image>>>();
            for (int c = 0; c < sizeOfWarriors; ++c)
            {
                imageList.Add(new List<List<Image>>());
                for (int i = 0; i < 2; ++i)
                {
                    imageList[c].Add(new List<Image>());
                }
            }


            try
            {
                background = Image.FromFile(@"./img/battleField.png");
                mask = Image.FromFile(@"./img/mask.png");
                select = Image.FromFile(@"./img/Select.png");
                icon = Icon.ExtractAssociatedIcon(@"./img/LittleWar.ico");

                imageList[(int)WarriorList.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L.png"));
                imageList[(int)WarriorList.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L1.png"));
                imageList[(int)WarriorList.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L2.png"));
                imageList[(int)WarriorList.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L3.png"));
                imageList[(int)WarriorList.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L4.png"));

                imageList[(int)WarriorList.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R.png"));
                imageList[(int)WarriorList.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R1.png"));
                imageList[(int)WarriorList.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R2.png"));
                imageList[(int)WarriorList.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R3.png"));
                imageList[(int)WarriorList.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R4.png"));


                imageList[(int)WarriorList.Sword][Part.A].Add(Image.FromFile(@"./img/Sword-L0.png"));
                imageList[(int)WarriorList.Sword][Part.A].Add(Image.FromFile(@"./img/Sword-L1.png"));
                imageList[(int)WarriorList.Sword][Part.B].Add(Image.FromFile(@"./img/Sword-R0.png"));
                imageList[(int)WarriorList.Sword][Part.B].Add(Image.FromFile(@"./img/Sword-R1.png"));

                imageList[(int)WarriorList.Arrow][Part.A].Add(Image.FromFile(@"./img/Arrow-L0.png"));
                imageList[(int)WarriorList.Arrow][Part.A].Add(Image.FromFile(@"./img/Arrow-L1.png"));
                imageList[(int)WarriorList.Arrow][Part.B].Add(Image.FromFile(@"./img/Arrow-R0.png"));
                imageList[(int)WarriorList.Arrow][Part.B].Add(Image.FromFile(@"./img/Arrow-R1.png"));

                imageList[(int)WarriorList.Shield][Part.A].Add(Image.FromFile(@"./img/Shield-L.png"));
                imageList[(int)WarriorList.Shield][Part.A].Add(null);
                imageList[(int)WarriorList.Shield][Part.B].Add(Image.FromFile(@"./img/Shield-R.png"));
                imageList[(int)WarriorList.Shield][Part.B].Add(null);

                imageList[(int)WarriorList.Rocket][Part.A].Add(Image.FromFile(@"./img/Rocket-L.png"));
                imageList[(int)WarriorList.Rocket][Part.A].Add(null);
                imageList[(int)WarriorList.Rocket][Part.B].Add(Image.FromFile(@"./img/Rocket-R.png"));
                imageList[(int)WarriorList.Rocket][Part.B].Add(null);

                imageList[(int)WarriorList.Wall][Part.A].Add(Image.FromFile(@"./img/Wall-L.png"));
                imageList[(int)WarriorList.Wall][Part.A].Add(null);
                imageList[(int)WarriorList.Wall][Part.B].Add(Image.FromFile(@"./img/Wall-R.png"));
                imageList[(int)WarriorList.Wall][Part.B].Add(null);

                imageList[(int)WarriorList.Hatchet][Part.A].Add(Image.FromFile(@"./img/Hatchet-L0.png"));
                imageList[(int)WarriorList.Hatchet][Part.A].Add(Image.FromFile(@"./img/Hatchet-L1.png"));
                imageList[(int)WarriorList.Hatchet][Part.B].Add(Image.FromFile(@"./img/Hatchet-R0.png"));
                imageList[(int)WarriorList.Hatchet][Part.B].Add(Image.FromFile(@"./img/Hatchet-R1.png"));

                imageList[(int)WarriorList.Rescue][Part.A].Add(Image.FromFile(@"./img/Rescue.png"));
                imageList[(int)WarriorList.Rescue][Part.A].Add(null);
                imageList[(int)WarriorList.Rescue][Part.B].Add(Image.FromFile(@"./img/Rescue.png"));
                imageList[(int)WarriorList.Rescue][Part.B].Add(null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),"圖片資源錯誤");
            }
        }

        static public List<WarriorData> InitData;
        static public List<WarriorData> UpRefDat;
        static public void WarriorDataInitial()
        {
            InitData = new List<WarriorData>();
            InitData.Add(new WarriorData(100, 3, 10, 0));
            InitData.Add(new WarriorData(50, 1, 10, 80));
            InitData.Add(new WarriorData(500, 1, 5, 0));
            InitData.Add(new WarriorData(150, 2, 30, 0));
            InitData.Add(new WarriorData(500, 50, 500, 50));
            InitData.Add(new WarriorData(1000, 2, 0, 100));
            InitData.Add(new WarriorData(100, 3, 20, 50));

            UpRefDat = new List<WarriorData>();
            UpRefDat.Add(new WarriorData(10, 2, 2, 0));
            UpRefDat.Add(new WarriorData(5, 1, 3, 5));
            UpRefDat.Add(new WarriorData(50, 1, 3, 0));
            UpRefDat.Add(new WarriorData(10, 1, 5, 0));
            UpRefDat.Add(new WarriorData(50, 5, 100, 10));
            UpRefDat.Add(new WarriorData(250, 1, 0, 10));
            UpRefDat.Add(new WarriorData(10, 1, 10, 10));
        }
    }
}
