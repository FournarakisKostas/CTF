using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BruteForcer
{
    public partial class Form1 : Form
    {
        string brutestring = "00000000000000000000000000000000";
        string exeout = null;
        public Form1()
        {
            InitializeComponent();
        }     
        private void button1_Click(object sender, EventArgs e)
        {
            while (exeout!="11111111111111111111111111111111")
            brutestring = bruteletter(sendcommand(), brutestring);          
        }

        private string sendcommand()
        {
            exeout = null;
            string filename = Path.Combine(@"C:\", "LosT.exe");
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = "-b " + brutestring,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                exeout = proc.StandardOutput.ReadLine();
                richTextBox1.AppendText(exeout + Environment.NewLine);
                richTextBox2.Text = brutestring;
                
            }
            return exeout;
        }
        private string bruteletter(string exeout, string brutestring)
        {
            StringBuilder sb = new StringBuilder(brutestring);
            for (int i = 0; i < exeout.Length; i++)
            {
                if (exeout[i] == Convert.ToChar("0"))
                {
                    if ((brutestring[i] >= Convert.ToChar("0")) && (brutestring[i] <= Convert.ToChar("g")))
                    {
                        if (brutestring[i] == Convert.ToChar("g"))
                            sb[i] = Convert.ToChar("0");
                        else if (brutestring[i] == Convert.ToChar(":"))
                            sb[i] = Convert.ToChar("a");
                        else
                        {
                            sb[i] = Convert.ToChar(Convert.ToInt32(brutestring[i]) + 1);
                        }
                    }                   
                }
            }
            return sb.ToString();
        }

    }
}
