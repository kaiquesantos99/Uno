﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uno
{
    public partial class CuringaMaisQuatro : Form
    {
        public string resultado;

        public CuringaMaisQuatro()
        {
            InitializeComponent();
        }

        public string InputValue
        {
            get { return resultado; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (rbRed.Checked)
            {
                resultado = "Vermelho";
                this.Close();
            }
            else if (rbGreen.Checked)
            {
                resultado = "Verde";
                this.Close();
            }
            else if (rbBlue.Checked)
            {
                resultado = "Azul";
                this.Close();
            }
            else if (rbYellow.Checked)
            {
                resultado = "Amarelo";
                this.Close();
            }
            else
            {
                MessageBox.Show("Escolha uma cor e clique em confirmar!");
            }


        }

        private void rbRed_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
