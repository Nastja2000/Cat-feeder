namespace CatFeeder
{
    partial class AdminView
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
            this.AddBtn = new System.Windows.Forms.Button();
            this.GoBackBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_users = new System.Windows.Forms.ListView();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.ChooseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(668, 148);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(102, 37);
            this.AddBtn.TabIndex = 7;
            this.AddBtn.Text = "Add ";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Location = new System.Drawing.Point(64, 32);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Size = new System.Drawing.Size(100, 50);
            this.GoBackBtn.TabIndex = 5;
            this.GoBackBtn.Text = "Back ";
            this.GoBackBtn.UseVisualStyleBackColor = true;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(248, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose or add a user";
            // 
            // lv_users
            // 
            this.lv_users.HideSelection = false;
            this.lv_users.Location = new System.Drawing.Point(189, 108);
            this.lv_users.Name = "lv_users";
            this.lv_users.Size = new System.Drawing.Size(205, 227);
            this.lv_users.TabIndex = 8;
            this.lv_users.UseCompatibleStateImageBehavior = false;
            //this.lv_users.SelectedIndexChanged += new System.EventHandler(this.lv_users_SelectedIndexChanged);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBtn.Location = new System.Drawing.Point(627, 221);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(102, 37);
            this.DeleteBtn.TabIndex = 9;
            this.DeleteBtn.Text = "Delete ";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // tb_Name
            // 
            this.tb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Name.Location = new System.Drawing.Point(496, 153);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(150, 28);
            this.tb_Name.TabIndex = 10;
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Location = new System.Drawing.Point(443, 158);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(47, 20);
            this.lbl_Error.TabIndex = 11;
            this.lbl_Error.Text = "Error";
            // 
            // ChooseBtn
            // 
            this.ChooseBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseBtn.Location = new System.Drawing.Point(473, 221);
            this.ChooseBtn.Name = "ChooseBtn";
            this.ChooseBtn.Size = new System.Drawing.Size(102, 37);
            this.ChooseBtn.TabIndex = 12;
            this.ChooseBtn.Text = "Choose";
            this.ChooseBtn.UseVisualStyleBackColor = true;
            this.ChooseBtn.Click += new System.EventHandler(this.ChooseBtn_Click);
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChooseBtn);
            this.Controls.Add(this.lbl_Error);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.lv_users);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddBtn);
            this.Name = "AdminView";
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button GoBackBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_users;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label lbl_Error;
        private System.Windows.Forms.Button ChooseBtn;
    }
}