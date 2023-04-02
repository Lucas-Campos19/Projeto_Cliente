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
    public partial class TelaProduto : Form
    {
        public TelaProduto()
        {
            InitializeComponent();
        }

        Conexao con = new Conexao();    

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "delete from tb_produto where prod_codigo=" + txtCodigo.Text;
            if (con.Executa(sql))
            {
                MessageBox.Show("Excluido com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao excluir!");
            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string sql = "update tb_produto set prod_nome='"+txtNome.Text+"', prod_descricao='"+txtDescricao.Text+"', prod_categoria="+cbxCategoria.SelectedValue+", prod_valor="+txtValor.Text+ " where prod_codigo="+txtCodigo.Text;
            if (con.Executa(sql))
            {
                MessageBox.Show("Atualizado com sucesso!");

            }
            else
            {
                MessageBox.Show("Erro ao atualizar!");
            }
            CarregaTabela();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string sql = "insert into tb_produto values(null, '" + txtNome.Text + "' , '" + txtDescricao.Text + "' , " + cbxCategoria.SelectedValue + ", " + txtValor.Text+");";
            if (con.Executa(sql))
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
            CarregaTabela();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigo = Convert.ToInt32(dgvDados["prod_codigo", e.RowIndex].Value);
            DataTable dados = con.Retorna("select * from tb_produto where prod_codigo=" + codigo);
            txtCodigo.Text = codigo.ToString();
            txtNome.Text = dados.Rows[0]["prod_nome"].ToString();
            txtDescricao.Text = dados.Rows[0]["prod_descricao"].ToString();
            cbxCategoria.SelectedValue = Convert.ToInt32(dados.Rows[0]["prod_categoria"]);
            txtValor.Text = dados.Rows[0]["prod_valor"].ToString();

        }

        private void TelaProduto_Load(object sender, EventArgs e)
        {
            CarregaCategoria();
            CarregaTabela();

        }

        private void CarregaCategoria()
        {
            cbxCategoria.DataSource = null;
            cbxCategoria.DataSource = con.Retorna("select * from tb_categoria");
            cbxCategoria.DisplayMember = "cat_descricao";
            cbxCategoria.ValueMember = "cat_id";
        }

        private void CarregaTabela()
        {
            dgvDados.DataSource = null;
            DataTable dados = con.Retorna("select * from tb_produto");
            if (dados.Rows[0]["prod_codigo"].ToString() != "")
            {
                dgvDados.DataSource = dados;
            }
        }
    }
}
