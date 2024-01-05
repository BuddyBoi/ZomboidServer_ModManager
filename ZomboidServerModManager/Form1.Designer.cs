namespace ZomboidServerModManager
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
            this.listboxModsAvailable = new System.Windows.Forms.ListBox();
            this.listboxModsEnabled = new System.Windows.Forms.ListBox();
            this.buttonModEnable = new System.Windows.Forms.Button();
            this.buttonModDisable = new System.Windows.Forms.Button();
            this.buttonModSetupList = new System.Windows.Forms.Button();
            this.listboxModSelectedPreview = new System.Windows.Forms.ListBox();
            this.labelOne = new System.Windows.Forms.Label();
            this.richtextGeneratedConfig = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listboxModsAvailable
            // 
            this.listboxModsAvailable.FormattingEnabled = true;
            this.listboxModsAvailable.Location = new System.Drawing.Point(12, 12);
            this.listboxModsAvailable.Name = "listboxModsAvailable";
            this.listboxModsAvailable.Size = new System.Drawing.Size(305, 238);
            this.listboxModsAvailable.TabIndex = 0;
            this.listboxModsAvailable.SelectedIndexChanged += new System.EventHandler(this.listboxModsAvailable_SelectedIndexChanged);
            // 
            // listboxModsEnabled
            // 
            this.listboxModsEnabled.FormattingEnabled = true;
            this.listboxModsEnabled.Location = new System.Drawing.Point(333, 12);
            this.listboxModsEnabled.Name = "listboxModsEnabled";
            this.listboxModsEnabled.Size = new System.Drawing.Size(306, 238);
            this.listboxModsEnabled.TabIndex = 1;
            // 
            // buttonModEnable
            // 
            this.buttonModEnable.Location = new System.Drawing.Point(12, 256);
            this.buttonModEnable.Name = "buttonModEnable";
            this.buttonModEnable.Size = new System.Drawing.Size(305, 23);
            this.buttonModEnable.TabIndex = 2;
            this.buttonModEnable.Text = "Add";
            this.buttonModEnable.UseVisualStyleBackColor = true;
            this.buttonModEnable.Click += new System.EventHandler(this.buttonModEnable_Click);
            // 
            // buttonModDisable
            // 
            this.buttonModDisable.Location = new System.Drawing.Point(334, 256);
            this.buttonModDisable.Name = "buttonModDisable";
            this.buttonModDisable.Size = new System.Drawing.Size(305, 23);
            this.buttonModDisable.TabIndex = 3;
            this.buttonModDisable.Text = "Remove";
            this.buttonModDisable.UseVisualStyleBackColor = true;
            this.buttonModDisable.Click += new System.EventHandler(this.buttonModDisable_Click);
            // 
            // buttonModSetupList
            // 
            this.buttonModSetupList.Location = new System.Drawing.Point(12, 379);
            this.buttonModSetupList.Name = "buttonModSetupList";
            this.buttonModSetupList.Size = new System.Drawing.Size(627, 23);
            this.buttonModSetupList.TabIndex = 4;
            this.buttonModSetupList.Text = "Generate Config";
            this.buttonModSetupList.UseVisualStyleBackColor = true;
            this.buttonModSetupList.Click += new System.EventHandler(this.buttonModSetupList_Click);
            // 
            // listboxModSelectedPreview
            // 
            this.listboxModSelectedPreview.FormattingEnabled = true;
            this.listboxModSelectedPreview.Location = new System.Drawing.Point(12, 304);
            this.listboxModSelectedPreview.Name = "listboxModSelectedPreview";
            this.listboxModSelectedPreview.Size = new System.Drawing.Size(305, 69);
            this.listboxModSelectedPreview.TabIndex = 5;
            // 
            // labelOne
            // 
            this.labelOne.AutoSize = true;
            this.labelOne.Location = new System.Drawing.Point(12, 288);
            this.labelOne.Name = "labelOne";
            this.labelOne.Size = new System.Drawing.Size(95, 13);
            this.labelOne.TabIndex = 6;
            this.labelOne.Text = "Selected mod info:";
            // 
            // richtextGeneratedConfig
            // 
            this.richtextGeneratedConfig.Location = new System.Drawing.Point(12, 408);
            this.richtextGeneratedConfig.Name = "richtextGeneratedConfig";
            this.richtextGeneratedConfig.Size = new System.Drawing.Size(627, 170);
            this.richtextGeneratedConfig.TabIndex = 8;
            this.richtextGeneratedConfig.Text = "";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 590);
            this.Controls.Add(this.richtextGeneratedConfig);
            this.Controls.Add(this.labelOne);
            this.Controls.Add(this.listboxModSelectedPreview);
            this.Controls.Add(this.buttonModSetupList);
            this.Controls.Add(this.buttonModDisable);
            this.Controls.Add(this.buttonModEnable);
            this.Controls.Add(this.listboxModsEnabled);
            this.Controls.Add(this.listboxModsAvailable);
            this.Name = "Form1";
            this.Text = "Zomboid Server - Mod Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listboxModsAvailable;
        private System.Windows.Forms.ListBox listboxModsEnabled;
        private System.Windows.Forms.Button buttonModEnable;
        private System.Windows.Forms.Button buttonModDisable;
        private System.Windows.Forms.Button buttonModSetupList;
        private System.Windows.Forms.ListBox listboxModSelectedPreview;
        private System.Windows.Forms.Label labelOne;
        private System.Windows.Forms.RichTextBox richtextGeneratedConfig;
    }
}

