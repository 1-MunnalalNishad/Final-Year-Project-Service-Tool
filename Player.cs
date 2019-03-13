using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class Player : Form
    {
        private int playlistindex;

        public string[] FileName { get; private set; }
        public string[] FilePath { get; private set; }
        public int Startindex { get; private set; }
        public Player()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Multiselect = true;
            opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.3gp;*.avi;*.mov;*.flv;*.wmv;*.mpg|all files|*.*";
            if (opnFileDlg.ShowDialog() == DialogResult.OK)
            {
                FileName = opnFileDlg.SafeFileNames;
                FilePath = opnFileDlg.FileNames;
                for (int i = 0; i < FilePath.Length; i++)

                {
                    listBox1.Items.Add(FileName[i]);
                    Startindex = 0;
                    Playfile(0);
                }
            }
        }

        private void Playfile(int v)
        {
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.URL = FilePath[playlistindex];
            axWindowsMediaPlayer1.Ctlcontrols.next();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (listBox1.SelectedIndex == 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1.Update();
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.previous();
                    listBox1.SelectedIndex -= 1;
                    listBox1.Update();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (listBox1.SelectedIndex < (listBox1.Items.Count - 1))
                {
                    axWindowsMediaPlayer1.Ctlcontrols.next();
                    listBox1.SelectedIndex += 1;
                    listBox1.Update();
                }
                else
                {

                    listBox1.SelectedIndex = 0;
                    listBox1.Update();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.fullScreen = true;

            }
            else
            {
                axWindowsMediaPlayer1.fullScreen = false;
            }
        }

        private void bunifuTrackbar1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.settings.volume == 100)
            {
                axWindowsMediaPlayer1.settings.volume = 0;
            }
            else
            {
                axWindowsMediaPlayer1.settings.volume = 100;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = FilePath[listBox1.SelectedIndex];

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                metroTrackBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                metroTrackBar1.Value = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label2.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            label3.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                metroTrackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
           

        }

        private void Player_DoubleClick(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            metroTrackBar2.Minimum = 0;
            metroTrackBar2.Maximum = 100;
            axWindowsMediaPlayer1.settings.volume = metroTrackBar2.Value;
        }
    }
}
