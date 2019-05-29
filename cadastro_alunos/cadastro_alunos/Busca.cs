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
    public partial class Busca : Form
    {
        string conexao = "Server= localhost; Database=cadastro_alunos; port=3306; username=root; password=12071992";

        MySqlConnection connect;
        public Busca()
        {
            InitializeComponent();
            connect = new MySqlConnection(conexao);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            try 
            {
                int matricula = int.Parse(txtBusca.Text);
                string sql = "select * from cadastro where nr_matricula = "+matricula+";";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connect);
                connect.Open();
                reader = sqlCommand.ExecuteReader();

                if (reader.Read()) 
                {
                    txtDisplay.Text = "Registro encontrado:";
                    int contador = 1;

                    do 
                    {
                        txtDisplay.Text += "\r\n ("+contador+ ") Matricula: " + reader[0];
                        txtDisplay.Text += "\r\n ("+contador+ ") Aluno: " + reader[1];
                        txtDisplay.Text += "\r\n (" +contador+ ") Nota 1: " + reader[2];
                        txtDisplay.Text += "\r\n (" + contador + ") Nota 2: " + reader[3];
                        contador++;
                    } while (reader.Read());
                    connect.Close();
                }
                else
                {
                    txtDisplay.Text = "Registro não encontrado";
                    connect.Close();
                }
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
