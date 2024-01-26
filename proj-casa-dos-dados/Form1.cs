using System.Windows.Forms.Design;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj_casa_dos_dados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnApiRequest_Click(object sender, EventArgs e)
        {
            //await PerformApiRequest;
            try
            {
                string apiResponse = await ApiService.PerformApiRequestAsync();
                MessageBox.Show($"API Request completed. Response: {apiResponse}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "API Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}