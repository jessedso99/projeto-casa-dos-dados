using System.Windows.Forms.Design;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        private async void btnApiRequest_Click(object sender, EventArgs e)
        {
            try
            {
                int contPag = 0;
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

                // Realizando o request a agregando as responses na lista apiResponses
                do
                {
                    apiResponses.Add(await ApiService.PerformApiRequestAsync());
                    contPag++;

                    // Setando o valores para a Progressbar
                    progressBar1.Maximum = (ApiService.countJsonResult / 20) + 1;
                    progressBar1.Value = contPag;
                } while (((ApiService.countJsonResult) / 20) > contPag); // / 20) + 1 >= contPag);

                MessageBox.Show("Consulta conclu�da!");
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

        private void btn_gerarExcel_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = ApiService.countJsonResult + 1;
            gerarExcel.excelProcess(this);
        }
        public void UpdateProgressBar(int progressValue)
        {
            progressBar1.Value = progressValue;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}