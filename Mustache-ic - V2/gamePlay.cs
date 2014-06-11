using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
namespace Mustashe_ic
{
   

    /// <summary>
    /// Holds all the form controls and game items for playing.
    /// </summary>
    class gamePlay
    {
        tileClass[,] board;
        int n; //Defines the board as an N by N 
        public static int score;
        public static int lives;
        public int timer { set; get; } //Probably will change to helper class
        int count; //This is the variable used to keep track of how often to hide a tile 
        int hide_speed;//randX, randY; //ints used as random vars        
        Random rand; //Random generator - Will probably move 
        Queue<Tuple<int, int>> hiddenList; //Used as holder for hidden tiles - Stores x and y coordinate of tile in tuple
       
        
        public static System.Windows.Forms.Label label_lives, label_timer, label_score;
        public System.Windows.Forms.Panel panel_tile_holder;
       


        /// <summary>
        /// Initalizes an instance of the game
        /// </summary>
        /// <param name="g"> The form the game will be played on.</param>
        /// <param name="size">The number of tiles that the board will have. n x n </param>
        /// <param name="mode">Specifys the mode of play. World(world 1, 2, 3, ....) or Endless</param>
        public gamePlay(gameMain g, int size, int mode)
        {
            score = 0; //beginning score to zero
            timer = 30; // Starting time 30 secs
            n = size; //size of tile board - nxn
            
            //Lives label generation 
            label_lives = new System.Windows.Forms.Label();
            label_lives.Text = "Number of lives";
            label_lives.AutoSize = true;
            label_lives.Location = new System.Drawing.Point(5, 5);
            label_lives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            //timer label generation
            label_timer = new System.Windows.Forms.Label();
            label_timer.Text = timer.ToString();
            label_timer.Location = new System.Drawing.Point(230, 5);
            label_timer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            //score label generation
            label_score = new System.Windows.Forms.Label();
            label_score.Text = score.ToString();
            label_score.Location = new System.Drawing.Point(450, 5);
            label_score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); ;
            //tile panel generation
            panel_tile_holder = new System.Windows.Forms.Panel();
            panel_tile_holder.Size = new System.Drawing.Size(g.Size.Width, 250);
            panel_tile_holder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
            panel_tile_holder.AutoSize = true;
            panel_tile_holder.Location = new System.Drawing.Point(0, 200);

            g.Controls.Add(label_lives);
            g.Controls.Add(label_timer);
            g.Controls.Add(label_score);
            g.Controls.Add(panel_tile_holder);

            init_board(n); //initializes the board
            hide_speed = 2;//How quickly tiles hide, 0 - 3 secs  
            rand = new Random();  //needed for random generation
            count = rand.Next(hide_speed); //get random tile wait time
            hiddenList = new Queue<Tuple<int, int>>(); //initalizes queue to hold the hidden tiles
            
            
            
                      

        }
        
        /// <summary>
        /// Initalizes the tile board onto panel_tile_holder
        /// </summary>
        /// <param name="size">The number of tiles on the game board. size x size </param>
        private void init_board(int size) //Creates a size X size grid of tiles 
        {
            board = new tileClass[size, size];
            
            
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)    // This is where I print the gameboard into the panel 
                {
                    
                    board[i, j] = new tileClass();
                    board[i, j].tile.Size = new System.Drawing.Size(100, 100);
                    board[i, j].tile.Location = new System.Drawing.Point(i * 125 + 5, j * 100 + 5);
                    //
                    //sets each tile to image from the the imageList
                    board[i, j].tileImage();
;                    
                    
                    //board[i, j].tile.Click += new EventHandler(tile_clicked);
                    panel_tile_holder.Controls.Add(board[i, j].tile);
                }
            }

        }

        

        
        /// <summary>
        /// One "Turn" of the game. Decrements the count variable. If there are 2 or more hidden tiles, un-hide one. If count is '0' then hide a random tile then generate a new counter.
        /// </summary>
        public void gameTick() //Ran each sec for the alloted time 
        {
            --count; //decremete counter for hiding tile
            --timer;
            if (hiddenList.Count >= 2) //if there are 1 or more hidden tiles unhide one
            {
                //Would like to add a way to randomize the queue if we countine with this method in the future
                var temp = hiddenList.Dequeue();
                board[int.Parse(temp.Item1.ToString()), int.Parse(temp.Item2.ToString())].tile.Show();
            }

            if (count < 0)
            { 
                //when the count is 0 its tile to hide a tile 

                int aa = rand.Next(1,3); //Needs to be based on number of tiles on the board
                for (int x = 0; x < aa; ++x)
                {
                    int i = rand.Next(n);
                    int j = rand.Next(n);  //Gather random i and j values 
                    hiddenList.Enqueue(Tuple.Create(i, j));  //add them to the queue
                    board[i, j].tile.Hide();  //hide the associated tile 
                    count = rand.Next(hide_speed); //get random tile wait time
                }
            }
            label_timer.Text = timer.ToString();
            
        }

        public void hideGameControls()
        {
            panel_tile_holder.Hide();
            label_lives.Hide();
            label_score.Hide();
            label_timer.Hide();
        }

        /*public void scorePoints()
        {
            score = +200;
            label_score.Text = score.ToString();
            
            
        }*/

        private void tile_clicked(object sender, EventArgs e)
        {
            

           
        }

       }
}
