using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarrenLee.Media;
namespace Dashboard
{
    public partial class mycamera : Form
    {
        Boolean flag;
        int count = 0;
        Camera myCamera = new Camera();
        public mycamera()
        {
            InitializeComponent();
            GetInfo();
            myCamera.OnFrameArrived += myCamera_OnFrameArrived;
        }

        private void myCamera_OnFrameArrived(object source, DarrenLee.Media.FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            pictureBox1.Image = img;
        }

        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {

        }

        private void GetInfo()
        {

            var cameraDevice = myCamera.GetCameraSources();
            var cameraResolution = myCamera.GetSupportedResolutions();

            foreach (var d in cameraDevice)
            {
                comboBox1.Items.Add(d);
            }

            foreach (var r in cameraResolution)
            {
                comboBox2.Items.Add(r);
            }

            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.ChangeCamera(comboBox1.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.Start(comboBox2.SelectedIndex);
        }

        private void mycamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            myCamera.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + @"\" + "image" + count.ToString();
            myCamera.Capture(filename);
            count++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
            timer1.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (flag)
            {
                if (this.Opacity <= 1.0)
                {
                    this.Opacity += 0.025;
                }
                else
                {
                    timer1.Stop();
                }
            }
            else
            {
                if (this.Opacity >= 0.0)
                {
                    this.Opacity -= 0.025;
                }
                else
                {
                    timer1.Stop();
                    this.Close();
                }
            }
        }

        private void mycamera_Click(object sender, EventArgs e)
        {
            flag = true;
            this.Opacity = 0.1;
            timer1.Start();
        }
    }
}