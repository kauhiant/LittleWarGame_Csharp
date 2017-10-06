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
        static public GameTime gameTime = new GameTime();
        static public List<List<List<Image>>> imageList;
        static public Image background;

        static public int pictureWidth = 50;
        static public int mainLineHeight = 100;
        static public int HPBarHeight = 150;

        static public int warriorHeight = 50;
        static public int castleHeight = 100;

        static public int AStartPoint = 100;
        static public int BStartPoint = 600;

        static public int SwordCD = 10;
        static public int ArrowCD = 15;
        static public int ShieldCD = 20;
        static public int RocketCD = 50;
        static public int HatchetCD = 30;
        static public int WallCD = 50;
        static public int RescueCD = 25;

        public enum Warrior_Type { attacker,shielder,helper }
        public enum Warrior { Castle , Sword , Arrow , Shield , Hatchet , Rocket ,  Wall , Rescue }
        public enum Status { move, attack }


        static public class Part
        {
            static public int A = 0;
            static public int B = 1;
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

                imageList[(int)Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L.png"));
                imageList[(int)Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L1.png"));
                imageList[(int)Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L2.png"));
                imageList[(int)Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L3.png"));
                imageList[(int)Warrior.Castle][Part.A].Add(Image.FromFile(@"./img/castle-L4.png"));

                imageList[(int)Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R.png"));
                imageList[(int)Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R1.png"));
                imageList[(int)Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R2.png"));
                imageList[(int)Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R3.png"));
                imageList[(int)Warrior.Castle][Part.B].Add(Image.FromFile(@"./img/castle-R4.png"));


                imageList[(int)Warrior.Sword][Part.A].Add(Image.FromFile(@"./img/Sword-L0.png"));
                imageList[(int)Warrior.Sword][Part.A].Add(Image.FromFile(@"./img/Sword-L1.png"));
                imageList[(int)Warrior.Sword][Part.B].Add(Image.FromFile(@"./img/Sword-R0.png"));
                imageList[(int)Warrior.Sword][Part.B].Add(Image.FromFile(@"./img/Sword-R1.png"));

                imageList[(int)Warrior.Arrow][Part.A].Add(Image.FromFile(@"./img/Arrow-L0.png"));
                imageList[(int)Warrior.Arrow][Part.A].Add(Image.FromFile(@"./img/Arrow-L1.png"));
                imageList[(int)Warrior.Arrow][Part.B].Add(Image.FromFile(@"./img/Arrow-R0.png"));
                imageList[(int)Warrior.Arrow][Part.B].Add(Image.FromFile(@"./img/Arrow-R1.png"));

                imageList[(int)Warrior.Shield][Part.A].Add(Image.FromFile(@"./img/Shield-L.png"));
                imageList[(int)Warrior.Shield][Part.A].Add(null);
                imageList[(int)Warrior.Shield][Part.B].Add(Image.FromFile(@"./img/Shield-R.png"));
                imageList[(int)Warrior.Shield][Part.B].Add(null);

                imageList[(int)Warrior.Rocket][Part.A].Add(Image.FromFile(@"./img/Rocket-L.png"));
                imageList[(int)Warrior.Rocket][Part.A].Add(null);
                imageList[(int)Warrior.Rocket][Part.B].Add(Image.FromFile(@"./img/Rocket-R.png"));
                imageList[(int)Warrior.Rocket][Part.B].Add(null);

                imageList[(int)Warrior.Wall][Part.A].Add(Image.FromFile(@"./img/Wall-L.png"));
                imageList[(int)Warrior.Wall][Part.A].Add(null);
                imageList[(int)Warrior.Wall][Part.B].Add(Image.FromFile(@"./img/Wall-R.png"));
                imageList[(int)Warrior.Wall][Part.B].Add(null);

                imageList[(int)Warrior.Hatchet][Part.A].Add(Image.FromFile(@"./img/Hatchet-L0.png"));
                imageList[(int)Warrior.Hatchet][Part.A].Add(Image.FromFile(@"./img/Hatchet-L1.png"));
                imageList[(int)Warrior.Hatchet][Part.B].Add(Image.FromFile(@"./img/Hatchet-R0.png"));
                imageList[(int)Warrior.Hatchet][Part.B].Add(Image.FromFile(@"./img/Hatchet-R1.png"));

                imageList[(int)Warrior.Rescue][Part.A].Add(Image.FromFile(@"./img/Rescue.png"));
                imageList[(int)Warrior.Rescue][Part.A].Add(null);
                imageList[(int)Warrior.Rescue][Part.B].Add(Image.FromFile(@"./img/Rescue.png"));
                imageList[(int)Warrior.Rescue][Part.B].Add(null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),"圖片資源錯誤");
            }
        }
    }
}
