using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


/*Dominic Cox
 * Russell Ballengee
 * Jamie Wimsatt
 */


namespace Mustashe_ic
{
    public partial class gameMain : Form
    {
        //Controls for game menu
        System.Windows.Forms.Button button_worldsMode;
        System.Windows.Forms.Button button_endlessMode;

        //World Panels
        System.Windows.Forms.Panel panel_world1;
        System.Windows.Forms.Panel panel_world2;
        System.Windows.Forms.Panel panel_world3;
        System.Windows.Forms.Panel panel_world4;

        //Sub-World buttons
        List<System.Windows.Forms.Button> list_button_sub_world1;
        List<System.Windows.Forms.Button> list_button_sub_world2;
        List<System.Windows.Forms.Button> list_button_sub_world3;
        List<System.Windows.Forms.Button> list_button_sub_world4;

        //Label associated with the count down before a game start
        System.Windows.Forms.Label label_countDown;
        
        //Controls associated with the results page shown after a completed game
        System.Windows.Forms.Panel panel_results;
        System.Windows.Forms.Label label_win_lose;
        System.Windows.Forms.Label label_score;
        System.Windows.Forms.Button button_return;
        System.Windows.Forms.Button button_continue;

        //Timers for game length and countDown label 
        System.Windows.Forms.Timer timer_game;
        System.Windows.Forms.Timer timer_countDownLabel;

        System.Windows.Forms.Panel panel_howTo;
        System.Windows.Forms.PictureBox pictureBox_next;
        System.Windows.Forms.PictureBox pictureBox_exit;

        //Static vars for gathering game mode, and sub-mode
        static int gameMode, subMode;
        public int count;
        
        gamePlay game;

        /// <summary>
        /// Default constructor for gameMain form
        /// Initializes default controls and imageList for tileClass
        /// </summary>
        public gameMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the start button is hit, it creates the next page that 
        /// allows the player to choose which game mode they want to play.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {

            //On Start click - Hide everything currently active on the form
            if ((Button)sender == button_start)
            {
                button_start.Hide();
                button_leaderboard.Hide();
                button_howTo.Hide();

            }
            if((Button)sender == button_return)
            {
                panel_results.Hide();
                button_return.Hide();
                button_continue.Hide();
            }
            
            gameMain.ActiveForm.BackgroundImage = Mustache_ic___V2.Properties.Resources.moustache_bg;
            gameMain.ActiveForm.BackgroundImageLayout = ImageLayout.Stretch;
            
            //Creates world mode button 
            button_worldsMode = new Button();
            button_worldsMode.Text = "Worlds";
            button_worldsMode.Size = new Size(250, 390);
            button_worldsMode.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button_worldsMode.AutoSize = true;
            button_worldsMode.Location = new Point(75, 144);
            button_worldsMode.Anchor = ((System.Windows.Forms.AnchorStyles)(AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top));
            button_worldsMode.Click += new System.EventHandler(worldButton_Click); //Bind button click event to worldButton_click function
            this.Controls.Add(button_worldsMode);

