using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Larin_M2
{
    public partial class Form1 : Form
    {
        DataTable Partners = new DataTable();
        DataTable PartnerProduct = new DataTable();
        DataTable Products = new DataTable();
        DataTable MaterialType = new DataTable();
        DataTable ProductType = new DataTable();

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            // Настраиваем flowLayoutPanel1 для вертикального списка карточек
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;   // без переноса в колонки
            flowLayoutPanel1.AutoScroll = true;    // если карточек больше, появится скролл
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Partners.Clear();
            PartnerProduct.Clear();
            Products.Clear();
            MaterialType.Clear();
            ProductType.Clear();
            flowLayoutPanel1.Controls.Clear();
            LoadData();
            PopulatePartnerList();
        }

        public void LoadData()
        {
            string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Demo_Larin;Trusted_Connection=True;";
            using (var connection = new SqlConnection(conn))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Partners_import", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(Partners);

                using (var command = new SqlCommand("SELECT * FROM Partner_products_import", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(PartnerProduct);

                using (var command = new SqlCommand("SELECT * FROM Products_import", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(Products);

                using (var command = new SqlCommand("SELECT * FROM Material_type_import", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(MaterialType);

                using (var command = new SqlCommand("SELECT * FROM Product_type_import", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(ProductType);
            }
        }

        public void PopulatePartnerList()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in Partners.Rows)
            {
                // Подсчёт продаж
                int countSale = 0;
                foreach (DataRow pp in PartnerProduct.Rows)
                    if (pp[1].ToString() == row[1].ToString())
                        countSale += Convert.ToInt32(pp[2]);

                // Вычисление скидки
                int discount;
                if (countSale < 10000) discount = 0;
                else if (countSale < 50000) discount = 5;
                else if (countSale < 300000) discount = 10;
                else discount = 15;

                // Создаём панель-карточку
                var partnerPanel = new Panel
                {
                    Width = 1150,
                    Height = 120,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Padding = new Padding(10),
                    Tag = row  // Сохраняем DataRow здесь
                };

                // Общий обработчик клика
                EventHandler clickHandler = (s, e) =>
                {
                    // Ищем вверх по иерархии панель с DataRow в Tag
                    Control ctl = (Control)s;
                    while (ctl != null && !(ctl is Panel && ctl.Tag is DataRow))
                        ctl = ctl.Parent;

                    if (ctl != null)
                    {
                        var dr = (DataRow)ctl.Tag;
                        this.Hide();
                        new Form2(dr).Show();
                    }
                };

                // Вешаем обработчик на саму панель
                partnerPanel.Click += clickHandler;

                // Разметка внутри карточки
                var layout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 1,
                };
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

                var infoLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    Text = $"{row[0]} | {row[1]}\n{row[2]}\n{row[4]}\nРейтинг: {row[7]}"
                };

                var discLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    Text = $"{discount}%",
                    TextAlign = ContentAlignment.TopRight,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Dock = DockStyle.Fill
                };

                layout.Controls.Add(infoLabel, 0, 0);
                layout.Controls.Add(discLabel, 1, 0);

                partnerPanel.Controls.Add(layout);

                // Рекурсивно вешаем тот же обработчик на все вложенные контролы
                AddClickHandlerToAllControls(partnerPanel, clickHandler);

                flowLayoutPanel1.Controls.Add(partnerPanel);
            }
        }

        // Рекурсивный метод подвески клика на все вложенные контролы
        private void AddClickHandlerToAllControls(Control parent, EventHandler handler)
        {
            foreach (Control ctl in parent.Controls)
            {
                ctl.Click += handler;
                if (ctl.HasChildren)
                    AddClickHandlerToAllControls(ctl, handler);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
