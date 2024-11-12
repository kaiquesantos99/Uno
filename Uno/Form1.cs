using Uno.Classes;

namespace Uno
{
    public partial class Form1 : Form
    {
        DadosPlayer dados = new DadosPlayer();

        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dados.Player1 = txtNome.Text;

            if (rbKaique1.Checked)
            {
                dados.Avatar1 = Properties.Resources.kaique;
            }
            else if (rbCarol1.Checked)
            {
                dados.Avatar1 = Properties.Resources.carol;
            }

            panPlayer1.Visible = false;
            panPlayer2.Visible = true;
        }

        private void btnOk2_Click(object sender, EventArgs e)
        {
            dados.Player2 = txtNome2.Text;

            if (rbKaique2.Checked)
            {
                dados.Avatar2 = Properties.Resources.kaique;
            }
            else if (rbCarol2.Checked)
            {
                dados.Avatar2 = Properties.Resources.carol;
            }

            new Uno(dados).Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
