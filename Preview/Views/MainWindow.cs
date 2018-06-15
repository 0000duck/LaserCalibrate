using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
//fileread
using System.IO;
using OpenTK.Graphics.ES11;
using ZedGraph;

//sharpgl
using SharpGL;

namespace Preview
{
    public partial class MainWindow : Form
    {
        private Form _lastForm;
        private PowerMode _mode;
        private ControlClass _control;
        private ImageX img;
       

        public MainWindow(PowerMode mode,Form powerModeWindow)
        {
            InitializeComponent();
            _control=ControlClass.GetInstance();
            _mode = mode;
            _lastForm = powerModeWindow;
            switch (_mode)
            {
                case PowerMode.High:
                    PowerModeLabel.Text="工作模式：高功率";break;
                case PowerMode.Medium:
                    PowerModeLabel.Text = "工作模式：中功率";
                    Calibrate.Enabled = true;
                    break;
                case PowerMode.Low:
                    PowerModeLabel.Text = "工作模式：低功率"; break;
            }
            _control.StartPreview(AnglePicture,ShiftPicture);

            img = _control.imageX;
            UpDateTask.Start();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            UpDateTask.Stop();
            _control.StopPreview();
            _lastForm.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            UpDateTask.Stop();
            _control.StopPreview();
            _lastForm.Close();
            this.Close();
        }

        private void Calibrate_Click(object sender, EventArgs e)
        {
            _control.Calibrate();
        }

        /// <summary>
        /// timer回调函数 100ms更新一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDateTask_Tick(object sender, EventArgs e)
        {

            //绘制十字并更新图像
            _control.DrawCross();
            //更新2D图

            Pic2D.Image = img.ColorMap;

            //更新数据列表
            XWidth.Text = img.BreadthX.ToString();
            YWidth.Text = img.BreadthY.ToString();
            XCoord.Text = img.ShapeCenterX.ToString();
            YCoord.Text = img.ShapeCenterY.ToString();
            XBias.Text = img.BiasX.ToString();
            YBias.Text = img.BiasY.ToString();
            HorizontalAngle.Text = img.AngleX.ToString();
            VerticalAngle.Text = img.AngleY.ToString();


            //更新能量分布图
            heightMap = new Image<Gray, Byte>(img.GrayBitmap);
            colormat = new Image<Bgr, Byte>(img.ColorMap).Convert<Rgb, Byte>();


            createPaneY(zedGraphControl2);

            createPaneX(zedGraphControl1);
        }

        // --- Fields ---
        #region Private Static Fields

        private const int STEP_SIZE = 10;                                       // Width And Height Of Each Quad (NEW)
        private const float HEIGHT_RATIO = 1.5f;                                // Ratio That The Y Is Scaled According To The X And Z (NEW)
        private static bool bRender = true;                                     // Polygon Flag Set To TRUE By Default (NEW)
        private static Image<Gray, Byte> heightMap;                             // Holds The Height Map Data (NEW)
        private static Image<Rgb, Byte> colormat;
        private static float scaleValue = 0.15f;                                // Scale Value For The Terrain (NEW)
        public float view_x = 0.0f;
        public float view_y = 0.0f;
        public float view_z = 0.0f;

        public float Tra_z = 0.0f;
        public float eye_z = 0.0f;
        private static bool Key;


        //Image<Gray, Byte> graymat = new Image<Gray, Byte>(heightMap.Size);
        //CvInvoke.Threshold(heightMap, graymat, 150, 255, ThresholdType.Trunc);

        #endregion Private Static Fields

        //该函数用来进行绘图，通过调用renderheitmap来进行
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            // 创建一个GL对象
            OpenGL gl = openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.MatrixMode(SharpGL.Enumerations.MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Perspective(20, 3, 0.1f, 1000f);

            //设置视角
            gl.LookAt(-heightMap.Rows / 6, 180, -heightMap.Cols / 6 + eye_z, 0, 0, 0, 0, 1, 0);//设置视角位置


            gl.Enable(OpenGL.GL_BLEND);//开启混合
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);//设置混合因子
            gl.Enable(OpenGL.GL_POINT_SMOOTH);//开启点平滑
            gl.Enable(OpenGL.GL_NICEST);//设置质量优先

