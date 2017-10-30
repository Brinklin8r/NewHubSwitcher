namespace HubSwitcher {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cbSystemDropDown = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblUIN = new System.Windows.Forms.Label();
            this.lblResutls = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.tbUIN = new System.Windows.Forms.TextBox();
            this.btnCurrent = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSystemDropDown
            // 
            this.cbSystemDropDown.FormattingEnabled = true;
            this.cbSystemDropDown.Location = new System.Drawing.Point(11, 12);
            this.cbSystemDropDown.Name = "cbSystemDropDown";
            this.cbSystemDropDown.Size = new System.Drawing.Size(218, 21);
            this.cbSystemDropDown.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Location = new System.Drawing.Point(96, 97);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(56, 25);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLaunch.Location = new System.Drawing.Point(173, 97);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(55, 25);
            this.btnLaunch.TabIndex = 2;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(12, 46);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(38, 13);
            this.lblURL.TabIndex = 3;
            this.lblURL.Text = "URL:  ";
            // 
            // lblUIN
            // 
            this.lblUIN.AutoSize = true;
            this.lblUIN.Location = new System.Drawing.Point(12, 72);
            this.lblUIN.Name = "lblUIN";
            this.lblUIN.Size = new System.Drawing.Size(35, 13);
            this.lblUIN.TabIndex = 4;
            this.lblUIN.Text = "UIN:  ";
            // 
            // lblResutls
            // 
            this.lblResutls.AutoSize = true;
            this.lblResutls.Location = new System.Drawing.Point(12, 138);
            this.lblResutls.Name = "lblResutls";
            this.lblResutls.Size = new System.Drawing.Size(42, 13);
            this.lblResutls.TabIndex = 5;
            this.lblResutls.Text = "Results";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(48, 43);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(180, 20);
            this.tbURL.TabIndex = 6;
            // 
            // tbUIN
            // 
            this.tbUIN.Location = new System.Drawing.Point(48, 69);
            this.tbUIN.Name = "tbUIN";
            this.tbUIN.Size = new System.Drawing.Size(180, 20);
            this.tbUIN.TabIndex = 7;
            // 
            // btnCurrent
            // 
            this.btnCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCurrent.Location = new System.Drawing.Point(15, 97);
            this.btnCurrent.Name = "btnCurrent";
            this.btnCurrent.Size = new System.Drawing.Size(56, 25);
            this.btnCurrent.TabIndex = 8;
            this.btnCurrent.Text = "Current";
            this.btnCurrent.UseVisualStyleBackColor = true;
            this.btnCurrent.Click += new System.EventHandler(this.btnCurrent_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(241, 183);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCurrent);
            this.Controls.Add(this.tbUIN);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.lblResutls);
            this.Controls.Add(this.lblUIN);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbSystemDropDown);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainForm";
            this.Text = "HubSwitcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSystemDropDown;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label lblUIN;
        private System.Windows.Forms.Label lblResutls;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.TextBox tbUIN;
        private System.Windows.Forms.Button btnCurrent;
        private System.Windows.Forms.Button btnSave;
    }
}

