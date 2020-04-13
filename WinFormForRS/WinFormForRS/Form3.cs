using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormForRS
{
    public partial class Form3 : Form
    {

        List<Button> btns = new List<Button>();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }

        public static int temp_soil_type;

        public Form3()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(233, 247, 255);
            pictureBox1.Image = Program.w_source_img;

            btns.Add(button4);
            btns.Add(button5);
            btns.Add(button6);
            btns.Add(button7);

            changeButton(Program.regional_soil);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();

            this.Dispose();
            this.Close();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Program.regional_soil = 0;

            changeButton(Program.regional_soil);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.regional_soil = 1;
            changeButton(Program.regional_soil);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.regional_soil = 2;
            changeButton(Program.regional_soil);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Program.regional_soil = 3;
            changeButton(Program.regional_soil);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();

            this.Dispose();
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void changeButton(Int32 regional_soil)
        {
            foreach(Button bt in btns)
            {
                bt.BackgroundImage = null;
                bt.ForeColor = SystemColors.Highlight;
            }
            btns[regional_soil].BackgroundImage = Properties.Resources.p1;
            btns[regional_soil].ForeColor = Color.White;
        }
    }
}
