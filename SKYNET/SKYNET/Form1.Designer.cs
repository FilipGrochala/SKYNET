namespace SKYNET
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_load = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_iterrations = new System.Windows.Forms.TextBox();
            this.button_commit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_save = new System.Windows.Forms.Button();
            this.button_trening = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_exam = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 434);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_load);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox_iterrations);
            this.tabPage1.Controls.Add(this.button_commit);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nauczyciel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(9, 140);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(110, 32);
            this.button_load.TabIndex = 8;
            this.button_load.Text = "Wczytaj";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ilość iteracji:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_iterrations
            // 
            this.textBox_iterrations.Location = new System.Drawing.Point(9, 34);
            this.textBox_iterrations.Name = "textBox_iterrations";
            this.textBox_iterrations.Size = new System.Drawing.Size(108, 22);
            this.textBox_iterrations.TabIndex = 5;
            // 
            // button_commit
            // 
            this.button_commit.Location = new System.Drawing.Point(9, 62);
            this.button_commit.Name = "button_commit";
            this.button_commit.Size = new System.Drawing.Size(110, 30);
            this.button_commit.TabIndex = 4;
            this.button_commit.Text = "Zatwierdż";
            this.button_commit.UseVisualStyleBackColor = true;
            this.button_commit.Click += new System.EventHandler(this.button_commit_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_save);
            this.tabPage2.Controls.Add(this.button_trening);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trenowanie";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(653, 40);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(108, 27);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Zapisz";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_trening
            // 
            this.button_trening.Location = new System.Drawing.Point(651, 4);
            this.button_trening.Name = "button_trening";
            this.button_trening.Size = new System.Drawing.Size(110, 30);
            this.button_trening.TabIndex = 1;
            this.button_trening.Text = "Trenuj!";
            this.button_trening.UseVisualStyleBackColor = true;
            this.button_trening.Click += new System.EventHandler(this.button_trening_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(7, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(640, 214);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Controls.Add(this.button_exam);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(767, 405);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Egzamin";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Wczytaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(7, 139);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(754, 260);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr. neuronu:";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Odpowiedź:";
            // 
            // button_exam
            // 
            this.button_exam.BackColor = System.Drawing.Color.Chartreuse;
            this.button_exam.Location = new System.Drawing.Point(420, 100);
            this.button_exam.Name = "button_exam";
            this.button_exam.Size = new System.Drawing.Size(120, 23);
            this.button_exam.TabIndex = 1;
            this.button_exam.Text = "Test!";
            this.button_exam.UseVisualStyleBackColor = false;
            this.button_exam.Click += new System.EventHandler(this.button_exam_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SpringGreen;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(314, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button_trening;
        private System.Windows.Forms.Button button_commit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button_exam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_iterrations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
    }
}