            //Creates endless mode button
            button_endlessMode = new Button();
            button_endlessMode.Text = "Endless";
            button_endlessMode.Size = new Size(250, 390);
            button_endlessMode.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button_endlessMode.AutoSize = true;
            button_endlessMode.Location = new Point(375, 144);
            button_endlessMode.Anchor = ((AnchorStyles)(AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom));
            //Needs event
            this.Controls.Add(button_endlessMode);            
        }
        /// <summary>
        /// Creates the How to Play instructions window when the button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_howTo_Click(object sender, EventArgs e)
        {
            //Hides main menu buttons and creates a panel for the instuctions to be shown on
            button_start.Hide();
            button_leaderboard.Hide();
            button_howTo.Hide();
            panel_howTo = new Panel();
            panel_howTo.Size = new Size(570, 369);
            panel_howTo.Location = new Point(85, 140);
            panel_howTo.BackgroundImage = Mustache_ic___V2.Properties.Resources.howTo_page1;

            //Creates a next page icon
            pictureBox_next = new PictureBox();
            pictureBox_next.Size = new Size(45, 45);
            pictureBox_next.BackgroundImage = Mustache_ic___V2.Properties.Resources.next;
            pictureBox_next.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox_next.BackColor = Color.Transparent;
            pictureBox_next.Location = new Point(490, 320);

            //Creates an exit icon
            pictureBox_exit = new PictureBox();
            pictureBox_exit.Size = new Size(45, 45);
            pictureBox_exit.BackgroundImage = Mustache_ic___V2.Properties.Resources.close;
            pictureBox_exit.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox_exit.BackColor = Color.Transparent;
            pictureBox_exit.Location = new Point(490, 120);

            panel_howTo.Controls.Add(pictureBox_next);
            panel_howTo.Controls.Add(pictureBox_exit);
            this.Controls.Add(panel_howTo);

            pictureBox_next.Click += new EventHandler(pictureBox_next_Click);
            pictureBox_exit.Click += new EventHandler(pictureBox_close_Click);

        }
        /// <summary>
        /// Moves to the next page on the How to Play instructions.
        /// </summary>
        int num = 0;
        private void pictureBox_next_Click(object sender, EventArgs e)
        {
            ++num;
            switch(num)
            {
                case 1:
                    panel_howTo.BackgroundImage = Mustache_ic___V2.Properties.Resources.howTo_page2;
                    
                    break;
                case 2:
                    panel_howTo.BackgroundImage = Mustache_ic___V2.Properties.Resources.howTo_page3;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Closes the How to Play window and returns to the main page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            panel_howTo.Hide();
            button_start.Show();
            button_leaderboard.Show();
            button_howTo.Show();

        }

        /// <summary>
        /// When worlds mode has been selected, it moves to the next page for
        /// the player to choose which world.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worldButton_Click(object sender, EventArgs e) //Loads world selection buttons 
        {
            //Will probably need to make this a class variable
            int numSubWorlds = 3;

            button_worldsMode.Hide();
            button_endlessMode.Hide();
            gameMain.ActiveForm.BackgroundImage = Mustache_ic___V2.Properties.Resources.bg1;
            gameMain.ActiveForm.BackgroundImageLayout = ImageLayout.Stretch;

            int xPanelSize = (gameMain.ActiveForm.Width - 25)/2;
            int yPanelSize = (gameMain.ActiveForm.Height - 25)/2;

            int xButtonSize = xPanelSize - 20;
            int yButtonSize = (yPanelSize - 250) / numSubWorlds;

            int controlOffset = 5;

            //World 1 Panel & Buttons
            panel_world1 = new Panel();
            panel_world1.Size = new Size(xPanelSize, yPanelSize);
            panel_world1.Location = new Point(controlOffset, controlOffset);
            panel_world1.Tag = 1;
            panel_world1.BackColor = Color.Transparent;

            list_button_sub_world1 = new List<Button>();
            for (int i = 0; i < numSubWorlds; ++i )
            {
                Button bTmp = new Button();
                bTmp.Text = "Dinosaur - World " + (i + 1);
                bTmp.TextAlign = ContentAlignment.MiddleCenter;
                bTmp.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bTmp.Size = new Size(xButtonSize, yButtonSize);
                bTmp.Tag = i + 1;
                bTmp.Click += new EventHandler(level_countdown);
                list_button_sub_world1.Add(bTmp);
                panel_world1.Controls.Add(list_button_sub_world1[i]);
                list_button_sub_world1[i].Location = new Point(controlOffset, i * yButtonSize + controlOffset * (i + 1));

            }

            //World 2 button
            panel_world2 = new Panel();
            panel_world2.Size = new Size(xPanelSize, yPanelSize);
            panel_world2.Location = new Point(2*controlOffset + xPanelSize, controlOffset);
            panel_world2.Tag = 2;
            panel_world2.BackColor = Color.Transparent;

            list_button_sub_world2 = new List<Button>(numSubWorlds);
            for (int i = 0; i < numSubWorlds; ++i)
            {
                Button bTmp = new Button();
                bTmp.Text = "Pet - World " + (i + 1);
                bTmp.TextAlign = ContentAlignment.MiddleCenter;
                bTmp.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bTmp.Size = new Size(xButtonSize, yButtonSize);
                bTmp.Tag = i + 1;
                bTmp.Click += new EventHandler(level_countdown);
                list_button_sub_world2.Add(bTmp);
                panel_world2.Controls.Add(list_button_sub_world2[i]);
                list_button_sub_world2[i].Location = new Point(controlOffset, i * yButtonSize + controlOffset * (i + 1));

            }
            //World 3 button
            panel_world3 = new Panel();
            panel_world3.Size = new Size(xPanelSize, yPanelSize);
            panel_world3.Location = new Point(controlOffset, 2*controlOffset + yPanelSize);
            panel_world3.Tag = 3;
            panel_world3.BackColor = Color.Transparent;

            list_button_sub_world3 = new List<Button>(numSubWorlds);
            for (int i = 0; i < numSubWorlds; ++i)
            {
                Button bTmp = new Button();
                bTmp.Text = "Aquatic - World " + (i + 1);
                bTmp.TextAlign = ContentAlignment.MiddleCenter;
                bTmp.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bTmp.Size = new Size(xButtonSize, yButtonSize);
                bTmp.Tag = i + 1;
                bTmp.Click += new EventHandler(level_countdown);
                list_button_sub_world3.Add(bTmp);
                panel_world3.Controls.Add(list_button_sub_world3[i]);
                list_button_sub_world3[i].Location = new Point(controlOffset, i * yButtonSize + controlOffset * (i + 1));

            }
            //World 4 Button
            panel_world4 = new Panel();
            panel_world4.Size = new Size(xPanelSize, yPanelSize);
            panel_world4.Location = new Point(2*controlOffset + xPanelSize, 2*controlOffset + yPanelSize);
            panel_world4.Tag = 4;
            panel_world4.BackColor = Color.Transparent;

            list_button_sub_world4 = new List<Button>(numSubWorlds);
            for (int i = 0; i < numSubWorlds; ++i)
            {
                Button bTmp = new Button();
                bTmp.Text = "Dinosaur - World " + (i + 1);
                bTmp.TextAlign = ContentAlignment.MiddleCenter;
                bTmp.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bTmp.Size = new Size(xButtonSize, yButtonSize);
                bTmp.Tag = i + 1;
                bTmp.Click += new EventHandler(level_countdown);
                list_button_sub_world4.Add(bTmp);
                panel_world4.Controls.Add(list_button_sub_world4[i]);
                list_button_sub_world4[i].Location = new Point(controlOffset, i * yButtonSize + controlOffset * (i + 1));

            }

            this.Controls.Add(panel_world1);
            this.Controls.Add(panel_world2);
            this.Controls.Add(panel_world3);
            this.Controls.Add(panel_world4);

        }
       
        /// <summary>
        /// Begins "Ready, Set..., GO!" message. then moves to world_startGame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void level_countdown(object sender, EventArgs e)
        {
            gameMode = Convert.ToInt32(((Control)sender).Parent.Tag);
            subMode = Convert.ToInt32(sender.GetType().GetProperty("Tag").GetValue(sender));
            //Also need to grab sub-mode from button sender as well

            //May need to throw this into another method
            panel_world1.Hide();
            panel_world2.Hide();
            panel_world3.Hide();
            panel_world4.Hide();

            gameMain.ActiveForm.BackgroundImage = null;
            label_countDown = new Label();
            label_countDown.AutoSize = true;
            label_countDown.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_countDown.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right));
            label_countDown.ForeColor = Color.Red;
            label_countDown.Text = "Ready";

