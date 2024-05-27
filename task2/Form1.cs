using System;
using System.Drawing;
using System.Windows.Forms;
namespace task2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap baner;
        Rectangle rct;
        public Form1()
        {
            InitializeComponent();
            try 
            {
                baner = new Bitmap("baner.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла баннера\n {ex.ToString()} Баннер");
                this.Close();
                return;
            }
            rct.X = 0;
            rct.Y = 0;
            rct.Width = baner.Width;
            rct.Height = baner.Height;
            timer1.Interval = 50;
            timer1.Enabled = true;
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.ForeColor == start) label1.ForeColor = end;
            else label1.ForeColor = start;
            if (label1.Left > -label1.Width) label1.Left -= 5;
            else label1.Left = this.Width;//this - относительно чего label будет двигаться влево
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Y < rct.Y + rct.Height) && (e.Y > rct.Y))
            {
                if (timer1.Enabled != false)
                    timer1.Enabled = false;
            }
            else
            {
                if (timer1.Enabled != true)
                    timer1.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            start = label1.ForeColor;
            end = Color.Green;
            Timer timer = new Timer();
            timer.Interval = 5;
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        Color start;
        Color end;
    }
}
