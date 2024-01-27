using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace proj_casa_dos_dados
{
    public class gerarExcel
    {
        public static void excelProcess(Form1 myForm)
        {
            List<string> cnpjResponses = myForm.GetApiResponses();

            //foreach (string cnpj in cnpjResponses)
            foreach (string jsonResponse in cnpjResponses)
            {
                //CnpjData cnpjData = JsonConvert.DeserializeObject<CnpjData>(jsonResponse);
                //MessageBox.Show(jsonResponse);
                
                CnpjDataContainer dataContainer = JsonConvert.DeserializeObject<CnpjDataContainer>(jsonResponse);
                List<CnpjData> cnpj_DataList = dataContainer?.data?.cnpj;

                //ExportToExcel(new List<CnpjData> { cnpj_DataList });
                ExportToExcel(cnpj_DataList);
            }
        }

        static void ExportToExcel(List<CnpjData> cnpjDataList)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Add a worksheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("CnpjData");

                // Add headers
                worksheet.Cells[1, 1].Value = "Cnpj";
                worksheet.Cells[1, 2].Value = "Cnpj Raiz";
                worksheet.Cells[1, 3].Value = "Filial Numero";
                worksheet.Cells[1, 4].Value = "Razao Social";
                worksheet.Cells[1, 5].Value = "Nome Fantasia";
                worksheet.Cells[1, 6].Value = "Data Abertura";
                worksheet.Cells[1, 7].Value = "Situacao Cadastral";
                worksheet.Cells[1, 8].Value = "Logradouro";
                worksheet.Cells[1, 9].Value = "Numero";
                worksheet.Cells[1, 10].Value = "Bairro";
                worksheet.Cells[1, 11].Value = "Municipio";
                worksheet.Cells[1, 12].Value = "Uf";
                //worksheet.Cells[1, 13].Value = "Atividade Principal Codigo";
                //worksheet.Cells[1, 14].Value = "Atividade Principal Descricao";
                worksheet.Cells[1, 15].Value = "Cnpj MEI";
                worksheet.Cells[1, 16].Value = "Versao";

                // Add data rows
                int row = 2;
                foreach (CnpjData cnpjData in cnpjDataList)
                {
                    worksheet.Cells[row, 1].Value = cnpjData.cnpj;
                    worksheet.Cells[row, 2].Value = cnpjData.cnpj_raiz;
                    worksheet.Cells[row, 3].Value = cnpjData.filial_numero;
                    worksheet.Cells[row, 4].Value = cnpjData.razao_social;
                    worksheet.Cells[row, 5].Value = cnpjData.nome_fantasia;
                    worksheet.Cells[row, 6].Value = cnpjData.data_abertura;
                    worksheet.Cells[row, 7].Value = cnpjData.situacao_cadastral;
                    worksheet.Cells[row, 8].Value = cnpjData.logradouro;
                    worksheet.Cells[row, 9].Value = cnpjData.numero;
                    worksheet.Cells[row, 10].Value = cnpjData.bairro;
                    worksheet.Cells[row, 11].Value = cnpjData.municipio;
                    worksheet.Cells[row, 12].Value = cnpjData.uf;
                    //worksheet.Cells[row, 13].Value = cnpjData.AtividadePrincipal.codigo;
                    //worksheet.Cells[row, 14].Value = cnpjData.AtividadePrincipal.descricao;
                    worksheet.Cells[row, 15].Value = cnpjData.cnpj_mei;
                    worksheet.Cells[row, 16].Value = cnpjData.versao;

                    row++;
                }

                // Save the Excel package to a file
                string fullPath = @"C:\Users\jesse\Downloads\CnpjData.xlsx";
                FileInfo excelFile = new FileInfo(fullPath);
                excelPackage.SaveAs(excelFile);
                Console.WriteLine("Excel file created and data exported.");
            }
        }
    }
}
