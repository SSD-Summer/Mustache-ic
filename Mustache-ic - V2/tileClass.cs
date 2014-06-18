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

        //Used to return random numbers - need to remove
        private int num;
        static System.Timers.Timer timer = new System.Timers.Timer();


        /// <summary>
        /// Default constructor. Sets: 
        ///     correctObject=false
        ///     Allocates a new button for tile
        ///     assigns buttons event to tile_clicked
        /// </summary>
        public tileClass()
        {
            correctObject = false;
            tile = new System.Windows.Forms.Button();
            tile.Click += new EventHandler(tile_clicked);

        }

        /// <summary>
        /// Same as default except sets:
        ///     correctObject = val
        /// </summary>
        /// <param name="val">Manualy sets if tile is the correct selection for that game.</param>
        public tileClass(bool val)
        {
            correctObject = val;
            tile = new System.Windows.Forms.Button();
            tile.Click += new EventHandler(tile_clicked);

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
            //need to work on image scale settings 

            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bird);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.chicken);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.dog);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.cat);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.crab);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bronc);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.goldfish);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.jellyfish);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.pig);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.sheep);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.steg);
            alive_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.t_rex);

            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bird_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.chicken_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.dog_moustashe);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.cat_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.crab_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.bron_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.goldfish_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.jellyfish_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.pig_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.sheep_moustache);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.steg_moustashe);
            dead_imageList.Images.Add(global::Mustache_ic___V2.Properties.Resources.t_rex_moustashe);

        }


       
        /// <summary>
        /// Sets the image on the tile. If image_num == 1, alive image; else dead image
        /// </summary>
        /// <param name="x">Width of tile image is being attached too</param>
        /// <param name="y">Height of tile image is being attached too</param>
        public void tileImage(int x, int y)
        {
            //sets images to the tiles. If image_num = 0, moustache pic is displayed on tile and a pause is in place, if image_num = 1, normal pic

            int a = num_Generator(0, 11);

            //Adjusts images to current tile size
            alive_imageList.ImageSize = new Size(x, y);
            dead_imageList.ImageSize = new Size(x, y);

            this.tile.Image = alive_imageList.Images[a];

            this.tile.Show();

            if (a == 5)
            {
                this.tile.Tag = 5;
            }
            else if (a == 10)
            {
                this.tile.Tag = 10;
            }
            else if (a == 11)
            {
                this.tile.Tag = 11;
            }
            else
            {
                this.tile.Tag = 0;
            }
        }

        /// <summary>
        /// Hides button associated with tile
        /// </summary>
        public void hideTile()
        {
            this.tile.Hide();
        }

       /* public async Task imageTimer()
        {
            await Task.Delay(TimeSpan.FromSeconds(30));
            return Task;
        }*/



        /// <summary>
        /// When image tile is clicked, scores points, SIMPLE NEEDS WORK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void tile_clicked(object sender, EventArgs e)
        {
            //simple scoring-- need to make it image specific
            int a = int.Parse(this.tile.Tag.ToString());

            switch (a)
            {
                case 5:
                    {
                gamePlay.score = gamePlay.score + 200;
                gamePlay.label_score.Text = gamePlay.score.ToString();
                this.tile.Image = dead_imageList.Images[5];
                        //timer.Interval = 5000;
                       // timer.Start();

                        //this.tileImage();
                        break;
            }
                case 10:
            {
                gamePlay.score = gamePlay.score + 200;
                gamePlay.label_score.Text = gamePlay.score.ToString();
                this.tile.Image = dead_imageList.Images[10];
                        //timer.Interval = 5000;
                        //timer.Start();

                        //this.tileImage();

                        break;
            }
                case 11:
            {
                gamePlay.score = gamePlay.score + 200;
                gamePlay.label_score.Text = gamePlay.score.ToString();
                this.tile.Image = dead_imageList.Images[11];
                        //timer.Interval = 5000;
                        //timer.Start();

                        //this.tileImage();
                        break;
            }
                default:
            {
                if (gamePlay.lives > 0)
                {
                    gamePlay.lives = gamePlay.lives - 1;
                             gamePlay.label_lives.Text = "Lives  " + gamePlay.lives.ToString();
                             
                        }
                        break;

                }
                }

            if(gamePlay.lives == 0)
                {
                //code to get to the END GAME SCREEN goes here
                }

           
        }
    }
}
