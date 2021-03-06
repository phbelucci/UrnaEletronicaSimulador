﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercicioLp2
{
    public partial class Presidente : Form
    {
        public int numeroClicado = 0;
        public int casaAtual = 0;
        public int loopeleicao = 0;

        public Presidente()
        {
            
            InitializeComponent();
            confirma.Visible = false;
            primDigito.Text = null;
            segDigito.Text = null;

        }

        //define o nome que aparecerá no campo Cargo Candidato
        private void Presidente_Load(object sender, EventArgs e)
        {
            nomeCargo.Text = "PRESIDENTE";
        }

        //TECLAS BRANCO, CORRIGE E CONFIRMA
        private void branco_Click(object sender, EventArgs e)
        {
            primDigito.Text = "9";
            segDigito.Text = "9";
            casaAtual = 0;
            numeroClicado = 0;
            nomeCandidato.Text = "BRANCO";
            partidoCandidato.Text = "BRANCO";
            fotoCandidato.BackgroundImage = null;
            confirma.Visible = true;
        }

        private void corrige_Click(object sender, EventArgs e)
        {
            casaAtual = 0;
            numeroClicado = 0;
            primDigito.Text = null;
            segDigito.Text = null;
            nomeCandidato.Text = null;
            partidoCandidato.Text = null;
            fotoCandidato.BackgroundImage = null;
        }


        private void confirma_Click(object sender, EventArgs e)
        {
            string numeroCandidatoEscolhido = primDigito.Text + segDigito.Text;
            
            if (numeroCandidatoEscolhido == "99")
            {
                numeroCandidatoEscolhido = "99999";
                Conexao conexao1 = new Conexao(numeroCandidatoEscolhido, "BRANCO");
                conexao1.conectarIncrementaVoto(numeroCandidatoEscolhido, "BRANCO");
                Close();
            }
            else { 
                Conexao conexao1 = new Conexao(numeroCandidatoEscolhido, "PRESIDENTE");
                conexao1.conectarIncrementaVoto(numeroCandidatoEscolhido, "PRESIDENTE");
                Close();
            }
        }



        //Seta o valor para cada tecla e chama a função insereNumero para preencher as casas
        private void tecla1_Click(object sender, EventArgs e)
        {
            numeroClicado = 1;
            insereNumero(numeroClicado);
        }

        private void tecla2_Click(object sender, EventArgs e)
        {
            numeroClicado = 2;
            insereNumero(numeroClicado);
        }

        private void tecla3_Click(object sender, EventArgs e)
        {
            numeroClicado = 3;
            insereNumero(numeroClicado);
        }

        private void tecla4_Click(object sender, EventArgs e)
        {
            numeroClicado = 4;
            insereNumero(numeroClicado);
        }

        private void tecla5_Click(object sender, EventArgs e)
        {
            numeroClicado = 5;
            insereNumero(numeroClicado);
        }

        private void tecla6_Click(object sender, EventArgs e)
        {
            numeroClicado = 6;
            insereNumero(numeroClicado);
        }

        private void tecla7_Click(object sender, EventArgs e)
        {
            numeroClicado = 7;
            insereNumero(numeroClicado);
        }

        private void tecla8_Click(object sender, EventArgs e)
        {
            numeroClicado = 8;
            insereNumero(numeroClicado);
        }

        private void tecla9_Click(object sender, EventArgs e)
        {
            numeroClicado = 9;
            insereNumero(numeroClicado);
        }

        private void tecla0_Click(object sender, EventArgs e)
        {
            numeroClicado = 0;
            insereNumero(numeroClicado);
        }


        //inicializa a função insereNumero e chama a conexao com BD para buscar o candidato escolhido.
        public void insereNumero(int numeroClicado)
        {
            this.numeroClicado = numeroClicado;
            casaAtual += 1;

            switch (casaAtual)
            {
                case 1:
                    if (primDigito.Text == "")
                    {
                        primDigito.Text = Convert.ToString(numeroClicado);
                    }
                    break;
                case 2:
                    if ((primDigito.Text != "") && (segDigito.Text == ""))
                    {
                        segDigito.Text = Convert.ToString(numeroClicado);
                    }
                    break;
            }
            string candidatoEscolhido = (primDigito.Text + segDigito.Text);
            if (segDigito.Text != "")
            {

                try
                {
                    confirma.Visible = true;
                    Conexao conectar = new Conexao(candidatoEscolhido, "PRESIDENTE");
                    nomeCandidato.Text = conectar.getNome();
                    partidoCandidato.Text = conectar.getPartido();
                    fotoCandidato.BackgroundImage = Image.FromFile(@"avatar.png");
                }
                catch
                {
                    Console.WriteLine("erro foto");
                    fotoCandidato.BackgroundImage = null;
                }

            }

        }
        public int loop()
        {
            return loopeleicao;
        }

    }
    
}
