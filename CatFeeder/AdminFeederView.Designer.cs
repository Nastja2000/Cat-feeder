namespace CatFeeder
{
    partial class AdminFeederView
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
            this.ChooseBtn = new System.Windows.Forms.Button();
            this.GoBackBtn = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.lv_users = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ChooseBtn
            // 
            this.ChooseBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseBtn.Location = new System.Drawing.Point(438, 269);
            this.ChooseBtn.Name = "ChooseBtn";
            this.ChooseBtn.Size = new System.Drawing.Size(102, 37);
            this.ChooseBtn.TabIndex = 41;
            this.ChooseBtn.Text = "Choose";
            this.ChooseBtn.UseVisualStyleBackColor = true;
            this.ChooseBtn.Click += new System.EventHandler(this.ChooseBtn_Click);
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Location = new System.Drawing.Point(46, 41);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Size = new System.Drawing.Size(100, 50);
            this.GoBackBtn.TabIndex = 39;
            this.GoBackBtn.Text = "Back ";
            this.GoBackBtn.UseVisualStyleBackColor = true;
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(581, 152);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(150, 30);
            this.btn_Export.TabIndex = 38;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(413, 152);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(150, 30);
            this.btn_Import.TabIndex = 37;
            this.btn_Import.Text = "Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // lv_users
            // 
            this.lv_users.HideSelection = false;
            this.lv_users.Location = new System.Drawing.Point(215, 73);
            this.lv_users.Name = "lv_users";
            this.lv_users.Size = new System.Drawing.Size(152, 248);
            this.lv_users.TabIndex = 35;
            this.lv_users.UseCompatibleStateImageBehavior = false;
            // 
            // AdminFeederView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChooseBtn);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.lv_users);
            this.Name = "AdminFeederView";
            this.Text = "AdminFeederView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button ChooseBtn;
        private System.Windows.Forms.Button GoBackBtn;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.ListView lv_users;
    }
}