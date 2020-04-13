using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormForRS
{
    static class Program
    {

        public static double regional_S;//区域面积
        public static double regional_groundwater_level_m;//区域地下水位
        public static double regional_groundwater_level_deep_h;//区域地下水临界深度
        public static double average_rainfall_a;//设计雨量
        public static double maximum_rainfall_b;//核校雨量
        public static double average_evaporation_c;//蒸发量
        public static int regional_soil;//区域土质
        public static double regional_soil_n;//区域土质系数

        public static double rainwater_collection_deep_H;//蓄水沟深度
        public static double rainwater_collection_space_X;//蓄水沟间距
        public static double rainwater_collection_length_l;//蓄水沟总长度


        public static double rainwater_collection_width_top_L; //蓄水沟上宽
        public static double rainwater_collection_width_bottom_L;//蓄水沟下宽
        public static double flooded_S;//淹没区面积

        public static Bitmap o_source_img;
        public static Bitmap w_source_img;



        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            regional_soil = 0;

            w_source_img = Properties.Resources.image8;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }

        public static void caculate_step()
        {
            Program.regional_soil_n = retrieve_soil_n(Program.regional_soil);// 计算土质系数
            // 底宽 S/H -nH
            Program.rainwater_collection_width_bottom_L = ((Program.rainwater_collection_deep_H - Program.regional_groundwater_level_m) * Program.regional_S * 0.085 + Program.average_rainfall_a * Program.regional_S * (0.0915 + 0.085) / 1000 - Program.average_evaporation_c * Program.regional_S * 0.085 / 1000) / (Program.rainwater_collection_length_l * Program.rainwater_collection_deep_H) - Program.regional_soil_n * Program.rainwater_collection_deep_H;
            Program.rainwater_collection_width_bottom_L = Math.Round(Program.rainwater_collection_width_bottom_L, 2, MidpointRounding.AwayFromZero);
            // 上宽 2S/H + nH -((H-m + (a-c)/100000)*8.5*S + a*9.15*S/100000)*H/l
            Program.rainwater_collection_width_top_L = ((Program.rainwater_collection_deep_H - Program.regional_groundwater_level_m) * Program.regional_S * 0.085 + Program.average_rainfall_a * Program.regional_S * (0.0915 + 0.085) / 1000 - Program.average_evaporation_c * Program.regional_S * 0.085 / 1000) / (Program.rainwater_collection_length_l * Program.rainwater_collection_deep_H) + Program.regional_soil_n * Program.rainwater_collection_deep_H;
            Program.rainwater_collection_width_top_L = Math.Round(Program.rainwater_collection_width_top_L, 2, MidpointRounding.AwayFromZero);
            // 淹没区面积 (b-a)*17.64/(1000*100)*S*2/3 = ((b-a)*17.64*s*2)/(1000*100*3)
            Program.flooded_S = ((Program.maximum_rainfall_b - Program.average_rainfall_a) * 17.64 * Program.regional_S * 2) / (1000  * 100  * 3);
            Program.flooded_S = Math.Round(Program.flooded_S, 0, MidpointRounding.AwayFromZero);
        }

        private static double retrieve_soil_n(int soil_type)
        {
            double soil_n = 1.0;
            switch (soil_type)
            {
                case 1:
                    soil_n = retrieve_soil_1();
                    break;
                case 2:
                    soil_n = retrieve_soil_2();
                    break;
                case 3:
                    soil_n = retrieve_soil_3();
                    break;
                case 4:
                    soil_n = retrieve_soil_4();
                    break;
                default:
                    soil_n = retrieve_soil_1();
                    break;
            }

            return soil_n;
        }

        private static double retrieve_soil_1()
        {
            double soil_n = 1.0;
            if (Program.rainwater_collection_deep_H < 1.5)
            {
                soil_n = 1.0;
            }
            else if (Program.rainwater_collection_deep_H >= 1.5 && Program.rainwater_collection_deep_H < 3.0)
            {
                soil_n = 1.25;
            }
            else if (Program.rainwater_collection_deep_H >= 3.0 && Program.rainwater_collection_deep_H < 4.0)
            {
                soil_n = 1.5;
            }
            else
            {
                soil_n = 2.0;
            }
            return soil_n;
        }

        private static double retrieve_soil_2()
        {
            double soil_n = 1.5;
            if (Program.rainwater_collection_deep_H < 1.5)
            {
                soil_n = 1.5;
            }
            else if (Program.rainwater_collection_deep_H >= 1.5 && Program.rainwater_collection_deep_H < 3.0)
            {
                soil_n = 2.0;
            }
            else if (Program.rainwater_collection_deep_H >= 3.0 && Program.rainwater_collection_deep_H < 4.0)
            {
                soil_n = 2.5;
            }
            else
            {
                soil_n = 3.0;
            }
            return soil_n;
        }

        private static double retrieve_soil_3()
        {
            double soil_n = 2.0;
            if (Program.rainwater_collection_deep_H < 1.5)
            {
                soil_n = 2.0;
            }
            else if (Program.rainwater_collection_deep_H >= 1.5 && Program.rainwater_collection_deep_H < 3.0)
            {
                soil_n = 2.5;
            }
            else if (Program.rainwater_collection_deep_H >= 3.0 && Program.rainwater_collection_deep_H < 4.0)
            {
                soil_n = 3.0;
            }
            else
            {
                soil_n = 4.0;
            }
            return soil_n;
        }

        private static double retrieve_soil_4()
        {
            double soil_n = 2.5;
            if (Program.rainwater_collection_deep_H < 1.5)
            {
                soil_n = 2.5;
            }
            else if (Program.rainwater_collection_deep_H >= 1.5 && Program.rainwater_collection_deep_H < 3.0)
            {
                soil_n = 3.0;
            }
            else if (Program.rainwater_collection_deep_H >= 3.0 && Program.rainwater_collection_deep_H < 4.0)
            {
                soil_n = 4.0;
            }
            else
            {
                soil_n = 5.0;
            }
            return soil_n;
        }
    }
}
