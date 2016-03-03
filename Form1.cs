using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;

namespace Course_Project__Practice_
{
    public partial class Form1 : Form
    {
        int stream = 0;
        ~Form1()
        {
            if (stream != 0)
            {
                Bass.BASS_StreamFree(stream);
                Bass.BASS_Free();
            }
        }
        public Form1()
        {
            InitializeComponent(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            //Button_Path.AddEllipse(0, 0, button2.Width, button2.Height);
            //Region Button_Region = new Region(Button_Path);
            //button2.Region = Button_Region;
        }

        //Набор методов изменения цвета кнопок
        private void btn2_OnEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(255, 193, 7);
        }
        private void btn2_OnLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(96, 125, 139);
        }
        private void btn3_OnEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(255, 193, 7);
        }
        private void btn3_OnLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(96, 125, 139);
        }
        private void btn5_OnEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(255, 193, 7);
        }
        private void btn5_OnLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(96, 125, 139);
        }
        private void btn6_OnEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(255, 193, 7);
        }
        private void btn6_OnLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(96, 125, 139);
        }
        private void btn7_OnEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(255, 193, 7);
        }
        private void btn7_OnLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.FromArgb(96, 125, 139);
        }
        private void lbl4_OnEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(244, 67, 54);
        }
        private void lbl4_OnLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(255, 255, 255);
        }
        // конец набора

        private void MouseMove_Window(object sender, MouseEventArgs e)
        {
            int x, y = 0;
            if (e.Button == MouseButtons.Left)
            {
                x = e.X + Location.X;
                y = e.Y;
                Location = new Point(x, y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle))
                {
                    stream = Bass.BASS_StreamCreateFile("test.mp3", 0, 0, BASSFlag.BASS_DEFAULT);
                    if (stream != 0)
                    {
                        Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0.5f);
                        Bass.BASS_ChannelPlay(stream, false);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка!", "Roger Player");
                    }
                    if (Bass.BASS_ChannelPause(stream) == true)
                    {
                        Bass.BASS_ChannelPlay(stream, false);
                    }
                }
            }
            catch (System.Exception q)
            {
                MessageBox.Show(q.ToString());
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Такую фигню мог написать только один человек: \nСтасевич Т-393", "Roger Player");
        }

        private void OnValChange_Sound(object sender, EventArgs e)
        {
            float volume = (float)(sender as TrackBar).Value / 100.0f;
            if (stream != 0)
            {
                Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volume);
                if (volume == 0)
                {
                    Bass.BASS_ChannelPause(stream);
                }
                else Bass.BASS_ChannelPlay(stream, false);
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPause(stream);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа разработана учащимся 3-го курса \nгруппы Т-393 Стасевичем Владиславом", "Roger Player");
        }
    }
}
