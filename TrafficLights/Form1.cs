using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class Form1 : Form
    {
        Color def;
        Color forecolor1;
        Color forecolor2;
        Color forecolor3;
        int lineWidth = 2;
        int centerX = 100;
        int centerY = 120;
        int radius = 50;
        Graphics g;
        SolidBrush myBrush;
        Pen myPen;
        int num = 1;
        int sleep1;
        int sleep2;
        int sleep3;
        Thread drawingAuto;
        bool goUp = false;
        public Form1()
        {
            InitializeComponent();
            forecolor1 = Color.Red;
            forecolor2 = Color.Yellow;
            forecolor3 = Color.Green;
            def = Color.Gray;
            sleep1 = Convert.ToInt32(numericUpDown1.Value);
            sleep2 = Convert.ToInt32(numericUpDown2.Value);
            sleep3 = Convert.ToInt32(numericUpDown3.Value);
            g = CreateGraphics();
            myPen = new Pen(forecolor1, lineWidth);
            myBrush = new SolidBrush(forecolor1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (drawingAuto != null)
                drawingAuto.Abort();
            groupBox1.Enabled = false;
            myPen = new Pen(def, lineWidth);
            myBrush = new SolidBrush(def);
            g.FillCircle(myBrush, centerX, centerY, radius);
            g.DrawCircle(myPen, centerX, centerY, radius);

            g.FillCircle(myBrush, centerX, centerY + radius * 2 + 20, radius);
            g.DrawCircle(myPen, centerX, centerY + radius * 2 + 20, radius);

            g.FillCircle(myBrush, centerX, centerY + radius * 4 + 40, radius);
            g.DrawCircle(myPen, centerX, centerY + radius * 4 + 40, radius);
            switch (num)
            {
                case 1:
                    goUp = false;
                    myPen = new Pen(forecolor1, lineWidth);
                    myBrush = new SolidBrush(forecolor1);
                    g.FillCircle(myBrush, centerX, centerY, radius);
                    g.DrawCircle(myPen, centerX, centerY, radius);
                    break;
                case 2:
                    myPen = new Pen(forecolor2, lineWidth);
                    myBrush = new SolidBrush(forecolor2);
                    g.FillCircle(myBrush, centerX, centerY + radius * 2 + 20, radius);
                    g.DrawCircle(myPen, centerX, centerY + radius * 2 + 20, radius);
                    break;
                case 3:
                    goUp = true;
                    myPen = new Pen(forecolor3, lineWidth);
                    myBrush = new SolidBrush(forecolor3);
                    g.FillCircle(myBrush, centerX, centerY + radius * 4 + 40, radius);
                    g.DrawCircle(myPen, centerX, centerY + radius * 4 + 40, radius);
                    break;
            }
            if(!goUp)
                num++;
            else
                num--;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            g.FillCircle(myBrush, centerX, centerY, radius);
            g.DrawCircle(myPen, centerX, centerY, radius);
            myPen = new Pen(def, lineWidth);
            myBrush = new SolidBrush(def);
            g.FillCircle(myBrush, centerX, centerY + radius * 2 + 20, radius);
            g.DrawCircle(myPen, centerX, centerY + radius * 2 + 20, radius);

            g.FillCircle(myBrush, centerX, centerY + radius * 4 + 40, radius);
            g.DrawCircle(myPen, centerX, centerY + radius * 4 + 40, radius);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (drawingAuto != null)
                drawingAuto.Abort();
            myPen = new Pen(forecolor1, lineWidth);
            myBrush = new SolidBrush(forecolor1);
            g.FillCircle(myBrush, centerX, centerY, radius);
            g.DrawCircle(myPen, centerX, centerY, radius);
            myPen = new Pen(def, lineWidth);
            myBrush = new SolidBrush(def);
            g.FillCircle(myBrush, centerX, centerY + radius * 2 + 20, radius);
            g.DrawCircle(myPen, centerX, centerY + radius * 2 + 20, radius);

            g.FillCircle(myBrush, centerX, centerY + radius * 4 + 40, radius);
            g.DrawCircle(myPen, centerX, centerY + radius * 4 + 40, radius);
            sleep1 = Convert.ToInt32(numericUpDown1.Value);
            sleep2 = Convert.ToInt32(numericUpDown2.Value);
            sleep3 = Convert.ToInt32(numericUpDown3.Value);
            drawingAuto = new Thread(() =>
            {
                while (true)
                {
                    myPen = new Pen(def, lineWidth);
                    myBrush = new SolidBrush(def);
                    g.FillCircle(myBrush, centerX, centerY, radius);
                    g.DrawCircle(myPen, centerX, centerY, radius);

                    g.FillCircle(myBrush, centerX, centerY + radius * 2 + 20, radius);
                    g.DrawCircle(myPen, centerX, centerY + radius * 2 + 20, radius);

                    g.FillCircle(myBrush, centerX, centerY + radius * 4 + 40, radius);
                    g.DrawCircle(myPen, centerX, centerY + radius * 4 + 40, radius);
                    switch (num)
                    {
                        case 1:
                            goUp = false;
                            myPen = new Pen(forecolor1, lineWidth);
                            myBrush = new SolidBrush(forecolor1);
                            g.FillCircle(myBrush, centerX, centerY, radius);
                            g.DrawCircle(myPen, centerX, centerY, radius);
                            Thread.Sleep(sleep1);
                            break;
                        case 2:
                            myPen = new Pen(forecolor2, lineWidth);
                            myBrush = new SolidBrush(forecolor2);
                            g.FillCircle(myBrush, centerX, centerY + radius * 2 + 20, radius);
                            g.DrawCircle(myPen, centerX, centerY + radius * 2 + 20, radius);
                            Thread.Sleep(sleep2);
                            break;
                        case 3:
                            goUp = true;
                            myPen = new Pen(forecolor3, lineWidth);
                            myBrush = new SolidBrush(forecolor3);
                            g.FillCircle(myBrush, centerX, centerY + radius * 4 + 40, radius);
                            g.DrawCircle(myPen, centerX, centerY + radius * 4 + 40, radius);
                            Thread.Sleep(sleep3);
                            break;
                    }
                    if (!goUp)
                        num++;
                    else
                        num--;
                }
            });
            drawingAuto.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }
    }
}
