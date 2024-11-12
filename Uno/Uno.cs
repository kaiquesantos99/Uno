using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uno.Classes;

namespace Uno
{
    public partial class Uno : Form
    {
        List<Card> cartas = new List<Card>();

        List<Card> cartasPlayer1 = new List<Card>(); // Lista de cartas do jogador 1
        List<Card> cartasPlayer2 = new List<Card>(); // Lista de cartas do jogador 2


        // Atributos da partida
        private int valorCartaAtual;
        private string corCartaAtual;
        private bool vezPlayer1;

        // Atributos jogador 1
        private int qtdCartasPlayer1 = 7;

        // Atributos jogador 2
        private int qtdCartasPlayer2 = 7;

        public Uno(DadosPlayer d)
        {
            InitializeComponent();

            // Passo 1 - Definir os nomes e avatares dos jogadores
            lblPlayer1.Text = d.Player1;
            lblPlayer2.Text = d.Player2;
            pbAvatar1.Image = d.Avatar1;
            pbAvatar2.Image = d.Avatar2;

            // Passo 2 - Define a cor de fundo
            this.BackColor = ColorTranslator.FromHtml("#C5BEB3");

            // Passo 3 - Cria instância de todas as cartas do jogo e adiciona na lista

            // RedCard e Add List
            Card red0 = new Card { Cor = "Vermelho", Valor = 0, Imagem = Properties.Resources.red_0 }; cartas.Add(red0);
            Card red1 = new Card { Cor = "Vermelho", Valor = 1, Imagem = Properties.Resources.red_1 }; cartas.Add(red1); cartas.Add(red1);
            Card red2 = new Card { Cor = "Vermelho", Valor = 2, Imagem = Properties.Resources.red_2 }; cartas.Add(red2); cartas.Add(red2);
            Card red3 = new Card { Cor = "Vermelho", Valor = 3, Imagem = Properties.Resources.red_3 }; cartas.Add(red3); cartas.Add(red3);
            Card red4 = new Card { Cor = "Vermelho", Valor = 4, Imagem = Properties.Resources.red_4 }; cartas.Add(red4); cartas.Add(red4);
            Card red5 = new Card { Cor = "Vermelho", Valor = 5, Imagem = Properties.Resources.red_5 }; cartas.Add(red5); cartas.Add(red5);
            Card red6 = new Card { Cor = "Vermelho", Valor = 6, Imagem = Properties.Resources.red_6 }; cartas.Add(red6); cartas.Add(red6);
            Card red7 = new Card { Cor = "Vermelho", Valor = 7, Imagem = Properties.Resources.red_7 }; cartas.Add(red7); cartas.Add(red7);
            Card red8 = new Card { Cor = "Vermelho", Valor = 8, Imagem = Properties.Resources.red_8 }; cartas.Add(red8); cartas.Add(red8);
            Card red9 = new Card { Cor = "Vermelho", Valor = 9, Imagem = Properties.Resources.red_9 }; cartas.Add(red9); cartas.Add(red9);
            // RedCard Especial e Add List
            Card redInverter = new Card { Cor = "Vermelho", Valor = 69, Imagem = Properties.Resources.red_inverter }; cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); // 8 inverter
            Card redPular = new Card { Cor = "Vermelho", Valor = 24, Imagem = Properties.Resources.red_pular }; cartas.Add(redPular); cartas.Add(redPular); cartas.Add(redPular); cartas.Add(redPular); cartas.Add(redPular); cartas.Add(redPular); cartas.Add(redPular); cartas.Add(redPular); // 8 pular
            Card redMaisDois = new Card { Cor = "Vermelho", Valor = 22, Imagem = Properties.Resources.red_mais_2 }; cartas.Add(redMaisDois); cartas.Add(redMaisDois); cartas.Add(redMaisDois); cartas.Add(redMaisDois); cartas.Add(redMaisDois); cartas.Add(redMaisDois); cartas.Add(redMaisDois); cartas.Add(redMaisDois); // 8 mais 2

            // 4 coringas e 8 especiais coloridas

