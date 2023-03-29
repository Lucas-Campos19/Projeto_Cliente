using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cliente
{
    class Conexao
    {
        static private string server = "localhost";
        static private string database = "bd_teste";
        static private string usuario = "root";
        static private string senha = "";

        static public string strConn = $"server={server}; User id={usuario}; database={database}; password{senha}";

        MySqlConnection cn;

        private bool Conectar()
        {
            bool result;
            try
            {
                cn = new MySqlConnection(strConn);
                cn.Open();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private void Desconectar()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public bool Executa(string sql)
        {
            bool resultado;
            Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, cn);
                comando.ExecuteNonQuery();
                resultado = true;
            }
            catch
            {
                resultado = false;
            }
            finally
            {
                Desconectar();
            }
            return resultado;
        }
    }
}
