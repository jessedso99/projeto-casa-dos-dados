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
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnApiRequest
            // 
            btnApiRequest.Location = new Point(320, 126);
            btnApiRequest.Name = "btnApiRequest";
            btnApiRequest.Size = new Size(75, 23);
            btnApiRequest.TabIndex = 0;
            btnApiRequest.Text = "Consultar";
            btnApiRequest.UseVisualStyleBackColor = true;
            btnApiRequest.Click += btnApiRequest_Click;
            // 
            // btn_gerarExcel
            // 
            btn_gerarExcel.Enabled = false;
            btn_gerarExcel.Location = new Point(401, 126);
            btn_gerarExcel.Name = "btn_gerarExcel";
            btn_gerarExcel.Size = new Size(75, 23);
            btn_gerarExcel.TabIndex = 1;
            btn_gerarExcel.Text = "Gerar Excel";
            btn_gerarExcel.UseVisualStyleBackColor = true;
            btn_gerarExcel.Click += btn_gerarExcel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(466, 103);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pesquisa Avançada";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(194, 60);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(146, 23);
            textBox1.TabIndex = 4;
            textBox1.Text = "Considerar todo operíodo";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(194, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(266, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(174, 64);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(174, 28);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(162, 15);
            label1.TabIndex = 0;
            label1.Text = "Data de Abertura - A partir de";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 126);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(288, 23);
            progressBar1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 160);
            Controls.Add(progressBar1);
            Controls.Add(groupBox1);
            Controls.Add(btn_gerarExcel);
            Controls.Add(btnApiRequest);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "OfBusiness Tool - Casa dos Dados";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnApiRequest;
        private Button btn_gerarExcel;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ProgressBar progressBar1;
    }
}