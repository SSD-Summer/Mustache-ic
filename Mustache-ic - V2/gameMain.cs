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

namespace Mustashe_ic
{
    public partial class gameMain : Form
    {
        //Controls for game menu
        System.Windows.Forms.Button button_worldsMode;
        System.Windows.Forms.Button button_endlessMode;
        System.Windows.Forms.Button button_world1;
       
        //Label associated with the count down before a game start
        System.Windows.Forms.Label label_countDown;
        
        //Controls associated with the results page shown after a completed game
        System.Windows.Forms.Panel panel_results;
        System.Windows.Forms.Label label_win_lose;
        System.Windows.Forms.Label label_score;
        System.Windows.Forms.Button button_return;
        System.Windows.Forms.Button button_continue;

        //Timers for game length and countDown label 
        System.Windows.Forms.Timer game_timer;
        System.Windows.Forms.Timer labelTimer;
        public int count;
        private int score = 0;

        gamePlay game;
        public gameMain()
        {
            InitializeComponent();
            tileClass.imageList();
            //gamePlay game = new gamePlay(this, 4, 1);


        }

        private void button_start_Click(object sender, EventArgs e)
        {

            //On Start click - Hide everything currently active on the form
            if ((Button)sender == button_start)
            {
                button_start.Hide();
                button_leaderboard.Hide();

                gameMain.ActiveForm.BackgroundImage = null;
            }
            if((Button)sender == button_return)
            {
                panel_results.Hide();
                button_return.Hide();
                button_continue.Hide();
            }
            
            //Start mode button drawing
            button_worldsMode = new Button();
            button_worldsMode.Text = "Worlds";
            button_worldsMode.Size = new Size(250, 390);
            button_worldsMode.AutoSize = true;
            button_worldsMode.Location = new Point(75, 144);
            button_worldsMode.Anchor = ((System.Windows.Forms.AnchorStyles)(AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top));
            button_worldsMode.Click += new System.EventHandler(worldButton_Click); //Bind button click event to worldButton_click function
            this.Controls.Add(button_worldsMode);


            button_endlessMode = new Button();
            button_endlessMode.Text = "Endless";
            button_endlessMode.Size = new Size(250, 390);
            button_endlessMode.AutoSize = true;
            button_endlessMode.Location = new Point(375, 144);
            button_endlessMode.Anchor = ((AnchorStyles)(AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom));
            this.Controls.Add(button_endlessMode);            
        }

        private void worldButton_Click(object sender, EventArgs e) //Loads world selection buttons 
        {
            button_worldsMode.Hide();
            button_endlessMode.Hide();
            button_world1 = new Button();
            button_world1.Text = "World 1";
            button_world1.Size = new Size(250, 195);
            button_world1.AutoSize = true;
            button_world1.Location = new Point(20, 20);
            button_world1.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left));
            //button_world1.Click += new System.EventHandler(world_startGame);
            button_world1.Click += new System.EventHandler(level_countdown);
            this.Controls.Add(button_world1);
        }
       
        /// <summary>
        /// begins "ready, set, go" message. then moves to world_startGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void level_countdown(object sender, EventArgs e)
        {
            button_world1.Hide();
            label_countDown = new Label();
            label_countDown.AutoSize = true;
            label_countDown.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_countDown.ForeColor = Color.Red;
            label_countDown.Text = "Ready";
            label_countDown.Location = new Point(300, 300);
            this.Controls.Add(label_countDown);

            count = 1;
            labelTimer = new Timer();
            labelTimer.Tick += new EventHandler(labelTimer_tick);
            labelTimer.Disposed += new EventHandler(world_startGame);
            labelTimer.Interval = 1000;
            labelTimer.Enabled = true;

        }

        /// <summary>
        /// timer for the "ready set go" message before level starts. 
        /// </summary>
        
        private void labelTimer_tick(object sender, EventArgs e)
        {
            if (count > 3)
            {
                labelTimer.Dispose();
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
                    //labelTimer.Enabled = false;
                    break;
            }
            count++;

        }
       
        private void world_startGame(object sender, EventArgs e)
        {

            label_countDown.Visible = false;
            game = new gamePlay(this, 3, 1);

            game_timer = new System.Windows.Forms.Timer();
            game_timer.Tick += new EventHandler(timer_Tick);
            game_timer.Disposed += new EventHandler(results);
            game_timer.Interval = 1000;
            game_timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(game.timer <= 1)
            {
                game_timer.Dispose();
                //game_timer.Stop();
                //Code for once a single round of gameplay is finished
            }

            game.gameTick();
        }

        /// <summary>
        /// Shows the player's score, whether they win/lose, and the top 10 on the leaderboard for the current level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void results(object sender, EventArgs e)
        {
            game.hideGameControls();
           //Creates a panel for results of the game to show
            panel_results = new Panel();
            panel_results.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_results.Location = new System.Drawing.Point(0, 0);
            panel_results.Size = new System.Drawing.Size(698, 715);
            panel_results.Visible = true;
            panel_results.BackColor = Color.AntiqueWhite;

            //Creates a label for player's final score
            label_score = new Label();
            label_score.AutoSize = true;
            label_score.BackColor = System.Drawing.Color.Transparent;
            label_score.Text = "Score: ";
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
            label_win_lose.Text = "You Win!";
            label_win_lose.Visible = true;

            button_return = new Button();
            button_return.AutoSize = true;
            button_return.Size = new System.Drawing.Size(200, 100);
            button_return.Location = new Point(100, 400);
            button_return.Text = "Return";
            button_return.Font = new System.Drawing.Font("Comic Sans MS", 26F, FontStyle.Bold);
            button_return.Click += new EventHandler(button_start_Click);

            button_continue = new Button();
            button_continue.AutoSize = true;
            button_continue.Size = new System.Drawing.Size(200, 100);
            button_continue.Location = new Point(400, 400);
            button_continue.Text = "Continue";
            button_continue.Font = new System.Drawing.Font("Comic Sans MS", 26F, FontStyle.Bold);

            panel_results.Controls.Add(button_return);
            panel_results.Controls.Add(button_continue);
            panel_results.Controls.Add(label_score);
            panel_results.Controls.Add(label_win_lose);
            this.Controls.Add(panel_results);
            label_win_lose.Show();
            label_score.Show();

            this.panel_results.BringToFront();
            
            //Depending on the player's score, it will say either they won or lost.
            int passingScore = 1000;
            if (score >= passingScore)
            {
                label_win_lose.Text = "You Win!"; 
            }
            else
            {
                label_win_lose.Text = "You Lose!";
            }
        }



    }
    
}