            gl.Scale(scaleValue, scaleValue * HEIGHT_RATIO, scaleValue);
            RenderHeightMap(ref heightMap);
        }

        //get height
        private static int GetHeight(Image<Gray, Byte> heightMap, int x, int y)
        {          // This Returns The Height From A Height Map Index
            x = x % heightMap.Rows;                                                   // Error Check Our x Value
            y = y % heightMap.Cols;                                                   // Error Check Our y Value

            return heightMap.Data[x, y, 0];                             // Index Into Our Height Array And Return The Height
        }

        //该函数用来进行初始化，设置opengl的各个参数
        private void OpenGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {

            OpenGL gl = openGLControl1.OpenGL;

            //启用阴影平滑(Smooth Shading)。

            gl.ShadeModel(OpenGL.GL_SMOOTH);

            gl.ClearColor(0.0f, 0.0f, 0.0f, 0.5f);

            //设置深度缓冲

            gl.ClearDepth(9.0f);

            //启动深度测试

            gl.Enable(OpenGL.GL_DEPTH_TEST);



            //深度测试的类型

            gl.DepthFunc(OpenGL.GLU_DISPLAY_MODE);

            //进行透视修正

            gl.Hint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GLU_DISPLAY_MODE);

            //LoadRawFile("light.bmp");//灰度文件在Debug/Data文件夹下
            //CvInvoke.ApplyColorMap(heightMap, colormat, Emgu.CV.CvEnum.ColorMapType.Jet);
        }



        private void RenderHeightMap(ref Image<Gray, Byte> heightMap)
        {                                                                            // This Renders The Height Map As Quads
            int X, Y;                                                           // Create Some Variables To Walk The Array With.
            int x, y, z;                                                        // Create Some Variables For Readability
            OpenGL gl = openGLControl1.OpenGL;

            if (heightMap == null)
            {                                             // Make Sure Our Height Data Is Valid
                MessageBox.Show("Wrong Data!");
            }

            gl.Translate(view_x, 0, 0);
            gl.Rotate(0, view_y, 0);
            gl.Translate(0, 0, view_z);

            if (bRender)
            {                                                       // What We Want To Render
                gl.Begin(OpenGL.GL_QUADS);                                        // Render Polygons
            }
            else
            {
                gl.Begin(OpenGL.GL_LINES);                                        // Render Lines Instead
            }

            for (X = 0; X < (heightMap.Rows - STEP_SIZE); X += STEP_SIZE)
            {
                for (Y = 0; Y < (heightMap.Cols - STEP_SIZE); Y += STEP_SIZE)
                {
                    // Get The (X, Y, Z) Value For The Bottom Left Vertex
                    x = X - (heightMap.Rows - STEP_SIZE) / 2;
                    y = GetHeight(heightMap, X, Y);
                    z = Y - (heightMap.Cols - STEP_SIZE) / 2;

                    SetVertexColor(ref colormat, X, Y);                            // Set The Color Value Of The Current Vertex
                    gl.Vertex(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered (Integer Points Are Faster)

                    // Get The (X, Y, Z) Value For The Top Left Vertex
                    x = X - (heightMap.Rows - STEP_SIZE) / 2;
                    y = GetHeight(heightMap, X, Y + STEP_SIZE);
                    z = Y + STEP_SIZE - (heightMap.Cols - STEP_SIZE) / 2;

                    SetVertexColor(ref colormat, X, Y);                            // Set The Color Value Of The Current Vertex
                    gl.Vertex(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered

                    // Get The (X, Y, Z) Value For The Top Right Vertex
                    x = X + STEP_SIZE - (heightMap.Rows - STEP_SIZE) / 2;
                    y = GetHeight(heightMap, X + STEP_SIZE, Y + STEP_SIZE);
                    z = Y + STEP_SIZE - (heightMap.Cols - STEP_SIZE) / 2;

                    SetVertexColor(ref colormat, X, Y);                            // Set The Color Value Of The Current Vertex
                    gl.Vertex(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered

                    // Get The (X, Y, Z) Value For The Bottom Right Vertex
                    x = X + STEP_SIZE - (heightMap.Rows - STEP_SIZE) / 2;
                    y = GetHeight(heightMap, X + STEP_SIZE, Y);
                    z = Y - (heightMap.Cols - STEP_SIZE) / 2;

                    SetVertexColor(ref colormat, X, Y);                            // Set The Color Value Of The Current Vertex
                    gl.Vertex(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered
                }
            }

            gl.End();
            gl.Color(1, 1, 1, 1);                                           // Reset The Colo

        }


        private void SetVertexColor(ref Image<Rgb, Byte> colormat, int x, int y)
        {

            OpenGL gl = openGLControl1.OpenGL;

            gl.Color(colormat.Data[x, y, 0], colormat.Data[x, y, 1], colormat.Data[x, y, 2]);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //方法二：if
            if (keyData == Keys.E)
            //判断E键是否按下
            {
                Key = true;
                return true;
            }
            else if (keyData == Keys.F)
            //判断F键是否按下
            { }
            else if (keyData == Keys.Up)   //向下
            {
                view_x += 5f;
            }
            else if (keyData == Keys.Down) //向上
            {
                view_x -= 5f;
            }
            else if (keyData == Keys.Right) //向右
            {
                view_y += 0.5f;
            }
            else if (keyData == Keys.Left) //向左
            {
                view_y -= 0.5f;
            }
            else if (keyData == Keys.A) //近
            {
                view_z += 5f;
            }
            else if (keyData == Keys.D)//远
            {
                view_z -= 5f;
            }
            return base.ProcessCmdKey(ref msg, keyData);//返回所有键值
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void createPaneY(ZedGraphControl zed)
        {
            //var img = _control.imageX;
            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = "Y方向能量分布图";
            myPane.XAxis.Title.Text = "Y";
            myPane.YAxis.Title.Text = "E";

            PointPairList list1 = new PointPairList();

            for(int i=0;i<heightMap.Height;i++)
            {
                float x = i;
                float y1 = heightMap.Data[i, (int)img.ShapeCenterX + heightMap.Width/2, 0];
                list1.Add(x, y1);
            }


            LineItem myCurve = myPane.AddCurve("Enegy", list1, Color.Red, SymbolType.None);

            myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);

            String[] labels = new String[heightMap.Height];

            for(int i=0;i<heightMap.Height;i++)
            {
                labels[i] = (i - heightMap.Height/2).ToString();
            }

            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Type = AxisType.Text;

            zed.AxisChange();

            Refresh();

            zed.GraphPane.CurveList.Clear();
            //zed.GraphPane.GraphItemList.Clear();

        }

        private void createPaneX(ZedGraphControl zed)
        {
            //var img = _control.imageX;
            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = "X方向能量分布图";
            myPane.XAxis.Title.Text = "X";
            myPane.YAxis.Title.Text = "E";

            PointPairList list1 = new PointPairList();

            for (int i = 0; i < heightMap.Width; i++)
            {
                float x = i;
                float y1 = heightMap.Data[(int)img.ShapeCenterY + heightMap.Height / 2, i, 0];
                list1.Add(x, y1);
            }


            LineItem myCurve = myPane.AddCurve("Enegy", list1, Color.Red, SymbolType.None);

            myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);

            String[] labels = new String[heightMap.Width];

            for (int i = 0; i < heightMap.Width; i++)
            {
                labels[i] = (i - heightMap.Width / 2).ToString();
            }

            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Type = AxisType.Text;

            zed.AxisChange();

            zed.Refresh();

            zed.GraphPane.CurveList.Clear();
            //zed.GraphPane.GraphItemList.Clear();

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        
    }

}
