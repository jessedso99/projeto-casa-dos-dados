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
            //await PerformApiRequest;
            try
            {
                //string apiResponse = await ApiService.PerformApiRequestAsync();
                //MessageBox.Show($"API Request completed. Response: {apiResponse}");
                apiResponses.Add(await ApiService.PerformApiRequestAsync());
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