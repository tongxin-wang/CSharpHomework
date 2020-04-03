using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    //递归次数增多绘制图形可能会出现卡顿
    public partial class Form1 : Form
    {
        private Pen pen = Pens.Blue;
        private Graphics graphics;
        double per1 = 0.6;
        double per2 = 0.7;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;

        public Form1()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            DrawCayleyTree(this.trbDepth.Value, this.pnlTree.Size.Width / 2,
                this.pnlTree.Size.Height - 20, this.trbLeng.Value, -Math.PI / 2);
        }

        void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if(n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            DrawLine(x0, y0, x1, y1);
            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void DrawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void trbDepth_ValueChanged(object sender, EventArgs e)
        {
            this.lblDepth.Text = this.trbDepth.Value.ToString();
        }

        //递归次数增多会卡顿，不在移动过程中画图
        private void trbDepth_MouseCaptureChanged(object sender, EventArgs e)
        {
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }

        private void trbLeng_ValueChanged(object sender, EventArgs e)
        {
            this.lblLeng.Text = this.trbLeng.Value.ToString();
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }

        private void trbPer1_ValueChanged(object sender, EventArgs e)
        {
            per1 = Convert.ToDouble(this.trbPer1.Value) / 10;     //更新per1
            this.lblPer1.Text = per1.ToString();
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }

        private void trbPer2_ValueChanged(object sender, EventArgs e)
        {
            per2 = Convert.ToDouble(this.trbPer2.Value) / 10;     //更新per2
            this.lblPer2.Text = per2.ToString();
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }

        private void trbTh1_ValueChanged(object sender, EventArgs e)
        {
            th1 = Convert.ToDouble(this.trbTh1.Value) * Math.PI / 180;      //更新th1
            this.lblTh1.Text = this.trbTh1.Value.ToString();
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }

        private void trbTh2_ValueChanged(object sender, EventArgs e)
        {
            th2 = Convert.ToDouble(this.trbTh2.Value) * Math.PI / 180;      //更新th2
            this.lblTh2.Text = this.trbTh2.Value.ToString();
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            pen = new Pen(this.colorDialog1.Color);        //更新画笔
            this.lblPenColor.ForeColor = pen.Color;
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lblPenColor.ForeColor = pen.Color;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //窗体第一次显示时绘制图形
            if(graphics == null) graphics = this.pnlTree.CreateGraphics();
            graphics.Clear(BackColor);
            Draw();
        }
    }
}
