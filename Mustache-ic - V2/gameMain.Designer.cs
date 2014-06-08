namespace Mustashe_ic
{
    partial class gameMain
    {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameMain));
            this.button_start = new System.Windows.Forms.Button();
            this.button_leaderboard = new System.Windows.Forms.Button();
            this.imageList_animals = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(210, 151);
            this.button_start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(298, 106);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_leaderboard
            // 
            this.button_leaderboard.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_leaderboard.Location = new System.Drawing.Point(210, 317);
            this.button_leaderboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_leaderboard.Name = "button_leaderboard";
            this.button_leaderboard.Size = new System.Drawing.Size(298, 116);
            this.button_leaderboard.TabIndex = 2;
            this.button_leaderboard.Text = "Leaderboards";
            this.button_leaderboard.UseVisualStyleBackColor = true;
            // 
            // imageList_animals
            // 
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
            // 
            // gameMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mustache_ic___V2.Properties.Resources.title;
            this.ClientSize = new System.Drawing.Size(698, 715);
            this.Controls.Add(this.button_leaderboard);
            this.Controls.Add(this.button_start);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "gameMain";
            this.Text = "gameMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_leaderboard;
        private System.Windows.Forms.ImageList imageList_animals;
        private System.Windows.Forms.ImageList imageList;



    }
}