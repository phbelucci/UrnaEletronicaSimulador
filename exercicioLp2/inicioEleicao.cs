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
    public partial class inicioEleicao : Form
    {
        public inicioEleicao()
        {
            InitializeComponent();  
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();     
        }

        private void inicioEleicao_Load(object sender, EventArgs e)
        {
            dataHoraInicio.Text = DateTime.Now.ToShortDateString()+" -- " +DateTime.Now.ToLongTimeString();
            numVotosDepEst.Text = "0";
            numVotosDepFederal.Text = "0";
            numVotosSenador.Text = "0";
            numVotosGover.Text = "0";
            numVotosPres.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
