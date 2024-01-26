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
            SuspendLayout();
            // 
            // btnApiRequest
            // 
            btnApiRequest.Location = new Point(138, 95);
            btnApiRequest.Name = "btnApiRequest";
            btnApiRequest.Size = new Size(75, 23);
            btnApiRequest.TabIndex = 0;
            btnApiRequest.Text = "Consultar";
            btnApiRequest.UseVisualStyleBackColor = true;
            btnApiRequest.Click += btnApiRequest_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 360);
            Controls.Add(btnApiRequest);
            Name = "Form1";
            Text = "OfBusiness Tool - Casa dos Dados";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnApiRequest;
    }
}