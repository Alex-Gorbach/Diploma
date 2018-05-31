using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Recepies;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        ParserWorker<string[]> parser;
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                new ArborioParser()
                );
            parser.OnCompleted += Parser_OnComplated;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPointLabel.Parent = pictureBox1;
            EndPointLabel.Parent = pictureBox1;
            StartPointLabel.BackColor = Color.Transparent;
            EndPointLabel.BackColor = Color.Transparent;
        }

        private void Parser_OnComplated(object obj)
        {
            MessageBox.Show("Выполнено!");
        }

        private void Parser_OnNewData(object args1, string[] args2)
        {
            ListTitles.Items.AddRange(args2);
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            var numericStart = NumericStart.Value;
            var numericEnd = NumericEnd.Value;
            if(numericStart<= numericEnd) { 
            ListTitles.Items.Clear();
            parser.Settings = new ArborioSettings((int)NumericStart.Value, (int)NumericEnd.Value);
            parser.Start();
            }
            else
            {
                MessageBox.Show("Начальнаяточка не может быть меньше конечной!");
            }
        }


        private void AbortButtonClick(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
