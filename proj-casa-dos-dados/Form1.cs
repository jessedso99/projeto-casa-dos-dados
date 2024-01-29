using System.Windows.Forms.Design;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj_casa_dos_dados
{
    public partial class Form1 : Form
    {
        private List<string> apiResponses;

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
                do
                {
                    apiResponses.Add(await ApiService.PerformApiRequestAsync());
                    contPag++;
                } while (((ApiService.countJsonResult) / 20)+1 >= contPag);
                
                //Console.WriteLine(ApiService.countJsonResult);

                MessageBox.Show("API request completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "API Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> GetApiResponses()
        {
            return apiResponses;
        }

        private void btn_gerarExcel_Click(object sender, EventArgs e)
        {
            gerarExcel.excelProcess(this);
        }
    }
}