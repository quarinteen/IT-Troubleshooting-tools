using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
namespace DnsAndIpResolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                richTextBox1.AppendText("Begin resolve Process");
                richTextBox1.AppendText(Environment.NewLine + "The results will also be written to a file and placed on your desktop. Look for the text file HostIP.txt.");
                richTextBox1.AppendText(Environment.NewLine + "If you are trying to resolve a large list of IP addresses the application might appear frozen or not responding. Its fine just let it do its thing.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string thisHost = "";
            IPAddress[] host = Dns.GetHostAddresses(thisHost);
            //richTextBox1.AppendText("Begin resolve Process");
            //richTextBox1.AppendText(Environment.NewLine + "The results will also be written to a file and placed on your desktop. Look for the text file HostIP.txt.");
            StreamReader hostNameIn = new StreamReader(textBox1.Text);
            StreamReader hostNameIn2 = new StreamReader(textBox1.Text);
            StreamWriter sw = File.CreateText("C://Users//" + Environment.UserName + "//Desktop//HostIP.txt");
            string linec = "";
            Thread.Sleep(500);
            while ((linec == hostNameIn.ReadLine()) != true)
            {
                linec = hostNameIn.ReadLine();
                try
                {
                    //StreamReader hostNameIn = new StreamReader("c://hostname.txt");


                    while (hostNameIn2.EndOfStream != true)
                    {
                        if (radioButton1.Checked == true)
                        {
                            string hNames = hostNameIn2.ReadLine();
                            Console.WriteLine("Pinging " + hNames);
                            IPAddress[] dnsHost = Dns.GetHostAddresses(hNames);
                            richTextBox1.AppendText(Environment.NewLine + "Host " + hNames + " IP: " + dnsHost[0]);
                            //Console.WriteLine("Host " + hNames + " IP: " + dnsHost[0]);
                            sw.WriteLine("Host " + hNames + " IP: " + dnsHost[0]);
                            //Console.WriteLine();
                        }
                        if (radioButton2.Checked == true)
                        {
                            string hNames2 = hostNameIn2.ReadLine();
                            Console.WriteLine("Pinging " + hNames2);
                            IPHostEntry dnsHost2 = Dns.GetHostEntry(hNames2);
                            //IPAddress[] dnsHost2 = Dns.GetHostEntry(hNames2);
                            richTextBox1.AppendText(Environment.NewLine + "Host " + hNames2 + " IP: " + dnsHost2.HostName);
                            //Console.WriteLine("Host " + hNames2 + " IP: " + dnsHost2.HostName);
                            sw.WriteLine("Host " + hNames2 + " IP: " + dnsHost2.HostName);
                            //Console.WriteLine();

                        }

                    }


                }
                catch (Exception e1)
                {
                    sw.WriteLine("Unable to resolve " + linec + " " + e1.Message);
                    Console.WriteLine(e);
                }

            }
            sw.Close();
            hostNameIn.Close();
            hostNameIn2.Close();
            MessageBox.Show("Complete!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("C://Users//" + Environment.UserName + "//Desktop//HostIP.txt"))
            {
                //Start notepad and open the file
                Process.Start("notepad.exe", "C://Users//" + Environment.UserName + "//Desktop//HostIP.txt");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}