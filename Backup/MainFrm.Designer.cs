namespace Fast_Fourier_Transform
{
    partial class MainFrm
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
            this.components = new System.ComponentModel.Container();
            this.CNMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectFullImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ImageInput = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scalepercentage = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ImSelected = new System.Windows.Forms.PictureBox();
            this.FourierMag = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FourierPhase = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.InvFourier = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CNMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageInput)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierMag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierPhase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvFourier)).BeginInit();
            this.SuspendLayout();
            // 
            // CNMenuStrip
            // 
            this.CNMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFullImageToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.CNMenuStrip.Name = "CNMenuStrip";
            this.CNMenuStrip.Size = new System.Drawing.Size(148, 70);
            // 
            // selectFullImageToolStripMenuItem
            // 
            this.selectFullImageToolStripMenuItem.Name = "selectFullImageToolStripMenuItem";
            this.selectFullImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.selectFullImageToolStripMenuItem.Text = "Select Image";
            this.selectFullImageToolStripMenuItem.Click += new System.EventHandler(this.selectFullImageToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.openFileToolStripMenuItem.Text = "Preview";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1015, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Open";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // ImageInput
            // 
            this.ImageInput.ContextMenuStrip = this.CNMenuStrip;
            this.ImageInput.Location = new System.Drawing.Point(12, 28);
            this.ImageInput.Name = "ImageInput";
            this.ImageInput.Size = new System.Drawing.Size(400, 600);
            this.ImageInput.TabIndex = 13;
            this.ImageInput.TabStop = false;
            this.ImageInput.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageInput_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 643);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Scaling Percentage";
            // 
            // scalepercentage
            // 
            this.scalepercentage.Location = new System.Drawing.Point(136, 640);
            this.scalepercentage.Name = "scalepercentage";
            this.scalepercentage.Size = new System.Drawing.Size(26, 20);
            this.scalepercentage.TabIndex = 14;
            this.scalepercentage.Text = "25";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1015, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel1.Text = "Image Dimensions : ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel2.Text = "Width X Height";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel3.Text = "After Scaling : ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel4.Text = "Width X Height";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel5.Text = "Selected Part Dimensions";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel6.Text = "Width X Height";
            // 
            // ImSelected
            // 
            this.ImSelected.ContextMenuStrip = this.CNMenuStrip;
            this.ImSelected.Location = new System.Drawing.Point(475, 44);
            this.ImSelected.Name = "ImSelected";
            this.ImSelected.Size = new System.Drawing.Size(256, 256);
            this.ImSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImSelected.TabIndex = 17;
            this.ImSelected.TabStop = false;
            // 
            // FourierMag
            // 
            this.FourierMag.ContextMenuStrip = this.CNMenuStrip;
            this.FourierMag.Location = new System.Drawing.Point(475, 327);
            this.FourierMag.Name = "FourierMag";
            this.FourierMag.Size = new System.Drawing.Size(256, 256);
            this.FourierMag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FourierMag.TabIndex = 18;
            this.FourierMag.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Selected Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fourier Magnitude Plot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(734, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fourier Phase Plot";
            // 
            // FourierPhase
            // 
            this.FourierPhase.ContextMenuStrip = this.CNMenuStrip;
            this.FourierPhase.Location = new System.Drawing.Point(737, 44);
            this.FourierPhase.Name = "FourierPhase";
            this.FourierPhase.Size = new System.Drawing.Size(256, 256);
            this.FourierPhase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FourierPhase.TabIndex = 21;
            this.FourierPhase.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(734, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Inverse Fourier  Plot";
            // 
            // InvFourier
            // 
            this.InvFourier.ContextMenuStrip = this.CNMenuStrip;
            this.InvFourier.Location = new System.Drawing.Point(737, 327);
            this.InvFourier.Name = "InvFourier";
            this.InvFourier.Size = new System.Drawing.Size(256, 256);
            this.InvFourier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InvFourier.TabIndex = 23;
            this.InvFourier.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 594);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 34);
            this.button1.TabIndex = 25;
            this.button1.Text = "Forward FFT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(819, 589);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 34);
            this.button2.TabIndex = 26;
            this.button2.Text = "Inverse FFT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 698);
            this.Controls.Add(this.InvFourier);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FourierPhase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FourierMag);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ImageInput);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ImSelected);
            this.Controls.Add(this.scalepercentage);
            this.Controls.Add(this.label1);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast Fourier Transform";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.CNMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageInput)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierMag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierPhase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvFourier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CNMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFullImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.PictureBox ImageInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scalepercentage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox ImSelected;
        private System.Windows.Forms.PictureBox FourierMag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox FourierPhase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox InvFourier;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

