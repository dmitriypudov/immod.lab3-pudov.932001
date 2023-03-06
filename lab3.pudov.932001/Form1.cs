using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3.pudov
{
    public partial class Form1 : Form
    {

        bool help = true;
        List<Control> labels = new List<Control>();
        string biNumber;
        List<int> FirstLine;
        Color[,] Colors;
        List<int> line = new List<int>(new int[15]);
        List<int> otherLine = new List<int>(new int[15]);

        public Form1()
        {
            InitializeComponent();

            Colors = new Color[15, 14];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Colors[i, j] = SystemColors.Control;
                }
            }
        }
 private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void edRule_ValueChanged(object sender, EventArgs e)
        {

        }

        private void acriveBut_Click(object sender, EventArgs e)
        {
            if (help)
            {
                labels.Add(label0);
                labels.Add(label1);
                labels.Add(label2);
                labels.Add(label3);
                labels.Add(label4);
                labels.Add(label5);
                labels.Add(label6);
                labels.Add(label7);
                labels.Add(label8);
                labels.Add(label9);
                labels.Add(label10);
                labels.Add(label11);
                labels.Add(label12);

                Tablica.Refresh();
                biNumber = Convert.ToString((int)edRule.Value, 2);

                if (biNumber.Length != 8)
                {
                    int n = 8 - biNumber.Length;
                    for (int i = 0; i < n; i++)
                    {
                        biNumber = biNumber.Insert(0, "0");
                    }
                }


                FirstLine = new List<int>(new int[15]);
                for (int i = 0; i < FirstLine.Count; i++)
                {
                    if (i == 7 || i == 8 || i == 12)
                    {
                        FirstLine[i] = 1;
                        Colors[i, 0] = Color.Green;
                    }
                    else
                    {
                        FirstLine[i] = 0;
                    }
                }

                for (int i = 0; i < otherLine.Count; i++)
                {
                    otherLine[i] = 0;
                }

                Tablica.Refresh();
                line = FirstLine;
            }
            help = false;

            if (btnStart.Text == "Start")
            {
                btnStart.Text = "Stop";
                timer1.Start();
            }
            else
            {
                btnStart.Text = "Start";
                timer1.Stop();
            }
            Tablica.Refresh();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label0_Click(object sender, EventArgs e)
        {

        }

        private void table_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (Colors != null)
            {
                using (var b = new SolidBrush(Colors[e.Column, e.Row]))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
            }
        }

        public int check(string help)
        {
            switch (help)
            {
                case "110":
                    return biNumber[1] - 48;
                case "101":
                    return biNumber[2] - 48;
                case "011":
                    return biNumber[4] - 48;
                case "010":
                    return biNumber[5] - 48;
                case "100":
                    return biNumber[3] - 48;
                case "000":
                    return biNumber[7] - 48;
                case "111":
                    return biNumber[0] - 48;
                case "001":
                    return biNumber[6] - 48;
                default:
                    return biNumber[0] - 48;
            }
        }

        int Count = 1;
        bool First = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            labels[Count].Text = Count.ToString();

            if (First == true)
            {
                First = false;
            }
            else
            {
                for (int i = 0; i < otherLine.Count; i++)
                {
                    line[i] = otherLine[i];
                }
            }

            for (int i = 0; i < line.Count; i++)
            {
                if (i != 0 && i != line.Count - 1)
                {
                    string Result = "";
                    Result = line[i - 1].ToString() + line[i].ToString() + line[i + 1].ToString();
                    int result = check(Result);
                    otherLine[i] = result;
                    if (otherLine[i] == 1)
                    {
                        Colors[i, Count] = Color.Green;
                    }
                }
            }

            Tablica.Refresh();
            Count++;

            if (Count == 13)
            {
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
