using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PostgreSqlLesson.DbConnection; // Пространство имен для вашего класса подключения
using System.Runtime.InteropServices; // Для работы с Excel
using Excel = Microsoft.Office.Interop.Excel; // Добавляем использование пространства имен Excel
using System.Text.RegularExpressions; // Для работы с регулярными выражениями


namespace PostgreSqlLesson.Windows
{
    public partial class MainUserControl : UserControl
    {
        private DbContext dbConnection;

        public MainUserControl()
        {
            InitializeComponent();
            dbConnection = new DbContext(); // Инициализация подключения
            richTextBox2.Font = new Font("JetBrains Mono", 12); // Устанавливаем шрифт и размер
            richTextBox2.TextChanged += RichTextBox2_TextChanged; // Подписываемся на событие изменения текста
        }

        private void RichTextBox2_TextChanged(object sender, EventArgs e)
        {
            // Вызываем метод подсветки каждый раз, когда текст меняется
            HighlightSQLSyntax(richTextBox2.Text);
        }

        // Обработчик нажатия для button28 (Выполнение SQL-запроса)
        private void button28_Click(object sender, EventArgs e)
        {
            string query = richTextBox2.Text.Trim(); // Получаем текст из richTextBox2

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Пожалуйста, введите запрос.");
                return;
            }

            // Подсветить синтаксис перед выполнением запроса
            HighlightSQLSyntax(query);

            // Выполнение запроса
            if (IsRestrictedCommand(query))
            {
                MessageBox.Show("Запрещено выполнение команд INSERT, DELETE, UPDATE или DROP.");
                return;
            }

            try
            {
                // Выполняем запрос SELECT
                DataTable dataTable = dbConnection.ExecuteQuery(query);

                // Проверка на пустоту результата
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для отображения.");
                }
                else
                {
                    // Отображаем данные в DataGridView
                    dataGridView2.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
        }


        // Метод для проверки запретных SQL команд
        private bool IsRestrictedCommand(string query)
        {
            string[] restrictedCommands = { "INSERT", "DELETE", "UPDATE", "DROP" };
            string upperQuery = query.ToUpper();
            foreach (var command in restrictedCommands)
            {
                if (upperQuery.Contains(command))
                {
                    return true; // Запрещенная команда найдена
                }
            }
            return false; // Запрещенных команд нет
        }

        // Обработчик нажатия для button26 (Экспорт в Excel)
        private void button26_Click(object sender, EventArgs e)
        {
            if (dataGridView2 == null || dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            // Открытие диалогового окна для выбора пути и имени файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл как";
            saveFileDialog.DefaultExt = "xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Создаем объект Excel
                    var excelApp = new Excel.Application();
                    if (excelApp == null)
                    {
                        MessageBox.Show("Не удалось создать экземпляр Excel.");
                        return;
                    }

                    var workBook = excelApp.Workbooks.Add();
                    var workSheet = (Excel.Worksheet)workBook.Sheets[1];

                    // Заголовки столбцов
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        workSheet.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
                    }

                    // Данные
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            if (dataGridView2.Rows[i].Cells[j].Value != null)
                            {
                                workSheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // Сохраняем файл Excel по выбранному пути
                    workBook.SaveAs(filePath);
                    MessageBox.Show("Файл успешно сохранен!");

                    // Отображаем Excel
                    excelApp.Visible = true;

                    // Очистка
                    Marshal.ReleaseComObject(excelApp);
                    Marshal.ReleaseComObject(workBook);
                    Marshal.ReleaseComObject(workSheet);
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}");
                }
            }
        }


        // Обработчик нажатия для button27 (Очистка запросника)
        private void button27_Click(object sender, EventArgs e)
        {
            // Очистить содержимое richTextBox2
            richTextBox2.Clear();

            // Очистить данные в DataGridView
            dataGridView2.DataSource = null; // Убираем источник данных, что очистит DataGridView
            dataGridView2.Rows.Clear(); // Очищаем строки (если есть привязка к данным)
        }



        public void ClearContent()
        {
            // Очистить richTextBox
            richTextBox2.Clear();

            // Очистить DataGridView
            dataGridView2.DataSource = null;

            // Можно добавить очистку других элементов, если нужно
        }





        private void HighlightSQLSyntax(string sqlQuery)
        {
            // Очищаем прежнее форматирование
            richTextBox2.Clear();
            richTextBox2.Text = sqlQuery;

            // Устанавливаем начальный цвет для всего текста
            richTextBox2.SelectionColor = Color.Black;

            // Определяем регулярные выражения для поиска ключевых слов, строк и комментариев
            string keywordsPattern = @"\b(SELECT|FROM|WHERE|INSERT|UPDATE|DELETE|DROP|ALTER|CREATE|JOIN|AND|OR|NOT|IN|BETWEEN|LIKE|IS|NULL|EXCEPT|UNION|INTERSECT|GROUP BY|ORDER BY|HAVING|LIMIT|OFFSET|DISTINCT)\b";
            string keywordsPattern2 = @"\b(INSERT|UPDATE|DELETE|DROP|ALTER|CREATE)\b";
            string stringPattern = @"'(.*?)'"; // Строки в одинарных кавычках
            string commentPattern = @"(--.*?$)|(/\*.*?\*/)"; // Однострочные и многострочные комментарии

            // Применяем подсветку для каждого типа
            ApplySyntaxHighlighting(keywordsPattern, Color.Blue); // Ключевые слова
            ApplySyntaxHighlighting(stringPattern, Color.Green); // Строки
            ApplySyntaxHighlighting(commentPattern, Color.Gray); // Комментарии
            ApplySyntaxHighlighting(keywordsPattern2, Color.Red); // Комментарии

        }

        // Метод для применения подсветки для определенных паттернов
        private void ApplySyntaxHighlighting(string pattern, Color color)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(richTextBox2.Text);

            foreach (Match match in matches)
            {
                // Выделяем текст и меняем его цвет
                richTextBox2.Select(match.Index, match.Length);
                richTextBox2.SelectionColor = color;
            }

            // После подсветки возвращаем цвет текста к черному (или любому другому по умолчанию)
            richTextBox2.Select(richTextBox2.TextLength, 0);
            richTextBox2.SelectionColor = Color.Black;
        }


    }
}
