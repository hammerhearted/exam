using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace MyTimer
{
    public partial class Form1 : Form
    {
        private int elapsedTimeInTenthSeconds = 0;
        private Label label;
        private Button start;
        private Button stop;
        private Timer timer1;

        public Form1()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateTimer();
            CreateLabel();
            CreateButtonStart();
            CreateButtonStop();
            CreateForm();
        }

        private void CreateForm()
        {
            Text = "Секундомер";
            MaximizeBox = false;
            ClientSize = new Size(401, 300);
            MaximumSize = new Size(401, 350);
            MinimumSize = MaximumSize;
            BackgroundImage = Image.FromFile("background.jpg");
            ResumeLayout(false);
        }

        private void CreateButtonStop()
        {
            stop = new Button();
            stop.BackColor = Color.Transparent;
            stop.FlatAppearance.BorderSize = 0;
            stop.FlatStyle = FlatStyle.Flat;
            stop.Font = new Font("Calibri Light", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            stop.ForeColor = Color.White;
            stop.Location = new Point(254, 220);
            stop.Size = new Size(123, 55);
            stop.TabIndex = 2;
            stop.Text = "СБРОС";
            stop.UseVisualStyleBackColor = false;
            stop.Click += (a, b) =>
            {
                timer1.Enabled = false;
                elapsedTimeInTenthSeconds = 0;
                label.Text = GetElapsedTime();
                start.Text = "ПУСК";
            };
            Controls.Add(stop);
        }

        private void CreateTimer()
        {
            timer1 = new Timer();
            timer1.Tick += (a, b) =>
            {
                ++elapsedTimeInTenthSeconds;
                label.Text = GetElapsedTime();
            };
        }

        private string GetElapsedTime()
        {
            int num1 = elapsedTimeInTenthSeconds % 10;
            int num2 = elapsedTimeInTenthSeconds / 10;
            int num3 = num2 / 60;
            if (num3 > 99)
                num3 = 0;
            int num4 = num2 % 60;
            return string.Format("{0:00}:{1:00}.{2}", num3, num4, num1);
        }

        private void CreateButtonStart()
        {
            start = new Button();
            start.BackColor = Color.Transparent;
            start.FlatAppearance.BorderSize = 0;
            start.FlatStyle = FlatStyle.Flat;
            start.Font = new Font("Calibri Light", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            start.ForeColor = Color.White;
            start.Location = new Point(36, 220);
            start.Size = new Size(123, 55);
            start.TabIndex = 2;
            start.Text = "ПУСК";
            start.UseVisualStyleBackColor = false;
            start.Click += (a, b) =>
            {
                if (start.Text == "ПУСК")
                {
                    start.Text = "СТОП";
                    timer1.Enabled = true;
                }
                else
                {
                    start.Text = "ПУСК";
                    timer1.Enabled = false;
                }
            };
            Controls.Add(start);
        }

        private void CreateLabel()
        {
            label = new Label();
            label.BackColor = Color.Transparent;
            label.Font = new Font("Calibri Light", 72f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            label.ForeColor = Color.White;
            label.Location = new Point(32, 37);
            label.Size = new Size(345, 119);
            label.TabIndex = 1;
            label.Text = "00:00.0";
            Controls.Add(label);
        }
    }
}
