namespace NAMMMHDotNetInternshipTraining.WinFormsAppSample
{
    partial class FrmBlog
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
            btn_save = new Button();
            btn_cancle = new Button();
            txtTitle = new TextBox();
            txtName = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            lbl_title = new Label();
            lbl_name = new Label();
            lbl_author = new Label();
            lbl_content = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btn_save
            // 
            btn_save.Location = new Point(451, 229);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(94, 29);
            btn_save.TabIndex = 0;
            btn_save.Text = "&Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancle
            // 
            btn_cancle.Location = new Point(302, 229);
            btn_cancle.Name = "btn_cancle";
            btn_cancle.Size = new Size(94, 29);
            btn_cancle.TabIndex = 1;
            btn_cancle.Text = "&Cancle";
            btn_cancle.UseVisualStyleBackColor = true;
            btn_cancle.Click += button2_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(302, 22);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(243, 27);
            txtTitle.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(302, 84);
            txtName.Name = "txtName";
            txtName.Size = new Size(243, 27);
            txtName.TabIndex = 3;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(302, 144);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(243, 27);
            txtAuthor.TabIndex = 4;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(302, 196);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(243, 27);
            txtContent.TabIndex = 5;
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(209, 25);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(69, 20);
            lbl_title.TabIndex = 6;
            lbl_title.Text = "BlogTitle";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(209, 87);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(80, 20);
            lbl_name.TabIndex = 7;
            lbl_name.Text = "BlogName";
            // 
            // lbl_author
            // 
            lbl_author.AutoSize = true;
            lbl_author.Location = new Point(209, 147);
            lbl_author.Name = "lbl_author";
            lbl_author.Size = new Size(85, 20);
            lbl_author.TabIndex = 8;
            lbl_author.Text = "BlogAuthor";
            // 
            // lbl_content
            // 
            lbl_content.AutoSize = true;
            lbl_content.Location = new Point(209, 199);
            lbl_content.Name = "lbl_content";
            lbl_content.Size = new Size(92, 20);
            lbl_content.TabIndex = 9;
            lbl_content.Text = "BlogContent";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(149, 278);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(519, 308);
            dataGridView1.TabIndex = 10;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 609);
            Controls.Add(dataGridView1);
            Controls.Add(lbl_content);
            Controls.Add(lbl_author);
            Controls.Add(lbl_name);
            Controls.Add(lbl_title);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtName);
            Controls.Add(txtTitle);
            Controls.Add(btn_cancle);
            Controls.Add(btn_save);
            Name = "FrmBlog";
            Text = "FrmStudent";
            Load += FrmBlog_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_save;
        private Button btn_cancle;
        private TextBox txtTitle;
        private TextBox txtName;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label lbl_title;
        private Label lbl_name;
        private Label lbl_author;
        private Label lbl_content;
        private DataGridView dataGridView1;
    }
}