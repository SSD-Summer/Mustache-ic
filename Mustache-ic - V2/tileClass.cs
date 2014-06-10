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
        public System.Windows.Forms.ImageList imageList_animals;

        private System.ComponentModel.IContainer components = null;
        

        private int num;       

        
        //public System.Windows.Forms.ImageList imageList_animals;
        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameMain));*/
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



        private int num_Generator(int min_val, int max_val)
        {

            Random rand = new Random();
            num = rand.Next(min_val, max_val);
            return num;
        }


      //sets images to the tiles. If image_num = 0, moustache pic is displayed on tile and a pause is in place, if image_num = 1, normal pic
  
        public void tileImage(int image_num)
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameMain));
            this.imageList_animals = new System.Windows.Forms.ImageList(this.components);

            imageList_animals = new System.Windows.Forms.ImageList(this.components);
            this.imageList_animals.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_animals.ImageStream")));
            this.imageList_animals.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_animals.Images.SetKeyName(0, "bird.jpg");
            this.imageList_animals.Images.SetKeyName(1, "cat.jpg");
            this.imageList_animals.Images.SetKeyName(2, "chicken.jpg");
            this.imageList_animals.Images.SetKeyName(3, "dog.jpg");
            this.imageList_animals.Images.SetKeyName(4, "crab.jpg");
            this.imageList_animals.Images.SetKeyName(5, "goldfish.jpg");
            this.imageList_animals.Images.SetKeyName(6, "t_rex.jpg");
            this.imageList_animals.Images.SetKeyName(7, "bronc.jpg");
            this.imageList_animals.Images.SetKeyName(8, "steg.jpg");
            this.imageList_animals.Images.SetKeyName(9, "jellyfish.jpg");
            this.imageList_animals.Images.SetKeyName(10, "pig.jpg");
            this.imageList_animals.Images.SetKeyName(11, "sheep.jpg");

            //this.imageList_animals.Images.Add(global::Mustache_ic___V2.Properties.Resources.bird);

           /*alive_imageList = new System.Windows.Forms.ImageList();
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
            Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\pig_moustache.jpg"));*/


            //if image is normal
            if (image_num == 1)
            {
                //his.tile.Image = alive_imageList.Images[num_Generator(0, 11)];
                this.tile.Image = imageList_animals.Images[num_Generator(0, 11)];
               
            }
            //if image has moustache
            else
        {
                //this.tile.Image = dead_imageList.Images[num_Generator(0, 11)];
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
                //Code to add mustache to button picture
                //Add to score
            }
            else
            {
                //Code to remove points from score
                //Remove lives
            }

            //code to fade in and fade out picture and change picture
        }
    }
}
