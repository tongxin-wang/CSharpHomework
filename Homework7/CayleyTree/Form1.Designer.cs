namespace CayleyTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.trbDepth = new System.Windows.Forms.TrackBar();
            this.trbLeng = new System.Windows.Forms.TrackBar();
            this.trbPer1 = new System.Windows.Forms.TrackBar();
            this.trbPer2 = new System.Windows.Forms.TrackBar();
            this.trbTh1 = new System.Windows.Forms.TrackBar();
            this.trbTh2 = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlValue = new System.Windows.Forms.Panel();
            this.lblPenColor = new System.Windows.Forms.Label();
            this.lblTh2Text = new System.Windows.Forms.Label();
            this.lblTh1Text = new System.Windows.Forms.Label();
            this.lblPer2Text = new System.Windows.Forms.Label();
            this.lblPer1Text = new System.Windows.Forms.Label();
            this.lblLengText = new System.Windows.Forms.Label();
            this.lblDepthText = new System.Windows.Forms.Label();
            this.lblTh2 = new System.Windows.Forms.Label();
            this.lblTh1 = new System.Windows.Forms.Label();
            this.lblPer2 = new System.Windows.Forms.Label();
            this.lblPer1 = new System.Windows.Forms.Label();
            this.lblLeng = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.pnlTree = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trbDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLeng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh2)).BeginInit();
            this.pnlValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Location = new System.Drawing.Point(119, 433);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(115, 30);
            this.btnChooseColor.TabIndex = 0;
            this.btnChooseColor.Text = "选择画笔颜色";
            this.btnChooseColor.UseVisualStyleBackColor = true;
            this.btnChooseColor.Click += new System.EventHandler(this.btnChooseColor_Click);
            // 
            // trbDepth
            // 
            this.trbDepth.Location = new System.Drawing.Point(96, 22);
            this.trbDepth.Maximum = 20;
            this.trbDepth.Minimum = 1;
            this.trbDepth.Name = "trbDepth";
            this.trbDepth.Size = new System.Drawing.Size(199, 56);
            this.trbDepth.TabIndex = 1;
            this.trbDepth.Value = 10;
            this.trbDepth.ValueChanged += new System.EventHandler(this.trbDepth_ValueChanged);
            this.trbDepth.MouseCaptureChanged += new System.EventHandler(this.trbDepth_MouseCaptureChanged);
            // 
            // trbLeng
            // 
            this.trbLeng.Location = new System.Drawing.Point(96, 84);
            this.trbLeng.Maximum = 200;
            this.trbLeng.Minimum = 20;
            this.trbLeng.Name = "trbLeng";
            this.trbLeng.Size = new System.Drawing.Size(199, 56);
            this.trbLeng.SmallChange = 10;
            this.trbLeng.TabIndex = 2;
            this.trbLeng.Value = 100;
            this.trbLeng.ValueChanged += new System.EventHandler(this.trbLeng_ValueChanged);
            // 
            // trbPer1
            // 
            this.trbPer1.Location = new System.Drawing.Point(96, 156);
            this.trbPer1.Minimum = 1;
            this.trbPer1.Name = "trbPer1";
            this.trbPer1.Size = new System.Drawing.Size(199, 56);
            this.trbPer1.TabIndex = 3;
            this.trbPer1.Value = 6;
            this.trbPer1.ValueChanged += new System.EventHandler(this.trbPer1_ValueChanged);
            // 
            // trbPer2
            // 
            this.trbPer2.Location = new System.Drawing.Point(96, 229);
            this.trbPer2.Minimum = 1;
            this.trbPer2.Name = "trbPer2";
            this.trbPer2.Size = new System.Drawing.Size(199, 56);
            this.trbPer2.TabIndex = 4;
            this.trbPer2.Value = 7;
            this.trbPer2.ValueChanged += new System.EventHandler(this.trbPer2_ValueChanged);
            // 
            // trbTh1
            // 
            this.trbTh1.Location = new System.Drawing.Point(96, 303);
            this.trbTh1.Maximum = 90;
            this.trbTh1.Minimum = 1;
            this.trbTh1.Name = "trbTh1";
            this.trbTh1.Size = new System.Drawing.Size(199, 56);
            this.trbTh1.TabIndex = 5;
            this.trbTh1.Value = 30;
            this.trbTh1.ValueChanged += new System.EventHandler(this.trbTh1_ValueChanged);
            // 
            // trbTh2
            // 
            this.trbTh2.Location = new System.Drawing.Point(96, 371);
            this.trbTh2.Maximum = 90;
            this.trbTh2.Minimum = 1;
            this.trbTh2.Name = "trbTh2";
            this.trbTh2.Size = new System.Drawing.Size(199, 56);
            this.trbTh2.TabIndex = 6;
            this.trbTh2.Value = 20;
            this.trbTh2.ValueChanged += new System.EventHandler(this.trbTh2_ValueChanged);
            // 
            // pnlValue
            // 
            this.pnlValue.Controls.Add(this.lblPenColor);
            this.pnlValue.Controls.Add(this.lblTh2Text);
            this.pnlValue.Controls.Add(this.lblTh1Text);
            this.pnlValue.Controls.Add(this.lblPer2Text);
            this.pnlValue.Controls.Add(this.lblPer1Text);
            this.pnlValue.Controls.Add(this.lblLengText);
            this.pnlValue.Controls.Add(this.lblDepthText);
            this.pnlValue.Controls.Add(this.lblTh2);
            this.pnlValue.Controls.Add(this.lblTh1);
            this.pnlValue.Controls.Add(this.lblPer2);
            this.pnlValue.Controls.Add(this.lblPer1);
            this.pnlValue.Controls.Add(this.lblLeng);
            this.pnlValue.Controls.Add(this.lblDepth);
            this.pnlValue.Controls.Add(this.trbTh2);
            this.pnlValue.Controls.Add(this.trbTh1);
            this.pnlValue.Controls.Add(this.trbPer2);
            this.pnlValue.Controls.Add(this.trbPer1);
            this.pnlValue.Controls.Add(this.trbLeng);
            this.pnlValue.Controls.Add(this.trbDepth);
            this.pnlValue.Controls.Add(this.btnChooseColor);
            this.pnlValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlValue.Location = new System.Drawing.Point(610, 0);
            this.pnlValue.Name = "pnlValue";
            this.pnlValue.Size = new System.Drawing.Size(364, 502);
            this.pnlValue.TabIndex = 7;
            // 
            // lblPenColor
            // 
            this.lblPenColor.AutoSize = true;
            this.lblPenColor.Location = new System.Drawing.Point(126, 478);
            this.lblPenColor.Name = "lblPenColor";
            this.lblPenColor.Size = new System.Drawing.Size(97, 15);
            this.lblPenColor.TabIndex = 19;
            this.lblPenColor.Text = "当前画笔颜色";
            // 
            // lblTh2Text
            // 
            this.lblTh2Text.AutoSize = true;
            this.lblTh2Text.Location = new System.Drawing.Point(6, 380);
            this.lblTh2Text.Name = "lblTh2Text";
            this.lblTh2Text.Size = new System.Drawing.Size(82, 15);
            this.lblTh2Text.TabIndex = 18;
            this.lblTh2Text.Text = "左分支角度";
            // 
            // lblTh1Text
            // 
            this.lblTh1Text.AutoSize = true;
            this.lblTh1Text.Location = new System.Drawing.Point(6, 317);
            this.lblTh1Text.Name = "lblTh1Text";
            this.lblTh1Text.Size = new System.Drawing.Size(82, 15);
            this.lblTh1Text.TabIndex = 17;
            this.lblTh1Text.Text = "右分支角度";
            // 
            // lblPer2Text
            // 
            this.lblPer2Text.AutoSize = true;
            this.lblPer2Text.Location = new System.Drawing.Point(3, 238);
            this.lblPer2Text.Name = "lblPer2Text";
            this.lblPer2Text.Size = new System.Drawing.Size(97, 15);
            this.lblPer2Text.TabIndex = 16;
            this.lblPer2Text.Text = "左分支长度比";
            // 
            // lblPer1Text
            // 
            this.lblPer1Text.AutoSize = true;
            this.lblPer1Text.Location = new System.Drawing.Point(3, 167);
            this.lblPer1Text.Name = "lblPer1Text";
            this.lblPer1Text.Size = new System.Drawing.Size(97, 15);
            this.lblPer1Text.TabIndex = 15;
            this.lblPer1Text.Text = "右分支长度比";
            // 
            // lblLengText
            // 
            this.lblLengText.AutoSize = true;
            this.lblLengText.Location = new System.Drawing.Point(15, 93);
            this.lblLengText.Name = "lblLengText";
            this.lblLengText.Size = new System.Drawing.Size(67, 15);
            this.lblLengText.TabIndex = 14;
            this.lblLengText.Text = "主干长度";
            // 
            // lblDepthText
            // 
            this.lblDepthText.AutoSize = true;
            this.lblDepthText.Location = new System.Drawing.Point(15, 31);
            this.lblDepthText.Name = "lblDepthText";
            this.lblDepthText.Size = new System.Drawing.Size(67, 15);
            this.lblDepthText.TabIndex = 13;
            this.lblDepthText.Text = "递归深度";
            // 
            // lblTh2
            // 
            this.lblTh2.AutoSize = true;
            this.lblTh2.Location = new System.Drawing.Point(301, 380);
            this.lblTh2.Name = "lblTh2";
            this.lblTh2.Size = new System.Drawing.Size(23, 15);
            this.lblTh2.TabIndex = 12;
            this.lblTh2.Text = "20";
            // 
            // lblTh1
            // 
            this.lblTh1.AutoSize = true;
            this.lblTh1.Location = new System.Drawing.Point(301, 317);
            this.lblTh1.Name = "lblTh1";
            this.lblTh1.Size = new System.Drawing.Size(23, 15);
            this.lblTh1.TabIndex = 11;
            this.lblTh1.Text = "30";
            // 
            // lblPer2
            // 
            this.lblPer2.AutoSize = true;
            this.lblPer2.Location = new System.Drawing.Point(301, 238);
            this.lblPer2.Name = "lblPer2";
            this.lblPer2.Size = new System.Drawing.Size(31, 15);
            this.lblPer2.TabIndex = 10;
            this.lblPer2.Text = "0.7";
            // 
            // lblPer1
            // 
            this.lblPer1.AutoSize = true;
            this.lblPer1.Location = new System.Drawing.Point(301, 167);
            this.lblPer1.Name = "lblPer1";
            this.lblPer1.Size = new System.Drawing.Size(31, 15);
            this.lblPer1.TabIndex = 9;
            this.lblPer1.Text = "0.6";
            // 
            // lblLeng
            // 
            this.lblLeng.AutoSize = true;
            this.lblLeng.Location = new System.Drawing.Point(301, 93);
            this.lblLeng.Name = "lblLeng";
            this.lblLeng.Size = new System.Drawing.Size(31, 15);
            this.lblLeng.TabIndex = 8;
            this.lblLeng.Text = "100";
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.BackColor = System.Drawing.SystemColors.Control;
            this.lblDepth.Location = new System.Drawing.Point(301, 31);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(23, 15);
            this.lblDepth.TabIndex = 7;
            this.lblDepth.Text = "10";
            // 
            // pnlTree
            // 
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTree.Location = new System.Drawing.Point(0, 0);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(610, 502);
            this.pnlTree.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 502);
            this.Controls.Add(this.pnlTree);
            this.Controls.Add(this.pnlValue);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.trbDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLeng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh2)).EndInit();
            this.pnlValue.ResumeLayout(false);
            this.pnlValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChooseColor;
        private System.Windows.Forms.TrackBar trbDepth;
        private System.Windows.Forms.TrackBar trbLeng;
        private System.Windows.Forms.TrackBar trbPer1;
        private System.Windows.Forms.TrackBar trbPer2;
        private System.Windows.Forms.TrackBar trbTh1;
        private System.Windows.Forms.TrackBar trbTh2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel pnlValue;
        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.Label lblTh2;
        private System.Windows.Forms.Label lblTh1;
        private System.Windows.Forms.Label lblPer2;
        private System.Windows.Forms.Label lblPer1;
        private System.Windows.Forms.Label lblLeng;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.Label lblTh2Text;
        private System.Windows.Forms.Label lblTh1Text;
        private System.Windows.Forms.Label lblPer2Text;
        private System.Windows.Forms.Label lblPer1Text;
        private System.Windows.Forms.Label lblLengText;
        private System.Windows.Forms.Label lblDepthText;
        private System.Windows.Forms.Label lblPenColor;
    }
}

