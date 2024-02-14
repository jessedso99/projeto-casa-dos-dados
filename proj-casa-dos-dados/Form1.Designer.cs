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
            dateTimePicker2 = new DateTimePicker();
            radioButton3 = new RadioButton();
            progressBar1 = new ProgressBar();
            groupBox2 = new GroupBox();
            checkedListBox1 = new CheckedListBox();
            radioButtonSim = new RadioButton();
            radioButtonNao = new RadioButton();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // btnApiRequest
            // 
            btnApiRequest.Location = new Point(192, 380);
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
            btn_gerarExcel.Location = new Point(273, 380);
            btn_gerarExcel.Name = "btn_gerarExcel";
            btn_gerarExcel.Size = new Size(69, 23);
            btn_gerarExcel.TabIndex = 1;
            btn_gerarExcel.Text = "Exportar";
            btn_gerarExcel.UseVisualStyleBackColor = true;
            btn_gerarExcel.Click += btn_gerarExcel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 85);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data de Abertura - A partir de";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 51);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(146, 23);
            textBox1.TabIndex = 4;
            textBox1.Text = "Considerar todo operíodo";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(29, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(295, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(9, 55);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 2;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(9, 27);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(29, 22);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(295, 23);
            dateTimePicker2.TabIndex = 7;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Location = new Point(9, 27);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(14, 13);
            radioButton3.TabIndex = 6;
            radioButton3.TabStop = true;
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 351);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(330, 23);
            progressBar1.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dateTimePicker2);
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Location = new Point(12, 103);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(330, 57);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Data de Abertura - Até";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(6, 72);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(115, 94);
            checkedListBox1.Sorted = true;
            checkedListBox1.TabIndex = 13;
            // 
            // radioButtonSim
            // 
            radioButtonSim.AutoSize = true;
            radioButtonSim.Location = new Point(6, 22);
            radioButtonSim.Name = "radioButtonSim";
            radioButtonSim.Size = new Size(45, 19);
            radioButtonSim.TabIndex = 14;
            radioButtonSim.Text = "Sim";
            radioButtonSim.UseVisualStyleBackColor = true;
            // 
            // radioButtonNao
            // 
            radioButtonNao.AutoSize = true;
            radioButtonNao.Checked = true;
            radioButtonNao.Location = new Point(57, 22);
            radioButtonNao.Name = "radioButtonNao";
            radioButtonNao.Size = new Size(47, 19);
            radioButtonNao.TabIndex = 15;
            radioButtonNao.TabStop = true;
            radioButtonNao.Text = "Não";
            radioButtonNao.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButtonSim);
            groupBox3.Controls.Add(radioButtonNao);
            groupBox3.Location = new Point(157, 169);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(185, 46);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Buscar Email e Telefone?";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(radioButton5);
            groupBox4.Controls.Add(radioButton4);
            groupBox4.Controls.Add(checkedListBox1);
            groupBox4.Location = new Point(12, 169);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(139, 176);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Estado (UF)";
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Checked = true;
            radioButton5.Location = new Point(6, 47);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(88, 19);
            radioButton5.TabIndex = 15;
            radioButton5.TabStop = true;
            radioButton5.Text = "Selecionar...";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += radioButton5_CheckedChanged;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(6, 22);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(114, 19);
            radioButton4.TabIndex = 14;
            radioButton4.Text = "Todos os Estados";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 414);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnApiRequest;
        private Button btn_gerarExcel;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ProgressBar progressBar1;
        private DateTimePicker dateTimePicker2;
        private RadioButton radioButton3;
        private GroupBox groupBox2;
        private CheckedListBox checkedListBox1;
        private RadioButton radioButtonSim;
        private RadioButton radioButtonNao;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
    }
}