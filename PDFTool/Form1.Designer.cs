namespace PDFTool
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
            this.panel1AppMode = new System.Windows.Forms.Panel();
            this.button3Delete = new System.Windows.Forms.Button();
            this.button2Split = new System.Windows.Forms.Button();
            this.button1Merge = new System.Windows.Forms.Button();
            this.panel2ActionDetail = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3FileHolder = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1AppMode.SuspendLayout();
            this.panel2ActionDetail.SuspendLayout();
            this.panel3FileHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1AppMode
            // 
            this.panel1AppMode.Controls.Add(this.button3Delete);
            this.panel1AppMode.Controls.Add(this.button2Split);
            this.panel1AppMode.Controls.Add(this.button1Merge);
            this.panel1AppMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1AppMode.Location = new System.Drawing.Point(0, 0);
            this.panel1AppMode.Name = "panel1AppMode";
            this.panel1AppMode.Size = new System.Drawing.Size(150, 600);
            this.panel1AppMode.TabIndex = 0;
            // 
            // button3Delete
            // 
            this.button3Delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3Delete.Location = new System.Drawing.Point(0, 300);
            this.button3Delete.Name = "button3Delete";
            this.button3Delete.Size = new System.Drawing.Size(150, 150);
            this.button3Delete.TabIndex = 2;
            this.button3Delete.Text = "Delete";
            this.button3Delete.UseVisualStyleBackColor = false;
            this.button3Delete.Click += new System.EventHandler(this.button3Delete_Click);
            // 
            // button2Split
            // 
            this.button2Split.BackColor = System.Drawing.SystemColors.GrayText;
            this.button2Split.Location = new System.Drawing.Point(0, 150);
            this.button2Split.Name = "button2Split";
            this.button2Split.Size = new System.Drawing.Size(150, 150);
            this.button2Split.TabIndex = 1;
            this.button2Split.Text = "Split";
            this.button2Split.UseVisualStyleBackColor = false;
            this.button2Split.Click += new System.EventHandler(this.button2Split_Click);
            // 
            // button1Merge
            // 
            this.button1Merge.AllowDrop = true;
            this.button1Merge.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1Merge.Location = new System.Drawing.Point(0, 0);
            this.button1Merge.Name = "button1Merge";
            this.button1Merge.Size = new System.Drawing.Size(150, 150);
            this.button1Merge.TabIndex = 0;
            this.button1Merge.Text = "Merge";
            this.button1Merge.UseVisualStyleBackColor = false;
            this.button1Merge.UseWaitCursor = true;
            this.button1Merge.Click += new System.EventHandler(this.button1Merge_Click);
            // 
            // panel2ActionDetail
            // 
            this.panel2ActionDetail.Controls.Add(this.textBox4);
            this.panel2ActionDetail.Controls.Add(this.textBox3);
            this.panel2ActionDetail.Controls.Add(this.pictureBox2);
            this.panel2ActionDetail.Controls.Add(this.pictureBox1);
            this.panel2ActionDetail.Controls.Add(this.button5);
            this.panel2ActionDetail.Controls.Add(this.textBox1);
            this.panel2ActionDetail.Controls.Add(this.tableLayoutPanel2);
            this.panel2ActionDetail.Controls.Add(this.button2);
            this.panel2ActionDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2ActionDetail.Location = new System.Drawing.Point(700, 0);
            this.panel2ActionDetail.Name = "panel2ActionDetail";
            this.panel2ActionDetail.Size = new System.Drawing.Size(300, 600);
            this.panel2ActionDetail.TabIndex = 0;
            this.panel2ActionDetail.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2ActionDetail_Paint);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(30, 544);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(250, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Merge Documents";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 506);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 20);
            this.textBox1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(30, 50);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(250, 450);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Add PDF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3FileHolder
            // 
            this.panel3FileHolder.Controls.Add(this.tableLayoutPanel1);
            this.panel3FileHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3FileHolder.Location = new System.Drawing.Point(150, 0);
            this.panel3FileHolder.Name = "panel3FileHolder";
            this.panel3FileHolder.Size = new System.Drawing.Size(550, 600);
            this.panel3FileHolder.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 560);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(75, 75);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(30, 300);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 40);
            this.textBox3.TabIndex = 8;
            this.textBox3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(180, 300);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 40);
            this.textBox4.TabIndex = 9;
            this.textBox4.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panel3FileHolder);
            this.Controls.Add(this.panel2ActionDetail);
            this.Controls.Add(this.panel1AppMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1AppMode.ResumeLayout(false);
            this.panel2ActionDetail.ResumeLayout(false);
            this.panel2ActionDetail.PerformLayout();
            this.panel3FileHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1AppMode;
        private System.Windows.Forms.Button button3Delete;
        private System.Windows.Forms.Button button2Split;
        private System.Windows.Forms.Button button1Merge;
        private System.Windows.Forms.Panel panel2ActionDetail;
        private System.Windows.Forms.Panel panel3FileHolder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
    }
}

