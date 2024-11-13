using Uno.Classes;

namespace Uno
{
    public partial class Form1 : Form
    {
        DadosPlayer dados = new DadosPlayer();

        public Form1()
        {
            InitializeComponent();

            this.BackColor = ColorTranslator.FromHtml("#C5BEB3");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text.Length > 0 && (rbKaique1.Checked || rbCarol1.Checked)))
            {
                if (rbKaique1.Checked)
                {
                    dados.Avatar1 = Properties.Resources.kaique;
                }
                else if (rbCarol1.Checked)
                {
                    dados.Avatar1 = Properties.Resources.carol;
                }

                dados.Player1 = txtNome.Text;
                panPlayer1.Visible = false;
                panPlayer2.Visible = true;
            }
            else
            {
                MessageBox.Show("Digite o nome e escolha um avatar!");
            }

            
        }

        private void btnOk2_Click(object sender, EventArgs e)
        {

            if ((txtNome2.Text.Length > 0 && (rbKaique2.Checked || rbCarol2.Checked)))
            {
                if (rbKaique2.Checked)
                {
                    dados.Avatar2 = Properties.Resources.kaique;
                }
                else if (rbCarol2.Checked)
                {
                    dados.Avatar2 = Properties.Resources.carol;
                }

                dados.Player2 = txtNome2.Text;
                new Uno(dados).Show();
            }
            else
            {
                MessageBox.Show("Digite o nome e escolha um avatar!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
