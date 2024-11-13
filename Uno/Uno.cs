﻿using System;
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
        List<Card> cartas = new List<Card>(); // Lista com todas as 108 cartas disponíveis no jogo

        List<Card> cartasPlayer1 = new List<Card>(); // Lista de cartas do jogador 1
        List<Card> cartasPlayer2 = new List<Card>(); // Lista de cartas do jogador 2

        List<PictureBox> espacosPlayer1 = new List<PictureBox>(); // Lista de espaços na mesa jogador 1
        List<PictureBox> espacosPlayer2 = new List<PictureBox>(); // Lista de espaços na mesa jogador 2


        // Atributos da partida
        private int valorCartaAtual;
        private string corCartaAtual;
        private bool vezPlayer1 = true;
        private bool primeiraJogada = true;
        private bool fimRodada = false;
        private bool fimPartida = false;

        private int valorCartaComprada = 11; // 11 é o valor nulo
        private string corCartaComprada;

        // Atributos jogador 1
        private int qtdCartasPlayer1 = 7;
        private bool comprouPlayer1 = false;

        // Atributos jogador 2
        private int qtdCartasPlayer2 = 7;
        private bool comprouPlayer2 = false;

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
            //Card redInverter = new Card { Cor = "Vermelho", Valor = 69, Imagem = Properties.Resources.red_inverter }; cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); cartas.Add(redInverter); // 8 inverter
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
            //Card blueInverter = new Card { Cor = "Azul", Valor = 69, Imagem = Properties.Resources.blue_inverter }; cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); cartas.Add(blueInverter); // 8 inverter
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
            //Card greenInverter = new Card { Cor = "Verde", Valor = 69, Imagem = Properties.Resources.green_inverter }; cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); cartas.Add(greenInverter); // 8 inverter
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
            //Card yellowInverter = new Card { Cor = "Amarelo", Valor = 69, Imagem = Properties.Resources.yellow_inverter }; cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); cartas.Add(yellowInverter); // 8 inverter
            Card yellowPular = new Card { Cor = "Amarelo", Valor = 24, Imagem = Properties.Resources.yellow_pular }; cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); cartas.Add(yellowPular); // 8 pular
            Card yellowMaisDois = new Card { Cor = "Amarelo", Valor = 22, Imagem = Properties.Resources.yellow_mais_2 }; cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); cartas.Add(yellowMaisDois); // 8 mais 2


            // Cartas Curingas e Add List
            Card curinga = new Card { Cor = "Nulo", Valor = 157, Imagem = Properties.Resources.curinga }; cartas.Add(curinga); cartas.Add(curinga); cartas.Add(curinga); cartas.Add(curinga); // 4 curinga
            Card curingaMaisQuatro = new Card { Cor = "Nulo", Valor = 44, Imagem = Properties.Resources.curinga_mais_4 }; cartas.Add(curingaMaisQuatro); cartas.Add(curingaMaisQuatro); cartas.Add(curingaMaisQuatro); cartas.Add(curingaMaisQuatro); // 4 curinga +4


            // Adiciona todos os espaços da mesa do player 1 na lista de espaços
            espacosPlayer1.Add(pbCard1Player1);
            espacosPlayer1.Add(pbCard2Player1);
            espacosPlayer1.Add(pbCard3Player1);
            espacosPlayer1.Add(pbCard4Player1);
            espacosPlayer1.Add(pbCard5Player1);
            espacosPlayer1.Add(pbCard6Player1);
            espacosPlayer1.Add(pbCard7Player1);
            espacosPlayer1.Add(pbCard8Player1);
            espacosPlayer1.Add(pbCard9Player1);
            espacosPlayer1.Add(pbCard10Player1);
            espacosPlayer1.Add(pbCard11Player1);
            espacosPlayer1.Add(pbCard12Player1);
            espacosPlayer1.Add(pbCard13Player1);
            espacosPlayer1.Add(pbCard14Player1);
            espacosPlayer1.Add(pbCard15Player1);
            espacosPlayer1.Add(pbCard16Player1);
            espacosPlayer1.Add(pbCard17Player1);
            espacosPlayer1.Add(pbCard18Player1);
            espacosPlayer1.Add(pbCard19Player1);
            espacosPlayer1.Add(pbCard20Player1);
            espacosPlayer1.Add(pbCard21Player1);
            espacosPlayer1.Add(pbCard22Player1);
            espacosPlayer1.Add(pbCard23Player1);
            espacosPlayer1.Add(pbCard24Player1);
            espacosPlayer1.Add(pbCard25Player1);
            espacosPlayer1.Add(pbCard26Player1);
            espacosPlayer1.Add(pbCard27Player1);
            espacosPlayer1.Add(pbCard28Player1);
            espacosPlayer1.Add(pbCard29Player1);
            espacosPlayer1.Add(pbCard30Player1);

            // Adiciona todos os espaços da mesa do player 2 na lista de espaços
            espacosPlayer2.Add(pbCard1Player2);
            espacosPlayer2.Add(pbCard2Player2);
            espacosPlayer2.Add(pbCard3Player2);
            espacosPlayer2.Add(pbCard4Player2);
            espacosPlayer2.Add(pbCard5Player2);
            espacosPlayer2.Add(pbCard6Player2);
            espacosPlayer2.Add(pbCard7Player2);
            espacosPlayer2.Add(pbCard8Player2);
            espacosPlayer2.Add(pbCard9Player2);
            espacosPlayer2.Add(pbCard10Player2);
            espacosPlayer2.Add(pbCard11Player2);
            espacosPlayer2.Add(pbCard12Player2);
            espacosPlayer2.Add(pbCard13Player2);
            espacosPlayer2.Add(pbCard14Player2);
            espacosPlayer2.Add(pbCard15Player2);
            espacosPlayer2.Add(pbCard16Player2);
            espacosPlayer2.Add(pbCard17Player2);
            espacosPlayer2.Add(pbCard18Player2);
            espacosPlayer2.Add(pbCard19Player2);
            espacosPlayer2.Add(pbCard20Player2);
            espacosPlayer2.Add(pbCard21Player2);
            espacosPlayer2.Add(pbCard22Player2);
            espacosPlayer2.Add(pbCard23Player2);
            espacosPlayer2.Add(pbCard24Player2);
            espacosPlayer2.Add(pbCard25Player2);
            espacosPlayer2.Add(pbCard26Player2);
            espacosPlayer2.Add(pbCard27Player2);
            espacosPlayer2.Add(pbCard28Player2);
            espacosPlayer2.Add(pbCard29Player2);
            espacosPlayer2.Add(pbCard30Player2);


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
            if (vezPlayer1)
            {
                if (tlpMesaPlayer1.Visible)
                {
                    tlpMesaPlayer1.Visible = false;
                }
                else
                {
                    tlpMesaPlayer1.Visible = true;
                }
            }
        }

        private void pbCard1Player2_Click(object sender, EventArgs e)
        {
            int carta = 0;
            if (!fimRodada)
            {
                if (!vezPlayer1)
                {
                    if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 1 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        if (cartasPlayer2[carta].Valor == valorCartaComprada && cartasPlayer2[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player2.Image = null;
                                    pbCard1Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = true;
                                            qtdCartasPlayer1++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                            if (qtdCartasPlayer1 == 0)
                                            {
                                                fimRodada = true;
                                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                            }

                                            if (primeiraJogada)
                                            {
                                                primeiraJogada = false;
                                            }
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard1Player2.Image = null;
                                pbCard1Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }

                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                                comprouPlayer2 = false;
                                vezPlayer1 = true; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer2[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player2.Image = null;
                                    pbCard1Player2.Visible = false;

                                    // Jogador 1 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);



                                            qtdCartasPlayer1++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = false;
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 1 ganha mais 2 cartas


                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player2.Image = null;
                                    pbCard1Player2.Visible = false;

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer2 = false;
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player2.Image = null;
                                    pbCard1Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    comprouPlayer2 = false;
                                    vezPlayer1 = true; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer2 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard1Player2.Image = null;
                                pbCard1Player2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                            cartasPlayer1[carta] = null;

                            pbCard1Player2.Image = null;
                            pbCard1Player2.Visible = false;

                            qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer2.Visible = false;
                            vezPlayer1 = true; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer2[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard1Player2.Image = null;
                                pbCard1Player2.Visible = false;

                                // Jogador 1 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 1 ganha mais 2 cartas


                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard1Player2.Image = null;
                                pbCard1Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard1Player2.Image = null;
                                pbCard1Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = true; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer2 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 1!");
                }
            }



        }

        private void pictureBox2_Click(object sender, EventArgs e) // Monte de compras
        {
            if (!fimRodada) // Se a partida não tiver acabado
            {
                if (!primeiraJogada) // Se não for a primeira jogada
                {
                    if (vezPlayer1) // Se for a vez do player 1
                    {
                        if (!comprouPlayer1) // Se não comprou carta ainda
                        {
                            for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                            {
                                if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                {
                                    espacosPlayer1[c].Visible = true;

                                    Random random = new Random();
                                    int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                    espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                    espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                    if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                    {
                                        cartasPlayer1.Add(cartas[aleatorio]);
                                    }
                                    else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                    {
                                        cartasPlayer1[c] = cartas[aleatorio];
                                    }



                                    valorCartaComprada = cartas[aleatorio].Valor;
                                    corCartaComprada = cartas[aleatorio].Cor;
                                    cartas.RemoveAt(aleatorio);

                                    comprouPlayer1 = true;
                                    comprouPlayer2 = false;

                                    qtdCartasPlayer1++;
                                    btnPassaVez.Visible = true;

                                    break;
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Você não pode comprar mais de uma carta!");
                        }


                    }
                    else // Se for a vez do player 2
                    {
                        if (!comprouPlayer2) // Se não comprou carta ainda
                        {
                            for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                            {
                                if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                {
                                    espacosPlayer2[c].Visible = true;

                                    Random random = new Random();
                                    int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                    espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                    espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                    if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                    {
                                        cartasPlayer2.Add(cartas[aleatorio]);
                                    }
                                    else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                    {
                                        cartasPlayer2[c] = cartas[aleatorio];
                                    }


                                    valorCartaComprada = cartas[aleatorio].Valor;
                                    corCartaComprada = cartas[aleatorio].Cor;
                                    cartas.RemoveAt(aleatorio);

                                    comprouPlayer2 = true;
                                    comprouPlayer1 = false;

                                    qtdCartasPlayer2++;
                                    btnPassaVez.Visible = true;

                                    break;
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Você não pode comprar mais de uma carta!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Como você irá dar início a partida, você não pode comprar de imediato!");
                }

            }


        }

        private void pbMonteDescarte_Click(object sender, EventArgs e)
        {

        }

        private void pbCard1Player1_Click(object sender, EventArgs e)
        {
            int carta = 0;
            if (!fimRodada) // Se não for o fim da rodada
            {
                if (vezPlayer1) // Se for a vez do jogador 1
                {
                    if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 2 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        if (cartasPlayer1[carta].Valor == valorCartaComprada && cartasPlayer1[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player1.Image = null;
                                    pbCard1Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);


                                            tlpMesaPlayer1.Visible = false;
                                            btnPassaVez.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard1Player1.Image = null;
                                pbCard1Player1.Visible = false;

                                tlpMesaPlayer1.Visible = false;
                                btnPassaVez.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }
                                comprouPlayer1 = false;
                                vezPlayer1 = false; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer1[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player1.Image = null;
                                    pbCard1Player1.Visible = false;

                                    // Jogador 2 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer1.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 2 ganha mais 2 cartas


                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player1.Image = null;
                                    pbCard1Player1.Visible = false;

                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;
                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer1 = false;
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard1Player1.Image = null;
                                    pbCard1Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;

                                    comprouPlayer1 = false;
                                    vezPlayer1 = false; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard1Player1.Image = null;
                                pbCard1Player1.Visible = false;

                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador


                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);

                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer1.Visible = false;
                                        qtdCartasPlayer2++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                        if (qtdCartasPlayer1 == 0)
                                        {
                                            fimRodada = true;
                                            MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                        }

                                        if (primeiraJogada)
                                        {
                                            primeiraJogada = false;
                                        }

                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                            cartasPlayer1[carta] = null;

                            pbCard1Player1.Image = null;
                            pbCard1Player1.Visible = false;

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer1.Visible = false;
                            qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }

                            vezPlayer1 = false; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer1[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard1Player1.Image = null;
                                pbCard1Player1.Visible = false;

                                // Jogador 2 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);



                                        qtdCartasPlayer2++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 2 ganha mais 2 cartas

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard1Player1.Image = null;
                                pbCard1Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard1Player1.Image = null;
                                pbCard1Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = false; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 2!");
                }
            }

        }

        private void btnPassaVez_Click(object sender, EventArgs e)
        {
            if (vezPlayer1)
            {
                vezPlayer1 = false;
                tlpMesaPlayer1.Visible = false;
                btnPassaVez.Visible = false;
                MessageBox.Show("Passa a vez para o jogador 2!");
                valorCartaComprada = 11;
                corCartaComprada = null;
                comprouPlayer1 = false;
            }
            else
            {
                tlpMesaPlayer2.Visible = false;
                vezPlayer1 = true;
                btnPassaVez.Visible = false;
                MessageBox.Show("Passa a vez para o jogador 1!");
                valorCartaComprada = 11;
                corCartaComprada = null;
                comprouPlayer2 = false;
            }

        }

        private void pbCard2Player1_Click(object sender, EventArgs e)
        {
            int carta = 1;
            if (!fimRodada) // Se não for o fim da rodada
            {
                if (vezPlayer1) // Se for a vez do jogador 1
                {
                    if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 2 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        if (cartasPlayer1[carta].Valor == valorCartaComprada && cartasPlayer1[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player1.Image = null;
                                    pbCard2Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);


                                            tlpMesaPlayer1.Visible = false;
                                            btnPassaVez.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard2Player1.Image = null;
                                pbCard2Player1.Visible = false;

                                tlpMesaPlayer1.Visible = false;
                                btnPassaVez.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }
                                comprouPlayer1 = false;
                                vezPlayer1 = false; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer1[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player1.Image = null;
                                    pbCard2Player1.Visible = false;

                                    // Jogador 2 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer1.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 2 ganha mais 2 cartas


                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player1.Image = null;
                                    pbCard2Player1.Visible = false;

                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;
                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer1 = false;
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player1.Image = null;
                                    pbCard2Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;

                                    comprouPlayer1 = false;
                                    vezPlayer1 = false; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard2Player1.Image = null;
                                pbCard2Player1.Visible = false;

                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador


                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);

                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer1.Visible = false;
                                        qtdCartasPlayer2++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                        if (qtdCartasPlayer1 == 0)
                                        {
                                            fimRodada = true;
                                            MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                        }

                                        if (primeiraJogada)
                                        {
                                            primeiraJogada = false;
                                        }

                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                            cartasPlayer1[carta] = null;

                            pbCard2Player1.Image = null;
                            pbCard2Player1.Visible = false;

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer1.Visible = false;
                            qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }

                            vezPlayer1 = false; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer1[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard2Player1.Image = null;
                                pbCard2Player1.Visible = false;

                                // Jogador 2 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);



                                        qtdCartasPlayer2++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 2 ganha mais 2 cartas

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard2Player1.Image = null;
                                pbCard2Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard2Player1.Image = null;
                                pbCard2Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = false; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 2!");
                }
            }


        }

        private void pbCard3Player1_Click(object sender, EventArgs e)
        {
            int carta = 2;
            if (!fimRodada) // Se não for o fim da rodada
            {
                if (vezPlayer1) // Se for a vez do jogador 1
                {
                    if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 2 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        if (cartasPlayer1[carta].Valor == valorCartaComprada && cartasPlayer1[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player1.Image = null;
                                    pbCard3Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);


                                            tlpMesaPlayer1.Visible = false;
                                            btnPassaVez.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard3Player1.Image = null;
                                pbCard3Player1.Visible = false;

                                tlpMesaPlayer1.Visible = false;
                                btnPassaVez.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }
                                comprouPlayer1 = false;
                                vezPlayer1 = false; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer1[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player1.Image = null;
                                    pbCard3Player1.Visible = false;

                                    // Jogador 2 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer1.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 2 ganha mais 2 cartas


                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player1.Image = null;
                                    pbCard3Player1.Visible = false;

                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;
                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer1 = false;
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player1.Image = null;
                                    pbCard3Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;

                                    comprouPlayer1 = false;
                                    vezPlayer1 = false; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard3Player1.Image = null;
                                pbCard3Player1.Visible = false;

                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador


                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);

                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer1.Visible = false;
                                        qtdCartasPlayer2++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                        if (qtdCartasPlayer1 == 0)
                                        {
                                            fimRodada = true;
                                            MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                        }

                                        if (primeiraJogada)
                                        {
                                            primeiraJogada = false;
                                        }

                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                            cartasPlayer1[carta] = null;

                            pbCard3Player1.Image = null;
                            pbCard3Player1.Visible = false;

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer1.Visible = false;
                            qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }

                            vezPlayer1 = false; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer1[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard3Player1.Image = null;
                                pbCard3Player1.Visible = false;

                                // Jogador 2 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);



                                        qtdCartasPlayer2++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 2 ganha mais 2 cartas

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard3Player1.Image = null;
                                pbCard3Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard3Player1.Image = null;
                                pbCard3Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = false; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 2!");
                }
            }

        }

        private void pbCard2Player2_Click(object sender, EventArgs e)
        {
            int carta = 1;
            if (!fimRodada)
            {
                if (!vezPlayer1)
                {
                    if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 1 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        if (cartasPlayer2[carta].Valor == valorCartaComprada && cartasPlayer2[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player2.Image = null;
                                    pbCard2Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = true;
                                            qtdCartasPlayer1++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                            if (qtdCartasPlayer1 == 0)
                                            {
                                                fimRodada = true;
                                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                            }

                                            if (primeiraJogada)
                                            {
                                                primeiraJogada = false;
                                            }
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard2Player2.Image = null;
                                pbCard2Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }

                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                                comprouPlayer2 = false;
                                vezPlayer1 = true; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer2[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player2.Image = null;
                                    pbCard2Player2.Visible = false;

                                    // Jogador 1 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);



                                            qtdCartasPlayer1++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = false;
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 1 ganha mais 2 cartas


                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player2.Image = null;
                                    pbCard2Player2.Visible = false;

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer2 = false;
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard2Player2.Image = null;
                                    pbCard2Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    comprouPlayer2 = false;
                                    vezPlayer1 = true; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer2 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard2Player2.Image = null;
                                pbCard2Player2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                            cartasPlayer1[carta] = null;

                            pbCard2Player2.Image = null;
                            pbCard2Player2.Visible = false;

                            qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer2.Visible = false;
                            vezPlayer1 = true; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer2[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard2Player2.Image = null;
                                pbCard2Player2.Visible = false;

                                // Jogador 1 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 1 ganha mais 2 cartas


                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard2Player2.Image = null;
                                pbCard2Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard2Player2.Image = null;
                                pbCard2Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = true; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer2 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 1!");
                }
            }


        }

        private void pbCard16Player1_Click(object sender, EventArgs e)
        {

        }

        private void pbCard17Player2_Click(object sender, EventArgs e)
        {

        }

        private void pbAvatar2_Click(object sender, EventArgs e)
        {
            if (!vezPlayer1)
            {
                if (tlpMesaPlayer2.Visible)
                {
                    tlpMesaPlayer2.Visible = false;
                }
                else
                {
                    tlpMesaPlayer2.Visible = true;
                }
            }
        }

        private void pbCard4Player1_Click(object sender, EventArgs e)
        {
            int carta = 3;
            if (!fimRodada) // Se não for o fim da rodada
            {
                if (vezPlayer1) // Se for a vez do jogador 1
                {
                    if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 2 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        if (cartasPlayer1[carta].Valor == valorCartaComprada && cartasPlayer1[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard4Player1.Image = null;
                                    pbCard4Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);


                                            tlpMesaPlayer1.Visible = false;
                                            btnPassaVez.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard4Player1.Image = null;
                                pbCard4Player1.Visible = false;

                                tlpMesaPlayer1.Visible = false;
                                btnPassaVez.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }
                                comprouPlayer1 = false;
                                vezPlayer1 = false; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer1[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard4Player1.Image = null;
                                    pbCard4Player1.Visible = false;

                                    // Jogador 2 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer1.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 2 ganha mais 2 cartas


                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard4Player1.Image = null;
                                    pbCard4Player1.Visible = false;

                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;
                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer1 = false;
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard4Player1.Image = null;
                                    pbCard4Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;

                                    comprouPlayer1 = false;
                                    vezPlayer1 = false; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard4Player1.Image = null;
                                pbCard4Player1.Visible = false;

                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador


                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);

                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer1.Visible = false;
                                        qtdCartasPlayer2++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                        if (qtdCartasPlayer1 == 0)
                                        {
                                            fimRodada = true;
                                            MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                        }

                                        if (primeiraJogada)
                                        {
                                            primeiraJogada = false;
                                        }

                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                            cartasPlayer1.RemoveAt(carta);

                            pbCard4Player1.Image = null;
                            pbCard4Player1.Visible = false;

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer1.Visible = false;
                            qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }

                            vezPlayer1 = false; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer1[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard4Player1.Image = null;
                                pbCard4Player1.Visible = false;

                                // Jogador 2 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);



                                        qtdCartasPlayer2++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 2 ganha mais 2 cartas

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard4Player1.Image = null;
                                pbCard4Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard4Player1.Image = null;
                                pbCard4Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = false; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 2!");
                }
            }
        }

        private void pbCard5Player1_Click(object sender, EventArgs e)
        {
            int carta = 4;
            if (!fimRodada) // Se não for o fim da rodada
            {
                if (vezPlayer1) // Se for a vez do jogador 1
                {
                    if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 2 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        if (cartasPlayer1[carta].Valor == valorCartaComprada && cartasPlayer1[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard5Player1.Image = null;
                                    pbCard5Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);


                                            tlpMesaPlayer1.Visible = false;
                                            btnPassaVez.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard5Player1.Image = null;
                                pbCard5Player1.Visible = false;

                                tlpMesaPlayer1.Visible = false;
                                btnPassaVez.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }
                                comprouPlayer1 = false;
                                vezPlayer1 = false; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer1[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard5Player1.Image = null;
                                    pbCard5Player1.Visible = false;

                                    // Jogador 2 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer1.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 2 ganha mais 2 cartas


                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard5Player1.Image = null;
                                    pbCard5Player1.Visible = false;

                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;
                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer1 = false;
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard5Player1.Image = null;
                                    pbCard5Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;

                                    comprouPlayer1 = false;
                                    vezPlayer1 = false; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard5Player1.Image = null;
                                pbCard5Player1.Visible = false;

                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador


                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);

                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer1.Visible = false;
                                        qtdCartasPlayer2++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                        if (qtdCartasPlayer1 == 0)
                                        {
                                            fimRodada = true;
                                            MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                        }

                                        if (primeiraJogada)
                                        {
                                            primeiraJogada = false;
                                        }

                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                            cartasPlayer1.RemoveAt(carta);

                            pbCard5Player1.Image = null;
                            pbCard5Player1.Visible = false;

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer1.Visible = false;
                            qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }

                            vezPlayer1 = false; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer1[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard5Player1.Image = null;
                                pbCard5Player1.Visible = false;

                                // Jogador 2 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);



                                        qtdCartasPlayer2++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 2 ganha mais 2 cartas

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard5Player1.Image = null;
                                pbCard5Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard5Player1.Image = null;
                                pbCard5Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = false; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 2!");
                }
            }
        }

        private void pbCard6Player1_Click(object sender, EventArgs e)
        {
            int carta = 5;
            if (!fimRodada) // Se não for o fim da rodada
            {
                if (vezPlayer1) // Se for a vez do jogador 1
                {
                    if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 2 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        if (cartasPlayer1[carta].Valor == valorCartaComprada && cartasPlayer1[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard6Player1.Image = null;
                                    pbCard6Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);


                                            tlpMesaPlayer1.Visible = false;
                                            btnPassaVez.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard6Player1.Image = null;
                                pbCard6Player1.Visible = false;

                                tlpMesaPlayer1.Visible = false;
                                btnPassaVez.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }
                                comprouPlayer1 = false;
                                vezPlayer1 = false; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer1[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard6Player1.Image = null;
                                    pbCard6Player1.Visible = false;

                                    // Jogador 2 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer1.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 2 ganha mais 2 cartas


                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard6Player1.Image = null;
                                    pbCard6Player1.Visible = false;

                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;
                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer1 = false;
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard6Player1.Image = null;
                                    pbCard6Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;

                                    comprouPlayer1 = false;
                                    vezPlayer1 = false; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard6Player1.Image = null;
                                pbCard6Player1.Visible = false;

                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador


                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);

                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer1.Visible = false;
                                        qtdCartasPlayer2++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                        if (qtdCartasPlayer1 == 0)
                                        {
                                            fimRodada = true;
                                            MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                        }

                                        if (primeiraJogada)
                                        {
                                            primeiraJogada = false;
                                        }

                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                            cartasPlayer1.RemoveAt(carta);

                            pbCard6Player1.Image = null;
                            pbCard6Player1.Visible = false;

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer1.Visible = false;
                            qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }

                            vezPlayer1 = false; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer1[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard6Player1.Image = null;
                                pbCard6Player1.Visible = false;

                                // Jogador 2 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);



                                        qtdCartasPlayer2++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 2 ganha mais 2 cartas

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard6Player1.Image = null;
                                pbCard6Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard6Player1.Image = null;
                                pbCard6Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = false; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 2!");
                }
            }
        }

        private void pbCard7Player1_Click(object sender, EventArgs e)
        {
            int carta = 6;
            if (!fimRodada) // Se não for o fim da rodada
            {
                if (vezPlayer1) // Se for a vez do jogador 1
                {
                    if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 2 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        if (cartasPlayer1[carta].Valor == valorCartaComprada && cartasPlayer1[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard7Player1.Image = null;
                                    pbCard7Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);


                                            tlpMesaPlayer1.Visible = false;
                                            btnPassaVez.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard7Player1.Image = null;
                                pbCard7Player1.Visible = false;

                                tlpMesaPlayer1.Visible = false;
                                btnPassaVez.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }
                                comprouPlayer1 = false;
                                vezPlayer1 = false; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer1[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard7Player1.Image = null;
                                    pbCard7Player1.Visible = false;

                                    // Jogador 2 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer2[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer2.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer2[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer1.Visible = false;
                                            qtdCartasPlayer2++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            comprouPlayer1 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 2 ganha mais 2 cartas


                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard7Player1.Image = null;
                                    pbCard7Player1.Visible = false;

                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;
                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer1 = false;
                                    MessageBox.Show("Jogador 2 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                    valorCartaAtual = cartasPlayer1[carta].Valor;
                                    corCartaAtual = cartasPlayer1[carta].Cor;
                                    cartasPlayer1.RemoveAt(carta);

                                    pbCard7Player1.Image = null;
                                    pbCard7Player1.Visible = false;

                                    qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                    tlpMesaPlayer1.Visible = false;
                                    btnPassaVez.Visible = false;

                                    comprouPlayer1 = false;
                                    vezPlayer1 = false; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer1[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer1.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer1[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard7Player1.Image = null;
                                pbCard7Player1.Visible = false;

                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador


                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);

                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer1.Visible = false;
                                        qtdCartasPlayer2++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                        if (qtdCartasPlayer1 == 0)
                                        {
                                            fimRodada = true;
                                            MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                        }

                                        if (primeiraJogada)
                                        {
                                            primeiraJogada = false;
                                        }

                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer1[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                            cartasPlayer1.RemoveAt(carta);

                            pbCard7Player1.Image = null;
                            pbCard7Player1.Visible = false;

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer1.Visible = false;
                            qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }

                            vezPlayer1 = false; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer1[carta].Valor == valorCartaAtual || cartasPlayer1[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer1[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard7Player1.Image = null;
                                pbCard7Player1.Visible = false;

                                // Jogador 2 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer2.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer2[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer2[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer2[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer2[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer2.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer2.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer2[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);



                                        qtdCartasPlayer2++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 2 ganha mais 2 cartas

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else if (cartasPlayer1[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard7Player1.Image = null;
                                pbCard7Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 2 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer1[carta].Imagem;
                                valorCartaAtual = cartasPlayer1[carta].Valor;
                                corCartaAtual = cartasPlayer1[carta].Cor;
                                cartasPlayer1.RemoveAt(carta);

                                pbCard7Player1.Image = null;
                                pbCard7Player1.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer1.Visible = false;
                                qtdCartasPlayer1--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = false; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer1 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 2!");
                }
            }
        }

        private void pbCard3Player2_Click(object sender, EventArgs e)
        {
            int carta = 2;
            if (!fimRodada)
            {
                if (!vezPlayer1)
                {
                    if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 1 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        if (cartasPlayer2[carta].Valor == valorCartaComprada && cartasPlayer2[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player2.Image = null;
                                    pbCard3Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = true;
                                            qtdCartasPlayer1++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                            if (qtdCartasPlayer1 == 0)
                                            {
                                                fimRodada = true;
                                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                            }

                                            if (primeiraJogada)
                                            {
                                                primeiraJogada = false;
                                            }
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard3Player2.Image = null;
                                pbCard3Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }

                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                                comprouPlayer2 = false;
                                vezPlayer1 = true; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer2[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player2.Image = null;
                                    pbCard3Player2.Visible = false;

                                    // Jogador 1 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);



                                            qtdCartasPlayer1++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = false;
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 1 ganha mais 2 cartas


                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player2.Image = null;
                                    pbCard3Player2.Visible = false;

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer2 = false;
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer1[carta] = null;

                                    pbCard3Player2.Image = null;
                                    pbCard3Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    comprouPlayer2 = false;
                                    vezPlayer1 = true; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer2 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer1[carta] = null;

                                pbCard3Player2.Image = null;
                                pbCard3Player2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                            cartasPlayer1[carta] = null;

                            pbCard3Player2.Image = null;
                            pbCard3Player2.Visible = false;

                            qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer2.Visible = false;
                            vezPlayer1 = true; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer2[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard3Player2.Image = null;
                                pbCard3Player2.Visible = false;

                                // Jogador 1 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 1 ganha mais 2 cartas


                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard3Player2.Image = null;
                                pbCard3Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer1[carta] = null;

                                pbCard3Player2.Image = null;
                                pbCard3Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = true; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer2 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 1!");
                }
            }
        }

        private void pbCard4Player2_Click(object sender, EventArgs e)
        {
            int carta = 3;
            if (!fimRodada)
            {
                if (!vezPlayer1)
                {
                    if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 1 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        if (cartasPlayer2[carta].Valor == valorCartaComprada && cartasPlayer2[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard4Player2.Image = null;
                                    pbCard4Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = true;
                                            qtdCartasPlayer1++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                            if (qtdCartasPlayer1 == 0)
                                            {
                                                fimRodada = true;
                                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                            }

                                            if (primeiraJogada)
                                            {
                                                primeiraJogada = false;
                                            }
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard4Player2.Image = null;
                                pbCard4Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }

                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                                comprouPlayer2 = false;
                                vezPlayer1 = true; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer2[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard4Player2.Image = null;
                                    pbCard4Player2.Visible = false;

                                    // Jogador 1 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);



                                            qtdCartasPlayer1++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = false;
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 1 ganha mais 2 cartas


                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard4Player2.Image = null;
                                    pbCard4Player2.Visible = false;

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer2 = false;
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard4Player2.Image = null;
                                    pbCard4Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    comprouPlayer2 = false;
                                    vezPlayer1 = true; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer2 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard4Player2.Image = null;
                                pbCard4Player2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                            cartasPlayer2.RemoveAt(carta);

                            pbCard4Player2.Image = null;
                            pbCard4Player2.Visible = false;

                            qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer2.Visible = false;
                            vezPlayer1 = true; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer2[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard4Player2.Image = null;
                                pbCard4Player2.Visible = false;

                                // Jogador 1 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 1 ganha mais 2 cartas


                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard4Player2.Image = null;
                                pbCard4Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard4Player2.Image = null;
                                pbCard4Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = true; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer2 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 1!");
                }
            }
        }

        private void pbCard5Player2_Click(object sender, EventArgs e)
        {
            int carta = 4;
            if (!fimRodada)
            {
                if (!vezPlayer1)
                {
                    if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 1 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        if (cartasPlayer2[carta].Valor == valorCartaComprada && cartasPlayer2[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard5Player2.Image = null;
                                    pbCard5Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = true;
                                            qtdCartasPlayer1++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                            if (qtdCartasPlayer1 == 0)
                                            {
                                                fimRodada = true;
                                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                            }

                                            if (primeiraJogada)
                                            {
                                                primeiraJogada = false;
                                            }
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard5Player2.Image = null;
                                pbCard5Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }

                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                                comprouPlayer2 = false;
                                vezPlayer1 = true; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer2[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard5Player2.Image = null;
                                    pbCard5Player2.Visible = false;

                                    // Jogador 1 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);



                                            qtdCartasPlayer1++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = false;
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 1 ganha mais 2 cartas


                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard5Player2.Image = null;
                                    pbCard5Player2.Visible = false;

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer2 = false;
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard5Player2.Image = null;
                                    pbCard5Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    comprouPlayer2 = false;
                                    vezPlayer1 = true; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer2 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard5Player2.Image = null;
                                pbCard5Player2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                            cartasPlayer2.RemoveAt(carta);

                            pbCard5Player2.Image = null;
                            pbCard5Player2.Visible = false;

                            qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer2.Visible = false;
                            vezPlayer1 = true; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer2[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard5Player2.Image = null;
                                pbCard5Player2.Visible = false;

                                // Jogador 1 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 1 ganha mais 2 cartas


                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard5Player2.Image = null;
                                pbCard5Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard5Player2.Image = null;
                                pbCard5Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = true; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer2 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 1!");
                }
            }
        }

        private void pbCard6Player2_Click(object sender, EventArgs e)
        {
            int carta = 5;
            if (!fimRodada)
            {
                if (!vezPlayer1)
                {
                    if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 1 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        if (cartasPlayer2[carta].Valor == valorCartaComprada && cartasPlayer2[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard6Player2.Image = null;
                                    pbCard6Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = true;
                                            qtdCartasPlayer1++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                            if (qtdCartasPlayer1 == 0)
                                            {
                                                fimRodada = true;
                                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                            }

                                            if (primeiraJogada)
                                            {
                                                primeiraJogada = false;
                                            }
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard6Player2.Image = null;
                                pbCard6Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }

                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                                comprouPlayer2 = false;
                                vezPlayer1 = true; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer2[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard6Player2.Image = null;
                                    pbCard6Player2.Visible = false;

                                    // Jogador 1 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);



                                            qtdCartasPlayer1++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = false;
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 1 ganha mais 2 cartas


                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard6Player2.Image = null;
                                    pbCard6Player2.Visible = false;

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer2 = false;
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard6Player2.Image = null;
                                    pbCard6Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    comprouPlayer2 = false;
                                    vezPlayer1 = true; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer2 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard6Player2.Image = null;
                                pbCard6Player2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                            cartasPlayer2.RemoveAt(carta);

                            pbCard6Player2.Image = null;
                            pbCard6Player2.Visible = false;

                            qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer2.Visible = false;
                            vezPlayer1 = true; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer2[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard6Player2.Image = null;
                                pbCard6Player2.Visible = false;

                                // Jogador 1 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 1 ganha mais 2 cartas


                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard6Player2.Image = null;
                                pbCard6Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard6Player2.Image = null;
                                pbCard6Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = true; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer2 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 1!");
                }
            }
        }

        private void pbCard7Player2_Click(object sender, EventArgs e)
        {
            int carta = 6;
            if (!fimRodada)
            {
                if (!vezPlayer1)
                {
                    if (comprouPlayer1) // SE O JOGADOR 1 TIVER COMPRADO
                    {
                        MessageBox.Show("O jogador 1 deve jogar a carta comprada ou passar a vez!");
                    }
                    else if (comprouPlayer2) // SE O JOGADOR 2 TIVER COMPRADO
                    {
                        if (cartasPlayer2[carta].Valor == valorCartaComprada && cartasPlayer2[carta].Cor == corCartaComprada) // Verifica se esta carta é a carta comprada do monte de compras
                        {
                            // Verifica se a carta é curinga antes de verificar a cor e o valor
                            if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                            {
                                bool verificarCuringaMais4 = false;
                                for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                                {
                                    if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                    {
                                        verificarCuringaMais4 = true;
                                        break;
                                    }
                                }

                                if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                                {
                                    MessageBox.Show("Você não pode jogar esta carta agora!");
                                }
                                else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                                {

                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard7Player2.Image = null;
                                    pbCard7Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    // Hora de ferrar com a vida do adversário
                                    int maisQuatro = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);

                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = true;
                                            qtdCartasPlayer1++;
                                            maisQuatro++;
                                        }

                                        if (maisQuatro == 4)
                                        {
                                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                            {
                                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                                {
                                                    valorCartaAtual = 11;
                                                    corCartaAtual = dialog.InputValue;

                                                }
                                            }
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                                            if (qtdCartasPlayer1 == 0)
                                            {
                                                fimRodada = true;
                                                MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                            }

                                            if (primeiraJogada)
                                            {
                                                primeiraJogada = false;
                                            }
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }

                                    // Hora de ferrar com a vida do adverário
                                }
                            }
                            else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard7Player2.Image = null;
                                pbCard7Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                {
                                    if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                    {
                                        valorCartaAtual = 11;
                                        corCartaAtual = dialog.InputValue;

                                    }
                                }

                                if (qtdCartasPlayer1 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 1 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                                comprouPlayer2 = false;
                                vezPlayer1 = true; // Passa a vez para o próximo
                                MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                            }
                            else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                            {
                                // Verifica se é especial ou comum
                                if (cartasPlayer2[carta].Valor == 22) // Se for +2
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard7Player2.Image = null;
                                    pbCard7Player2.Visible = false;

                                    // Jogador 1 ganha mais 2 cartas
                                    int maisDuas = 0;
                                    for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                    {
                                        if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                        {
                                            espacosPlayer1[c].Visible = true;

                                            Random random = new Random();
                                            int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                            espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                            espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                            if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                            {
                                                cartasPlayer1.Add(cartas[aleatorio]);
                                            }
                                            else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                            {
                                                cartasPlayer1[c] = cartas[aleatorio];
                                            }

                                            cartas.RemoveAt(aleatorio);



                                            qtdCartasPlayer1++;
                                            maisDuas++;
                                        }

                                        if (maisDuas == 2)
                                        {
                                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                            btnPassaVez.Visible = false;
                                            tlpMesaPlayer2.Visible = false;
                                            comprouPlayer2 = false;
                                            break;
                                        }
                                    }
                                    // Jogador 1 ganha mais 2 cartas


                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard7Player2.Image = null;
                                    pbCard7Player2.Visible = false;

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                    comprouPlayer2 = false;
                                    MessageBox.Show("Jogador 1 perdeu a vez!");
                                }
                                else // Se for carta comum
                                {
                                    // Coloca a carta no monte de descarte e remove das cartas do jogador
                                    pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                    valorCartaAtual = cartasPlayer2[carta].Valor;
                                    corCartaAtual = cartasPlayer2[carta].Cor;
                                    cartasPlayer2.RemoveAt(carta);

                                    pbCard7Player2.Image = null;
                                    pbCard7Player2.Visible = false;

                                    qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                    btnPassaVez.Visible = false;
                                    tlpMesaPlayer2.Visible = false;
                                    comprouPlayer2 = false;
                                    vezPlayer1 = true; // Passa a vez para o próximo
                                }


                                if (qtdCartasPlayer2 == 0)
                                {
                                    fimRodada = true;
                                    MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                                }

                                if (primeiraJogada)
                                {
                                    primeiraJogada = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Você não pode jogar esta carta!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você deve jogar a mesma carta comprada ou passar a vez!");
                        }
                    }
                    else // SE NENHUM JOGADOR TIVER FEITO COMPRAS
                    {

                        // Verifica se a carta é curinga antes de verificar a cor e o valor
                        if (cartasPlayer2[carta].Valor == 44) // Se for curinga +4
                        {
                            bool verificarCuringaMais4 = false;
                            for (int c = 0; c <= cartasPlayer2.Count - 1; c++) // Verificar se tenho uma carta da mesma cor da carta do monte de descarte
                            {
                                if (cartasPlayer2[c].Cor == corCartaAtual) // Se a cor da carta que tenho for igual a carta do monte
                                {
                                    verificarCuringaMais4 = true;
                                    break;
                                }
                            }

                            if (verificarCuringaMais4) // Se tiver carta de mesma cor do monte, não posso jogar
                            {
                                MessageBox.Show("Você não pode jogar esta carta agora!");
                            }
                            else // Se não tiver carta de mesma cor, posso jogar, o adversario perde a vez e ganha 4 cartas
                            {

                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard7Player2.Image = null;
                                pbCard7Player2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                // Hora de ferrar com a vida do adversário
                                int maisQuatro = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisQuatro++;
                                    }

                                    if (maisQuatro == 4)
                                    {
                                        using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                                        {
                                            if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                            {
                                                valorCartaAtual = 11;
                                                corCartaAtual = dialog.InputValue;

                                            }
                                        }
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }

                                // Hora de ferrar com a vida do adverário
                            }
                        }
                        else if (cartasPlayer2[carta].Valor == 157) // Se for curinga
                        {
                            // Coloca a carta no monte de descarte e remove das cartas do jogador
                            pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                            cartasPlayer2.RemoveAt(carta);

                            pbCard7Player2.Image = null;
                            pbCard7Player2.Visible = false;

                            qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                            using (CuringaMaisQuatro dialog = new CuringaMaisQuatro())
                            {
                                if (dialog.ShowDialog() == DialogResult.OK) // Pede para o usuário escolher a cor a ser seguida
                                {
                                    valorCartaAtual = 11;
                                    corCartaAtual = dialog.InputValue;

                                }
                            }

                            btnPassaVez.Visible = false;
                            tlpMesaPlayer2.Visible = false;
                            vezPlayer1 = true; // Passa a vez para o próximo
                            MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);

                        }
                        else if (cartasPlayer2[carta].Valor == valorCartaAtual || cartasPlayer2[carta].Cor == corCartaAtual) // Verifica se esta carta bate com a carta do monte de descarte
                        {
                            // Verifica se é especial ou comum
                            if (cartasPlayer2[carta].Valor == 22) // Se for +2
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard7Player2.Image = null;
                                pbCard7Player2.Visible = false;

                                // Jogador 1 ganha mais 2 cartas
                                int maisDuas = 0;
                                for (int c = 0; c < espacosPlayer1.Count; c++) // Procura por espaços vazios na mesa do player 1
                                {
                                    if (!espacosPlayer1[c].Visible) // Se o espaço na posição estiver vazio
                                    {
                                        espacosPlayer1[c].Visible = true;

                                        Random random = new Random();
                                        int aleatorio = (int)random.NextInt64(0, cartas.Count - 1);
                                        espacosPlayer1[c].Image = cartas[aleatorio].Imagem; // Uma carta aleatória é inserida naquele espaço vazio
                                        espacosPlayer1[c].Visible = true; // Torna visivel o espaço alugado para colocar carta na mesa

                                        if (c > cartasPlayer1.Count - 1) // Adiciona em um novo espaço na mesa
                                        {
                                            cartasPlayer1.Add(cartas[aleatorio]);
                                        }
                                        else // Adiciona em uma posição vazia da mesa que não seja uma depois da ultima
                                        {
                                            cartasPlayer1[c] = cartas[aleatorio];
                                        }

                                        cartas.RemoveAt(aleatorio);


                                        btnPassaVez.Visible = false;
                                        tlpMesaPlayer2.Visible = false;
                                        qtdCartasPlayer1++;
                                        maisDuas++;
                                    }

                                    if (maisDuas == 2)
                                    {
                                        MessageBox.Show("Jogue uma carta de cor " + corCartaAtual);
                                        break;
                                    }
                                }
                                // Jogador 1 ganha mais 2 cartas


                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else if (cartasPlayer2[carta].Valor == 24) // Se for pular
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard7Player2.Image = null;
                                pbCard7Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;

                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador
                                MessageBox.Show("Jogador 1 perdeu a vez!");
                            }
                            else // Se for carta comum
                            {
                                // Coloca a carta no monte de descarte e remove das cartas do jogador
                                pbMonteDescarte.Image = cartasPlayer2[carta].Imagem;
                                valorCartaAtual = cartasPlayer2[carta].Valor;
                                corCartaAtual = cartasPlayer2[carta].Cor;
                                cartasPlayer2.RemoveAt(carta);

                                pbCard7Player2.Image = null;
                                pbCard7Player2.Visible = false;

                                btnPassaVez.Visible = false;
                                tlpMesaPlayer2.Visible = false;
                                qtdCartasPlayer2--; // Diminui a quantidade de cartas do jogador

                                vezPlayer1 = true; // Passa a vez para o próximo
                            }


                            if (qtdCartasPlayer2 == 0)
                            {
                                fimRodada = true;
                                MessageBox.Show("Fim de jogo. Jogador 2 venceu!");
                            }

                            if (primeiraJogada)
                            {
                                primeiraJogada = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não pode jogar esta carta!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("É a vez do jogador 1!");
                }
            }
        }
    }
}
