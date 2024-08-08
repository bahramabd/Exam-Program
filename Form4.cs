using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public void loadform(object Fom)
        {
            if (this.panel3.Controls.Count > 0) { this.panel3.Controls.RemoveAt(0); }
            Form f = Fom as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(f);
            this.panel3.Tag = f;
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            label3.Visible = false;
            loadform(new Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            loadform(new Form2());
        }

        private void button3_Click(object sender, EventArgs e)
        {

            label3.Visible = false;
            loadform(new Form3());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


            label3.Visible = true; pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
