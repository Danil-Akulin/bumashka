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

    public partial class Form3 : Form
    {
        public Button but = new Button();
        private Control button;

        public PictureBox img = new PictureBox();
        private Control image;

        public PictureBox img1 = new PictureBox();
        private Control imagee;

        public PictureBox img2 = new PictureBox();
        private Control imageee;

        public Form3()
        {
            BackColor = Color.AntiqueWhite;
            this.Height = 700;
            this.Width = 800;
            this.Text = "Menüü";


            this.Controls.Add(button);
            
            //                                          кнопка для перехода на прошлую форму

            but.Text = "Tagasi";
            but.Size = new Size(70, 70);
            but.Location = new Point(700, 20);
            but.Font = new Font("Times New Roman", 15.0f);
            ////////////////                            Картинка бумаги             0
            img.Size = new Size(150, 150);
            img.Location = new Point(600, 150);
            //img.Image = Properties.Resources.paper;
            img.Image = Image.FromFile(@"..\..\img\paper.jpg");
            this.Controls.Add(img);
            /////////////////




            ////////////////                            Картинка бумаги             1
            img1.Size = new Size(150, 150);
            img1.Location = new Point(320, 150);
            //img.Image = Properties.Resources.paper;
            img1.Image = Image.FromFile(@"..\..\img\rock.jpg");
            this.Controls.Add(img1);
            /////////////////



            ///            ////////////////                            Картинка бумаги   2
            img2.Size = new Size(150, 150);
            img2.Location = new Point(30, 150);
            //img.Image = Properties.Resources.paper;
            img2.Image = Image.FromFile(@"..\..\img\scissors.jpg");
            this.Controls.Add(img2);
            /////////////////
            //                                          даём кнопке свойства
            but.Click += new EventHandler(but_Click);
            this.Controls.Add(but);

            TextBox box = new TextBox();
            box.Location = new Point(70, 100);

            box.Text = "Tere, olete valinud režiimi \"mängi sõbraga\"";
            Font myfont = new Font("Times New Roman", 25.0f);        //изменения размера шрифта
            box.Font = myfont;                                    // хз

            box.ReadOnly = true;                                //только для чтения
            box.Height = 250;
            box.Width = 800;
            box.BackColor = Color.AntiqueWhite;                //изменяет забний цвет на цвет страницы
            box.BorderStyle = 0;                             // уберает чёрные рамки

            //box.AutoSize = false;

            this.Controls.Add(box);

        }

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
        private void but_Click(object sender, EventArgs e)
        {
            AutoClosingMessageBox.Show("Please Wait", "Treatment", 1000);    //Авто закрытие меседж бокса
            Form1 f1 = new Form1();    //переходна вторую форму
            f1.Show();
            this.Hide();
        }


    }
}