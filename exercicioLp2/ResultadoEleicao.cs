using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace exercicioLp2
{
    class ResultadoEleicao
    {

        public string nomeCandidatoConsultaBD;
        public string partidoCandidatoConsultaBD;
        public string cargoCandidatoConsultaBD;
        public string votosCandidatoConsultaBD;

        public ResultadoEleicao() { 

                try
                {

                    //instancia uma variavel do tipo MySqlConnection como os parametros do server
                    MySqlConnection conexao = new MySqlConnection("server=dbinstanciaexerurna.cpp65shndpya.sa-east-1.rds.amazonaws.com;port=3306;UserId=phbelucci;database=dados_candidatos; password =Sophia20");

                    //abre conexão com BD
                    conexao.Open();
                    Console.WriteLine("Conectado ao banco...");

                    //comando para buscar dados no banco
                    MySqlCommand buscaCandidato = new MySqlCommand("SELECT nome_candidato, partido_candidato, cargo_candidato, votos_candidato FROM dados_candidatos WHERE votos_candidato != 0;", conexao);
                  


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
                    cargoCandidatoConsultaBD = lerDados.GetString(2);
                    votosCandidatoConsultaBD = lerDados.GetString(3);
                    Console.WriteLine(nomeCandidatoConsultaBD);
                    Console.WriteLine(partidoCandidatoConsultaBD);
                    Console.WriteLine(cargoCandidatoConsultaBD);
                    Console.WriteLine(votosCandidatoConsultaBD);

                    

                //fecha conexão com BD
                    conexao.Close();
                    Console.WriteLine("Conexão com banco finalizada!");

                }
                catch (Exception erro)
                {
                   
                    Console.WriteLine(erro);

                }
        }
    }
}
