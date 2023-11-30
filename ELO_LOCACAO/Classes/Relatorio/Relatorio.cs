using ELO_LOCACAO.Paginas;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace ELO_LOCACAO.Classes.Relatorio
{
    internal class Relatorio
    {
        public static string FilePath;

        public bool GeradorEquip(DataGridView dataGridView)
        {
            //Palavra de Status se geração de relatório foi feita ou não;
            bool status = false;

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                {
                    string nomeDaColuna = dataGridView.Columns[colunaIndex].HeaderText;
                    excelWorksheet.Cells[1, colunaIndex + 1] = nomeDaColuna;
                }

                for (int rowIndex = 0; rowIndex < dataGridView.Rows.Count; rowIndex++)
                {
                    for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                    {
                        // Preencha a célula do Excel com o valor da célula do DataGridView
                        excelWorksheet.Cells[rowIndex + 2, colunaIndex + 1] = dataGridView.Rows[rowIndex].Cells[colunaIndex].Value;
                    }
                }

                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    // Define o título do diálogo
                    dialog.Title = "Salvar Arquivo";

                    // Define o filtro de extensão de arquivo (opcional)
                    dialog.Filter = "Planilha Excel (*.xlsx)|*.xlsx|Todos os Arquivos (*.*)|*.*";

                    // Configura o diálogo para permitir ao usuário especificar o nome do arquivo
                    dialog.FileName = "Relatório_Equipamento.xlsx"; // Nome padrão do arquivo

                    // Exibe o diálogo e obtém o resultado
                    DialogResult result = dialog.ShowDialog();

                    // Verifica se o usuário clicou em "OK"
                    if (result == DialogResult.OK)
                    {
                        // Obtém o caminho completo do arquivo escolhido pelo usuário
                        string pastaSelecionada = dialog.FileName;

                        excelWorkbook.SaveAs(pastaSelecionada);

                        MessageBox.Show("Planilha do Excel criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Feche e libere os objetos do Excel
                        excelWorkbook.Close();
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                        MessageBox.Show("Arquivo salvo: " + pastaSelecionada);

                        FilePath = pastaSelecionada;
                    }
                }

                status = true;

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório!: {ex}");
                Console.WriteLine(ex);

                status = false;

                return status;
            }
        }

        public bool GeradorIO(DataGridView dataGridView)
        {
            bool status = false;
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                {
                    string nomeDaColuna = dataGridView.Columns[colunaIndex].HeaderText;
                    excelWorksheet.Cells[1, colunaIndex + 1] = nomeDaColuna;
                }

                for (int rowIndex = 0; rowIndex < dataGridView.Rows.Count; rowIndex++)
                {
                    for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                    {
                        // Preencha a célula do Excel com o valor da célula do DataGridView
                        excelWorksheet.Cells[rowIndex + 2, colunaIndex + 1] = dataGridView.Rows[rowIndex].Cells[colunaIndex].Value;
                    }
                }

                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    // Define o título do diálogo
                    dialog.Title = "Salvar Arquivo";

                    // Define o filtro de extensão de arquivo (opcional)
                    dialog.Filter = "Planilha Excel (*.xlsx)|*.xlsx|Todos os Arquivos (*.*)|*.*";

                    // Configura o diálogo para permitir ao usuário especificar o nome do arquivo
                    dialog.FileName = "Relatório_IO.xlsx"; // Nome padrão do arquivo

                    // Exibe o diálogo e obtém o resultado
                    DialogResult result = dialog.ShowDialog();

                    // Verifica se o usuário clicou em "OK"
                    if (result == DialogResult.OK)
                    {
                        // Obtém o caminho completo do arquivo escolhido pelo usuário
                        string pastaSelecionada = dialog.FileName;

                        excelWorkbook.SaveAs(pastaSelecionada);
                        
                        MessageBox.Show("Planilha do Excel criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Feche e libere os objetos do Excel
                        excelWorkbook.Close();
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                        MessageBox.Show("Arquivo salvo: " + pastaSelecionada);
                    }
                }

                status = true;

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                Console.WriteLine(ex);

                status = false;

                return status;
            }
        }

        public bool GeradorComm(DataGridView dataGridView)
        {

            bool status = false;
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                {
                    string nomeDaColuna = dataGridView.Columns[colunaIndex].HeaderText;
                    excelWorksheet.Cells[1, colunaIndex + 1] = nomeDaColuna;
                }

                for (int rowIndex = 0; rowIndex < dataGridView.Rows.Count; rowIndex++)
                {
                    for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                    {
                        // Preencha a célula do Excel com o valor da célula do DataGridView
                        excelWorksheet.Cells[rowIndex + 2, colunaIndex + 1] = dataGridView.Rows[rowIndex].Cells[colunaIndex].Value;
                    }
                }

                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    // Define o título do diálogo
                    dialog.Title = "Salvar Arquivo";

                    // Define o filtro de extensão de arquivo (opcional)
                    dialog.Filter = "Planilha Excel (*.xlsx)|*.xlsx|Todos os Arquivos (*.*)|*.*";

                    // Configura o diálogo para permitir ao usuário especificar o nome do arquivo
                    dialog.FileName = "Relatório_Comm.xlsx"; // Nome padrão do arquivo

                    // Exibe o diálogo e obtém o resultado
                    DialogResult result = dialog.ShowDialog();

                    // Verifica se o usuário clicou em "OK"
                    if (result == DialogResult.OK)
                    {
                        // Obtém o caminho completo do arquivo escolhido pelo usuário
                        string pastaSelecionada = dialog.FileName;

                        excelWorkbook.SaveAs(pastaSelecionada);

                        MessageBox.Show("Planilha do Excel criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Feche e libere os objetos do Excel
                        excelWorkbook.Close();
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                        MessageBox.Show("Arquivo salvo: " + pastaSelecionada);
                    }
                }

                status = true;

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                Console.WriteLine(ex);

                status = false;

                return status;
            }
        }

        public bool GeradorEncoder(DataGridView dataGridView)
        {

            bool status = false;
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                {
                    string nomeDaColuna = dataGridView.Columns[colunaIndex].HeaderText;
                    excelWorksheet.Cells[1, colunaIndex + 1] = nomeDaColuna;
                }

                for (int rowIndex = 0; rowIndex < dataGridView.Rows.Count; rowIndex++)
                {
                    for (int colunaIndex = 0; colunaIndex < dataGridView.Columns.Count; colunaIndex++)
                    {
                        // Preencha a célula do Excel com o valor da célula do DataGridView
                        excelWorksheet.Cells[rowIndex + 2, colunaIndex + 1] = dataGridView.Rows[rowIndex].Cells[colunaIndex].Value;
                    }
                }

                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    // Define o título do diálogo
                    dialog.Title = "Salvar Arquivo";

                    // Define o filtro de extensão de arquivo (opcional)
                    dialog.Filter = "Planilha Excel (*.xlsx)|*.xlsx|Todos os Arquivos (*.*)|*.*";

                    // Configura o diálogo para permitir ao usuário especificar o nome do arquivo
                    dialog.FileName = "Relatório_Encoder.xlsx"; // Nome padrão do arquivo

                    // Exibe o diálogo e obtém o resultado
                    DialogResult result = dialog.ShowDialog();

                    // Verifica se o usuário clicou em "OK"
                    if (result == DialogResult.OK)
                    {
                        // Obtém o caminho completo do arquivo escolhido pelo usuário
                        string pastaSelecionada = dialog.FileName;

                        excelWorkbook.SaveAs(pastaSelecionada);

                        MessageBox.Show("Planilha do Excel criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Feche e libere os objetos do Excel
                        excelWorkbook.Close();
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                        MessageBox.Show("Arquivo salvo: " + pastaSelecionada);
                    }
                }

                status = true;

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                Console.WriteLine(ex);

                status = false;

                return status;
            }
        }
    }
}
