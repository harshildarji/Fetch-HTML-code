using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace getWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Enter URL";
            textBox1.MouseDown += new MouseEventHandler(textBox1_MouseDown);
        }

        void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    textBox2.Text = "Please wait...";
                    using (Stream stream = client.OpenRead("http://www.google.com"))
                    {
                        try
                        {
                            string init = textBox1.Text;
                            char[] check = init.ToCharArray();
                            string str = null;
                            string url = null;
                            for (int i = 0; i < 4; i++)
                            {
                                str = str + check[i];
                            }
                            if (str == "http")
                            {
                                url = textBox1.Text;
                            }
                            else
                            {
                                url = "http://" + textBox1.Text;
                            }
                            string getHtml = client.DownloadString(url);
                            textBox1.Text = url;
                            textBox2.Text = getHtml;
                        }
                        catch
                        {
                            textBox2.Text = "Unable to retrieve HTML code. Plaese check the URL you've entered";
                        }
                    }
                }
                catch
                {
                    textBox2.Text = "Internet connection not available";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "HTML File | *.html";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
                MessageBox.Show("congratulation, file saved!", "Successful");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by: Harshil Darji (github.com/H-Darji)", "About");
        }
    }
}
