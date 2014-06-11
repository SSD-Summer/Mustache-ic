namespace Mustashe_ic
{
    partial class gameMain
    {
        public System.Windows.Forms.ImageList imageList;

        private System.Windows.Forms.Button button_leaderboard;

        private System.Windows.Forms.Button button_start;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_start = new System.Windows.Forms.Button();
            this.button_leaderboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(177, 196);
            this.button_start.Margin = new System.Windows.Forms.Padding(4);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(328, 143);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_leaderboard
            // 
            this.button_leaderboard.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_leaderboard.Location = new System.Drawing.Point(120, 379);
            this.button_leaderboard.Margin = new System.Windows.Forms.Padding(4);
            this.button_leaderboard.Name = "button_leaderboard";
            this.button_leaderboard.Size = new System.Drawing.Size(448, 108);
            this.button_leaderboard.TabIndex = 2;
            this.button_leaderboard.Text = "Leaderboards";
            this.button_leaderboard.UseVisualStyleBackColor = true;
            // 
            // gameMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Mustache_ic___V2.Properties.Resources.title;
            this.ClientSize = new System.Drawing.Size(699, 719);
            this.Controls.Add(this.button_leaderboard);
            this.Controls.Add(this.button_start);
            this.Location = new System.Drawing.Point(200, 200);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(715, 790);
            this.MinimumSize = new System.Drawing.Size(715, 726);
            this.Name = "gameMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
    }
}