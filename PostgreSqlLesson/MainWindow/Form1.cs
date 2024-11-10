using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using PostgreSqlLesson.Windows;
using PostgreSqlLesson.Windows.DB;

namespace PostgreSqlLesson
{



    public partial class Form1 : Form
    {
        private MainUserControl _mainControl;

        private SelectUserControl select;                        // 1 

        private WhereUserControl _where;                        //  2 

        private BetweenInNotinUserControl _betweenControl;     //   3

        private ColumnСoncatenationUserControl _concatControl;  //  4

        private CrossJoinUserControl _crossJoinControl;                 // 5

        private DistinctUserControl _distinctControl;                  //  6

        private ExceptUserControl _exceptControl;                     //   7

        private FuncAvgUserControl _avgControl;                    //  8

        private FuncCountUserControl _countControl;                 // 9

        private FuncSumUserControl _sumControl;                    //  10

        private GroupByUserControl _groupByControl;               //   11

        private HavingUserControl _having;                      //  12

        private InnerJoinUserControl _innerJoinControl;                 // 13

        private IntersectUserControl _intersectControl;                //  14

        private LeftJoinUserControl _leftJoinControl;                 //   15

        private RightUserControl _rightJoinControl;                    //  16

        private LimitOffsetUserControl _limitOffsetControl;             // 17

        private OrderByUserControl _orderByControl;                //  18

        private SubqueriesUserControl _subqueryControl;             //   19

        private UnionUserControl _unionControl;                        //  20
        //21

        private bool isForm2Visible = false; // Состояние второго окна

        private bool isMenuVisible;
        private int menuWidth;
        private Timer menuTimer;
        private List<string> wordList = new List<string>();

        private bool _isMainControlVisible = false;

        public Form1()
        {
            InitializeComponent();
            menuWidth = panel2.Width;
            isMenuVisible = false;
            panel2.Width = 0; // Начальное значение скрытой панели

            // Инициализация таймера
            menuTimer = new Timer();
            menuTimer.Interval = 1; // Интервал таймера для анимации
            menuTimer.Tick += MenuTimer_Tick;

            wordList.Add("SELECT");
            wordList.Add("FROM");
            wordList.Add("WHERE");
            wordList.Add("INSERT");
            wordList.Add("DELETE");




            // Создаем и открываем UserControl Select при загрузке основной формы
            select = new SelectUserControl();
            OpenUserControlInPanel(select);



            //richTextBox1.TextChanged += RichTextBox1_TextChanged;
            //richTextBox1.MouseWheel += RichTextBox1_MouseWheel;

        }







        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (isMenuVisible)
            {
                // Instantly hide the menu
                panel2.Width = 0;
                isMenuVisible = false;
            }
            else
            {
                // Instantly show the menu
                panel2.Width = menuWidth;
                isMenuVisible = true;
            }

            // Stop the timer immediately, as no animation is needed
            menuTimer.Stop();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menuTimer.Start();
        }







        // Ensure to call this in your Form1_Load or after initializing the TabControl
        private void Form1_Load(object sender, EventArgs e)
        {

        }







        private void OpenUserControlInPanel(UserControl userControl)
        {
            panel4.Controls.Clear();
            userControl.Dock = DockStyle.Fill; // Заполняем панель
            panel4.Controls.Add(userControl);
            userControl.BringToFront(); // Перемещаем на передний пла
        }



