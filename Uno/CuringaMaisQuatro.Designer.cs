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
            label1 = new Label();
            btnConfirmar = new Button();
            groupBox1 = new GroupBox();
            rbYellow = new RadioButton();
            rbBlue = new RadioButton();
            rbGreen = new RadioButton();
            rbRed = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(395, 29);
            label1.TabIndex = 4;
            label1.Text = "ESCOLHA A PRÓXIMA COR";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(167, 219);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(75, 23);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbYellow);
            groupBox1.Controls.Add(rbBlue);
            groupBox1.Controls.Add(rbGreen);
            groupBox1.Controls.Add(rbRed);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(395, 127);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // rbYellow
            // 
            rbYellow.AutoSize = true;
            rbYellow.Location = new Point(295, 102);
            rbYellow.Name = "rbYellow";
            rbYellow.Size = new Size(54, 19);
            rbYellow.TabIndex = 3;
            rbYellow.TabStop = true;
            rbYellow.Text = "Verde";
            rbYellow.UseVisualStyleBackColor = true;
            // 
            // rbBlue
            // 
            rbBlue.AutoSize = true;
            rbBlue.Location = new Point(6, 102);
            rbBlue.Name = "rbBlue";
            rbBlue.Size = new Size(48, 19);
            rbBlue.TabIndex = 2;
            rbBlue.TabStop = true;
            rbBlue.Text = "Azul";
            rbBlue.UseVisualStyleBackColor = true;
            // 
            // rbGreen
            // 
            rbGreen.AutoSize = true;
            rbGreen.Location = new Point(295, 22);
            rbGreen.Name = "rbGreen";
            rbGreen.Size = new Size(70, 19);
            rbGreen.TabIndex = 1;
            rbGreen.TabStop = true;
            rbGreen.Text = "Amarelo";
            rbGreen.UseVisualStyleBackColor = true;
            // 
            // rbRed
            // 
            rbRed.AutoSize = true;
            rbRed.Location = new Point(6, 22);
            rbRed.Name = "rbRed";
            rbRed.Size = new Size(75, 19);
            rbRed.TabIndex = 0;
            rbRed.TabStop = true;
            rbRed.Text = "Vermelho";
            rbRed.UseVisualStyleBackColor = true;
            rbRed.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // CuringaMaisQuatro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 254);
            Controls.Add(groupBox1);
            Controls.Add(btnConfirmar);
            Controls.Add(label1);
            Name = "CuringaMaisQuatro";
            Text = "Carta Curinga - Cor";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Button btnConfirmar;
        private GroupBox groupBox1;
        private RadioButton rbRed;
        private RadioButton rbYellow;
        private RadioButton rbBlue;
        private RadioButton rbGreen;
    }
}