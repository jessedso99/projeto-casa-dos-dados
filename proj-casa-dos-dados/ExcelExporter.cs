using OfficeOpenXml;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace proj_casa_dos_dados
{
    internal class ExcelExporter
    {
        public static async Task ExportToExcel(ExcelPackage excelPackage)
        {
            if (excelPackage == null)
            {
                throw new ArgumentNullException(nameof(excelPackage));
            }
            try
            {
                try
                {
                    excelPackage.SaveAs(new FileInfo(@"C:\Casa dos Dados\Consulta_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx"));
                    MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso");
                }
                catch 
                {
                    criarPasta();
                    excelPackage.SaveAs(new FileInfo(@"C:\Casa dos Dados\Consulta_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx"));
                    MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar salvar o arquivo: {ex.Message}", "Erro");
            }

        }

        public static void criarPasta()
        {
            // Specify the path of the folder to create
            string folderPath = @"C:\Casa dos Dados";

            try
            {
                // Check if the folder exists
                if (!Directory.Exists(folderPath))
                {
                    // If the folder does not exist, create it
                    Directory.CreateDirectory(folderPath);
                    //MessageBox.Show("Folder created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("Folder already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

