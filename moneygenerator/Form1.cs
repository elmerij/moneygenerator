using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Ensure your DeepAI.Client NuGet package is up to date: https://www.nuget.org/packages/DeepAI.Client
// Example posting a text URL:

using DeepAI; // Add this line to the top of your file
using System.IO;

namespace moneygenerator
{
    public partial class Form1 : Form
    {
        string resultsFile = @"results.txt";
        string wordlistFile = @"wordlist.txt";
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Interval=1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists(resultsFile))
            {
                if (File.Exists(wordlistFile))
                {
                    if (checkBox1.Checked)
                    {
                        var lines = File.ReadAllLines(wordlistFile);
                        var r = new Random();
                        var randomLineNumber = r.Next(0, lines.Length - 1);
                        var line = lines[randomLineNumber];
                        DeepAI_API api = new DeepAI_API(apiKey: "f324a1e7-c056-4613-9e27-9cfb0ccad096");

                        StandardApiResponse resp = api.callStandardApi("text2img", new
                        {
                            text = line
                        });
                        File.AppendAllText(resultsFile,
                               DateTime.Now.ToString() + " Created NFT with the keyword: " + line + " Link: " + api.objectAsJsonString(resp) + Environment.NewLine);
                    }
                    DeepAI_API api2 = new DeepAI_API(apiKey: "f324a1e7-c056-4613-9e27-9cfb0ccad096");

                    StandardApiResponse resp2 = api2.callStandardApi("text2img", new
                    {
                        text = textBox2.Text
                    });
                    File.AppendAllText(resultsFile,
                           DateTime.Now.ToString() + " Created NFT with the keyword: " + textBox2.Text + " Link: " + api2.objectAsJsonString(resp2) + Environment.NewLine);
                }
                
            }
            else
            {
                MessageBox.Show("results.txt or wordlist.txt not found");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(resultsFile))
            {
                if (File.Exists(wordlistFile))
                {
                    
                }

            }
            else
            {
                File.Create("results.txt");
                File.Create("wordlist.txt");
                MessageBox.Show("created results.txt and wordlist.txt, please restart moneygenerator", "moneygenerator");
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