        // Универсальный метод для открытия UserControl в целевой панели
        private void OpenUserControlInPanel(UserControl userControl, Panel targetPanel)
        {
            targetPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // Универсальный метод для переключения между UserControl и MainUserControl
        private void ToggleUserControl(UserControl userControl, Panel targetPanel, Button toggleButton, string theoryText)
        {
            if (_isMainControlVisible)
            {
                // Очистить содержимое, прежде чем скрыть
                if (_mainControl != null)
                {
                    _mainControl.ClearContent();
                }

                targetPanel.Controls.Clear();
                _isMainControlVisible = false;
                toggleButton.Text = "Запросник";
                OpenUserControlInPanel(userControl, targetPanel);
            }
            else
            {
                if (_mainControl == null)
                {
                    _mainControl = new MainUserControl();
                    _mainControl.Dock = DockStyle.Fill;
                }

                // Очистить содержимое перед добавлением нового контрола
                _mainControl.ClearContent();

                targetPanel.Controls.Clear();
                targetPanel.Controls.Add(_mainControl);
                _mainControl.BringToFront();
                _isMainControlVisible = true;
                toggleButton.Text = theoryText;
            }
        }







        // Реализация для региона Select
        private void button25_Click_1(object sender, EventArgs e)
        {
            select = new SelectUserControl();
            ToggleUserControl(select, panel4, button25, "Теория");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            select = new SelectUserControl();
            main_control.SelectTab(0);
        }

        // Реализация для региона Where
        private void button21_Click(object sender, EventArgs e)
        {
            _where = new WhereUserControl();
            ToggleUserControl(_where, panel7, button21, "Теория");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(1);
            _where = new WhereUserControl();
            OpenUserControlInPanel(_where, panel7);
        }

        // Реализация для региона Having
        private void button22_Click(object sender, EventArgs e)
        {
            _having = new HavingUserControl();
            ToggleUserControl(_having, panel9, button22, "Теория");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(2);
            _having = new HavingUserControl();
            OpenUserControlInPanel(_having, panel9);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            _betweenControl = new BetweenInNotinUserControl();
            ToggleUserControl(_betweenControl, panel11, button23, "Теория");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(3);
            _betweenControl = new BetweenInNotinUserControl();
            OpenUserControlInPanel(_betweenControl, panel11);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            _groupByControl = new GroupByUserControl();
            ToggleUserControl(_groupByControl, panel13, button24, "Теория");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(4);
            _groupByControl = new GroupByUserControl();
            OpenUserControlInPanel(_groupByControl, panel13);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            _orderByControl = new OrderByUserControl();
            ToggleUserControl(_orderByControl, panel15, button26, "Теория");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(5);
            _orderByControl = new OrderByUserControl();
            OpenUserControlInPanel(_orderByControl, panel15);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            _limitOffsetControl = new LimitOffsetUserControl();
            ToggleUserControl(_limitOffsetControl, panel17, button27, "Теория");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(6);
            _limitOffsetControl = new LimitOffsetUserControl();
            OpenUserControlInPanel(_limitOffsetControl, panel17);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            _unionControl = new UnionUserControl();
            ToggleUserControl(_unionControl, panel19, button28, "Теория");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(7);
            _unionControl = new UnionUserControl();
            OpenUserControlInPanel(_unionControl, panel19);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            _intersectControl = new IntersectUserControl();
            ToggleUserControl(_intersectControl, panel21, button29, "Теория");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(8);
            _intersectControl = new IntersectUserControl();
            OpenUserControlInPanel(_intersectControl, panel21);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            _exceptControl = new ExceptUserControl();
            ToggleUserControl(_exceptControl, panel23, button30, "Теория");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(9);
            _exceptControl = new ExceptUserControl();
            OpenUserControlInPanel(_exceptControl, panel23);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            _distinctControl = new DistinctUserControl();
            ToggleUserControl(_distinctControl, panel25, button31, "Теория");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(10);
            _distinctControl = new DistinctUserControl();
            OpenUserControlInPanel(_distinctControl, panel25);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            _innerJoinControl = new InnerJoinUserControl();
            ToggleUserControl(_innerJoinControl, panel27, button32, "Теория");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(11);
            _innerJoinControl = new InnerJoinUserControl();
            OpenUserControlInPanel(_innerJoinControl, panel27);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            _leftJoinControl = new LeftJoinUserControl();
            ToggleUserControl(_leftJoinControl, panel29, button33, "Теория");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(12);
            _leftJoinControl = new LeftJoinUserControl();
            OpenUserControlInPanel(_leftJoinControl, panel29);
        }


        private void button34_Click(object sender, EventArgs e)
        {
            _rightJoinControl = new RightUserControl();
            ToggleUserControl(_rightJoinControl, panel31, button34, "Теория");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(13);
            _rightJoinControl = new RightUserControl();
            OpenUserControlInPanel(_rightJoinControl, panel31);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            _crossJoinControl = new CrossJoinUserControl();
            ToggleUserControl(_crossJoinControl, panel33, button35, "Теория");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(14);
            _crossJoinControl = new CrossJoinUserControl();
            OpenUserControlInPanel(_crossJoinControl, panel33);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            _avgControl = new FuncAvgUserControl();
            ToggleUserControl(_avgControl, panel35, button36, "Теория");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(15);
            _avgControl = new FuncAvgUserControl();
            OpenUserControlInPanel(_avgControl, panel35);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            _sumControl = new FuncSumUserControl();
            ToggleUserControl(_sumControl, panel37, button37, "Теория");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(16);
            _sumControl = new FuncSumUserControl();
            OpenUserControlInPanel(_sumControl, panel37);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            _countControl = new FuncCountUserControl();
            ToggleUserControl(_countControl, panel39, button38, "Теория");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(17);
            _countControl = new FuncCountUserControl();
            OpenUserControlInPanel(_countControl, panel39);
        }

        private void button39_Click_1(object sender, EventArgs e)
        {
            _subqueryControl = new SubqueriesUserControl();
            ToggleUserControl(_subqueryControl, panel41, button39, "Теория");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(18);
            _subqueryControl = new SubqueriesUserControl();
            OpenUserControlInPanel(_subqueryControl, panel41);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            _concatControl = new ColumnСoncatenationUserControl();
            ToggleUserControl(_concatControl, panel43, button40, "Теория");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            main_control.SelectTab(19);
            _concatControl = new ColumnСoncatenationUserControl();
            OpenUserControlInPanel(_concatControl, panel43);
        }

        private void tableLayoutPanel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EnableAllButtons()
        {
            EnableAllButtonsRecursive(this);
        }

        private void EnableAllButtonsRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = true;
                }
                else
                {
                    EnableAllButtonsRecursive(control); // Рекурсивный вызов для вложенных контейнеров
                }
            }
        }


        private UserControl _currentControl;
        private bool isMainControlVisible = true;
        private int _lastSelectedTabIndex = 0;
        private Button _activeButton;

        private void ToggleUserControl1(UserControl newControl, Panel targetPanel, Button toggleButton, string toggleText)
        {
            if (isMainControlVisible)
            {
                // Блокируем остальные кнопки
                DisableButtonsExcept(toggleButton);

                // Сохраняем текущий индекс активной вкладки
                _lastSelectedTabIndex = main_control.SelectedIndex;

                // Скрываем main_control и заменяем его на новый UserControl
                targetPanel.Controls.Clear();
                newControl.Dock = DockStyle.Fill;
                targetPanel.Controls.Add(newControl);
                newControl.BringToFront();

                // Обновляем состояние
                _currentControl = newControl;
                isMainControlVisible = false;
                _activeButton = toggleButton;
                toggleButton.Text = "Вернуться";
            }
            else
            {
                // Возвращаем main_control на панель
                targetPanel.Controls.Clear();
                main_control.Dock = DockStyle.Fill;
                targetPanel.Controls.Add(main_control);
                main_control.BringToFront();

                // Устанавливаем ранее выбранный индекс вкладки
                main_control.SelectedIndex = _lastSelectedTabIndex;

                // Обновляем состояние
                isMainControlVisible = true;
                _activeButton = null;
                toggleButton.Text = toggleText;

                // Разблокируем все кнопки
                EnableAllButtons();
            }
        }

        private void DisableButtonsExcept(Button activeButton)
        {
            foreach (Control control in activeButton.Parent.Controls)
            {
                if (control is Button button && button != activeButton)
                {
                    button.Enabled = false;
                }
            }
        }

      



        private void button42_Click(object sender, EventArgs e)
        {
            var schemasControl = new SchemasUserControl();
            ToggleUserControl1(schemasControl, panel3, button42, "Схема");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            var tableUserControl = new TablesUserControl();
            ToggleUserControl1(tableUserControl, panel3, button43, "Таблицы");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            var descriptionControl = new DescriptionDbUserControl();
            ToggleUserControl1(descriptionControl, panel3, button45, "Описание БД");
        }

    }
}
