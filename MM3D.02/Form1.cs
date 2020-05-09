using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;
using Chart3DLib;
using MM3D;
using System.Windows.Forms.DataVisualization.Charting;

namespace MM3D._02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboboxSetup();
            ComboboxColorSetup();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            cm = new ColorMap();
            chart3D1.C3ChartStyle.IsColorBar = true;
            chart3D1.C3Labels.Title = "No Title";
            chart3D1.C3DataSeries.LineStyle.IsVisible = false;
        }

        public static int nx = 10; // Розмірність по х
        public static int ny = 10; // Розмірність по y
        ColorMap cm;
        MM3DMath Obj = new MM3DMath();

        /*protected override void OnPaint(PaintEventArgs e)
        {
            ChartTypeSetup();
            ChartColorSetup();

            //Мінімальні та максимальні значення шкал по осях x,y,z.

            chart3D1.C3Axes.XMin = 0;
            chart3D1.C3Axes.XMax = 1;
            chart3D1.C3Axes.YMin = 0;
            chart3D1.C3Axes.YMax = 1;
            chart3D1.C3Axes.ZMin = 0;//Form2.min;//(float)MatrixCriticalValues(Form2.Graf, "min");
            chart3D1.C3Axes.ZMax = 1;// Form2.max;// (float)MatrixCriticalValues(Form2.Graf, "max");

            //крок для підпису шкали
            chart3D1.C3Axes.XTick = (chart3D1.C3Axes.XMax - chart3D1.C3Axes.XMin) / 10;
            chart3D1.C3Axes.YTick = (chart3D1.C3Axes.YMax - chart3D1.C3Axes.YMin) / 10;
            chart3D1.C3Axes.ZTick = (chart3D1.C3Axes.ZMax - chart3D1.C3Axes.ZMin) / 10;

            chart3D1.C3DataSeries.XDataMin = chart3D1.C3Axes.XMin;
            chart3D1.C3DataSeries.YDataMin = chart3D1.C3Axes.YMin;
            chart3D1.C3DataSeries.XSpacing = 0.03f;
            chart3D1.C3DataSeries.YSpacing = 0.03f;
            //chart3D1.C3DataSeries.XNumber = nx;
            //chart3D1.C3DataSeries.YNumber = ny;
            chart3D1.C3DataSeries.XNumber = 30;
            chart3D1.C3DataSeries.YNumber = 30;


            Point3[,] pts = new Point3[chart3D1.C3DataSeries.XNumber,
                chart3D1.C3DataSeries.YNumber];

            for (int i = 0; i < chart3D1.C3DataSeries.XNumber; i++)
            {
                for (int j = 0; j < chart3D1.C3DataSeries.YNumber; j++)
                {
                    float x, y;
                    //double zz;
                    x =  //Координати x
                        chart3D1.C3DataSeries.XDataMin +
               i * chart3D1.C3DataSeries.XSpacing;
                    y =  //Координати y
                        chart3D1.C3DataSeries.YDataMin +
               j * chart3D1.C3DataSeries.YSpacing;
                    //zz = Form2.Graf[i, j, Convert.ToInt32(numericUpDownCut.Value), Convert.ToInt32(numericUpTime.Value) + 1];
                    float z = (float)(i+j)/(chart3D1.C3DataSeries.XNumber + chart3D1.C3DataSeries.YNumber);
                    pts[i, j] = new Point3(x, y, z, 1);
                }
            }
            chart3D1.C3DataSeries.PointArray = pts;
        }*/

        private void ComboboxSetup()
        {
            toolStripComboBox1.Items.Add("Mesh");
            toolStripComboBox1.Items.Add("MeshZ");
            toolStripComboBox1.Items.Add("Waterfall");
            toolStripComboBox1.Items.Add("Surface");
            toolStripComboBox1.Items.Add("XYColor");
            toolStripComboBox1.Items.Add("Contour");
            toolStripComboBox1.Items.Add("Filled Contour");
            toolStripComboBox1.Items.Add("Mesh + Contour");
            toolStripComboBox1.Items.Add("Surface + Contour");
            toolStripComboBox1.Items.Add("Surface + Filled Contour");
            toolStripComboBox1.Items.Add("Bar3D");
            toolStripComboBox1.SelectedItem = "Surface";
        }

        private void ComboboxColorSetup()
        {
            toolStripComboBox2.Items.Add("Gray");
            toolStripComboBox2.Items.Add("Spring");
            toolStripComboBox2.Items.Add("Summer");
            toolStripComboBox2.Items.Add("Autumn");
            toolStripComboBox2.Items.Add("Winter");
            toolStripComboBox2.Items.Add("Jet");
            toolStripComboBox2.Items.Add("Hot");
            toolStripComboBox2.Items.Add("Cool");
            toolStripComboBox2.SelectedItem = "Jet";
        }

        private void ChartTypeSetup()
        {
            string chartType = toolStripComboBox1.SelectedItem.ToString();
            switch (chartType)
            {
                case "Mesh":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.Mesh;
                    break;
                case "MeshZ":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.MeshZ;
                    break;
                case "Waterfall":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.Waterfall;
                    break;
                case "Surface":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.Surface;
                    break;
                case "XYColor":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.XYColor;
                    break;
                case "Contour":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.Contour;
                    break;
                case "Filled Contour":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.FillContour;
                    break;
                case "Mesh + Contour":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.MeshContour;
                    break;
                case "Surface + Contour":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.SurfaceContour;
                    break;
                case "Surface + Filled Contour":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.SurfaceFillContour;
                    break;
                case "Bar3D":
                    chart3D1.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.Bar3D;
                    break;
            }
        }

        private void ChartColorSetup()
        {
            string CMap = toolStripComboBox2.SelectedItem.ToString();
            switch (CMap)
            {
                case "Gray":
                    chart3D1.C3DrawChart.CMap = cm.Gray();
                    break;
                case "Summer":
                    chart3D1.C3DrawChart.CMap = cm.Spring();
                    break;
                case "Spring":
                    chart3D1.C3DrawChart.CMap = cm.Summer();
                    break;
                case "Autumn":
                    chart3D1.C3DrawChart.CMap = cm.Autumn();
                    break;
                case "Winter":
                    chart3D1.C3DrawChart.CMap = cm.Winter();
                    break;
                case "Jet":
                    chart3D1.C3DrawChart.CMap = cm.Jet();
                    break;
                case "Hot":
                    chart3D1.C3DrawChart.CMap = cm.Hot();
                    break;
                case "Cool":
                    chart3D1.C3DrawChart.CMap = cm.Cool();
                    break;
            }
        }

        //***************************************************************

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Obj.z_time - 2 ;
            numericUpDown1.Minimum = 0;
            numericUpDown2.Maximum = Obj.m1 - 1;
            numericUpDown2.Minimum = 0;

            numericUpDown6.Maximum = Obj.z_time - 2;
            numericUpDown6.Minimum = 0;

            numericUpDown4.Maximum = 2;
            numericUpDown4.Minimum = 0;

            numericUpDown5.Maximum = Obj.m1 - 1;
            numericUpDown5.Minimum = 0;
            numericUpDown7.Maximum = Obj.m1 - 1;
            numericUpDown7.Minimum = 0;

            Obj.Run();
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Drow();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = 30;
            if (chart3D1.C3ViewAngle.Azimuth - k < -180) chart3D1.C3ViewAngle.Azimuth = 180 - (chart3D1.C3ViewAngle.Azimuth + k + 180);
            else
                chart3D1.C3ViewAngle.Azimuth = chart3D1.C3ViewAngle.Azimuth - k;// chart3D1.C3ViewAngle.Azimuth - 90;
            Drow(); 
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Обертання по осі Oxy проміжок від [-180 до 180]
            int k  = 30;
            if (chart3D1.C3ViewAngle.Azimuth + k > 180) chart3D1.C3ViewAngle.Azimuth = -180 + (chart3D1.C3ViewAngle.Azimuth + k - 180);
            else
            chart3D1.C3ViewAngle.Azimuth = chart3D1.C3ViewAngle.Azimuth + k;
            Drow();
        }

        private void Drow()
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (!checkBox3.Checked)
                Obj.f_choise = 10;
            else
            {
                if (radioButton58.Checked)
                  Obj.f_choise = 0;

                if (radioButton59.Checked)
                   Obj.f_choise = 1;

                if (radioButton60.Checked)
                    Obj.f_choise = 2;

                if (radioButton54.Checked)
                    Obj.f_choise = 3;
            }



            Obj.conc = Convert.ToDouble(textBox84.Text);
            Obj.a = Convert.ToInt32(textBox2.Text);
            Obj.b = Convert.ToInt32(textBox63.Text);

            textBox64.Text = Convert.ToString(Obj.f_choise);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ChartTypeSetup();
            ChartColorSetup();

            dataGridView1.ColumnCount = Obj.m1;
            dataGridView1.RowCount = Obj.m2;
            for (int i = 0; i < Obj.m1; i++)
                dataGridView1.Columns[i].Width = 66;

            chart3D1.C3Axes.XMin = 0;
            chart3D1.C3Axes.XMax = Obj.m1-1;
            chart3D1.C3Axes.YMin = 0;
            chart3D1.C3Axes.YMax = Obj.m2-1;

            double mult = 1e3; // 1e7;                                                //   MULTIPLIER
            int time = (int) (3 * numericUpDown1.Value + numericUpDown3.Value);
            int pos = (int)numericUpDown2.Value;

            int time_ = (int)(numericUpDown1.Value);
            long min = 0, max = 1;

            if (checkBox1.Checked)
            {
                if (radioButton4.Checked)
                {
                    point_minmax(Obj.H_b, time, ref min, ref max, 1);
                }

                if (radioButton6.Checked)
                {
                    point_minmax(Obj.C_b, time, ref min, ref max, 1);
                }

                if (radioButton5.Checked)
                {
                    point_minmax(Obj.T_b, time, ref min, ref max, 1); 
                }

                if (radioButton7.Checked)
                {
                    point_minmax(Obj.U_z_b, time_, ref min, ref max, mult);
                }
                if (radioButton8.Checked)
                {
                    point_minmax(Obj.V_z_b, time_, ref min, ref max, mult); 
                }

                if (radioButton9.Checked)
                {
                    point_minmax(Obj.W_z_b, time_, ref min, ref max, mult);
                }

                if (radioButton10.Checked)
                {
                    point_minmax(Obj.V_b, time_, ref min, ref max, 1);
                }

                //min max E_
                if (radioButton11.Checked)
                {
                    point_minmax(Obj.E_z_b, time_, ref min, ref max, mult);
                }
                if (radioButton12.Checked)
                {
                    point_minmax(Obj.E_y_b, time_, ref min, ref max, mult);
                }
                if (radioButton13.Checked)
                {
                    point_minmax(Obj.E_x_b, time_, ref min, ref max, mult); 
                }
                // min max sigma
                if (radioButton16.Checked)
                {
                    point_minmax(Obj.sigma_x_b, time_, ref min, ref max, 1);
                }
                if (radioButton14.Checked)
                {
                    point_minmax(Obj.sigma_y_b, time_, ref min, ref max, 1);
                }
                if (radioButton15.Checked)
                {
                    point_minmax(Obj.sigma_z_b, time_, ref min, ref max, 1);
                }
                // E_xy min max
                if (radioButton19.Checked)
                {
                    point_minmax(Obj.E_xy_b, time_, ref min, ref max, mult);
                }

                // E_xz min max
                if (radioButton18.Checked)
                {
                    point_minmax(Obj.E_xz_b, time_, ref min, ref max, mult);
                }
                // E_xz min max
                if (radioButton17.Checked)
                {
                    point_minmax(Obj.E_yz_b, time_, ref min, ref max, mult);
                }

                ////////////////////////////////////////////////////////////////

                // tau_xy min max
                if (radioButton22.Checked)
                {
                    point_minmax(Obj.tau_xy_b, time_, ref min, ref max, 1);
                }

                // E_xz min max
                if (radioButton21.Checked)
                {
                    point_minmax(Obj.tau_xz_b, time_, ref min, ref max, 1);
                }
                // E_xz min max
                if (radioButton20.Checked)
                {
                    point_minmax(Obj.tau_yz_b, time_,ref min, ref max, 1);
                }
            }
            else
            {
                if (radioButton4.Checked)
                {
                    point_minmax(Obj.H, time, ref min, ref max, 1);
                }

                if (radioButton6.Checked)
                {
                    point_minmax(Obj.C, time, ref min, ref max, 1);
                }

                if (radioButton5.Checked)
                {
                    point_minmax(Obj.T, time, ref min, ref max, 1);
                }

                if (radioButton7.Checked)
                {
                    point_minmax(Obj.U_z, time_, ref min, ref max, mult);
                }
                if (radioButton8.Checked)
                {
                    point_minmax(Obj.V_z, time_, ref min, ref max, mult);
                }

                if (radioButton9.Checked)
                {
                    point_minmax(Obj.W_z, time_, ref min, ref max, mult);
                }

                if (radioButton10.Checked)
                {
                    point_minmax(Obj.V, time_, ref min, ref max, 1);
                }

                //min max E_
                if (radioButton11.Checked)
                {
                    point_minmax(Obj.E_z, time_, ref min, ref max, mult);
                }
                if (radioButton12.Checked)
                {
                    point_minmax(Obj.E_y, time_, ref min, ref max, mult);
                }
                if (radioButton13.Checked)
                {
                    point_minmax(Obj.E_x, time_, ref min, ref max, mult);
                }
                // min max sigma
                if (radioButton16.Checked)
                {
                    point_minmax(Obj.sigma_x, time_, ref min, ref max, 1);
                }
                if (radioButton14.Checked)
                {
                    point_minmax(Obj.sigma_y, time_, ref min, ref max, 1);
                }
                if (radioButton15.Checked)
                {
                    point_minmax(Obj.sigma_z, time_, ref min, ref max, 1);
                }
                // E_xy min max
                if (radioButton19.Checked)
                {
                    point_minmax(Obj.E_xy, time_, ref min, ref max, mult);
                }

                // E_xz min max
                if (radioButton18.Checked)
                {
                    point_minmax(Obj.E_xz, time_, ref min, ref max, mult);
                }
                // E_xz min max
                if (radioButton17.Checked)
                {
                    point_minmax(Obj.E_yz, time_, ref min, ref max, mult);
                }

                ////////////////////////////////////////////////////////////////

                // tau_xy min max
                if (radioButton22.Checked)
                {
                    point_minmax(Obj.tau_xy, time_, ref min, ref max, 1);
                }

                // E_xz min max
                if (radioButton21.Checked)
                {
                    point_minmax(Obj.tau_xz, time_, ref min, ref max, 1);
                }
                // E_xz min max
                if (radioButton20.Checked)
                {
                    point_minmax(Obj.tau_yz, time_, ref min, ref max, 1);
                }
            }

            

            if (min == max) max = max + 1;
            chart3D1.C3Axes.ZMin = min; //Form2.min;//(float)MatrixCriticalValues(Form2.Graf, "min");
            chart3D1.C3Axes.ZMax = max; // Form2.max;// (float)MatrixCriticalValues(Form2.Graf, "max");
            
            textBox30.Text = "" +min;
            textBox31.Text = "" +max;
            //крок для підпису шкали
            chart3D1.C3Axes.XTick = (float)Math.Round(((chart3D1.C3Axes.XMax - chart3D1.C3Axes.XMin) / (10)), 1);
            chart3D1.C3Axes.YTick = (float)Math.Round(((chart3D1.C3Axes.YMax - chart3D1.C3Axes.YMin) / (10)), 1);
            chart3D1.C3Axes.ZTick = (float)Math.Round(((chart3D1.C3Axes.ZMax - chart3D1.C3Axes.ZMin) / 10.0), 1);

            chart3D1.C3DataSeries.XDataMin = chart3D1.C3Axes.XMin;
            chart3D1.C3DataSeries.YDataMin = chart3D1.C3Axes.YMin;
            chart3D1.C3DataSeries.XSpacing = (float)1;// (1.0 / (Obj.m1 - 1.0));
            chart3D1.C3DataSeries.YSpacing = (float)1;// (1.0 / (Obj.m2 - 1.0));
            //chart3D1.C3DataSeries.XNumber = nx;
            //chart3D1.C3DataSeries.YNumber = ny;
            chart3D1.C3DataSeries.XNumber = Obj.m1;
            chart3D1.C3DataSeries.YNumber = Obj.m2;
            
            Point3[,] pts = new Point3[chart3D1.C3DataSeries.XNumber,
                chart3D1.C3DataSeries.YNumber];

            for (int i = 0; i < chart3D1.C3DataSeries.XNumber; i++)
            {
                for (int j = 0; j < chart3D1.C3DataSeries.YNumber; j++)
                {
                    float x, y;
                    //double zz;
                    //Координати x
                    x = chart3D1.C3DataSeries.XDataMin + i * chart3D1.C3DataSeries.XSpacing;
                    //Координати y
                    y = chart3D1.C3DataSeries.YDataMin + j * chart3D1.C3DataSeries.YSpacing;
                    //zz = Form2.Graf[i, j, Convert.ToInt32(numericUpDownCut.Value), Convert.ToInt32(numericUpTime.Value) + 1];
                    float z = 0;

                    // Zadania znachen v grafic
                    if (!checkBox1.Checked)
                    {
                        // Концентрація
                        if (radioButton6.Checked)
                        {
                            add_point( Obj.C, time, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Температура
                        if (radioButton5.Checked)
                        {
                            add_point( Obj.T, time, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        // Напір
                        if (radioButton4.Checked)
                        {
                            add_point( Obj.H, time, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //Зміщення по Ox
                        if (radioButton7.Checked)
                        {
                            add_point( Obj.U_z, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Зміщення по Oy
                        if (radioButton8.Checked)
                        {
                            add_point( Obj.V_z, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Зміщення по Oz
                        if (radioButton9.Checked)
                        {
                            add_point( Obj.W_z, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Швидкість фільтрації
                        if (radioButton10.Checked)
                        {
                            add_point( Obj.V, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Деформація E_z
                        if (radioButton11.Checked)
                        {
                            add_point( Obj.E_z, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Деформація E_y
                        if (radioButton12.Checked)
                        {
                            add_point( Obj.E_y, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Деформація E_x
                        if (radioButton13.Checked)
                        {
                            add_point( Obj.E_x, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Напруження Sigma_z
                        if (radioButton15.Checked)
                        {
                            add_point( Obj.sigma_z, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Напруження Sigma_y
                        if (radioButton14.Checked)
                        {
                            add_point( Obj.sigma_y, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Напруження Sigma_x
                        if (radioButton16.Checked)
                        {
                            add_point( Obj.sigma_x, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //E_xy
                        if (radioButton19.Checked)
                        {
                            add_point( Obj.E_xy, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //E_xz
                        if (radioButton18.Checked)
                        {
                            add_point( Obj.E_xz, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //E_yz
                        if (radioButton17.Checked)
                        {
                            add_point( Obj.E_yz, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //tau_xy
                        if (radioButton22.Checked)
                        {
                            add_point( Obj.tau_xy, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //tau_xz
                        if (radioButton21.Checked)
                        {
                            add_point( Obj.tau_xz, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //tau_yz
                        if (radioButton20.Checked)
                        {
                            add_point( Obj.tau_yz, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                    }
                    else
                    {
                        // Концентрація
                        if (radioButton6.Checked)
                        {
                            add_point( Obj.C_b, time, i, j, pos, ref x, ref y, ref z,1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Температура
                        if (radioButton5.Checked)
                        {
                            add_point( Obj.T_b, time, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        // Напір
                        if (radioButton4.Checked)
                        {
                            add_point( Obj.H_b, time, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //Зміщення по Ox
                        if (radioButton7.Checked)
                        {
                            add_point( Obj.U_z_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Зміщення по Oy
                        if (radioButton8.Checked)
                        {
                            add_point( Obj.V_z_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Зміщення по Oz
                        if (radioButton9.Checked)
                        {
                            add_point( Obj.W_z_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Швидкість фільтрації
                        if (radioButton10.Checked)
                        {
                            add_point( Obj.V_b, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Деформація E_z
                        if (radioButton11.Checked)
                        {
                            add_point( Obj.E_z_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Деформація E_y
                        if (radioButton12.Checked)
                        {
                            add_point( Obj.E_y_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Деформація E_x
                        if (radioButton13.Checked)
                        {
                            add_point( Obj.E_x_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Напруження Sigma_z
                        if (radioButton15.Checked)
                        {
                            add_point( Obj.sigma_z_b, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        // Напруження Sigma_y
                        if (radioButton14.Checked)
                        {
                            add_point( Obj.sigma_y_b, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //Напруження Sigma_x
                        if (radioButton16.Checked)
                        {
                            add_point( Obj.sigma_x_b, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //E_xy
                        if (radioButton19.Checked)
                        {
                            add_point( Obj.E_xy_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //E_xz
                        if (radioButton18.Checked)
                        {
                            add_point( Obj.E_xz_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //E_yz
                        if (radioButton17.Checked)
                        {
                            add_point( Obj.E_yz_b, time_, i, j, pos, ref x, ref y, ref z, mult);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //tau_xy
                        if (radioButton22.Checked)
                        {
                            add_point( Obj.tau_xy_b, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }

                        //tau_xz
                        if (radioButton21.Checked)
                        {
                            add_point( Obj.tau_xz_b, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                        //tau_yz
                        if (radioButton20.Checked)
                        {
                            add_point( Obj.tau_yz_b, time_, i, j, pos, ref x, ref y, ref z, 1);
                            pts[i, j] = new Point3(x, y, z, 1);
                        }
                    }

                    if (pts[i, j].Z == 0)
                    {
                        pts[i, j].Z = 0.0001f;
                    }

                }
            }
                chart3D1.C3DataSeries.PointArray = pts;
        }

        private void add_point(double[,,,] objct , int time, int  i,int j, int pos,ref float x, ref float y, ref float z, double mult)
        {
            if (radioButton3.Checked)
            {
                z = (float)(objct[time, i, j, pos]*mult);
                dataGridView1[j, i].Value =( objct[time, i, j, pos] * mult);
                
            }
            else if (radioButton2.Checked)
            {
                z = (float)(objct[time, i, pos, j] * mult);
                dataGridView1[j, i].Value = (objct[time, i, pos, j] * mult);
            }
            else if (radioButton1.Checked)
            {
                z = (float)(objct[time, pos, i, j] * mult);
                dataGridView1[j, i].Value = (objct[time, pos, i, j] * mult);
            }
        }

        private void point_minmax(double[,,,] objct, int time, ref long min, ref long max, double mult)
        {
            min = (long)(objct[time, 0, 0, 0] * mult);
            max = (long)(objct[time, 0, 0, 0] * mult);
            for (int i = 0; i < Obj.m1; i++)
                for (int j = 0; j < Obj.m2; j++)
                    for (int z = 0; z < Obj.m3; z++)
                    {
                        if (min > (objct[time, i, j, z] * mult)) min = (long)(objct[time, i, j, z] * mult);
                        if (max < (objct[time, i, j, z] * mult)) max = (long)(objct[time, i, j, z] * mult);
                    }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int k = 10;
            if (chart3D1.C3ViewAngle.Elevation + k > 90) chart3D1.C3ViewAngle.Elevation = -90 + (chart3D1.C3ViewAngle.Elevation + k - 90);
            else
                chart3D1.C3ViewAngle.Elevation = chart3D1.C3ViewAngle.Elevation + k;
            Drow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chart3D1.C3ViewAngle.Elevation = 30;
            chart3D1.C3ViewAngle.Azimuth = -45;
            Drow();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int k = 10;
            if (chart3D1.C3ViewAngle.Elevation - k < -90) chart3D1.C3ViewAngle.Elevation = 90 - (chart3D1.C3ViewAngle.Elevation + k + 90);
            else
                chart3D1.C3ViewAngle.Elevation = chart3D1.C3ViewAngle.Elevation - k;// chart3D1.C3ViewAngle.Azimuth - 90;
            Drow();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Obj = new MM3DMath();
            label26.Text = "";
            try
            {
                Obj.H_0 = Convert.ToDouble(textBox1.Text);
                Obj.H_2 = Convert.ToDouble(textBox3.Text);
                Obj.H_1 = Convert.ToDouble(textBox4.Text);
                Obj.C_0 = Convert.ToDouble(textBox5.Text);
                Obj.C_2 = Convert.ToDouble(textBox6.Text);
                Obj.C_1 = Convert.ToDouble(textBox7.Text);
                Obj.T_0 = Convert.ToDouble(textBox8.Text);
                Obj.T_2 = Convert.ToDouble(textBox15.Text);
                Obj.T_1 = Convert.ToDouble(textBox14.Text);
                Obj.ro = Convert.ToDouble(textBox22.Text);

                Obj.C_p = Convert.ToDouble(textBox21.Text);
                Obj.C_t = Convert.ToDouble(textBox20.Text);
                Obj.tau = Convert.ToDouble(textBox19.Text);
                Obj.eps = Convert.ToDouble(textBox25.Text);

                Obj.z_time = Convert.ToInt32(textBox13.Text);
                Obj.m_time = 3 * Convert.ToInt32(textBox13.Text);

                Obj.m1 = Convert.ToInt32(textBox12.Text);
                Obj.m2 = Convert.ToInt32(textBox12.Text);
                Obj.m3 = Convert.ToInt32(textBox12.Text);

                Obj.LamdaT = Convert.ToDouble(textBox23.Text);
                Obj.Alpha_T = Convert.ToDouble(textBox11.Text);
                Obj.D = Convert.ToDouble(textBox10.Text);
                Obj.D_t = Convert.ToDouble(textBox9.Text);
                Obj.gamma = Convert.ToDouble(textBox18.Text);
                Obj.gamma_r = Convert.ToDouble(textBox17.Text);
                Obj.gamma_zv2 = Convert.ToDouble(textBox16.Text);
                Obj.gamma_pr3 = Convert.ToDouble(textBox29.Text); 
                Obj.V_C = Convert.ToDouble(textBox28.Text);

                Obj.V_T = Convert.ToDouble(textBox27.Text);
                Obj.tau = Convert.ToDouble(textBox19.Text);
                Obj.eps = Convert.ToDouble(textBox25.Text);
                Obj.K = Convert.ToDouble(textBox26.Text);

                Obj.h1 = Convert.ToDouble(textBox32.Text);
                Obj.h2 = Convert.ToDouble(textBox32.Text);
                Obj.h3 = Convert.ToDouble(textBox32.Text);

            }
            catch
            {
                label26.Text = "Щось пішло не так";
            }
            Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Obj = new MM3DMath();
            label26.Text = "";
            try
            {
                Obj.H_0 = 1;
                Obj.H_2 = 1;
                Obj.H_1 = 10;
                Obj.C_0 = 8;
                Obj.C_2 = 8;
                Obj.C_1 = 350;
                Obj.T_0 = 15;
                Obj.T_2 = 15;
                Obj.T_1 = 30;
                Obj.ro = 1100;

                Obj.C_p = 4.2e03;
                Obj.C_t = 2.137e06;
                Obj.tau = 30;
                Obj.eps = 10E-05;

                Obj.z_time = 38;
                Obj.m_time = 3 * 38;

                Obj.m1 = 16;
                Obj.m2 = 16;
                Obj.m3 = 16;

                Obj.LamdaT = 108E03;
                Obj.Alpha_T = 1E-06;
                Obj.D = 2E-2;
                Obj.D_t = 2E-3;
                Obj.gamma = 6.5E-05;
                Obj.gamma_r = 1E4;
                Obj.gamma_zv2 = 1.3E03;
                Obj.gamma_pr3 = 1.7E04;
                Obj.V_C = 2.8E-06;

                Obj.V_T = 2.8E-05;
                Obj.tau =30;
                Obj.eps = 1E-05;
                Obj.K =0.001;

                Obj.h1 = 1;
                Obj.h2 = 1;
                Obj.h3 = 1;

            }
            catch
            {
                label26.Text = "Щось пішло не так";
            }

            Show();
        }

        public void Show()
        {
            textBox34.Text = Convert.ToString(Obj.H_0);
            textBox36.Text = Convert.ToString(Obj.H_2);
            textBox38.Text = Convert.ToString(Obj.H_1);

            textBox40.Text = Convert.ToString(Obj.C_0);
            textBox42.Text = Convert.ToString(Obj.C_2);
            textBox44.Text = Convert.ToString(Obj.C_1);

            textBox46.Text = Convert.ToString(Obj.T_0);
            textBox48.Text = Convert.ToString(Obj.T_2);
            textBox50.Text = Convert.ToString(Obj.T_1);

            textBox58.Text = Convert.ToString(Obj.ro);
            textBox57.Text = Convert.ToString(Obj.C_p);
            textBox54.Text = Convert.ToString(Obj.C_t);
            textBox52.Text = Convert.ToString(Obj.tau);
            textBox37.Text = Convert.ToString(Obj.eps);

            textBox33.Text = Convert.ToString(Obj.z_time);
            textBox53.Text = Convert.ToString(Obj.m1);
            textBox24.Text = Convert.ToString(Obj.LamdaT);
            textBox55.Text = Convert.ToString(Obj.Alpha_T);
            textBox56.Text = Convert.ToString(Obj.D);
            textBox59.Text = Convert.ToString(Obj.D_t);
            textBox51.Text = Convert.ToString(Obj.gamma);
            textBox49.Text = Convert.ToString(Obj.gamma_r);
            textBox47.Text = Convert.ToString(Obj.gamma_zv2);
            textBox45.Text = Convert.ToString(Obj.gamma_pr3);
            textBox43.Text = Convert.ToString(Obj.V_C);
            textBox41.Text = Convert.ToString(Obj.V_T);
            textBox39.Text = Convert.ToString(Obj.K);
            textBox35.Text = Convert.ToString(Obj.h1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {Drow();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton68_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton69_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton67_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        int series_S = 1;
        string SeriesN = "";

        double avg0 = 0,
               avg = 0;

        private void AddElementToGrid(double x, int row, int el)
        {
            if (row == 0)
            {
                avg0 += x;
                dataGridView2.Rows[row].Cells[el + 1].Value = x;

                if (el == Obj.m1 - 1)
                {
                    avg0 = avg0 / Obj.m1;
                    dataGridView2.Rows[row].Cells[0].Value = 0;
                }
            }

            else
            {
                avg += x;
                dataGridView2.Rows[row].Cells[el + 1].Value = x;

                if (el == Obj.m1 - 1)
                {
                    avg = avg / Obj.m1;
                    dataGridView2.Rows[row].Cells[0].Value = Math.Round((avg - avg0) / avg0 * 100, 3, MidpointRounding.AwayFromZero);
                }
            }

            
        }

         private void button15_Click(object sender, EventArgs e)
        {
            dataGridView2.ColumnCount = Obj.m1 + 1;
            dataGridView2.Rows.Add();
            dataGridView2.ColumnHeadersVisible = false;

            if (series_S == 1)
            {
                chart2.Series.Clear();
            }
            
            long time = Convert.ToInt64(numericUpDown6.Value);
            //long time_full = Convert.ToInt64(numericUpDown6.Value) * 3 + Convert.ToInt64(numericUpDown4.Value);
            long time_full = Convert.ToInt64(numericUpDown6.Value) + Convert.ToInt64(numericUpDown4.Value);
            long Val1 = Convert.ToInt64(numericUpDown5.Value);
            long Val2 = Convert.ToInt64(numericUpDown7.Value);

            {
                if (radioButton40.Checked)
                    SeriesN = ( nameof (Obj.T)).ToString();
                if (radioButton44.Checked)
                    SeriesN = (nameof (Obj.C)).ToString();
                if (radioButton39.Checked)
                    SeriesN = (nameof(Obj.H)).ToString();
                if (radioButton35.Checked)
                    SeriesN = (nameof(Obj.V)).ToString();
                if (radioButton38.Checked)
                    SeriesN = (nameof(Obj.U_z)).ToString();
                if (radioButton37.Checked)
                    SeriesN = (nameof(Obj.V_z)).ToString();
                if (radioButton36.Checked)
                    SeriesN = (nameof(Obj.W_z)).ToString();
                if (radioButton31.Checked)
                    SeriesN = (nameof(Obj.sigma_x)).ToString();
                if (radioButton29.Checked)
                    SeriesN = (nameof(Obj.sigma_y)).ToString();
                if (radioButton30.Checked)
                    SeriesN = (nameof(Obj.sigma_z)).ToString();
                if (radioButton34.Checked)
                    SeriesN = (nameof(Obj.E_x)).ToString();
                if (radioButton33.Checked)
                    SeriesN = (nameof(Obj.E_y)).ToString();
                if (radioButton32.Checked)
                    SeriesN = (nameof(Obj.E_z)).ToString();
                if (radioButton28.Checked)
                    SeriesN = (nameof(Obj.E_xy)).ToString();
                if (radioButton27.Checked)
                    SeriesN = (nameof(Obj.E_xz)).ToString();
                if (radioButton26.Checked)
                    SeriesN = (nameof(Obj.E_yz)).ToString();
                if (radioButton25.Checked)
                    SeriesN = (nameof(Obj.tau_xy)).ToString();
                if (radioButton24.Checked)
                    SeriesN = (nameof(Obj.tau_xz)).ToString();
                if (radioButton23.Checked)
                    SeriesN = (nameof(Obj.tau_yz)).ToString();
            }
            
            SeriesN += "[" +numericUpDown6.Value.ToString()+ ", ";
            if (radioButtonXOY.Checked)
                SeriesN += Val1.ToString() +", " + Val2.ToString() +", N]";
            if (radioButtonXOZ.Checked)
                SeriesN += Val1.ToString() + ", " + "N, " + Val2.ToString() + "]";
            if (radioButtonZOY.Checked)
                SeriesN += "N, " + Val1.ToString() + ", " + Val2.ToString() + "]";

            series_S += 1;
            
            
            

            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = SeriesN,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line,
                BorderWidth = 4
            };

            int s_end = 1;
            string s_text = SeriesN;

            bool exists = false;

            foreach (var item in chart2.Series)
            {
                if (item.Name == SeriesN)
                {
                    exists = true;
                }
            }


            while ( exists )
            {
                
                SeriesN = s_text;
                SeriesN += " " + s_end.ToString();
                s_end++;

                exists = false;
                foreach (var item in chart2.Series)
                {
                    if (item.Name == SeriesN)
                    {
                        exists = true;
                    }
                }
                series1.Name = SeriesN;
            }
                
            this.chart2.Series.Add(series1);

            chart2.ResetAutoValues();
            
            if (radioButtonXOY.Checked)
                for (int i = 0; i < Obj.m3; i++)
                {
                    //T
                    if (radioButton40.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i,Obj.T[time_full,Val1,Val2,i]);
                        AddElementToGrid(Obj.T[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }     
                    //C
                    if (radioButton44.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.C[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.C[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //H
                    if (radioButton39.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.H[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.H[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //Speed
                    if (radioButton35.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.V[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.V[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //U_z
                    if (radioButton38.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.U_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.U_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //V_z
                    if (radioButton37.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.V_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.V_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //W_z
                    if (radioButton36.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.W_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.W_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }

                    //sigma_x
                    if (radioButton31.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_x[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_x[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //sigma_y
                    if (radioButton29.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_y[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_y[time, Val1, Val2, i], Obj.counter2D, i);
                    }                    
                    //sigma_z
                    if (radioButton30.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_x
                    if (radioButton34.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_x[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_x[time, Val1, Val2, i], Obj.counter2D, i);
                    }                    
                    //E_y
                    if (radioButton33.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_y[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_y[time, Val1, Val2, i], Obj.counter2D, i);
                    }                    
                    //E_z
                    if (radioButton32.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_xy
                    if (radioButton28.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.T[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.T[time, Val1, Val2, i], Obj.counter2D, i);
                    }                    
                    //E_xz
                    if (radioButton27.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_xz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_xz[time, Val1, Val2, i], Obj.counter2D, i);
                    }                    
                    //E_yz
                    if (radioButton26.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_yz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_yz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //tau_xy
                    if (radioButton25.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_xy[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_xy[time, Val1, Val2, i], Obj.counter2D, i);
                    }                    
                    //tau_xz
                    if (radioButton24.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.tau_xz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.tau_xz[time, Val1, Val2, i], Obj.counter2D, i);
                    }                    
                    //tau_yz
                    if (radioButton23.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.tau_yz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.tau_yz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                }

            if (radioButtonXOZ.Checked)
                for (int i = 0; i < Obj.m3; i++)
                {
                    //T
                    if (radioButton40.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.T[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.T[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //C
                    if (radioButton44.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.C[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.C[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //H
                    if (radioButton39.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.H[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.H[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //Speed
                    if (radioButton35.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.V[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.V[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //U_z
                    if (radioButton38.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.U_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.U_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //V_z
                    if (radioButton37.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.V_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.V_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //W_z
                    if (radioButton36.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.W_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.W_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }

                    //sigma_x
                    if (radioButton31.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_x[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_x[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //sigma_y
                    if (radioButton29.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_y[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_y[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //sigma_z
                    if (radioButton30.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_x
                    if (radioButton34.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_x[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_x[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_y
                    if (radioButton33.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_y[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_y[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_z
                    if (radioButton32.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_xy
                    if (radioButton28.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.T[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.T[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_xz
                    if (radioButton27.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_xz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_xz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_yz
                    if (radioButton26.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_yz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_yz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //tau_xy
                    if (radioButton25.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_xy[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_xy[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //tau_xz
                    if (radioButton24.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.tau_xz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.tau_xz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //tau_yz
                    if (radioButton23.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.tau_yz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.tau_yz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                }
            if (radioButtonZOY.Checked)
            {
                for (int i = 0; i < Obj.m3; i++)
                {
                    //T
                    if (radioButton40.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.T[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.T[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //C
                    if (radioButton44.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.C[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.C[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //H
                    if (radioButton39.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.H[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.H[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //Speed
                    if (radioButton35.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.V[time_full, Val1, Val2, i]);
                        AddElementToGrid(Obj.V[time_full, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //U_z
                    if (radioButton38.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.U_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.U_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //V_z
                    if (radioButton37.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.V_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.V_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //W_z
                    if (radioButton36.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.W_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.W_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }

                    //sigma_x
                    if (radioButton31.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_x[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_x[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //sigma_y
                    if (radioButton29.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_y[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_y[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //sigma_z
                    if (radioButton30.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.sigma_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.sigma_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_x
                    if (radioButton34.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_x[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_x[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_y
                    if (radioButton33.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_y[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_y[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_z
                    if (radioButton32.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_z[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_z[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_xy
                    if (radioButton28.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.T[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.T[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_xz
                    if (radioButton27.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_xz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_xz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //E_yz
                    if (radioButton26.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_yz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_yz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //tau_xy
                    if (radioButton25.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.E_xy[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.E_xy[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //tau_xz
                    if (radioButton24.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.tau_xz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.tau_xz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                    //tau_yz
                    if (radioButton23.Checked)
                    {
                        chart2.Series[SeriesN].Points.AddXY(i, Obj.tau_yz[time, Val1, Val2, i]);
                        AddElementToGrid(Obj.tau_yz[time, Val1, Val2, i], Obj.counter2D, i);
                    }
                }
            }

            Obj.counter2D++;
        }

        public void AddSeries() {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            chart2.Series.Clear();
            series_S = 1;
            dataGridView2.Rows.Clear();
            Obj.counter2D = 0;
            avg0 = 0;
            avg = 0;
        }

        private void radioButton58_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton59_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void radioButton60_CheckedChanged(object sender, EventArgs e)
        {
            Drow();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Obj.z_time - 2;
            numericUpDown1.Minimum = 0;
            numericUpDown2.Maximum = Obj.m1 - 1;
            numericUpDown2.Minimum = 0;

            numericUpDown6.Maximum = Obj.z_time - 2;
            numericUpDown6.Minimum = 0;

            numericUpDown4.Maximum = 2;
            numericUpDown4.Minimum = 0;

            numericUpDown5.Maximum = Obj.m1 - 1;
            numericUpDown5.Minimum = 0;
            numericUpDown7.Maximum = Obj.m1 - 1;
            numericUpDown7.Minimum = 0;

            Obj.Run();
            Show();
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            //
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                Obj.coeff_choise = 1;
                textBox66.Text = "0,11658";
                textBox67.Text = "-19,13338";
                textBox68.Text = "-0,01433";
                textBox69.Text = "0,07664";
                textBox70.Text = "-18,29209";
                textBox71.Text = "4875,65995";

                textBox72.Text = "0,05347";
                textBox73.Text = "-8,56879";
                textBox74.Text = "-0,01451";
                textBox75.Text = "0,04571";
                textBox76.Text = "-8,02227";
                textBox77.Text = "2098,68892";

                textBox78.Text = "0,13495";
                textBox79.Text = "-22,19182";
                textBox80.Text = "-0,01556";
                textBox81.Text = "0,08929";
                textBox82.Text = "-21,30479";
                textBox83.Text = "5646,9363";
            }
            else
            {
                Obj.coeff_choise = 0;
                textBox66.Text = "0";
                textBox67.Text = "0";
                textBox68.Text = "-1798,96";
                textBox69.Text = "4314,732";
                textBox70.Text = "-2615,37";
                textBox71.Text = "2545,743";

                textBox72.Text = "0";
                textBox73.Text = "0";
                textBox74.Text = "-1205,28";
                textBox75.Text = "2880,321";
                textBox76.Text = "-1741,92";
                textBox77.Text = "1696,324";

                textBox78.Text = "0";
                textBox79.Text = "0";
                textBox80.Text = "-0,000393";
                textBox81.Text = "0,1878866";
                textBox82.Text = "-22,70202";
                textBox83.Text = "4410,552";
            }
        }

        private void radioButton44_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chart3D1_Load(object sender, EventArgs e)
        {

        }
    }
}
