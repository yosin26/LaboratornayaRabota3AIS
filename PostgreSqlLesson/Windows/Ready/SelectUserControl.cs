using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSqlLesson.Windows
{
    public partial class SelectUserControl : UserControl
    {
        public SelectUserControl()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.Paint += Label_Paint;
                }
            }
        }

        private void Label_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                string text = label.Text;
                Font font = label.Font;
                PointF point = new PointF(0, 0); // Начальная точка для рисования текста
                int lineHeight = (int)e.Graphics.MeasureString("A", font).Height + 5; // Высота строки и дополнительное пространство

                string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    e.Graphics.DrawString(line, font, Brushes.Black, point);
                    point.Y += lineHeight; // Увеличиваем Y координату для следующей строки
                }
            }
        }
    }
}   
