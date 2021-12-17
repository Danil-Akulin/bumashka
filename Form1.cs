using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bumashka
{
    public partial class Form1 : Form
    {
        Button btn;
        PictureBox picb;

        public Button but = new Button();
        private Control button;

        public Button but2 = new Button();
        private Control button2;
        
        public Form1()
        {
            //                                                отвечает за размер / цвет окна
            
            BackColor = Color.AntiqueWhite;
            this.Height = 700;
            this.Width = 800;
            this.Text = "Меню";




            this.Controls.Add(button);
            this.Controls.Add(button);


            //////////////////////////////////////////////////////////

            //                                                 кнопка для игры с другом
            InitializeComponent();
            but2.Text = "Начать играть с другом";
            but2.Size = new Size(150, 100);
            but2.Location = new Point(615, 300);
            but2.Font = new Font("Times New Roman", 15.0f);
            //даём кнопке свойства
            but2.Click += new EventHandler(but2_Click);
            this.Controls.Add(but2);


            //////////////////////////////////////////////////////////

            //                                                       кнопка для игры одному
            InitializeComponent();
            but.Text = "Начать играть одному";
            but.Size = new Size(150, 100);
            but.Location = new Point(50, 300);
            but.Font = new Font("Times New Roman", 15.0f);

            //даём кнопке свойства
            but.Click += new EventHandler(but_Click);
            this.Controls.Add(but);

            ///////////////////////////////////          //Настройка приветствия на главном эеране
            TextBox box = new TextBox();
            box.Location = new Point(145, 150);

            box.Text = "Tere. See on mäng 'kivi, paber, käärid'";
            Font myfont = new Font("Times New Roman", 25.0f);        //изменения размера шрифта
            box.Font = myfont;                                    // хз

            box.ReadOnly = true;                                //только для чтения
            box.Height = 250;
            box.Width = 550;
            box.BackColor=Color.AntiqueWhite;                //изменяет забний цвет на цвет страницы
            box.BorderStyle = 0;                             // уберает чёрные рамки

            //box.AutoSize = false;

            this.Controls.Add(box);
        }

        /////////////////////////////////////////////////////////

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }          //Класс для автоматического закрытия всплывающего окна при переходе между формами

        /////////////

        private void but2_Click(object sender, EventArgs e)
        {
            
            AutoClosingMessageBox.Show("Please Wait", "Treatment", 1000);   //Авто закрытие меседж бокса
            Form3 f3 = new Form3();   //переходна вторую форму
            f3.Show();
            this.Hide();

        }

        private void but_Click(object sender, EventArgs e)
        {
            AutoClosingMessageBox.Show("Please Wait", "Treatment", 1000);    //Авто закрытие меседж бокса
            Form2 f2 = new Form2();    //переходна вторую форму
            f2.Show();
            this.Hide();

        }
    }
}