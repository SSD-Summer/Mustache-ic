using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace Mustashe_ic
{

    class tileClass
    {
        //Bool value whether or not the tile is the correct one. May need to be improved or changed
        public bool correctObject { get; set; }
        //The button - may need to switch to image
        public System.Windows.Forms.Button tile { get; set; }
        //Static image Lists to hold the images from the resouce file
        public static System.Windows.Forms.ImageList alive_imageList;
        public static System.Windows.Forms.ImageList dead_imageList;

        static int correctTileCount = 0;
        static int totalTileCount = 0;

        //Used to return random numbers - need to remove
        private int num;

        int xLoc, yLoc;
        int imageHideCounter;
        System.Windows.Forms.Timer imageTime;

        static System.Timers.Timer timer = new System.Timers.Timer();

        //Var used to distinguish which animals are correct for the current game --- Updated everytime a new game is started
        static int animalType; //

        /// <summary>
        /// Default constructor. Sets: 
        ///     correctObject=false
        ///     Allocates a new button for tile
        ///     assigns buttons event to tile_clicked
        /// </summary>
        public tileClass()
        {
            tile = new System.Windows.Forms.Button();
            //tile.Click += new EventHandler(tile_clicked);

        }

        public tileClass(int x, int y)
        {
            tile = new System.Windows.Forms.Button();
            tile.Click += new EventHandler(tile_clicked);
            xLoc = x;
            yLoc = y;

            //tile.Click += new EventHandler(tile_clicked);

        }

        public static void setAnimalType(int type)
        {
            animalType = type;
        }

        /// <summary>
        /// Random number generator that takes two ints as range and returns a int
        /// </summary>
        /// <param name="min_val"></param>
        /// <param name="max_val"></param>
        /// <returns></returns>
        private int num_Generator(int min_val, int max_val)
        {

            Random rand = new Random();
            num = rand.Next(min_val, max_val);
            return num;
        }

        /// <summary>
        /// Creates two static ImageList. alive_imageList stores non-moustache images, dead_imageList stores
        /// moustache images. The images are sized to 90 x 90
        /// </summary>
        public static void imageList()
        {
            alive_imageList = new System.Windows.Forms.ImageList();
            alive_imageList.ImageSize = new Size(90, 90); //makes the images same size as button
            dead_imageList = new System.Windows.Forms.ImageList();
            dead_imageList.ImageSize = new Size(90, 90);//makes the images same size as button

            //0 - 2 are dinos
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.steg);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.t_rex);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bronc);

            //3 - 5 are house 
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bird);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.dog);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.cat);

            //6 - 8 are water
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.crab);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.goldfish);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.jellyfish);

            //9 - 11 are farm
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.pig);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.sheep);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.chicken);

            ///////////////////////////////////////////////////////////////////////////////////////////

            //0 - 2 are dinos
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.steg_moustashe);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.t_rex_moustashe);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bron_moustache);

            //3 - 5 are house
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bird_moustache); 
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.dog_moustashe);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.cat_moustache);

            //6 - 8 are water
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.crab_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.goldfish_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.jellyfish_moustache);

            //8 - 11 are farm
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.pig_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.sheep_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.chicken_moustache);

        }


       
        /// <summary>
        /// Sets the image on the tile. If image_num == 1, alive image; else dead image
        /// </summary>
        /// <param name="x">Width of tile image is being attached too</param>
        /// <param name="y">Height of tile image is being attached too</param>
        public void tileImage(int x, int y)
        {
            //sets images to the tiles. If image_num = 0, moustache pic is displayed on tile and a pause is in place, if image_num = 1, normal pic

            int a = num_Generator(0, 12);

            //Adjusts images to current tile size
            alive_imageList.ImageSize = new Size(x, y);
            dead_imageList.ImageSize = new Size(x, y);

            this.tile.Image = alive_imageList.Images[a];
            this.tile.Tag = a;
            this.tile.Show();
        }

        /// <summary>
        /// Hides button associated with tile
        /// </summary>
        public void hideTile()
        {
            this.tile.Hide();
        }

        public void mustacheImage()
        {
            int tempTag = Convert.ToInt32(this.tile.Tag.ToString());
            this.tile.Image = dead_imageList.Images[tempTag];
            this.tile.Show();
        }

        public void get_random_regularImage()
        {
            int tempTag = Convert.ToInt32(this.tile.Tag.ToString());
            int newTag = num_Generator(0, 12);
            while (newTag == tempTag)
                newTag = num_Generator(0, 12);
            this.tile.Image = alive_imageList.Images[newTag];
        }

        public static Image getMustacheImage(int tag)
        {
            return dead_imageList.Images[tag];
        }

        private void tile_clicked(object sender, EventArgs e)
        {
            int tileTag = Convert.ToInt32(sender.GetType().GetProperty("Tag").GetValue(sender));
            
            //0 - 2 are dinos 
            //3 - 5 are house
            //6 - 8 are water
            //9 - 11 are farm

            if (animalType == 1)
            {
                if (tileTag >= 0 && tileTag <= 2)
                {
                    gamePlay.score += 200;
                    gamePlay.label_score.Text = gamePlay.score.ToString();
                    this.tile.Image = dead_imageList.Images[tileTag];
                    this.tile.Show();
                }
                else
                {
                    gamePlay.lives--;
                    gamePlay.label_lives.Text = gamePlay.lives.ToString();

                }
            }
            else if (animalType == 2)
            {
                if (tileTag >= 0 && tileTag <= 2)
                {
                    gamePlay.score += 200;
                    gamePlay.label_score.Text = gamePlay.score.ToString();
                    this.tile.Image = dead_imageList.Images[tileTag];
                    this.tile.Show();
                }
                else
                {
                    gamePlay.lives--;
                    gamePlay.label_lives.Text = gamePlay.lives.ToString();

                }
            }
            else if (animalType == 3)
            {
                if (tileTag >= 0 && tileTag <= 2)
                {
                    gamePlay.score += 200;
                    gamePlay.label_score.Text = gamePlay.score.ToString();
                    this.tile.Image = dead_imageList.Images[tileTag];
                    this.tile.Show();
                }
                else
                {
                    gamePlay.lives--;
                    gamePlay.label_lives.Text = gamePlay.lives.ToString();

                }
            }
            else if (animalType == 4)
            {
                if (tileTag >= 0 && tileTag <= 2)
                {
                    gamePlay.score += 200;
                    gamePlay.label_score.Text = gamePlay.score.ToString();
                    this.tile.Image = dead_imageList.Images[tileTag];
                    this.tile.Show();
                }
                else
                {
                    gamePlay.lives--;
                    gamePlay.label_lives.Text = gamePlay.lives.ToString();

                }
            }

            imageTime = new System.Windows.Forms.Timer();
            imageTime.Tick += new EventHandler(imageTimerTick);
            imageTime.Interval = 500;
            imageTime.Disposed += new EventHandler(hide_image);
            imageHideCounter = 2;
            imageTime.Start();
            //gamePlay.hideTileImage(xLoc, yLoc);

        }

        private void imageTimerTick(Object sender, EventArgs e)
        {
            --imageHideCounter;
            if(imageHideCounter <1)
            {
                imageTime.Dispose();
            }
        }

        private void hide_image(Object sender, EventArgs e)
        {
            gamePlay.hideTileImage(this.xLoc, this.yLoc);
        }

    }
}
