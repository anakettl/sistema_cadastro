using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastro_alunos
{
    public partial class Cadastro : Form
    {
        string conexao = "Server= localhost; Database=cadastro_alunos; port=3306; username=root; password=12071992";

        MySqlConnection connect;
        public Cadastro()
        {
            InitializeComponent();
            connect = new MySqlConnection(conexao);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try 
            {
                int matricula = int.Parse(txtMatricula.Text);
                string nome = txtNome.Text;
                float nota1 = Decimal.ToInt32(nr_nota1.Value);
                float nota2 = Decimal.ToInt32(nr_nota2.Value);

                string sql = "INSERT INTO cadastro (nr_matricula, nm_nome, nota_1, nota_2) values ("+matricula +", '"+nome+"' , "+nota1+ ", " + nota2 + ");";
                MySqlCommand sqlCommand = new MySqlCommand(sql,connect);

                connect.Open();
                txtDisplay.Text = "A conexão foi realizada com sucesso";
                sqlCommand.ExecuteReader();

                txtDisplay.Text = "A informação do aluno " + nome + " foi armazenada com sucesso";

                connect.Close();
            }
            catch (Exception ex) 
            {
                txtDisplay.Text = "Falha na conexão com o banco de dados";
                txtDisplay.Text += ex.Message;
                txtDisplay.Text += ex.StackTrace;
                connect.Close();

            }

            

        }
    }
}
