using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cadastro_alunos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declaração do formulário do cadastro
            Cadastro cad = new Cadastro();
            //indica que o formulario da questão 2 deve surgir dentro deste
            cad.MdiParent = this;
            //Mostra o formulário da questão 2
            cad.Show();
        }

        private void buscaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busca bus = new Busca();
            bus.MdiParent = this;
            bus.Show();
        }
    }
}
