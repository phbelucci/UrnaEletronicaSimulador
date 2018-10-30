using System;
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
    public partial class Senador : Form
    {
        public int numeroClicado = 0;
        public int casaAtual = 0;

        public Senador()
        {
            InitializeComponent();
            primDigito.Text = null;
            segDigito.Text = null;
            terDigito.Text = null;
            
        }

        private void Senador_Load(object sender, EventArgs e)
        {
            nomeCargo.Text = "SENADOR";
        }

        private void branco_Click(object sender, EventArgs e)
        {
            primDigito.Text = "-";
            segDigito.Text = "-";
            terDigito.Text = "-";
            casaAtual = 0;
            numeroClicado = 0;
            nomeCandidato.Text = "BRANCO";
            partidoCandidato.Text = "BRANCO";
            fotoCandidato.BackgroundImage = null;
        }

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

        private void corrige_Click(object sender, EventArgs e)
        {
            casaAtual = 0;
            numeroClicado = 0;
            primDigito.Text = null;
            segDigito.Text = null;
            terDigito.Text = null;
            nomeCandidato.Text = null;
            partidoCandidato.Text = null;
            fotoCandidato.BackgroundImage = null;
        }

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
                case 3:
                    if ((segDigito.Text != "") && (terDigito.Text == ""))
                    {
                        terDigito.Text = Convert.ToString(numeroClicado);
                    }
                    break;
                
            }
            string candidatoEscolhido = (primDigito.Text + segDigito.Text + terDigito.Text);
            if (terDigito.Text != "")
            {
                try { 
                    Conexao conectar = new Conexao(candidatoEscolhido,"SENADOR");
                    nomeCandidato.Text = conectar.getNome();
                    partidoCandidato.Text = conectar.getPartido();
                    fotoCandidato.BackgroundImage = Image.FromFile(conectar.getFoto());
                }
                catch
                {
                    fotoCandidato.BackgroundImage = Image.FromFile(@"C:\Users\phbel\Desktop\ADS-2018-IFSP\2_SEMESTRE\LP2\LISTA_URNA\exercicioLp2\img\avatar.png");
                }


            }

        }

        private void confirma_Click(object sender, EventArgs e)
        {
            string numeroCandidatoEscolhido = primDigito.Text + segDigito.Text + terDigito.Text;
            MessageBox.Show("O número do candidato é: " + numeroCandidatoEscolhido);
            Close();
        }
    }
}
