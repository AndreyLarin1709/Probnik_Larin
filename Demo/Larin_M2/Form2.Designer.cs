using System.Drawing;
using System.Windows.Forms;

namespace Larin_M2
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPartnerType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            comboBoxPartnerType = new ComboBox();
            label2 = new Label();
            textBox9 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            label8 = new Label();
            textBox8 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(339, 117);
            label1.Name = "label1";
            label1.Size = new Size(118, 23);
            label1.TabIndex = 0;
            label1.Text = "Тип партнёра";
            // 
            // comboBoxPartnerType
            // 
            comboBoxPartnerType.Font = new Font("Segoe UI", 10F);
            comboBoxPartnerType.FormattingEnabled = true;
            comboBoxPartnerType.Location = new Point(12, 109);
            comboBoxPartnerType.Name = "comboBoxPartnerType";
            comboBoxPartnerType.Size = new Size(315, 31);
            comboBoxPartnerType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(339, 157);
            label2.Name = "label2";
            label2.Size = new Size(165, 23);
            label2.TabIndex = 2;
            label2.Text = "Название партнёра";
            // 
            // textBox9
            // 
            textBox9.Font = new Font("Segoe UI", 10F);
            textBox9.Location = new Point(12, 151);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(315, 30);
            textBox9.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(339, 197);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 4;
            label3.Text = "Директор";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10F);
            textBox3.Location = new Point(12, 191);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(315, 30);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(339, 237);
            label4.Name = "label4";
            label4.Size = new Size(244, 23);
            label4.TabIndex = 6;
            label4.Text = "Электронный адрес партнёра";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 10F);
            textBox4.Location = new Point(12, 231);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(315, 30);
            textBox4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(339, 274);
            label5.Name = "label5";
            label5.Size = new Size(157, 23);
            label5.TabIndex = 8;
            label5.Text = "Телефон партнёра";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 10F);
            textBox5.Location = new Point(12, 271);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(315, 30);
            textBox5.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(339, 317);
            label6.Name = "label6";
            label6.Size = new Size(234, 23);
            label6.TabIndex = 10;
            label6.Text = "Физический адрес партнёра";
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 10F);
            textBox6.Location = new Point(12, 311);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(315, 30);
            textBox6.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(339, 357);
            label7.Name = "label7";
            label7.Size = new Size(47, 23);
            label7.TabIndex = 12;
            label7.Text = "ИНН";
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Segoe UI", 10F);
            textBox7.Location = new Point(12, 351);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(315, 30);
            textBox7.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(339, 397);
            label8.Name = "label8";
            label8.Size = new Size(73, 23);
            label8.TabIndex = 14;
            label8.Text = "Рейтинг";
            // 
            // textBox8
            // 
            textBox8.Font = new Font("Segoe UI", 10F);
            textBox8.Location = new Point(12, 391);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(315, 30);
            textBox8.TabIndex = 15;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(103, 186, 128);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(190, 427);
            button1.Name = "button1";
            button1.Size = new Size(137, 38);
            button1.TabIndex = 16;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(244, 232, 211);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = Color.FromArgb(103, 186, 128);
            button2.Location = new Point(12, 427);
            button2.Name = "button2";
            button2.Size = new Size(137, 38);
            button2.TabIndex = 17;
            button2.Text = "Вернуться";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1015, 602);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox8);
            Controls.Add(label8);
            Controls.Add(textBox7);
            Controls.Add(label7);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox9);
            Controls.Add(label2);
            Controls.Add(comboBoxPartnerType);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Мастер пол | Редактирование/Добавление";
            FormClosing += Form2_FormClosing;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox1;
    }
}
