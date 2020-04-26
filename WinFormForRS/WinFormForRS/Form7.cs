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
    public partial class Form7 : Form
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

        public Form7()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(233, 247, 255);
            pictureBox1.Image = Program.w_source_img;

            string top_L = Convert.ToString(Program.rainwater_collection_width_top_L);
            string bottom_L = Convert.ToString(Program.rainwater_collection_width_bottom_L);
            string flood_S = Convert.ToString(Program.flooded_S);
            string deep_h = Convert.ToString(Program.rainwater_collection_deep_H);
            string soil_n = Convert.ToString(Program.regional_soil_n);

            string flood_1_S = Convert.ToString(Program.flooded_S1);
            string flood_2_S = Convert.ToString(Program.flooded_S2);
            string flood_3_S = Convert.ToString(Program.flooded_S3);

            label2.Text = string.Format("蓄水沟上宽(m):{0}", top_L);
            label4.Text = string.Format("蓄水沟下宽(m):{0}", bottom_L);

            label5.Text = string.Format("S3:{0}", flood_3_S);
            label6.Text = string.Format("S2:{0}", flood_2_S);
            label7.Text = string.Format("S1:{0}", flood_1_S);

            label8.Text = string.Format("降水排泄区总面积(hm²):{0}", flood_S);
            label9.Text = string.Format("蓄水沟深(m):{0}", deep_h);
            label10.Text = string.Format("坡比系数:{0}", soil_n);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            this.Opacity = 0;
            this.ShowInTaskbar = false;
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
            Form5 form = new Form5();
            form.Show();

            this.Dispose();
            this.Close();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
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
