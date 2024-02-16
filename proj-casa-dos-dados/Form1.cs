using System.Windows.Forms.Design;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace proj_casa_dos_dados
{
    public partial class Form1 : Form
    {
        private List<string> apiResponses;
        public int ProgressBarValue { get; set; }

        public Form1()
        {
            InitializeComponent();
            apiResponses = new List<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> listaDeEstados = new List<string> { "RO", "AC", "AM", "RR", "PA", "AP", "TO", "MA", "PI", "CE", "RN", "PB", "PE", "AL", "SE", "BA", "MG", "ES", "RJ", "SP", "PR", "SC", "RS", "MS", "MT", "GO", "DF" };

            foreach (string item in listaDeEstados)
            {
                checkedListBox1.Items.Add(item);
            }
        }

        private async void btnApiRequest_Click(object sender, EventArgs e)
        {
            try
            {
                int contPag = 0;

                //Data de abertura - Start
                DateTime DataDeAbertura = dateTimePicker1.Value;
                string strDataDeAbertura = DataDeAbertura.ToString("yyyy-MM-dd");
                if (radioButton1.Checked)
                {
                    ApiService.dataDeAbertura = strDataDeAbertura;
                }
                else if (radioButton2.Checked)
                {
                    ApiService.dataDeAbertura = null;
                }
                else
                {
                    radioButton1.Checked = true;
                    ApiService.dataDeAbertura = strDataDeAbertura;
                }

                //Data de abertura - End
                DateTime DataDeAberturaEnd = dateTimePicker2.Value;
                string strDataDeAberturaEnd = DataDeAberturaEnd.ToString("yyyy-MM-dd");
                ApiService.dataDeAberturaEnd = strDataDeAberturaEnd;

                //Setando as UF selecionadas ou Todos os Estados para a Consulta do ApiService
                List<string> ListaUF_Selecionadas = new List<string>();
                if (radioButton5.Checked == true)
                {
                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        ListaUF_Selecionadas.Add(item.ToString());
                    }
                    // Serialize the List<string> to JSON array format
                    string ufJsonArray = JsonConvert.SerializeObject(ListaUF_Selecionadas);
                    ApiService.UF_Selecionados = ufJsonArray;
                }
                else
                {
                    string ufJsonArrayVoid = "[]";
                    ApiService.UF_Selecionados = ufJsonArrayVoid;
                }

                //Realizar Web Scrap?
                if (radioButtonSim.Checked)
                {
                    gerarExcel.performWebScraper = true;
                }
                else if (radioButtonNao.Checked)
                {
                    gerarExcel.performWebScraper = false;
                }
                else
                {
                    radioButtonNao.Checked = true;
                    gerarExcel.performWebScraper = false;
                }

                //Somente MEI ou Excluir MEI?
                if (rBtn_somenteMei.Checked)
                {
                    ApiService.somenteMEI = "true";
                    ApiService.excluirMEI = "false";
                }
                else if (rBtn_excluirMei.Checked)
                {
                    ApiService.somenteMEI = "false";
                    ApiService.excluirMEI = "true";
                }
                else if (rBtn_ambosMei.Checked)
                {
                    ApiService.somenteMEI = "false";
                    ApiService.excluirMEI = "false";
                }
                else
                {
                    ApiService.somenteMEI = "true";
                    ApiService.excluirMEI = "true";
                }

                // Realizando o request a agregando as responses na lista apiResponses
                do
                {
                    apiResponses.Add(await ApiService.PerformApiRequestAsync());
                    contPag++;

                    // Setando o valores para a Progressbar
                    progressBar1.Maximum = (ApiService.countJsonResult / 20) + 1;
                    progressBar1.Value = contPag;
                } while (((ApiService.countJsonResult) / 20) > contPag);

                MessageBox.Show("Consulta concluída!");
                progressBar1.Value = 0;
                btn_gerarExcel.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro ao realizar API Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> GetApiResponses()
        {
            return apiResponses;
        }

        private async void btn_gerarExcel_Click(object sender, EventArgs e)
        {
            btn_gerarExcel.Enabled = false;
            var progress = new Progress<int>(value =>
            {
                progressBar1.Value = value;
            });

            progressBar1.Maximum = 100;
            await Task.Run(() => gerarExcel.excelProcess(this, progress));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                checkedListBox1.Enabled = true;
            }
            else
            {
                checkedListBox1.Enabled = false;
            }
        }
    }
}