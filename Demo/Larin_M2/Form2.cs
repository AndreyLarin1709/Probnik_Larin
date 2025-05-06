using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Larin_M2
{
    public partial class Form2 : Form
    {
        private bool isEdit;
        private string partnerName;

        public Form2(DataRow dataRow)
        {
            InitializeComponent();
            this.CenterToScreen();
            comboBoxPartnerType.Text = dataRow[0].ToString();
            textBox9.Text = dataRow[1].ToString();
            textBox3.Text = dataRow[2].ToString();
            textBox4.Text = dataRow[3].ToString();
            textBox5.Text = dataRow[4].ToString();
            textBox6.Text = dataRow[5].ToString();
            textBox7.Text = dataRow[6].ToString();
            textBox8.Text = dataRow[7].ToString();
            partnerName = dataRow[1].ToString();
            isEdit = true;
        }

        public Form2()
        {
            InitializeComponent();
            this.CenterToScreen();
            isEdit = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Загрузка типов партнеров в ComboBox
            string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Demo_Larin;Trusted_Connection=True;";
            using (var connection = new SqlConnection(conn))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT DISTINCT Тип_партнера FROM Partners_import", connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable partnerTypes = new DataTable();
                    adapter.Fill(partnerTypes);
                    comboBoxPartnerType.DataSource = partnerTypes;
                    comboBoxPartnerType.DisplayMember = "Тип_партнера";
                    comboBoxPartnerType.ValueMember = "Тип_партнера";
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(comboBoxPartnerType.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Все поля обязательны для заполнения.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность телефона
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, @"^\+7\d{10}$"))
            {
                MessageBox.Show("Номер телефона должен быть в формате +7XXXXXXXXXX.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность email
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Некорректный формат электронной почты.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность рейтинга
            if (!int.TryParse(textBox8.Text, out int rating) || rating < 0 || rating > 10)
            {
                MessageBox.Show("Рейтинг должен быть целым числом от 0 до 10.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка ИНН на цифры (например, длина 10 или 12 символов)
            if (!long.TryParse(textBox7.Text, out long inn) || (textBox7.Text.Length != 10 && textBox7.Text.Length != 12))
            {
                MessageBox.Show("ИНН должен быть числовым значением и содержать 10 или 12 цифр.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка других текстовых полей, если необходимо (например, для директора можно добавить длину)
            if (textBox3.Text.Length < 3)
            {
                MessageBox.Show("Имя директора должно быть не менее 3 символов.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // После того, как все проверки пройдены, вставляем или обновляем данные
            string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Demo_Larin;Trusted_Connection=True;";
            using (var connection = new SqlConnection(conn))
            {
                connection.Open();
                string sql;
                if (isEdit)
                {
                    sql = "UPDATE Partners_import SET Тип_партнера = @value1, Наименование_партнера = @value2, Директор = @value3, Электронная_почта_партнера = @value4, Телефон_партнера = @value5, Юридический_адрес_партнера = @value6, ИНН = @value7, Рейтинг = @value8 WHERE Наименование_партнера = @name";
                }
                else
                {
                    sql = "INSERT INTO Partners_import (Тип_партнера, Наименование_партнера, Директор, Электронная_почта_партнера, Телефон_партнера, Юридический_адрес_партнера, ИНН, Рейтинг) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)";
                }

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@value1", comboBoxPartnerType.Text);
                    command.Parameters.AddWithValue("@value2", textBox9.Text);
                    command.Parameters.AddWithValue("@value3", textBox3.Text);
                    command.Parameters.AddWithValue("@value4", textBox4.Text);
                    command.Parameters.AddWithValue("@value5", textBox5.Text);
                    command.Parameters.AddWithValue("@value6", textBox6.Text);
                    command.Parameters.AddWithValue("@value7", textBox7.Text);
                    command.Parameters.AddWithValue("@value8", textBox8.Text);
                    if (isEdit)
                    {
                        command.Parameters.AddWithValue("@name", partnerName);
                    }

                    command.ExecuteNonQuery();
                }
            }

            // Перезагрузка данных и отображение списка
            this.Hide();
            var form1 = new Form1();
            form1.Show();
        }
    }
}
