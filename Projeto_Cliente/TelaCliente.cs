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
            if(txtId.Text == "")
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
            else
            {
                string atualiza = "update tb_cliente set cliente_nome='" + txtNome.Text + "' , cliente_cpf='" + txtCPF.Text + "' , cliente_celular='" + txtCelular.Text + "' where cliente_id=" + txtId.Text + ";";
                if (con.Executa(atualiza))
                {
                    MessageBox.Show("Atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao atualizar!");

                }
            }
            
            Limpar();
        }

        public void Limpar()
        {
            txtNome.Text = "";
            txtId.Text = "";
            txtCPF.Text = null;
            txtCelular.Text = null;
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                DataTable dados = con.Retorna("select * from tb_cliente where cliente_id="+txtId.Text);
                txtNome.Text = dados.Rows[0]["cliente_nome"].ToString();
                txtCPF.Text = dados.Rows[0]["cliente_cpf"].ToString();
                txtCelular.Text = dados.Rows[0]["cliente_celular"].ToString();

            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                string excluir = "delete  from tb_cliente where cliente_id=" + txtId.Text +";";
                if (con.Executa(excluir))
                {
                    MessageBox.Show("Excluido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Ocorreu erro ao excluir!");
                }
            }
            else
            {
                MessageBox.Show("ID não informado!");
            }

        }
    }
}
