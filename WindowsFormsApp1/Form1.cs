using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Button currentButton;
        public static int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                i++;
                startPoint = e.Location;
                currentButton = new Button();
                currentButton.Text = Convert.ToString("button " + i);
                currentButton.FlatStyle = FlatStyle.Flat;
                currentButton.FlatAppearance.BorderSize = 1;
                currentButton.BackColor = Color.LightGray;
                Controls.Add(currentButton);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentButton != null)
            {
                int x = Math.Min(startPoint.X, e.Location.X);
                int y = Math.Min(startPoint.Y, e.Location.Y);
                int width = Math.Abs(startPoint.X - e.Location.X);
                int height = Math.Abs(startPoint.Y - e.Location.Y);

                currentButton.Location = new Point(x, y);
                currentButton.Size = new Size(width, height);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && currentButton != null)
            {
                currentButton.Click += Button_Click;
                currentButton = null;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show("Clicked the dynamic button at location: " + clickedButton.Location);
        }
    }
}