            //Sets location to center of form in realtion to the size of the label
            //Need to adjust the location everytime its updated or fix the label size to largest string and center text within label
            label_countDown.Location = new Point(gameMain.ActiveForm.Width / 2 - (label_countDown.Width), gameMain.ActiveForm.Height / 2 - (label_countDown.Height));
            
            //Add label to form
            this.Controls.Add(label_countDown);

            //Timer setup for countdown label
            count = 1;
            timer_countDownLabel = new System.Windows.Forms.Timer();
            timer_countDownLabel.Tick += new EventHandler(labelTimer_tick);
            timer_countDownLabel.Disposed += new EventHandler(world_startGame);
            timer_countDownLabel.Interval = 1000;
            timer_countDownLabel.Enabled = true;

        }

        /// <summary>
        /// Timer for the "Ready, Set..., GO!" message before level starts. 
        /// </summary>
        private void labelTimer_tick(object sender, EventArgs e)
        {
            
            if (count >= 3)
            {
                timer_countDownLabel.Dispose();
            }

            switch (count)
            {
                case 1:
                    this.label_countDown.Text = "Set...";
                    break;
                case 2:
                    this.label_countDown.Text = "Go!";
                    break;
                default:
                    break;
            }
            count++;

        }
       
        /// <summary>
        /// Creates the buttons for the chosen level and initializes the timer for the level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void world_startGame(object sender, EventArgs e)
        {

            label_countDown.Visible = false;
            
            game = new gamePlay(this, 4, gameMode, 1); //For testing using a 4x4 grid, 1 and 1 are passed to simulate world 1 level 1

            timer_game = new System.Windows.Forms.Timer();
            timer_game.Tick += new EventHandler((s,ee)=>timer_Tick(s,ee,timer_game));
            timer_game.Disposed += new EventHandler(results);
            timer_game.Interval = 1000;
            timer_game.Start();

        }

        /// <summary>
        /// Timer for the levels. Once the level ends, it'll move to the results page.
        /// </summary>
        /// <param name="sender">This would be the control that called this event</param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e, System.Windows.Forms.Timer gT)
        {
            if(game.timer <= 1)
            {
                timer_game.Dispose();
            }

            game.gameTick(gT);
        }

        /// <summary>
        /// Shows the player's score, whether they win/lose, and the top 10 on the leaderboard for the current level.
        /// </summary>
        /// <param name="sender">Reference to method that calls this event</param>
        /// <param name="e"></param>
        public void results(object sender, EventArgs e)
        {
            game.hideGameControls();

           //Creates a panel for results of the game to show
            panel_results = new Panel();
            panel_results.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_results.Location = new System.Drawing.Point(0, 0);
            panel_results.Size = new System.Drawing.Size(gameMain.ActiveForm.Width,gameMain.ActiveForm.Height);
            panel_results.Visible = true;
            panel_results.BackColor = Color.AntiqueWhite;

            //Creates a label for player's final score
            label_score = new Label();
            label_score.AutoSize = true;
            label_score.BackColor = System.Drawing.Color.Transparent;
            label_score.Text = "Score: " + gamePlay.score.ToString();
            label_score.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_score.Location = new System.Drawing.Point(66, 114);
            label_score.Name = "label_score";
            label_score.Visible = true;
  

            //Indicates whether the player reached the needed score to move on 
            label_win_lose = new Label();
            label_win_lose.AutoSize = true;
            label_win_lose.BackColor = System.Drawing.Color.Transparent;
            label_win_lose.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_win_lose.ForeColor = System.Drawing.Color.Red;
            label_win_lose.Location = new System.Drawing.Point(196, 259);
            label_win_lose.Name = "label_win_lose";
            this.label_win_lose.Size = new System.Drawing.Size(286, 84);


            //Creates a button for the player to return the game modes page
            button_return = new Button();
            button_return.AutoSize = true;
            button_return.Size = new System.Drawing.Size(200, 100);
            button_return.Location = new Point(100, 400);
            button_return.Text = "Return";
            button_return.Font = new System.Drawing.Font("Comic Sans MS", 26F, FontStyle.Bold);
            button_return.Click += new EventHandler(button_start_Click);

            //Creates a button for the player to move onto the next levels
            button_continue = new Button();
            button_continue.AutoSize = true;
            button_continue.Size = new System.Drawing.Size(200, 100);
            button_continue.Location = new Point(400, 400);
            button_continue.Text = "Continue";
            button_continue.Font = new System.Drawing.Font("Comic Sans MS", 26F, FontStyle.Bold);

            //Add all created controls to panel
            panel_results.Controls.Add(button_return);
            panel_results.Controls.Add(button_continue);
            panel_results.Controls.Add(label_score);
            panel_results.Controls.Add(label_win_lose);

            //Add Panel to form
            this.Controls.Add(panel_results);
            label_win_lose.Show();
            label_score.Show();

            this.panel_results.BringToFront();
            
            //Depending on the player's score, it will say either they won or lost
            int passingScore = 1000;
            if (gamePlay.score >= passingScore)
            {
                label_win_lose.Text = "You Win!";
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(global::Mustache_ic___V2.Properties.Resources.WINNER);
                //player.Play();
               
            }
            else
            {
                label_win_lose.Text = "You Lose!";
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(global::Mustache_ic___V2.Properties.Resources.Price_Is_Right_loser_clip);
                //player.Play();
            }
        }


    }
    
}
