using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Cliente
{
    public partial class TelaCliente : Form
    {
        public TelaCliente()
        {
            InitializeComponent();
        }

        Conexao con = new Conexao();
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string insere = "insert into tb_cliente values (null,'" + txtNome.Text + "', '" + txtCelular.Text + "', '" + txtCPF.Text + "');";
            if (con.Executa(insere))
            {
                MessageBox.Show("Cadastrado com sucesso!!!");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao cadastrar!");
            }

        }
    }
}
