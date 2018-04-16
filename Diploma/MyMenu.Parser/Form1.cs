using System;
using System.Windows.Forms;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Habra;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        ParserWorcker<string[]> parser;
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorcker<string[]>(
                new HabraParser()
                );
            parser.OnCompleted += Parser_OnComplated;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnComplated(object obj)
        {
            MessageBox.Show("All work done!");
        }

        private void Parser_OnNewData(object args1, string[] args2)
        {
            ListTitles.Items.AddRange(args2);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Settings=new HabraSettings((int)NumericStart.Value,(int)NumericEnd.Value);
            parser.Start();
        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
       
    }
}
