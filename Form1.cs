using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(startForm));
            t.Start();
            InitializeComponent();
            string str = String.Empty;
            for(int i= 0; i< 30000; i++)
            {
                str += i.ToString();
            }
            t.Abort();
            
        }

        public void startForm()
        {
            SplashScreen.SplashForm frm = new SplashScreen.SplashForm();
            frm.AppName = "Plaese wait....";
            Application.Run(frm);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void musicBtn_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void vidBtn_Click(object sender, EventArgs e)
        {
            Player vidplay = new Player();
            vidplay.ShowDialog();
        }

        private void ImageBtn_Click(object sender, EventArgs e)
        {
            imageviewer img = new imageviewer();
            img.Show();
        }

        private void PdfBtn_Click(object sender, EventArgs e)
        {
            PDF p = new PDF();
            p.Show();
        }

        private void YoutubeBtn_Click(object sender, EventArgs e)
        {
            youtube ytube = new youtube();
            ytube.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void CompressBtn_Click(object sender, EventArgs e)
        {
            fileCompression fcompress = new fileCompression();
            fcompress.Show();
        }

        private void ClanderBtn_Click(object sender, EventArgs e)
        {
            face f = new face();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void VoiceRecBtn_Click(object sender, EventArgs e)
        {
            mycamera cam = new mycamera();
            cam.Show();
        }

        private void WebBtn_Click(object sender, EventArgs e)
        {
            browser bro = new browser();
            bro.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            googlemap g = new googlemap();
            g.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            face fa = new face();
            fa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Note n = new Note();
            n.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Currency cer = new Currency();
            cer.Show();
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            cal ca = new cal();
            ca.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Age_Calc age = new Age_Calc();
            age.Show();
        }
    }
}
