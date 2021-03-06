﻿using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Core.Edimdoma;
using WindowsFormsApp1.Recepies;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        ParserWorker<string[]> parser;
        ParserWorker<string[]> parser2;
        public bool isfirstdone = false;
        public Form1()
        {
            InitializeComponent();
            SitesToParse.SelectedIndex = 0;
            parser = new ParserWorker<string[]>(
                new ArborioParser()
                );
            parser2 = new ParserWorker<string[]>(
                new EdimdomaParser()
                );
            parser.OnCompleted += Parser_OnComplated;
            parser.OnNewData += Parser_OnNewData;
            parser2.OnCompleted += SecondParser_OnComplated;
            parser2.OnNewData += Parser_OnNewData;
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            StartPointLabel.Parent = pictureBox1;
            label1.Parent = pictureBox1;
            EndPointLabel.Parent = pictureBox1;
            StartPointLabel.BackColor = Color.Transparent;
            EndPointLabel.BackColor = Color.Transparent;
            label1.BackColor= Color.Transparent;
        }

        private void Parser_OnComplated( object obj )
        {
            isfirstdone = true;
            if (SitesToParse.SelectedIndex == 0) { 
            parser2.Settings = new EdimdomaSettings( (int)NumericStart.Value, (int)NumericEnd.Value );
            parser2.Start( 2 );
            }
            else { 
            MessageBox.Show( "Выполнено!" );
            }
        }

        private void SecondParser_OnComplated( object obj )
        {
            MessageBox.Show( "Выполнено!" );
        }

        private void Parser_OnNewData( object args1, string[] args2 )
        {
            ListTitles.Items.AddRange( args2 );
        }


        private void StartButton_Click( object sender, EventArgs e )
        {
            ListTitles.Items.Clear();
            var selectedSiteIndex =SitesToParse.SelectedIndex;
            var numericStart = NumericStart.Value;
            var numericEnd = NumericEnd.Value;
            if (numericStart <= numericEnd)
            {
                if (selectedSiteIndex == 0)
                {
                    
                    parser.Settings = new ArborioSettings( (int)NumericStart.Value, (int)NumericEnd.Value );
                    parser.Start( 1 );
                }
                if (selectedSiteIndex == 1)
                {
                    parser.Settings = new ArborioSettings( (int)NumericStart.Value, (int)NumericEnd.Value );
                    parser.Start( 1 );
                }
                if (selectedSiteIndex == 2)
                {
                    parser2.Settings = new EdimdomaSettings( (int)NumericStart.Value, (int)NumericEnd.Value );
                    parser2.Start( 2 );
                }

            }
            else
            {
                MessageBox.Show( "Начальнаяточка не может быть меньше конечной!" );
            }
        }


        private void AbortButtonClick( object sender, EventArgs e )
        {
            parser.Abort();
        }

        private void metroLabel2_Click( object sender, EventArgs e )
        {

        }

        private void label1_Click( object sender, EventArgs e )
        {

        }
    }
}
