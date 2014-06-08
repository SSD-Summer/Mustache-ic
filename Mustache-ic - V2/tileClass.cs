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

        public tileClass tileImage(tileClass Tile)
        {

            return Tile;
            
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
