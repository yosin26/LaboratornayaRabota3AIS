using System;
using System.Data;
using System.Windows.Forms;
using PostgreSqlLesson.DbConnection;

namespace PostgreSqlLesson.Windows.DB
{
    public partial class TablesUserControl : UserControl
    {
        private DbContext dbContext;

        public TablesUserControl()
        {
            InitializeComponent();
            dbContext = new DbContext();

            LoadTablesData();
        }

        // Метод для загрузки данных таблиц
        public void LoadTablesData()
        {
            // Список таблиц и запросов для каждой
            var tables = new (string TableName, string Query, DataGridView DataGridView)[]
            {
                ("Geese", "SELECT * FROM geese", dataGridView1),
                ("Owners", "SELECT * FROM owners", dataGridView2),
                ("Eggs", "SELECT * FROM eggs", dataGridView3),
                ("Feed", "SELECT * FROM feed", dataGridView4),
                ("Feeding Schedule", "SELECT * FROM feeding_schedule", dataGridView5),
                ("Vet Visits", "SELECT * FROM vet_visits", dataGridView6),
                ("Goose Owners", "SELECT * FROM goose_owners", dataGridView7)
            };

            foreach (var (tableName, query, dataGridView) in tables)
            {
                if (dataGridView != null)
                {
                    // Выполнение запроса и получение данных
                    DataTable dataTable = dbContext.ExecuteQuery(query);

                    // Проверка на null и присваивание данных в DataGridView
                    if (dataTable != null)
                    {
                        dataGridView.DataSource = dataTable;
                        dataGridView.ReadOnly = true;
                        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при загрузке данных для таблицы: {tableName}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            label1.Text = "Таблица Гуси";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            label1.Text = "Таблица Владельцы";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            label1.Text = "Таблица Яйца";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            label1.Text = "Таблица Корма";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
            label1.Text = "Таблица График кормления";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);
            label1.Text = "Таблица Визиты к ветеренару";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);
            label1.Text = "Таблица Связующая таблица Гусей и Владельцев";
        }
    }
}
