namespace Lab06_C
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
            components = new System.ComponentModel.Container();
            txtName = new TextBox();
            txtGuess = new TextBox();
            btnSubmit = new Button();
            lblMessage = new Label();
            lblRange = new Label();
            timer = new System.Windows.Forms.Timer(components);
            txtRoundsLeft = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAutoPlay = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(154, 144);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(270, 43);
            txtName.TabIndex = 0;
            // 
            // txtGuess
            // 
            txtGuess.Location = new Point(180, 278);
            txtGuess.Multiline = true;
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(124, 45);
            txtGuess.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.PapayaWhip;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(311, 265);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(113, 65);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Đoán";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click_1;
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.White;
            lblMessage.ForeColor = SystemColors.ActiveCaptionText;
            lblMessage.Location = new Point(12, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(412, 120);
            lblMessage.TabIndex = 3;
            lblMessage.Text = "Thông báo";
            // 
            // lblRange
            // 
            lblRange.BackColor = Color.White;
            lblRange.ForeColor = SystemColors.ControlText;
            lblRange.Location = new Point(190, 201);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(234, 50);
            lblRange.TabIndex = 4;
            // 
            // txtRoundsLeft
            // 
            txtRoundsLeft.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoundsLeft.Location = new Point(634, 12);
            txtRoundsLeft.Multiline = true;
            txtRoundsLeft.Name = "txtRoundsLeft";
            txtRoundsLeft.Size = new Size(82, 71);
            txtRoundsLeft.TabIndex = 6;
            txtRoundsLeft.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 152);
            label1.Name = "label1";
            label1.Size = new Size(143, 53);
            label1.TabIndex = 7;
            label1.Text = "Tên người chơi";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 283);
            label2.Name = "label2";
            label2.Size = new Size(100, 29);
            label2.TabIndex = 8;
            label2.Text = "Số đoán";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(445, 29);
            label3.Name = "label3";
            label3.Size = new Size(190, 29);
            label3.TabIndex = 9;
            label3.Text = "Số vòng chơi còn lại";
            // 
            // btnAutoPlay
            // 
            btnAutoPlay.BackColor = Color.PapayaWhip;
            btnAutoPlay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAutoPlay.Location = new Point(463, 240);
            btnAutoPlay.Name = "btnAutoPlay";
            btnAutoPlay.Size = new Size(136, 61);
            btnAutoPlay.TabIndex = 10;
            btnAutoPlay.Text = "AutoPlay";
            btnAutoPlay.UseVisualStyleBackColor = false;
            btnAutoPlay.Click += btnAutoPlay_Click_1;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(617, 228);
            label4.Name = "label4";
            label4.Size = new Size(91, 84);
            label4.TabIndex = 11;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.LightSeaGreen;
            label5.Location = new Point(445, 201);
            label5.Name = "label5";
            label5.Size = new Size(271, 131);
            label5.TabIndex = 12;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(48, 222);
            label6.Name = "label6";
            label6.Size = new Size(90, 29);
            label6.TabIndex = 13;
            label6.Text = "Phạm vi";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aquamarine;
            ClientSize = new Size(720, 361);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(btnAutoPlay);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRoundsLeft);
            Controls.Add(lblRange);
            Controls.Add(lblMessage);
            Controls.Add(btnSubmit);
            Controls.Add(txtGuess);
            Controls.Add(txtName);
            Controls.Add(label5);
            Name = "Form1";
            Text = "Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private System.Windows.Forms.Timer timer;
      

        // Trong Form1.Designer.cs
        private System.Windows.Forms.TextBox txtRoundsLeft;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGuess;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAutoPlay;
        private Label label4;
        private Label label5;
        private Label label6;

        // Đảm bảo các điều khiển được khởi tạo đúng trong InitializeComponent()
    }
}
