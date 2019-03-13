using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dashboard
{
    public partial class imageviewer : Form
    {
        string currentDir = "";


        public imageviewer()
        {
            InitializeComponent();
         
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var fb = new FolderBrowserDialog();
                if(fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentDir = fb.SelectedPath;
                    // display current dir in textbox
                    textBox1.Text = currentDir;
                    var dirInfo = new DirectoryInfo(currentDir);
                    // get file from directory
                    
             var files = dirInfo.GetFiles().Where(c => (c.Extension.Equals(".jpg") || c.Extension.Equals(".jpg") || c.Extension.Equals(".bmp") || c.Extension.Equals(".png")));
                    foreach(var image in files)
                    {
                        listBox1.Items.Add(image.Name);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("there was an error: " + ex.Message + ex.Source);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedImage = listBox1.SelectedItems[0].ToString();
                if (!string.IsNullOrEmpty(selectedImage) && !string.IsNullOrEmpty(currentDir))
                {
                    var fullPath = Path.Combine(currentDir, selectedImage);
                    pictureBox1.Image = Image.FromFile(fullPath);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }  
        }


                    



    

