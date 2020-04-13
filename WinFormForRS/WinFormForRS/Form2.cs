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
    public partial class Form2 : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }

        public Form2()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(233, 247, 255);
            pictureBox1.Image = Program.w_source_img;


            if (Program.regional_S > 0.0)
            {
                this.textBox1.Text = Convert.ToString(Program.regional_S);
            }
            if (Program.regional_groundwater_level_m > 0.0)
            {
                this.textBox2.Text = Convert.ToString(Program.regional_groundwater_level_m);
            }
            if(Program.regional_groundwater_level_deep_h > 0.0)
            {
                this.textBox3.Text = Convert.ToString(Program.regional_groundwater_level_deep_h);
            }
            if (Program.average_rainfall_a > 0)
            {
                this.textBox4.Text = Convert.ToString(Program.average_rainfall_a);
            }
            if (Program.maximum_rainfall_b > 0)
            {
                this.textBox5.Text = Convert.ToString(Program.maximum_rainfall_b);
            }

            if (Program.average_evaporation_c > 0)
            {
                this.textBox6.Text = Convert.ToString(Program.average_evaporation_c);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") ||
               textBox3.Text.Equals("") || textBox4.Text.Equals("") ||
               textBox5.Text.Equals("") || textBox6.Text.Equals(""))
            {
                MessageBox.Show("参数不能为空");
                return;
            }

            Program.regional_S = double.Parse(textBox1.Text);
            Program.regional_groundwater_level_m = double.Parse(textBox2.Text);
            Program.regional_groundwater_level_deep_h = double.Parse(textBox3.Text);
            Program.average_rainfall_a = double.Parse(textBox4.Text);
            Program.maximum_rainfall_b = double.Parse(textBox5.Text);
            Program.average_evaporation_c = double.Parse(textBox6.Text);

            Program.rainwater_collection_deep_H = Program.regional_groundwater_level_deep_h + 0.5;
            Program.rainwater_collection_space_X = Program.rainwater_collection_deep_H * 60;
            Program.rainwater_collection_length_l = Math.Round(Program.regional_S / Program.rainwater_collection_space_X, MidpointRounding.AwayFromZero);

            Form3 form = new Form3();
            form.Show();
            this.Dispose();
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
