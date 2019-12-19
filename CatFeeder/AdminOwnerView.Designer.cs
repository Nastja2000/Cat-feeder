namespace CatFeeder
{
    partial class AdminOwnerView
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
            this.GoBackBtn = new System.Windows.Forms.Button();
            this.ChooseBtn = new System.Windows.Forms.Button();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.lv_users = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Location = new System.Drawing.Point(46, 74);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Size = new System.Drawing.Size(100, 50);
            this.GoBackBtn.TabIndex = 26;
            this.GoBackBtn.Text = "Back ";
            this.GoBackBtn.UseVisualStyleBackColor = true;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_Click);
            // 
            // ChooseBtn
            // 
            this.ChooseBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseBtn.Location = new System.Drawing.Point(473, 268);
            this.ChooseBtn.Name = "ChooseBtn";
            this.ChooseBtn.Size = new System.Drawing.Size(102, 37);
            this.ChooseBtn.TabIndex = 25;
            this.ChooseBtn.Text = "Choose";
            this.ChooseBtn.UseVisualStyleBackColor = true;
            this.ChooseBtn.Click += new System.EventHandler(this.ChooseBtn_Click);
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Location = new System.Drawing.Point(443, 205);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(47, 20);
            this.lbl_Error.TabIndex = 24;
            this.lbl_Error.Text = "Error";
            // 
            // tb_Name
            // 
            this.tb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Name.Location = new System.Drawing.Point(496, 200);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(150, 28);
            this.tb_Name.TabIndex = 23;
            // 
            // lv_users
            // 
            this.lv_users.HideSelection = false;
            this.lv_users.Location = new System.Drawing.Point(194, 149);
            this.lv_users.Name = "lv_users";
            this.lv_users.Size = new System.Drawing.Size(205, 227);
            this.lv_users.TabIndex = 20;
            this.lv_users.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(230, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 35);
            this.label1.TabIndex = 19;
            this.label1.Text = "Choose or add a feeder";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(652, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 27;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(635, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 37);
            this.button2.TabIndex = 28;
            this.button2.Text = "Delete ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            // 
            // AdminOwnerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.ChooseBtn);
            this.Controls.Add(this.lbl_Error);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.lv_users);
            this.Controls.Add(this.label1);
            this.Name = "AdminOwnerView";
            this.Text = "AdminOwnerView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoBackBtn;
        private System.Windows.Forms.Button ChooseBtn;
        private System.Windows.Forms.Label lbl_Error;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.ListView lv_users;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}