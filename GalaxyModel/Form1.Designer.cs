namespace GalaxyModel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.numResolution = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.txtWs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPitchDegrees = new System.Windows.Forms.NumericUpDown();
            this.tbSpiralRadius = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numArms = new System.Windows.Forms.NumericUpDown();
            this.tbBulgeRadius = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSpiralBrightness = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBulgeBrightness = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.numResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPitchDegrees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpiralRadius)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBulgeRadius)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpiralBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBulgeBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numResolution
            // 
            resources.ApplyResources(this.numResolution, "numResolution");
            this.numResolution.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numResolution.Name = "numResolution";
            this.numResolution.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.anyvalue_changed);
            // 
            // txtWs
            // 
            resources.ApplyResources(this.txtWs, "txtWs");
            this.txtWs.Name = "txtWs";
            this.txtWs.TextChanged += new System.EventHandler(this.anyvalue_changed);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numPitchDegrees
            // 
            resources.ApplyResources(this.numPitchDegrees, "numPitchDegrees");
            this.numPitchDegrees.Maximum = new decimal(new int[] {
            89,
            0,
            0,
            0});
            this.numPitchDegrees.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPitchDegrees.Name = "numPitchDegrees";
            this.numPitchDegrees.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPitchDegrees.ValueChanged += new System.EventHandler(this.anyvalue_changed);
            // 
            // tbSpiralRadius
            // 
            this.tbSpiralRadius.LargeChange = 100;
            resources.ApplyResources(this.tbSpiralRadius, "tbSpiralRadius");
            this.tbSpiralRadius.Maximum = 1000;
            this.tbSpiralRadius.Name = "tbSpiralRadius";
            this.tbSpiralRadius.SmallChange = 10;
            this.tbSpiralRadius.TickFrequency = 100;
            this.tbSpiralRadius.Value = 500;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSpiralBrightness);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numArms);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtWs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numPitchDegrees);
            this.groupBox1.Controls.Add(this.tbSpiralRadius);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // numArms
            // 
            resources.ApplyResources(this.numArms, "numArms");
            this.numArms.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numArms.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numArms.Name = "numArms";
            this.numArms.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numArms.ValueChanged += new System.EventHandler(this.anyvalue_changed);
            // 
            // tbBulgeRadius
            // 
            this.tbBulgeRadius.LargeChange = 100;
            resources.ApplyResources(this.tbBulgeRadius, "tbBulgeRadius");
            this.tbBulgeRadius.Maximum = 1000;
            this.tbBulgeRadius.Name = "tbBulgeRadius";
            this.tbBulgeRadius.SmallChange = 10;
            this.tbBulgeRadius.TickFrequency = 100;
            this.tbBulgeRadius.Value = 100;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbBulgeBrightness);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbBulgeRadius);
            this.groupBox2.Controls.Add(this.label9);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tbSpiralBrightness
            // 
            resources.ApplyResources(this.tbSpiralBrightness, "tbSpiralBrightness");
            this.tbSpiralBrightness.LargeChange = 100;
            this.tbSpiralBrightness.Maximum = 2000;
            this.tbSpiralBrightness.Name = "tbSpiralBrightness";
            this.tbSpiralBrightness.SmallChange = 10;
            this.tbSpiralBrightness.TickFrequency = 200;
            this.tbSpiralBrightness.Value = 500;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tbBulgeBrightness
            // 
            resources.ApplyResources(this.tbBulgeBrightness, "tbBulgeBrightness");
            this.tbBulgeBrightness.LargeChange = 100;
            this.tbBulgeBrightness.Maximum = 2000;
            this.tbBulgeBrightness.Name = "tbBulgeBrightness";
            this.tbBulgeBrightness.SmallChange = 10;
            this.tbBulgeBrightness.TickFrequency = 200;
            this.tbBulgeBrightness.Value = 500;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numResolution);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPitchDegrees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpiralRadius)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBulgeRadius)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpiralBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBulgeBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numResolution;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtWs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPitchDegrees;
        private System.Windows.Forms.TrackBar tbSpiralRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbBulgeRadius;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numArms;
        private System.Windows.Forms.TrackBar tbSpiralBrightness;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar tbBulgeBrightness;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}