            // BlueCard e Add List
            Card blue0 = new Card { Cor = "Azul", Valor = 0, Imagem = Properties.Resources.blue_0 }; cartas.Add(blue0);
            Card blue1 = new Card { Cor = "Azul", Valor = 1, Imagem = Properties.Resources.blue_1 }; cartas.Add(blue1); cartas.Add(blue1);
            Card blue2 = new Card { Cor = "Azul", Valor = 2, Imagem = Properties.Resources.blue_2 }; cartas.Add(blue2); cartas.Add(blue2);
            Card blue3 = new Card { Cor = "Azul", Valor = 3, Imagem = Properties.Resources.blue_3 }; cartas.Add(blue3); cartas.Add(blue3);
            Card blue4 = new Card { Cor = "Azul", Valor = 4, Imagem = Properties.Resources.blue_4 }; cartas.Add(blue4); cartas.Add(blue4);
            Card blue5 = new Card { Cor = "Azul", Valor = 5, Imagem = Properties.Resources.blue_5 }; cartas.Add(blue5); cartas.Add(blue5);
            Card blue6 = new Card { Cor = "Azul", Valor = 6, Imagem = Properties.Resources.blue_6 }; cartas.Add(blue6); cartas.Add(blue6);
            Card blue7 = new Card { Cor = "Azul", Valor = 7, Imagem = Properties.Resources.blue_7 }; cartas.Add(blue7); cartas.Add(blue7);
            Card blue8 = new Card { Cor = "Azul", Valor = 8, Imagem = Properties.Resources.blue_8 }; cartas.Add(blue8); cartas.Add(blue8);
            Card blue9 = new Card { Cor = "Azul", Valor = 9, Imagem = Properties.Resources.blue_9 }; cartas.Add(blue9); cartas.Add(blue9);
            // BlueCard Especial e Add List
            Card blueInverter = new Card { Cor = "Azul", Valor = 69, Imagem = Properties.Resources.blue_inverter }; cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); // 8 inverter
            Card bluePular = new Card { Cor = "Azul", Valor = 24, Imagem = Properties.Resources.blue_pular }; cartas.Add(bluePular); cartas.Add(bluePular); cartas.Add(bluePular); cartas.Add(bluePular); cartas.Add(bluePular); cartas.Add(bluePular); cartas.Add(bluePular); cartas.Add(bluePular); // 8 pular
            Card blueMaisDois = new Card { Cor = "Azul", Valor = 22, Imagem = Properties.Resources.blue_mais_2 }; cartas.Add(blueMaisDois); cartas.Add(blueMaisDois); cartas.Add(blueMaisDois); cartas.Add(blueMaisDois); cartas.Add(blueMaisDois); cartas.Add(blueMaisDois); cartas.Add(blueMaisDois); cartas.Add(blueMaisDois); // 8 mais 2

