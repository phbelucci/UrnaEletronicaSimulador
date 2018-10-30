using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace exercicioLp2
{
    public partial class DeputadoEstadual : Form
    {
        public int numeroClicado = 0;
        public int casaAtual = 0;
        
        public DeputadoEstadual()
        {
            InitializeComponent();
            primDigito.Text = null;
            segDigito.Text = null;
            terDigito.Text = null;
            quaDigito.Text = null;
            quiDigito.Text = null;

        }

        private void deputadoFederal_Load(object sender, EventArgs e)
        {
            nomeCargo.Text = "DEPUTADO ESTADUAL";
        }

        


        private void branco_Click(object sender, EventArgs e)
        {
            primDigito.Text = "-";
            segDigito.Text = "-";
            terDigito.Text = "-";
            quaDigito.Text = "-";
            quiDigito.Text = "-";
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
            quaDigito.Text = null;
            quiDigito.Text = null;
            nomeCandidato.Text = null;
            partidoCandidato.Text = null;
            fotoCandidato.BackgroundImage = null;

        }

        private void confirma_Click(object sender, EventArgs e)
        {
            string numeroCandidatoEscolhido = primDigito.Text + segDigito.Text + terDigito.Text + quaDigito.Text + quiDigito.Text;
            MessageBox.Show("O número do candidato é: "+numeroCandidatoEscolhido);
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
                case 4:
                    if ((terDigito.Text != "") && (quaDigito.Text == ""))
                    {
                        quaDigito.Text = Convert.ToString(numeroClicado);
                    }
                    break;
                case 5:
                    if ((quaDigito.Text != "") && (quiDigito.Text == ""))
                    {
                        quiDigito.Text = Convert.ToString(numeroClicado);
                    }
                    break;
            }

            string candidatoEscolhido = (primDigito.Text + segDigito.Text + terDigito.Text + quaDigito.Text+quiDigito.Text);
            if (quiDigito.Text != "")
            {
                try
                {

                    //instancia uma variavel do tipo MySqlConnection como os parametros do server
                    MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;UserId=root;database=candidatos; password =");

                    //abre conexão com BD
                    conexao.Open();
                    Console.WriteLine("Conectado ao banco...");

                    //comando para buscar dados no banco
                    MySqlCommand buscaCandidato = new MySqlCommand("SELECT id_candidato, nome_candidato, partido_candidato, cargo_candidato, foto_candidato FROM dados_candidatos WHERE id_candidato = ?", conexao);
                    buscaCandidato.Parameters.Clear();
                    buscaCandidato.Parameters.Add("@id_candidato", MySqlDbType.String).Value = candidatoEscolhido;

                    //comando para executar Query (SELECT, INSERT, ETC...)
                    buscaCandidato.CommandType = CommandType.Text;

                    //recebe o conteudo do banco
                    MySqlDataReader lerDados;
                    lerDados = buscaCandidato.ExecuteReader();
                    lerDados.Read();

                    nomeCandidato.Text = lerDados.GetString(1);
                    partidoCandidato.Text = lerDados.GetString(2);
                    fotoCandidato.BackgroundImage = Image.FromFile(@"" + lerDados.GetString(4));

                    //fecha conexão com BD
                    conexao.Close();
                    Console.WriteLine("Conexão com banco finalizada!");

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Candidato Não Encontrado!\n\n\nPARA USO DE TI:\n" + erro);

                }
            }


        }
    }
}
