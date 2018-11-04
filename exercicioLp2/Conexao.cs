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
            conectarBuscarCandidato();
           

            void conectarBuscarCandidato()
            {
                
                try
                {

                    //instancia uma variavel do tipo MySqlConnection como os parametros do server
                    MySqlConnection conexao = new MySqlConnection("server=dbinstanciaexerurna.cpp65shndpya.sa-east-1.rds.amazonaws.com;port=3306;UserId=phbelucci;database=dados_candidatos; password =Sophia20");

                    //abre conexão com BD
                    conexao.Open();
                    Console.WriteLine("Conectado ao banco...");

                    //comando para buscar dados no banco
                    MySqlCommand buscaCandidato = new MySqlCommand("SELECT nome_candidato, partido_candidato, cargo_candidato, foto_candidato FROM dados_candidatos WHERE id_candidato = ? and cargo_candidato = ?", conexao);
                    buscaCandidato.Parameters.Clear();
                    buscaCandidato.Parameters.Add("@id_candidato", MySqlDbType.String).Value = Convert.ToInt64(numeroescolhido);
                    buscaCandidato.Parameters.Add("@cargo_candidato", MySqlDbType.String).Value = cargoCandidato;


                    //comando para executar Query (SELECT, INSERT, ETC...)
                   
                    buscaCandidato.CommandType = CommandType.Text;
                    buscaCandidato.ExecuteNonQuery();
                     
                    Console.WriteLine("Dados consultados e gravados com sucesso!");
                   

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
                    MessageBox.Show("CANDIDATO NÃO EXISTE! FAVOR DIGITAR NOVAMENTE");
                    Console.WriteLine("Candidato Não Encontrado!\n\n\nPARA USO DE TI:\n" + erro);

                }

            }

        }

        public void conectarIncrementaVoto(string a, string b)
        {
            string numeroescolhido = a;
            string cargoCandidato = b;


            try
            {

                //instancia uma variavel do tipo MySqlConnection como os parametros do server
                MySqlConnection conexao = new MySqlConnection("server=dbinstanciaexerurna.cpp65shndpya.sa-east-1.rds.amazonaws.com;port=3306;UserId=phbelucci;database=dados_candidatos;password=Sophia20");

                //abre conexão com BD
                conexao.Open();
                Console.WriteLine("Conectado ao banco...");

                //comando para buscar dados no banco
                MySqlCommand IncrementaVoto = new MySqlCommand("UPDATE dados_candidatos SET votos_candidato = votos_candidato+1 WHERE id_candidato = ? and cargo_candidato = ?", conexao);
                IncrementaVoto.Parameters.Clear();
                IncrementaVoto.Parameters.Add("@id_candidato", MySqlDbType.VarChar, 90).Value = Convert.ToInt32(numeroescolhido);
                IncrementaVoto.Parameters.Add("@cargo_candidato", MySqlDbType.String).Value = cargoCandidato;

                //comando para executar Query (SELECT, INSERT, ETC...)

                IncrementaVoto.CommandType = CommandType.Text;
                IncrementaVoto.ExecuteNonQuery();

                //fecha conexão com BD
                conexao.Close();
                Console.WriteLine("Conexão com banco finalizada!");

            }
            catch (Exception erro)
            {

                Console.WriteLine("Dados não gravados!"+erro);

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
