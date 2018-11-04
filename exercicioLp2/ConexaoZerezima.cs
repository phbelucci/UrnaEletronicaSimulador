using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace exercicioLp2
{
    class ConexaoZerezima
    {
        
        private int somaVotos = 0;

        public ConexaoZerezima()
        {
            
            consultaZerezima();


        }

        public void consultaZerezima()
        {

            try
            {

                //instancia uma variavel do tipo MySqlConnection como os parametros do server
                MySqlConnection conexao = new MySqlConnection("server=dbinstanciaexerurna.cpp65shndpya.sa-east-1.rds.amazonaws.com;port=3306;UserId=phbelucci;database=dados_candidatos; password =Sophia20");

                //abre conexão com BD
                conexao.Open();
                Console.WriteLine("Conectado ao banco...");

                //comando para zerar os votos no inicio da eleição
                MySqlCommand zeraVotos = new MySqlCommand("UPDATE dados_candidatos SET votos_candidato = 0;", conexao);

                //comando para consultar o numero de votos dos candidatos
                MySqlCommand consultaZerezima = new MySqlCommand("select sum(votos_candidato) from dados_candidatos where cargo_candidato = ('deputado federal'+'deputado estadual'+'senador'+'governador'+'presidente');", conexao);


                //comando para executar Query (SELECT, INSERT, ETC...)
                
                zeraVotos.ExecuteNonQuery();
                consultaZerezima.ExecuteNonQuery();

                Console.WriteLine("Dados consultados...");


                //recebe o conteudo do banco
                MySqlDataReader lerDados;
                lerDados = consultaZerezima.ExecuteReader();
                lerDados.Read();

                int somaVotos = Convert.ToInt32(lerDados.GetString(0));
                this.somaVotos = somaVotos;

                Console.WriteLine(somaVotos);


                //fecha conexão com BD
                conexao.Close();
                Console.WriteLine("Conexão com banco finalizada!");

            }
            catch (Exception erro)
            {

                Console.WriteLine("Zerezima não executada com sucesso!n\n\nPARA USO DE TI:\n" + erro);

            }
        }

        public int getVotosBD()
        {
            return somaVotos;
        }
        

    }
}
