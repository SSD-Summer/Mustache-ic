using System;
using System.Collections.Generic;
using System.Drawing;

namespace Mustashe_ic
{
    /// <summary>
    /// Holds all the form controls and game items for playing.
    /// </summary>
    internal class gamePlay
    {
        private tileClass[,] board;
        private int n; //Defines the board as an N by N
        private int score;

        public int timer { set; get; } //Probably will change to helper class

        private int count; //This is the variable used to keep track of how often to hide a tile
        private int hide_speed;//randX, randY; //ints used as random vars

        //int image_num;//uses rand to select a random image number
        //int num, min_val, max_val;//integers for random number generator
        private Random rand; //Random generator - Will probably move

        private Queue<Tuple<int, int>> hiddenList; //Used as holder for hidden tiles - Stores x and y coordinate of tile in tuple

        //System.Windows.Forms.ImageList imageList;

        public System.Windows.Forms.Label label_lives, label_timer, label_score;
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
            label_lives.Text = "Lives";
            //label_lives.AutoSize = true;
            label_lives.Location = new System.Drawing.Point(1, 1);
            label_lives.Font = new System.Drawing.Font("Comic Sans MS", 16F, FontStyle.Bold);
            label_lives.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            //timer label generation
            label_timer = new System.Windows.Forms.Label();
            label_timer.Text = timer.ToString();
            label_timer.Font = new System.Drawing.Font("Comic Sans MS", 16F, FontStyle.Bold);
            label_timer.Location = new System.Drawing.Point(g.Width/2, 1);
            label_timer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            //score label generation
            label_score = new System.Windows.Forms.Label();
            label_score.Text = score.ToString();
            label_score.Font = new System.Drawing.Font("Comic Sans MS", 16F, FontStyle.Bold);
            label_score.Location = new System.Drawing.Point(650, 1);
            label_score.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            //tile panel generation
            panel_tile_holder = new System.Windows.Forms.Panel();
            panel_tile_holder.Size = new System.Drawing.Size(g.Width, g.Height);
            panel_tile_holder.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left));
            //panel_tile_holder.AutoSize = true;
            panel_tile_holder.Location = new System.Drawing.Point(0, 100);

            g.Controls.Add(panel_tile_holder);

            g.Controls.Add(label_lives);
            g.Controls.Add(label_timer);
            g.Controls.Add(label_score);

            init_board(n); //initializes the board
            hide_speed = 2;//How quickly tiles hide, 0 - 3 secs
            rand = new Random();  //needed for random generation
            count = rand.Next(hide_speed); //get random tile wait time
            hiddenList = new Queue<Tuple<int, int>>(); //initalizes queue to hold the hidden tiles
            //imageList = new System.Windows.Forms.ImageList();
        }

        //created this method for num generator, might be able to use for all generator numbers once overloaded
        //private int num_Generator(int min_val, int max_val)
        //{
        //   Random rand = new Random();
        //   num = rand.Next(min_val, max_val);
        //   return num;
        //}
        /// <summary>
        /// Initalizes the tile board onto panel_tile_holder
        /// </summary>
        /// <param name="size">The number of tiles on the game board. size x size </param>
        private void init_board(int size) //Creates a size X size grid of tiles
        {
            board = new tileClass[size, size];
            int xDim, yDim;
            xDim = (gameMain.ActiveForm.Width/size) - 30;
            yDim = (gameMain.ActiveForm.Height/size) - 44;

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)    // This is where I print the gameboard into the panel
                {
                    //715x790
                    board[i, j] = new tileClass();
                    board[i, j].tile.Size = new System.Drawing.Size(xDim,yDim);
                    board[i, j].tile.BackColor = Color.Transparent;

                    board[i, j].tile.Location = new System.Drawing.Point(i * (xDim - 3) + 60, j * (yDim+5) + 5);
                    //
                    //sets each tile to image from the the imageList
                    board[i, j].tileImage(1);
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

                int aa = rand.Next(1, 3); //Needs to be based on number of tiles on the board
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

        private void tile_clicked(object sender, EventArgs e)
        {
        }
    }
}