            // GreenCard e Add List
            Card green0 = new Card { Cor = "Verde", Valor = 0, Imagem = Properties.Resources.green_0 }; cartas.Add(green0);
            Card green1 = new Card { Cor = "Verde", Valor = 1, Imagem = Properties.Resources.green_1 }; cartas.Add(green1); cartas.Add(green1);
            Card green2 = new Card { Cor = "Verde", Valor = 2, Imagem = Properties.Resources.green_2 }; cartas.Add(green2); cartas.Add(green2);
            Card green3 = new Card { Cor = "Verde", Valor = 3, Imagem = Properties.Resources.green_3 }; cartas.Add(green3); cartas.Add(green3);
            Card green4 = new Card { Cor = "Verde", Valor = 4, Imagem = Properties.Resources.green_4 }; cartas.Add(green4); cartas.Add(green4);
            Card green5 = new Card { Cor = "Verde", Valor = 5, Imagem = Properties.Resources.green_5 }; cartas.Add(green5); cartas.Add(green5);
            Card green6 = new Card { Cor = "Verde", Valor = 6, Imagem = Properties.Resources.green_6 }; cartas.Add(green6); cartas.Add(green6);
            Card green7 = new Card { Cor = "Verde", Valor = 7, Imagem = Properties.Resources.green_7 }; cartas.Add(green7); cartas.Add(green7);
            Card green8 = new Card { Cor = "Verde", Valor = 8, Imagem = Properties.Resources.green_8 }; cartas.Add(green8); cartas.Add(green8);
            Card green9 = new Card { Cor = "Verde", Valor = 9, Imagem = Properties.Resources.green_9 }; cartas.Add(green9); cartas.Add(green9);
            // GreenCard Especial e Add List
            Card greenInverter = new Card { Cor = "Verde", Valor = 69, Imagem = Properties.Resources.green_inverter }; cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); // 8 inverter
            Card greenPular = new Card { Cor = "Verde", Valor = 24, Imagem = Properties.Resources.green_pular }; cartas.Add(greenPular); cartas.Add(greenPular); cartas.Add(greenPular); cartas.Add(greenPular); cartas.Add(greenPular); cartas.Add(greenPular); cartas.Add(greenPular); cartas.Add(greenPular); // 8 pular
            Card greenMaisDois = new Card { Cor = "Verde", Valor = 22, Imagem = Properties.Resources.green_mais_2 }; cartas.Add(greenMaisDois); cartas.Add(greenMaisDois); cartas.Add(greenMaisDois); cartas.Add(greenMaisDois); cartas.Add(greenMaisDois); cartas.Add(greenMaisDois); cartas.Add(greenMaisDois); cartas.Add(greenMaisDois); // 8 mais 2

            // YellowCard e Add List
            Card yellow0 = new Card { Cor = "Amarelo", Valor = 0, Imagem = Properties.Resources.yellow_0 }; cartas.Add(yellow0);
            Card yellow1 = new Card { Cor = "Amarelo", Valor = 1, Imagem = Properties.Resources.yellow_1 }; cartas.Add(yellow1); cartas.Add(yellow1);
            Card yellow2 = new Card { Cor = "Amarelo", Valor = 2, Imagem = Properties.Resources.yellow_2 }; cartas.Add(yellow2); cartas.Add(yellow2);
            Card yellow3 = new Card { Cor = "Amarelo", Valor = 3, Imagem = Properties.Resources.yellow_3 }; cartas.Add(yellow3); cartas.Add(yellow3);
            Card yellow4 = new Card { Cor = "Amarelo", Valor = 4, Imagem = Properties.Resources.yellow_4 }; cartas.Add(yellow4); cartas.Add(yellow4);
            Card yellow5 = new Card { Cor = "Amarelo", Valor = 5, Imagem = Properties.Resources.yellow_5 }; cartas.Add(yellow5); cartas.Add(yellow5);
            Card yellow6 = new Card { Cor = "Amarelo", Valor = 6, Imagem = Properties.Resources.yellow_6 }; cartas.Add(yellow6); cartas.Add(yellow6);
            Card yellow7 = new Card { Cor = "Amarelo", Valor = 7, Imagem = Properties.Resources.yellow_7 }; cartas.Add(yellow7); cartas.Add(yellow7);
            Card yellow8 = new Card { Cor = "Amarelo", Valor = 8, Imagem = Properties.Resources.yellow_8 }; cartas.Add(yellow8); cartas.Add(yellow8);
            Card yellow9 = new Card { Cor = "Amarelo", Valor = 9, Imagem = Properties.Resources.yellow_9 }; cartas.Add(yellow9); cartas.Add(yellow9);
            // YellowCard Especial e Add List
            Card yellowInverter = new Card { Cor = "Amarelo", Valor = 69, Imagem = Properties.Resources.yellow_inverter }; cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); // 8 inverter
            Card yellowPular = new Card { Cor = "Amarelo", Valor = 24, Imagem = Properties.Resources.yellow_pular }; cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); // 8 pular
            Card yellowMaisDois = new Card { Cor = "Amarelo", Valor = 22, Imagem = Properties.Resources.yellow_mais_2 }; cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); // 8 mais 2


            // Cartas Curingas e Add List
            Card curinga = new Card { Cor = "Nulo", Valor = 157, Imagem = Properties.Resources.curinga }; cartas.Add(curinga); cartas.Add(curinga); cartas.Add(curinga); cartas.Add(curinga); // 4 curinga
            Card curingaMaisQuatro = new Card { Cor = "Nulo", Valor = 44, Imagem = Properties.Resources.curinga_mais_4 }; cartas.Add(curingaMaisQuatro); cartas.Add(curingaMaisQuatro); cartas.Add(curingaMaisQuatro); cartas.Add(curingaMaisQuatro); // 4 curinga +4




            // PLAYER 1
            // Gera cartas aleatórias para o player 1
            for (int c = 0; c <= 6; c++)
            {
                Random random = new Random();
                int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                cartasPlayer1.Add(cartas[aleatorio]);


                cartas.RemoveAt(aleatorio);


            }
            // Exibe as cartas do player1 no cenário
            pbCard1Player1.Image = cartasPlayer1[0].Imagem;
            pbCard2Player1.Image = cartasPlayer1[1].Imagem;
            pbCard3Player1.Image = cartasPlayer1[2].Imagem;
            pbCard4Player1.Image = cartasPlayer1[3].Imagem;
            pbCard5Player1.Image = cartasPlayer1[4].Imagem;
            pbCard6Player1.Image = cartasPlayer1[5].Imagem;
            pbCard7Player1.Image = cartasPlayer1[6].Imagem;

            // FIM PLAYER 2


            // PLAYER 2
            // Gera cartas aleatórias para o player 2
            for (int c = 0; c <= 6; c++)
            {
                Random random = new Random();
                int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                cartasPlayer2.Add(cartas[aleatorio]);


                cartas.RemoveAt(aleatorio);


            }
            // Exibe as cartas do player2 no cenário
            pbCard1Player2.Image = cartasPlayer2[0].Imagem;
            pbCard2Player2.Image = cartasPlayer2[1].Imagem;
            pbCard3Player2.Image = cartasPlayer2[2].Imagem;
            pbCard4Player2.Image = cartasPlayer2[3].Imagem;
            pbCard5Player2.Image = cartasPlayer2[4].Imagem;
            pbCard6Player2.Image = cartasPlayer2[5].Imagem;
            pbCard7Player2.Image = cartasPlayer2[6].Imagem;

            // FIM PLAYER 2


            // Gera a carta do inicio do jogo
            bool cartaInicial = false;
            while (!cartaInicial)
            {
                Random random = new Random();
                int aleatorio = (int)random.NextInt64(1, (cartas.Count - 1));
                Card carta = new Card();
                carta = cartas[aleatorio];

                if (carta.Valor >= 0 && carta.Valor <= 9)
                {
                    cartaInicial = true;
                    cartas.RemoveAt(aleatorio);
                    pbMonteDescarte.Image = carta.Imagem;
                    valorCartaAtual = carta.Valor;
                    corCartaAtual = carta.Cor;
                }
            }





        }

        private void Uno_Load(object sender, EventArgs e)
        {

        }

        private void lblPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void pbAvatar1_Click(object sender, EventArgs e)
        {

        }

        private void pbCard1Player2_Click(object sender, EventArgs e)
        {
            if (cartasPlayer2[0].Valor == valorCartaAtual || cartasPlayer2[0].Cor == corCartaAtual)
            {
                pbMonteDescarte.Image = cartasPlayer2[0].Imagem;
                valorCartaAtual = cartasPlayer2[0].Valor;
                corCartaAtual = cartasPlayer2[0].Cor;
                cartasPlayer2.RemoveAt(0);

                pbCard1Player2.Image = null;
                pbCard1Player2.Visible = false;

                qtdCartasPlayer2--;

                if (qtdCartasPlayer2 == 0)
                {
                    MessageBox.Show("Fim de jogo!");
                }
            }
            else
            {
                MessageBox.Show("Você não pode jogar esta carta!");
            }
        }
    }
}
