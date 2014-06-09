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
        public System.Windows.Forms.ImageList alive_imageList;
        public System.Windows.Forms.ImageList dead_imageList;

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

        //made a random number generator
        private int num_Generator(int min_val, int max_val)
        {

            Random rand = new Random();
            num = rand.Next(min_val, max_val);
            return num;
        }

        //sets images to the tiles. If image_num = 0, moustache pic is displayed on tile and a pause is in place, if image_num = 1, normal pic
        public void tileImage(int image_num)
        {
          

           alive_imageList = new System.Windows.Forms.ImageList();
           alive_imageList.ImageSize = new Size(100, 100); //makes the images same size as button

           dead_imageList = new System.Windows.Forms.ImageList();
           dead_imageList.ImageSize = new Size(100, 100);//makes the images same size as button

            //Imagelist with normal pics
            //need to move these to a global variable
           alive_imageList.Images.Add(
               Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\bird.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\chicken.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\bronc.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\cat.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\crab.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\dog.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\goldfish.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\pig.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\jellyfish.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\sheep.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\steg.jpg"));
           alive_imageList.Images.Add(
              Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\t_rex.jpg"));

            //Imagelist with moustache pics
            dead_imageList.Images.Add(
               Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\t_rex_moustashe.jpg"));
            dead_imageList.Images.Add(
               Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\cat_moustache.jpg"));
            dead_imageList.Images.Add(
               Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\bron_moustache.jpg"));
            dead_imageList.Images.Add(
               Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\crab_moustache.jpg"));
            dead_imageList.Images.Add(
                Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\dog_moustashe.jpg"));
            dead_imageList.Images.Add(
                Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\bird_moustache.jpg"));
            dead_imageList.Images.Add(
            Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\goldfish_moustache.jpg"));
            dead_imageList.Images.Add(
            Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\chicken_moustache.jpg"));
            dead_imageList.Images.Add(
            Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\jellyfish_moustache.jpg"));
            dead_imageList.Images.Add(
            Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\steg_moustashe.jpg"));
            dead_imageList.Images.Add(
            Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\sheep_moustache.jpg"));
            dead_imageList.Images.Add(
            Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\pig_moustache.jpg"));

            //if image is normal
            if (image_num == 1)
            {
                this.tile.Image = alive_imageList.Images[num_Generator(0, 11)];
               
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

        private void tile_clicked(object sender, EventArgs e)
        {

            if(this.correctObject == true)
            {
                tileImage(0); 
                

                //increment score
                
            }
            else
            {
                tileImage(1);
                //Remove lives
            }

            //code to fade in and fade out picture and change picture
        }
    }
}
