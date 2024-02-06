namespace proj_casa_dos_dados
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnApiRequest = new Button();
            btn_gerarExcel = new Button();
            SuspendLayout();
            // 
            // btnApiRequest
            // 
            btnApiRequest.Location = new Point(44, 41);
            btnApiRequest.Name = "btnApiRequest";
            btnApiRequest.Size = new Size(75, 23);
            btnApiRequest.TabIndex = 0;
            btnApiRequest.Text = "Consultar";
            btnApiRequest.UseVisualStyleBackColor = true;
            btnApiRequest.Click += btnApiRequest_Click;
            // 
            // btn_gerarExcel
            // 
            btn_gerarExcel.Location = new Point(213, 41);
            btn_gerarExcel.Name = "btn_gerarExcel";
            btn_gerarExcel.Size = new Size(75, 23);
            btn_gerarExcel.TabIndex = 1;
            btn_gerarExcel.Text = "Gerar Excel";
            btn_gerarExcel.UseVisualStyleBackColor = true;
            btn_gerarExcel.Click += btn_gerarExcel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 105);
            Controls.Add(btn_gerarExcel);
            Controls.Add(btnApiRequest);
            Name = "Form1";
            Text = "OfBusiness Tool - Casa dos Dados";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnApiRequest;
        private Button btn_gerarExcel;
    }
}