using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms.Design;
using HtmlAgilityPack;
using System.Data.Common;
using proj_casa_dos_dados.EstruturaDadosCnpj;

namespace proj_casa_dos_dados
{
    public class gerarExcel
    {
        private static int contCnpjResponses;
        private static int row = 2;
        public static void excelProcess(Form1 myForm)
        {
            List<string> cnpjResponses = myForm.GetApiResponses();
            contCnpjResponses = cnpjResponses.Count;

            ExportToExcel(cnpjResponses);
        }

        static async Task<string> ExportToExcel(List<string> cnpjResponses)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Definições do ExcelPackage (consultar documentação)
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("CnpjData");

                foreach (string jsonResponse in cnpjResponses)
                {
                    CnpjDataContainer dataContainer = JsonConvert.DeserializeObject<CnpjDataContainer>(jsonResponse);
                    List<CnpjData> cnpj_DataList = dataContainer?.data?.cnpj;

                    if (cnpj_DataList == null)
                    {
                        if (contCnpjResponses == 1)
                        {
                            MessageBox.Show("Não há dados a serem exportados");
                        }
                        else if (contCnpjResponses > 1)
                        {
                            //fim da lista de resultados (parece que ao fim de cada consulta a API tbm gera mais uma response com o resumo da consulta (status, count e pag:1))
                        }
                        else
                        {
                            MessageBox.Show("Algo deu errado. Contate o administrador da plataforma");
                        }
                    }
                    else
                    {
                        if (row == 2)
                        {
                            worksheet.Cells[1, 1].Value = "Cnpj"; //usar esse 2
                            worksheet.Cells[1, 2].Value = "Cnpj Raiz";
                            worksheet.Cells[1, 3].Value = "Filial Numero";
                            worksheet.Cells[1, 4].Value = "Razao Social"; //usar esse 1
                            worksheet.Cells[1, 5].Value = "Nome Fantasia";
                            worksheet.Cells[1, 6].Value = "Data Abertura";
                            worksheet.Cells[1, 7].Value = "Situacao Cadastral";
                            worksheet.Cells[1, 8].Value = "Logradouro";
                            worksheet.Cells[1, 9].Value = "Numero";
                            worksheet.Cells[1, 10].Value = "Bairro";
                            worksheet.Cells[1, 11].Value = "Municipio";
                            worksheet.Cells[1, 12].Value = "Uf";
                            worksheet.Cells[1, 13].Value = "Atividade Principal Codigo";
                            worksheet.Cells[1, 14].Value = "Atividade Principal Descricao";
                            worksheet.Cells[1, 15].Value = "Cnpj MEI";
                            worksheet.Cells[1, 16].Value = "Versao";
                            worksheet.Cells[1, 17].Value = "E-MAIL";
                            worksheet.Cells[1, 18].Value = "Telefone";
                            worksheet.Cells[1, 19].Value = "Link";
                        }

                        foreach (CnpjData cnpjData in cnpj_DataList)
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
                            worksheet.Cells[row, 13].Value = cnpjData.atividade_principal.codigo;
                            worksheet.Cells[row, 14].Value = cnpjData.atividade_principal.descricao;
                            worksheet.Cells[row, 15].Value = cnpjData.cnpj_mei;
                            worksheet.Cells[row, 16].Value = cnpjData.versao;

                            row++;
                        }
                    }
                }

                // Alguns dados estão em páginas específicas de cada CNPJ. É necessario um webscraping
                // Criando os links de cada página a ser consultada
                string linkRaizSolucao = "https://casadosdados.com.br/solucao/cnpj";

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    string razaoSocialNovo = ReplaceCharacters(worksheet.Cells[row, 4].Value.ToString());
                    string cnpjNovo = ReplaceCharacters(worksheet.Cells[row, 1].Value.ToString());

                    string linkSolucaoCnpj = $"{linkRaizSolucao}/{razaoSocialNovo}-{cnpjNovo}";
                    worksheet.Cells[row, 19].Value = linkSolucaoCnpj;
                }

                // Chamando o webscraper para recuperar os dados (E-MAIL e Telefone)
                WebScraper webScraperObj = new WebScraper();
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    object cellValue = worksheet.Cells[row, 19].Value;
                    string stringValue = cellValue?.ToString();

                    string[] labels = { "E-MAIL", "Telefone" };
                    int scrapeColIndex = 17;
                    foreach (string label in labels)
                    {
                        worksheet.Cells[row, scrapeColIndex].Value = await webScraperObj.ScrapeCnpjDados(stringValue, label);
                        scrapeColIndex++;
                    }
                }

                //Salvar o ExcelPackage como arquivo Excel (xlsx)
                SaveExcelFile(excelPackage);
            }
            return "Processo Encerrado";
        }

        // Regex para auxiliar na criação dos links das páginas de cada CNPJ
        static string ReplaceCharacters(string input)
        {
            string result = Regex.Replace(input, @"[- ,.:;\\/]+", "-");
            result = Regex.Replace(result, @"-+", "-");
            result = Regex.Replace(result, @"&+", "e");
            result = result.ToLower();

            return result;
        }

        // Salva o ExcelPackage no path selecionado
        private static void SaveExcelFile(ExcelPackage excelPackage)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Salvar resultados da consulta";
                saveFileDialog.DefaultExt = "xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao tentar salvar o arquivo: {ex.Message}", "Erro");
                    }
                }
            }
        }
    }
}
