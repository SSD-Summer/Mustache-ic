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
//using System.Timers;

namespace Mustashe_ic
{
    public partial class gameMain : Form
    {

        System.Windows.Forms.Button button_worldsMode;
        System.Windows.Forms.Button button_endlessMode;
        System.Windows.Forms.Button button_world1;
        System.Windows.Forms.Panel panel_results;

        System.Windows.Forms.Timer game_timer;
        System.Windows.Forms.Timer labelTimer;
        System.Windows.Forms.Label countDown;
        private string ready = "Ready";
        private string set = "Set";
        private string go = "GO!";
        private int score = 0;
        
        gamePlay game;
        public gameMain()
        {
            InitializeComponent();
            //gamePlay game = new gamePlay(this, 4, 1);
            

        }

        private void button_start_Click(object sender, EventArgs e)
        {

            //On Start click - Hide everything currently active on the form
            button_start.Hide();
            button_leaderboard.Hide();
            gameMain.ActiveForm.BackgroundImage = null;
            
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
        bool countdown_done = false;
        /// <summary>
        /// begins "ready, set, go" message. then moves to world_startGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void level_countdown(object sender, EventArgs e)
        {
            button_world1.Hide();
            //countDown.AutoSize = true;
            //countDown.BackColor = System.Drawing.Color.Transparent;
            //countDown.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold);
            //countDown.Location = new System.Drawing.Point(235, 259);
            //countDown.Name = "label_countDown";
            //countDown.Size = new System.Drawing.Size(208, 84);
            //countDown.Text = "Ready";
            //this.Controls.Add(countDown);
            countDown.Visible = true;
            countDown.Text = ready;

            labelTimer = new Timer();
            labelTimer.Tick += new EventHandler(labelTimer_tick);
            labelTimer.Disposed += new EventHandler(world_startGame);
            labelTimer.Interval = 2000;
            labelTimer.Enabled = true;

            if (countdown_done == true) //doesn't get to this
            {
                countDown.Visible = false;
                //labelTimer. += new EventHandler(world_startGame); //is there a way to create an event with the timer?
            }
        }

        /// <summary>
        /// timer for the "ready set go" message before level starts. 
        /// </summary>
        private static int count = 1;
        private void labelTimer_tick(object sender, EventArgs e)
        {

            if (count > 3)
            {
                labelTimer.Dispose();
            }

            switch (count)
            {
                case 1:
                    this.countDown.Text = set;
                    break;
                case 2:
                    this.countDown.Text = go;
                    break;
                default:
                    //labelTimer.Enabled = false;
                    countdown_done = true;
                    break;
            }
            count++;

            

        }

       
        private void world_startGame(object sender, EventArgs e)
        {


            game = new gamePlay(this, 3, 1);

            game_timer = new System.Windows.Forms.Timer();
            game_timer.Tick += new EventHandler(timer_Tick);
            game_timer.Interval = 1000;
            game_timer.Start();

            if (game.timer == 0)
            {
               
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(game.timer <= 1)
            {
                game_timer.Stop();
                //Code for once a single round of gameplay is finished
            }

            game.gameTick();
        }

        private void results(object sender, EventArgs e)
        {
            int passingScore = 1000;
            panel_results = new Panel();
            panel_results.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_results.Location = new System.Drawing.Point(0, 0);
            panel_results.Size = new System.Drawing.Size(698, 715);
            panel_results.TabIndex = 4;
            this.Controls.Add(panel_results);

            System.Windows.Forms.Label label_score = new Label();
            System.Windows.Forms.Label label_win_lose = new Label();

            if (score >= passingScore)
            {
                label_win_lose.Name = "You Win!"; 
            }
            else
            {
                label_win_lose.Name = "You Lose!";
            }
        }



    }
}
