using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mustashe_ic
{
    public partial class gameMain : Form
    {

        System.Windows.Forms.Button button_worldsMode;
        System.Windows.Forms.Button button_endlessMode;
        System.Windows.Forms.Button button_world1;

        System.Windows.Forms.Timer game_timer;

        gamePlay game;
        public gameMain()
        {
            InitializeComponent();
            //gamePlay game = new gamePlay(this, 4, 1);

        }

        private void button_start_Click(object sender, EventArgs e)
        {

            //On Start click - Hide everything currently active on the form
            button1.Hide();
            button2.Hide();
            label_GameTitleLabel.Hide();
            
            //Start mode button drawing
            button_worldsMode = new Button();
            button_worldsMode.Text = "Worlds";
            button_worldsMode.Size = new Size(250, 390);
            button_worldsMode.AutoSize = true;
            button_worldsMode.Location = new Point(5, 5);
            button_worldsMode.Anchor = ((System.Windows.Forms.AnchorStyles)(AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top));
            button_worldsMode.Click += new System.EventHandler(worldButton_Click); //Bind button click event to worldButton_click function
            this.Controls.Add(button_worldsMode);


            button_endlessMode = new Button();
            button_endlessMode.Text = "Endless";
            button_endlessMode.Size = new Size(250, 390);
            button_endlessMode.AutoSize = true;
            button_endlessMode.Location = new Point(255, 5);
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
            button_world1.Location = new Point(5, 5);
            button_world1.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left));
            button_world1.Click += new System.EventHandler(world_startGame);
            this.Controls.Add(button_world1);
        }
       
        private void world_startGame(object sender, EventArgs e)
        {
            button_world1.Hide();

            game = new gamePlay(this, 4, 1);

            game_timer = new Timer();
            game_timer.Tick += new EventHandler(timer_Tick);
            game_timer.Interval = 1000;
            game_timer.Start();

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

    }
}
