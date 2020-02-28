namespace WindowsFormsCalculator
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
            if (disposing && (components != null))
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
            this.textBox_Num1 = new System.Windows.Forms.TextBox();
            this.textBox_Num2 = new System.Windows.Forms.TextBox();
            this.comboBox_Operator = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.Btn_Calculate = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Num1
            // 
            this.textBox_Num1.Location = new System.Drawing.Point(12, 124);
            this.textBox_Num1.Name = "textBox_Num1";
            this.textBox_Num1.Size = new System.Drawing.Size(100, 25);
            this.textBox_Num1.TabIndex = 0;
            // 
            // textBox_Num2
            // 
            this.textBox_Num2.Location = new System.Drawing.Point(306, 124);
            this.textBox_Num2.Name = "textBox_Num2";
            this.textBox_Num2.Size = new System.Drawing.Size(100, 25);
            this.textBox_Num2.TabIndex = 1;
            // 
            // comboBox_Operator
            // 
            this.comboBox_Operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operator.FormattingEnabled = true;
            this.comboBox_Operator.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.comboBox_Operator.Location = new System.Drawing.Point(150, 124);
            this.comboBox_Operator.Name = "comboBox_Operator";
            this.comboBox_Operator.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Operator.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "=";
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(459, 124);
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ReadOnly = true;
            this.textBox_Result.Size = new System.Drawing.Size(100, 25);
            this.textBox_Result.TabIndex = 4;
            // 
            // Btn_Calculate
            // 
            this.Btn_Calculate.Location = new System.Drawing.Point(171, 234);
            this.Btn_Calculate.Name = "Btn_Calculate";
            this.Btn_Calculate.Size = new System.Drawing.Size(100, 29);
            this.Btn_Calculate.TabIndex = 5;
            this.Btn_Calculate.Text = "计算";
            this.Btn_Calculate.UseVisualStyleBackColor = true;
            this.Btn_Calculate.Click += new System.EventHandler(this.Btn_Calculate_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(352, 234);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(100, 29);
            this.Btn_Clear.TabIndex = 6;
            this.Btn_Clear.Text = "清除";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 337);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_Calculate);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Operator);
            this.Controls.Add(this.textBox_Num2);
            this.Controls.Add(this.textBox_Num1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Num1;
        private System.Windows.Forms.TextBox textBox_Num2;
        private System.Windows.Forms.ComboBox comboBox_Operator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Button Btn_Calculate;
        private System.Windows.Forms.Button Btn_Clear;
    }
}

