namespace Uno
{
    partial class CuringaMaisQuatro
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
            rbRed = new RadioButton();
            rbGreen = new RadioButton();
            rbBlue = new RadioButton();
            rbYellow = new RadioButton();
            label1 = new Label();
            btnConfirmar = new Button();
            SuspendLayout();
            // 
            // rbRed
            // 
            rbRed.AutoSize = true;
            rbRed.Location = new Point(110, 100);
            rbRed.Name = "rbRed";
            rbRed.Size = new Size(75, 19);
            rbRed.TabIndex = 0;
            rbRed.TabStop = true;
            rbRed.Text = "Vermelho";
            rbRed.UseVisualStyleBackColor = true;
            // 
            // rbGreen
            // 
            rbGreen.AutoSize = true;
            rbGreen.Location = new Point(236, 100);
            rbGreen.Name = "rbGreen";
            rbGreen.Size = new Size(54, 19);
            rbGreen.TabIndex = 1;
            rbGreen.TabStop = true;
            rbGreen.Text = "Verde";
            rbGreen.UseVisualStyleBackColor = true;
            // 
            // rbBlue
            // 
            rbBlue.AutoSize = true;
            rbBlue.Location = new Point(110, 160);
            rbBlue.Name = "rbBlue";
            rbBlue.Size = new Size(48, 19);
            rbBlue.TabIndex = 2;
            rbBlue.TabStop = true;
            rbBlue.Text = "Azul";
            rbBlue.UseVisualStyleBackColor = true;
            // 
            // rbYellow
            // 
            rbYellow.AutoSize = true;
            rbYellow.Location = new Point(236, 160);
            rbYellow.Name = "rbYellow";
            rbYellow.Size = new Size(70, 19);
            rbYellow.TabIndex = 3;
            rbYellow.TabStop = true;
            rbYellow.Text = "Amarelo";
            rbYellow.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(395, 29);
            label1.TabIndex = 4;
            label1.Text = "ESCOLHA A COR A SER JOGADA";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(163, 203);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(75, 23);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += button1_Click;
            // 
            // CuringaMaisQuatro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 254);
            Controls.Add(btnConfirmar);
            Controls.Add(label1);
            Controls.Add(rbYellow);
            Controls.Add(rbBlue);
            Controls.Add(rbGreen);
            Controls.Add(rbRed);
            Name = "CuringaMaisQuatro";
            Text = "Carta Curinga - Cor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbRed;
        private RadioButton rbGreen;
        private RadioButton rbBlue;
        private RadioButton rbYellow;
        private Label label1;
        private Button btnConfirmar;
    }
}