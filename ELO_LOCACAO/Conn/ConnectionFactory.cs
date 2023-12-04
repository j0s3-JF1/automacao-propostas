using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ELO_LOCACAO.Conn
{
    internal class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            //string data_source = "datasource=192.168.0.120;username=eloserver;password=elosolutions;database=EloDB"; //<- Servidor Lenovo
            //string data_source = "datasource=localhost;username=root;password=#Canario83.;database=EloDB"; //<- Servidor Localhost@
            string data_source = "datasource=10.100.10.80;username=eloserver;password=elosolutions;database=EloDB"; //<- Servidor Elo
            var conexao = new MySqlConnection(data_source);

            try
            {
                conexao.Open();

                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                    return conexao;
                }
                else
                {
                    conexao.Close();
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conexao.Close();
                return null;
            }
        }
    }
}