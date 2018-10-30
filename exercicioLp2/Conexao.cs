using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace exercicioLp2
{
    class Conexao
    {
        
        string nomeCandidatoConsultaBD;
        string partidoCandidatoConsultaBD;
        string fotoCandidatoConsultaBD;

        public Conexao(string numeroescolhidoParametro, string cargoCandidatoParametro)
        {

            string numeroescolhido = numeroescolhidoParametro;
            string cargoCandidato = cargoCandidatoParametro;
            conectar();

            void conectar()
            {
                
                try
                {

                    //instancia uma variavel do tipo MySqlConnection como os parametros do server
                    MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;UserId=root;database=candidatos; password =");

                    //abre conexão com BD
                    conexao.Open();
                    Console.WriteLine("Conectado ao banco...");

                    //comando para buscar dados no banco
                    MySqlCommand buscaCandidato = new MySqlCommand("SELECT nome_candidato, partido_candidato, cargo_candidato, foto_candidato FROM dados_candidatos WHERE id_candidato = ? and cargo_candidato = ?", conexao);
                    buscaCandidato.Parameters.Clear();
                    buscaCandidato.Parameters.Add("@id_candidato", MySqlDbType.Int64).Value = Convert.ToInt64(numeroescolhido);
                    buscaCandidato.Parameters.Add("@cargo_candidato", MySqlDbType.String).Value = cargoCandidato;


                    MySqlCommand insereVotos = new MySqlCommand("INSERT INTO dados_candidatos(votos_candidato) values (?) WHERE id_candidato = ?", conexao);
                    insereVotos.Parameters.Clear();
                    int voto = 1;
                    insereVotos.Parameters.Add("@voto", MySqlDbType.Int32).Value = voto;
                    insereVotos.Parameters.Add("@id_candidato", MySqlDbType.Int64).Value = Convert.ToInt64(numeroescolhido);
                    insereVotos.Parameters.Add("@cargo_candidato", MySqlDbType.String).Value = cargoCandidato;

                    //comando para executar Query (SELECT, INSERT, ETC...)
                    try { 
                        buscaCandidato.CommandType = CommandType.Text;
                        insereVotos.CommandType = CommandType.Text;
                        Console.WriteLine("Dados consultados e gravados com sucesso!");
                    }
                    catch
                    {
                        Console.WriteLine("Dados não gravados!");

                    }
                    //recebe o conteudo do banco
                    MySqlDataReader lerDados;
                    lerDados = buscaCandidato.ExecuteReader();
                    lerDados.Read();

                    nomeCandidatoConsultaBD = lerDados.GetString(0);
                    partidoCandidatoConsultaBD = lerDados.GetString(1);
                    fotoCandidatoConsultaBD = lerDados.GetString(3);
                    Console.WriteLine(fotoCandidatoConsultaBD);



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
        public string getNome()
        {
            
            return nomeCandidatoConsultaBD;
        }

        public string getPartido()
        {
            
            return partidoCandidatoConsultaBD;
        }

        public string getFoto()
        {
            
            return fotoCandidatoConsultaBD;
        }

    }
}
