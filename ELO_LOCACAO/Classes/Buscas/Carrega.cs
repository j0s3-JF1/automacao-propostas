using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Classes.Buscas
{
    internal class Carrega
    {
        /*
            Carrega Equipamentos
         */
        public void CarregaEquipamento(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT MODELO FROM EQUIPAMENTO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["MODELO"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "MODELO";
            comboBox.DisplayMember = "MODELO";


            Conexao.Close();
        }
        /*
            Carrega os Fabricantes
         */
        public void CarregaFabricante(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT FABRICANTE FROM FABRICANTE";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["FABRICANTE"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "FABRICANTE";
            comboBox.DisplayMember = "FABRICANTE";

            Conexao.Close();
        }

        /*
            Carrega os Status
         */

        public void CarregaStatusEquipamento(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT STATUS FROM STATUS_EQUIPAMENTO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["STATUS"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "STATUS";
            comboBox.DisplayMember = "STATUS";

            Conexao.Close();

        }

        public void CarregaStatusIO(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT STATUS FROM STATUS_PLACA_IO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["STATUS"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "STATUS";
            comboBox.DisplayMember = "STATUS";

            Conexao.Close();

        }

        public void CarregaStatusEncoder(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT STATUS FROM STATUS_PLACA_ENCODER";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["STATUS"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "STATUS";
            comboBox.DisplayMember = "STATUS";

            Conexao.Close();

        }

        public void CarregaStatusComunicacao(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT STATUS FROM STATUS_PLACA_COMUNICACAO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["STATUS"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "STATUS";
            comboBox.DisplayMember = "STATUS";

            Conexao.Close();

        }

        /*
            Carrega Numeros de Série, Cadastros e Localizações
         */
        public void CarregaNumSerie(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT NUMSERIE FROM EQUIPAMENTO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["NUMSERIE"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "NUMSERIE";
            comboBox.DisplayMember = "NUMSERIE";

            Conexao.Close();

        }

        public void CarregaCadastrado(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT NOME FROM CADASTRO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["NOME"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "NOME";
            comboBox.DisplayMember = "NOME";

            Conexao.Close();
        }

        public void CarregaLocalizacao(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT LOCALIZACAO FROM LOCALIZACAO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["LOCALIZACAO"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "LOCALIZACAO";
            comboBox.DisplayMember = "LOCALIZACAO";

            Conexao.Close();
        }

        public void CarregaProtocolo(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT PROTOCOLO FROM PROTOCOLO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["PROTOCOLO"] = "NÃO";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "PROTOCOLO";
            comboBox.DisplayMember = "PROTOCOLO";

            Conexao.Close();
        }

        public void CarregaEncoder(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT ENCODER FROM ENCODER";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["ENCODER"] = "NÃO";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "ENCODER";
            comboBox.DisplayMember = "ENCODER";

            Conexao.Close();
        }

        /*
            Carrega os ID´s
         */
        public void CarregaIDIO(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT ID FROM PLACA_IO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["ID"] = 0;
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "ID";
            comboBox.DisplayMember = "ID";

            Conexao.Close();
        }

        public void CarregaIDComunicacao(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT ID FROM PLACA_COMUNICACAO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["ID"] = 0;
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "ID";
            comboBox.DisplayMember = "ID";

            Conexao.Close();
        }

        public void CarregaIDEncoder(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT ID FROM PLACA_ENCODER";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["ID"] = 0;
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "ID";
            comboBox.DisplayMember = "ID";

            Conexao.Close();
        }

        public void CarregaIDCheckList(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT ID FROM PROPOSTA";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["ID"] = 0;
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "ID";
            comboBox.DisplayMember = "ID";

            Conexao.Close();
        }

        public void CarregaIDUsuario(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT ID FROM USUARIOS";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["ID"] = 0;
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "ID";
            comboBox.DisplayMember = "ID";

            Conexao.Close();
        }

        /*
            Carrega Empresas Check-List
         */

        public void CarregaEmpresa(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT EMPRESA FROM DADOS_CLIENTE";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["EMPRESA"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "EMPRESA";
            comboBox.DisplayMember = "EMPRESA";

            Conexao.Close();
        }

        public void CarregaCliente(System.Windows.Forms.ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT NOME FROM DADOS_CLIENTE";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var table = new DataTable();

            table.Load(reader);
            var linha = table.NewRow();
            linha["NOME"] = "";
            table.Rows.InsertAt(linha, 0);
            comboBox.DataSource = table;
            comboBox.ValueMember = "NOME";
            comboBox.DisplayMember = "NOME";

            Conexao.Close();
        }
    }
}
