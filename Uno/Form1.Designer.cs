namespace Uno
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            txtNome = new TextBox();
            pictureBox1 = new PictureBox();
            rbKaique1 = new RadioButton();
            rbCarol1 = new RadioButton();
            pictureBox2 = new PictureBox();
            panPlayer1 = new Panel();
            btnOk = new Button();
            label2 = new Label();
            panPlayer2 = new Panel();
            pictureBox13 = new PictureBox();
            rbKaique2 = new RadioButton();
            pictureBox14 = new PictureBox();
            rbCarol2 = new RadioButton();
            btnOk2 = new Button();
            label3 = new Label();
            txtNome2 = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panPlayer1.SuspendLayout();
            panPlayer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 57);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(85, 54);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(174, 23);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(94, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // rbKaique1
            // 
            rbKaique1.AutoSize = true;
            rbKaique1.Location = new Point(65, 130);
            rbKaique1.Name = "rbKaique1";
            rbKaique1.Size = new Size(14, 13);
            rbKaique1.TabIndex = 3;
            rbKaique1.TabStop = true;
            rbKaique1.UseVisualStyleBackColor = true;
            // 
            // rbCarol1
            // 
            rbCarol1.AutoSize = true;
            rbCarol1.Location = new Point(185, 130);
            rbCarol1.Name = "rbCarol1";
            rbCarol1.Size = new Size(14, 13);
            rbCarol1.TabIndex = 5;
            rbCarol1.TabStop = true;
            rbCarol1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(214, 100);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(75, 82);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // panPlayer1
            // 
            panPlayer1.Controls.Add(btnOk);
            panPlayer1.Controls.Add(label2);
            panPlayer1.Controls.Add(txtNome);
            panPlayer1.Controls.Add(label1);
            panPlayer1.Controls.Add(pictureBox1);
            panPlayer1.Controls.Add(rbKaique1);
            panPlayer1.Controls.Add(pictureBox2);
            panPlayer1.Controls.Add(rbCarol1);
            panPlayer1.Location = new Point(12, 12);
            panPlayer1.Name = "panPlayer1";
            panPlayer1.Size = new Size(371, 197);
            panPlayer1.TabIndex = 22;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(280, 54);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 23;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 19);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 22;
            label2.Text = "Player 1";
            // 
            // panPlayer2
            // 
            panPlayer2.Controls.Add(pictureBox13);
            panPlayer2.Controls.Add(rbKaique2);
            panPlayer2.Controls.Add(pictureBox14);
            panPlayer2.Controls.Add(rbCarol2);
            panPlayer2.Controls.Add(btnOk2);
            panPlayer2.Controls.Add(label3);
            panPlayer2.Controls.Add(txtNome2);
            panPlayer2.Controls.Add(label4);
            panPlayer2.Location = new Point(12, 12);
            panPlayer2.Name = "panPlayer2";
            panPlayer2.Size = new Size(371, 197);
            panPlayer2.TabIndex = 23;
            panPlayer2.Visible = false;
            // 
            // pictureBox13
            // 
            pictureBox13.Image = (Image)resources.GetObject("pictureBox13.Image");
            pictureBox13.Location = new Point(94, 100);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(75, 82);
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.TabIndex = 32;
            pictureBox13.TabStop = false;
            // 
            // rbKaique2
            // 
            rbKaique2.AutoSize = true;
            rbKaique2.Location = new Point(65, 130);
            rbKaique2.Name = "rbKaique2";
            rbKaique2.Size = new Size(14, 13);
            rbKaique2.TabIndex = 33;
            rbKaique2.TabStop = true;
            rbKaique2.UseVisualStyleBackColor = true;
            // 
            // pictureBox14
            // 
            pictureBox14.Image = (Image)resources.GetObject("pictureBox14.Image");
            pictureBox14.Location = new Point(214, 100);
            pictureBox14.Name = "pictureBox14";
            pictureBox14.Size = new Size(75, 82);
            pictureBox14.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox14.TabIndex = 34;
            pictureBox14.TabStop = false;
            // 
            // rbCarol2
            // 
            rbCarol2.AutoSize = true;
            rbCarol2.Location = new Point(185, 130);
            rbCarol2.Name = "rbCarol2";
            rbCarol2.Size = new Size(14, 13);
            rbCarol2.TabIndex = 35;
            rbCarol2.TabStop = true;
            rbCarol2.UseVisualStyleBackColor = true;
            // 
            // btnOk2
            // 
            btnOk2.Location = new Point(280, 54);
            btnOk2.Name = "btnOk2";
            btnOk2.Size = new Size(75, 23);
            btnOk2.TabIndex = 23;
            btnOk2.Text = "Ok";
            btnOk2.UseVisualStyleBackColor = true;
            btnOk2.Click += btnOk2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 19);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 22;
            label3.Text = "Player 2";
            // 
            // txtNome2
            // 
            txtNome2.Location = new Point(85, 54);
            txtNome2.Name = "txtNome2";
            txtNome2.Size = new Size(174, 23);
            txtNome2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 57);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 0;
            label4.Text = "Nome:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 223);
            Controls.Add(panPlayer1);
            Controls.Add(panPlayer2);
            Name = "Form1";
            Text = "Uno | Jogadores";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panPlayer1.ResumeLayout(false);
            panPlayer1.PerformLayout();
            panPlayer2.ResumeLayout(false);
            panPlayer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox14).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private PictureBox pictureBox1;
        private RadioButton rbKaique1;
        private RadioButton rbCarol1;
        private PictureBox pictureBox2;
        private Panel panPlayer1;
        private Label label2;
        private Button btnOk;
        private Panel panPlayer2;
        private Button btnOk2;
        private Label label3;
        private TextBox txtNome2;
        private Label label4;
        private PictureBox pictureBox13;
        private RadioButton rbKaique2;
        private PictureBox pictureBox14;
        private RadioButton rbCarol2;
    }
}
