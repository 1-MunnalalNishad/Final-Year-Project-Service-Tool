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
    public partial class Currency : Form
    {
        public Currency()
        {
            InitializeComponent();
        }

        public object DownloadUrlResolver { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.WindowState = FormWindowState.Minimized;
        

     
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void Currency_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.convertmymoney.com/");
          
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
