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

        public bool correctObject { get; set; }
        public System.Windows.Forms.Button tile { get; set; }
        public static System.Windows.Forms.ImageList alive_imageList;
        public static System.Windows.Forms.ImageList dead_imageList;
        private int num;       

        
        
        public tileClass()
        {
            correctObject = false;
            tile = new System.Windows.Forms.Button();
            tile.Click += new EventHandler(tile_clicked);
           
        }

        public tileClass(bool val)
        {
            correctObject = val;
            tile = new System.Windows.Forms.Button();
          
   
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


      //sets images to the tiles. If image_num = 0, moustache pic is displayed on tile and a pause is in place, if image_num = 1, normal pic
        /// <summary>
        /// Sets the image on the tile. If image_num == 1, alive image; else dead image
        /// </summary>
        /// <param name="image_num"></param>
        public void tileImage(int image_num)
        {           
            //if image is normal
            if (image_num == 1)
            {
                int a = num_Generator(0, 11);
                this.tile.Image = alive_imageList.Images[a];
                if(a == 5 || a == 10 || a == 11)
                {
                    this.tile.Tag = 1; //sets the tag to the dino images to 1
                }
                else
                {
                    this.tile.Tag = 0;
                }
               
            }
            //if image has moustache
            else
            {
                this.tile.Image = dead_imageList.Images[num_Generator(0, 11)];
                System.Threading.Thread.Sleep(1000); //keeps the image up, may have to adjust time

            }      
                      
        }

        
        public void hideTile()
        {
            this.tile.Hide();
        }

        /// <summary>
        /// When image tile is clicked, scores points, SIMPLE NEEDS WORK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void tile_clicked(object sender, EventArgs e)
        {
            //simple scoring-- need to make it image specific
            gamePlay.score = gamePlay.score + 200;
            gamePlay.label_score.Text = gamePlay.score.ToString();
            /*string a;
            a = this.tile.Tag.ToString();

                        label_timer.Text = timer.ToString();
            if( a == "5" || a == "10" || a == "11")
            {
                switch (switch_on)
                {
                    case a == 5:
                        this.tile.

                    default:
                }
                
            }
            
            if(this.correctObject == true)
            {
                
                //Code to add mustache to button picture
                //Add to score
            }
            else
            {
                //Code to remove points from score
                //Remove lives
            }*/

            //code to fade in and fade out picture and change picture
        }
    }
}
