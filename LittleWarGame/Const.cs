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
    static class Const
    {
        static public class WarriorType
        {
            public const char attacker = 'A';
            public const char shielder = 'B';
            public const char helper = 'C';
        }

        static public class Sound
        {
            static public SoundPlayer _click;
            static public SoundPlayer _attack;
        }
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
        static public class Warrior
        {
            static public int Castle = 0;
            static public int Sword = 1;
            static public int Arrow = 2;
            static public int Shield = 3;
            static public int Hatchet = 4;
            static public int Wall = 5;
            static public int Rocket = 6;
            static public int Rescue = 7;
        }
        static public class Part
        {
            static public int A = 0;
            static public int B = 1;
        }
        static public class Status
        {
            static public int move = 0;
            static public int attack = 1;
        }
        static public List< List< List<Image> > > imageList;

        static public int pictureWidth = 50;
        static public int mainLineHeight = 150;
        
        static public int warriorHeight = 50;
        static public int castleHeight = 100;

        static public int AStartPoint = 100;
        static public int BStartPoint = 500;

        static public int SwordCD = 10;
        static public int ArrowCD = 15;
        static public int ShieldCD = 20;
        static public int RocketCD = 50;
        static public int HatchetCD = 30;
        static public int WallCD = 50;
        static public int RescueCD = 25;

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
                imageList[Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L.png"));
                imageList[Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L1.png"));
                imageList[Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L2.png"));
                imageList[Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L3.png"));
                imageList[Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L4.png"));

                imageList[Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R.png"));
                imageList[Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R1.png"));
                imageList[Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R2.png"));
                imageList[Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R3.png"));
                imageList[Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R4.png"));


                imageList[Warrior.Sword][Part.A].Add(Image.FromFile(@"./img/Sword-L0.png"));
                imageList[Warrior.Sword][Part.A].Add(Image.FromFile(@"./img/Sword-L1.png"));
                imageList[Warrior.Sword][Part.B].Add(Image.FromFile(@"./img/Sword-R0.png"));
                imageList[Warrior.Sword][Part.B].Add(Image.FromFile(@"./img/Sword-R1.png"));

                imageList[Warrior.Arrow][Part.A].Add(Image.FromFile(@"./img/Arrow-L0.png"));
                imageList[Warrior.Arrow][Part.A].Add(Image.FromFile(@"./img/Arrow-L1.png"));
                imageList[Warrior.Arrow][Part.B].Add(Image.FromFile(@"./img/Arrow-R0.png"));
                imageList[Warrior.Arrow][Part.B].Add(Image.FromFile(@"./img/Arrow-R1.png"));

                imageList[Warrior.Shield][Part.A].Add(Image.FromFile(@"./img/Shield-L.png"));
                imageList[Warrior.Shield][Part.A].Add(null);
                imageList[Warrior.Shield][Part.B].Add(Image.FromFile(@"./img/Shield-R.png"));
                imageList[Warrior.Shield][Part.B].Add(null);

                imageList[Warrior.Rocket][Part.A].Add(Image.FromFile(@"./img/Rocket-L.png"));
                imageList[Warrior.Rocket][Part.A].Add(null);
                imageList[Warrior.Rocket][Part.B].Add(Image.FromFile(@"./img/Rocket-R.png"));
                imageList[Warrior.Rocket][Part.B].Add(null);

                imageList[Warrior.Wall][Part.A].Add(Image.FromFile(@"./img/Wall-L.png"));
                imageList[Warrior.Wall][Part.A].Add(null);
                imageList[Warrior.Wall][Part.B].Add(Image.FromFile(@"./img/Wall-R.png"));
                imageList[Warrior.Wall][Part.B].Add(null);

                imageList[Warrior.Hatchet][Part.A].Add(Image.FromFile(@"./img/Hatchet-L0.png"));
                imageList[Warrior.Hatchet][Part.A].Add(Image.FromFile(@"./img/Hatchet-L1.png"));
                imageList[Warrior.Hatchet][Part.B].Add(Image.FromFile(@"./img/Hatchet-R0.png"));
                imageList[Warrior.Hatchet][Part.B].Add(Image.FromFile(@"./img/Hatchet-R1.png"));

                imageList[Warrior.Rescue][Part.A].Add(Image.FromFile(@"./img/Rescue.png"));
                imageList[Warrior.Rescue][Part.A].Add(null);
                imageList[Warrior.Rescue][Part.B].Add(Image.FromFile(@"./img/Rescue.png"));
                imageList[Warrior.Rescue][Part.B].Add(null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),"圖片資源錯誤");
            }
        }
    }
}
