namespace BMPToPNGConverter
{
    partial class BMPToPNGConverter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folder_label = new System.Windows.Forms.Label();
            this.folder_textBox = new System.Windows.Forms.TextBox();
            this.folder_select_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.fail_listView = new System.Windows.Forms.ListView();
            this.failNams = new System.Windows.Forms.ColumnHeader();
            this.fail_label = new System.Windows.Forms.Label();
            this.stast_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // folder_label
            // 
            this.folder_label.AutoSize = true;
            this.folder_label.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.folder_label.Location = new System.Drawing.Point(12, 9);
            this.folder_label.Name = "folder_label";
            this.folder_label.Size = new System.Drawing.Size(134, 20);
            this.folder_label.TabIndex = 0;
            this.folder_label.Text = "폴더를 선택하세요";
            // 
            // folder_textBox
            // 
            this.folder_textBox.Location = new System.Drawing.Point(12, 32);
            this.folder_textBox.Name = "folder_textBox";
            this.folder_textBox.ReadOnly = true;
            this.folder_textBox.Size = new System.Drawing.Size(313, 23);
            this.folder_textBox.TabIndex = 1;
            // 
            // folder_select_button
            // 
            this.folder_select_button.Location = new System.Drawing.Point(331, 31);
            this.folder_select_button.Name = "folder_select_button";
            this.folder_select_button.Size = new System.Drawing.Size(75, 23);
            this.folder_select_button.TabIndex = 2;
            this.folder_select_button.Text = "폴더 선택";
            this.folder_select_button.UseVisualStyleBackColor = true;
            this.folder_select_button.Click += new System.EventHandler(this.folder_select_button_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(421, 31);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 4;
            this.start_button.Text = "변환";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // fail_listView
            // 
            this.fail_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.failNams});
            this.fail_listView.GridLines = true;
            this.fail_listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.fail_listView.LabelEdit = true;
            this.fail_listView.Location = new System.Drawing.Point(12, 94);
            this.fail_listView.Name = "fail_listView";
            this.fail_listView.Size = new System.Drawing.Size(600, 332);
            this.fail_listView.TabIndex = 5;
            this.fail_listView.UseCompatibleStateImageBehavior = false;
            this.fail_listView.View = System.Windows.Forms.View.Details;
            // 
            // failNams
            // 
            this.failNams.Text = "failNams";
            this.failNams.Width = 600;
            // 
            // fail_label
            // 
            this.fail_label.AutoSize = true;
            this.fail_label.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fail_label.Location = new System.Drawing.Point(12, 71);
            this.fail_label.Name = "fail_label";
            this.fail_label.Size = new System.Drawing.Size(74, 20);
            this.fail_label.TabIndex = 6;
            this.fail_label.Text = "실패 목록";
            // 
            // stast_label
            // 
            this.stast_label.AutoSize = true;
            this.stast_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stast_label.ForeColor = System.Drawing.Color.Red;
            this.stast_label.Location = new System.Drawing.Point(152, 58);
            this.stast_label.Name = "stast_label";
            this.stast_label.Size = new System.Drawing.Size(0, 21);
            this.stast_label.TabIndex = 7;
            // 
            // BMPToPNGConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 450);
            this.Controls.Add(this.stast_label);
            this.Controls.Add(this.fail_label);
            this.Controls.Add(this.fail_listView);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.folder_select_button);
            this.Controls.Add(this.folder_textBox);
            this.Controls.Add(this.folder_label);
            this.Name = "BMPToPNGConverter";
            this.Text = "BMPToPNGConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label folder_label;
        private TextBox folder_textBox;
        private Button folder_select_button;
        private Button start_button;
        private ListView fail_listView;
        private ColumnHeader failNams;
        private Label fail_label;
        private Label stast_label;
    }
}