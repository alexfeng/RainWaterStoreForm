using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace WinFormForRS
{
    public partial class Form6 : Form
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

        public Form6()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(233, 247, 255);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 保存数据到txt中
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件（*.txt）|*.txt";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.FileName = "蓄水沟数据";

            if(sfd.ShowDialog()==DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString();
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);

                
                string top_L = Convert.ToString(Program.rainwater_collection_width_top_L);
                string bottom_L = Convert.ToString(Program.rainwater_collection_width_bottom_L);
                string flood_S = Convert.ToString(Program.flooded_S);
                string deep_H = Convert.ToString(Program.rainwater_collection_deep_H);
                string space_X = Convert.ToString(Program.rainwater_collection_space_X);

                string flood_1_S = Convert.ToString(Program.flooded_S * 0.3);
                string flood_2_S = Convert.ToString(Program.flooded_S * 0.4);

                StreamWriter train_Data = new StreamWriter(localFilePath);
                string temp = null;
                temp = string.Format("蓄水沟上宽\t{0}", top_L);
                train_Data.WriteLine(temp);
                temp = string.Format("蓄水沟下宽\t{0}", bottom_L);
                train_Data.WriteLine(temp);
                temp = string.Format("蓄水沟深度\t{0}", deep_H);
                train_Data.WriteLine(temp);
                temp = string.Format("蓄水沟间距\t{0}", space_X);
                train_Data.WriteLine(temp);
                temp = string.Format("淹没区面积\t{0}", flood_S);
                train_Data.WriteLine(temp);
                train_Data.Close();
            }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
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
