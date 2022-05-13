using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class Form1 : Form
    {
        int t = 3000;
        int N = 1;
        int P = 5;


        Color forecolor1;
        int lineWidth = 2;
        Graphics g;
        SolidBrush myBrush;
        Pen myPen;

        int t_decrement = 100;
        int level = 1;
        int score = 0;
        int trys = 0;
        int succ_trys = 0;

        int minX;
        int minY;

        int maxX;
        int maxY;
        int x = 0;
        int y = 0;
        int r = 20;
        bool drawn = false;

        int bestScore = 0;
        Random random;
        Thread thread;
        int mouseClicked = 0;

        public Form1()
        {
            InitializeComponent();
            minX = 50 + r;
            minY = 50 + r;
            maxX = Width - minX - r;
            maxY = Height - minY - r;
            forecolor1 = Color.Red;
            g = CreateGraphics();
            random = new Random();
            label7.Text += level;
            label4.Text += t;
            label5.Text += score;
            label6.Text = $"Спроби(P={P}): {trys}";
            string fileContent = File.ReadAllText("../../Best Scores.txt");
            if (int.TryParse(fileContent, out int bestScore))
            {
                this.bestScore = bestScore;
            }
            else this.bestScore = 0;
            label8.Text += this.bestScore;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(t);
                    g.Clear(BackColor);
                    drawn = false;
                    x = random.Next(minX, maxX);
                    y = random.Next(minY, maxY);
                    myPen = new Pen(forecolor1, lineWidth);
                    myBrush = new SolidBrush(forecolor1);
                    g.FillCircle(myBrush, x, y, r);
                    g.DrawCircle(myPen, x, y, r);
                    mouseClicked = 0;
                    drawn = true;
                }
            });
            thread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (mouseClicked < 1)
            {
                mouseClicked += 1;
                trys += 1;
                if (drawn)
                {
                    var relativePoint = PointToClient(Cursor.Position);
                    var currentX = x;
                    var currentY = y;
                    if (Math.Pow(relativePoint.X - currentX, 2) + Math.Pow(relativePoint.Y - currentY, 2) < Math.Pow(r, 2))
                    {
                        succ_trys += 1;
                        score += N;
                    }
                }
                //game over
                if (trys >= P)
                {
                    if (succ_trys != 3)
                    {
                        //write to file
                        if (score >= bestScore)
                            File.WriteAllText("../../Best Scores.txt", score.ToString());

                        label6.Text = $"Спроби(P={P}): {trys}";
                        if (thread != null)
                            thread.Abort();
                        MessageBox.Show($"Ваш результат - {score}","Гра завершена!");
                        Close();
                    }
                }
                //new level
                else
                {
                    if (succ_trys == 3)
                    {
                        level += 1;
                        t -= t_decrement;
                        succ_trys = 0;
                        trys = 0;

                        //write to file
                        if (score >= bestScore)
                            File.WriteAllText("../../Best Scores.txt", score.ToString());
                    }
                }
                label7.Text = $"Рівень: {level}";
                label4.Text = $"Час(t): {t}";
                label5.Text = $"Результат(N): {score}";
                label6.Text = $"Спроби(P={P}): {trys}";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
                thread.Abort();
        }
    }
}
