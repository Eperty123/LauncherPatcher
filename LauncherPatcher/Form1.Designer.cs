/*
Copyright (c) 2021 Epery123

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE
OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace LauncherPatcher
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.websiteLinkLbl = new System.Windows.Forms.Label();
            this.websiteLinkTxtBox = new System.Windows.Forms.TextBox();
            this.launcherLogLbl = new System.Windows.Forms.Label();
            this.launcherLogTxtBox = new System.Windows.Forms.TextBox();
            this.launcherSettingsNameLbl = new System.Windows.Forms.Label();
            this.launcherSettingsTxtBox = new System.Windows.Forms.TextBox();
            this.patchInfoLbl = new System.Windows.Forms.Label();
            this.patchInfoTxtBox = new System.Windows.Forms.TextBox();
            this.defaultNewsLinkTxtBox = new System.Windows.Forms.TextBox();
            this.defaultnewsLinkLbl = new System.Windows.Forms.Label();
            this.regionCodeTxtBox = new System.Windows.Forms.TextBox();
            this.regionCodeLbl = new System.Windows.Forms.Label();
            this.rootGameFolderLbl = new System.Windows.Forms.Label();
            this.rootFolderTxtBox = new System.Windows.Forms.TextBox();
            this.connectSetupTxtBox = new System.Windows.Forms.TextBox();
            this.connectSetupLbl = new System.Windows.Forms.Label();
            this.dataDbTxtBox = new System.Windows.Forms.TextBox();
            this.dataDbFixLbl = new System.Windows.Forms.Label();
            this.patchLinkLbl = new System.Windows.Forms.Label();
            this.patchLinkTxtBox = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.patchBtn = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.ExportDefBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.websiteLinkLbl);
            this.groupBox1.Controls.Add(this.websiteLinkTxtBox);
            this.groupBox1.Controls.Add(this.launcherLogLbl);
            this.groupBox1.Controls.Add(this.launcherLogTxtBox);
            this.groupBox1.Controls.Add(this.launcherSettingsNameLbl);
            this.groupBox1.Controls.Add(this.launcherSettingsTxtBox);
            this.groupBox1.Controls.Add(this.patchInfoLbl);
            this.groupBox1.Controls.Add(this.patchInfoTxtBox);
            this.groupBox1.Controls.Add(this.defaultNewsLinkTxtBox);
            this.groupBox1.Controls.Add(this.defaultnewsLinkLbl);
            this.groupBox1.Controls.Add(this.regionCodeTxtBox);
            this.groupBox1.Controls.Add(this.regionCodeLbl);
            this.groupBox1.Controls.Add(this.rootGameFolderLbl);
            this.groupBox1.Controls.Add(this.rootFolderTxtBox);
            this.groupBox1.Controls.Add(this.connectSetupTxtBox);
            this.groupBox1.Controls.Add(this.connectSetupLbl);
            this.groupBox1.Controls.Add(this.dataDbTxtBox);
            this.groupBox1.Controls.Add(this.dataDbFixLbl);
            this.groupBox1.Controls.Add(this.patchLinkLbl);
            this.groupBox1.Controls.Add(this.patchLinkTxtBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 260);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Launcher Properties";
            // 
            // websiteLinkLbl
            // 
            this.websiteLinkLbl.AutoSize = true;
            this.websiteLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.websiteLinkLbl.Location = new System.Drawing.Point(329, 136);
            this.websiteLinkLbl.Name = "websiteLinkLbl";
            this.websiteLinkLbl.Size = new System.Drawing.Size(81, 13);
            this.websiteLinkLbl.TabIndex = 19;
            this.websiteLinkLbl.Text = "Website Link";
            // 
            // websiteLinkTxtBox
            // 
            this.websiteLinkTxtBox.Location = new System.Drawing.Point(332, 152);
            this.websiteLinkTxtBox.MaxLength = 63;
            this.websiteLinkTxtBox.Name = "websiteLinkTxtBox";
            this.websiteLinkTxtBox.Size = new System.Drawing.Size(295, 20);
            this.websiteLinkTxtBox.TabIndex = 18;
            this.websiteLinkTxtBox.TextChanged += new System.EventHandler(this.websiteLinkTxtBox_TextChanged);
            // 
            // launcherLogLbl
            // 
            this.launcherLogLbl.AutoSize = true;
            this.launcherLogLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherLogLbl.Location = new System.Drawing.Point(329, 94);
            this.launcherLogLbl.Name = "launcherLogLbl";
            this.launcherLogLbl.Size = new System.Drawing.Size(121, 13);
            this.launcherLogLbl.TabIndex = 17;
            this.launcherLogLbl.Text = "Launcher Log Name";
            // 
            // launcherLogTxtBox
            // 
            this.launcherLogTxtBox.Location = new System.Drawing.Point(332, 113);
            this.launcherLogTxtBox.MaxLength = 22;
            this.launcherLogTxtBox.Name = "launcherLogTxtBox";
            this.launcherLogTxtBox.Size = new System.Drawing.Size(295, 20);
            this.launcherLogTxtBox.TabIndex = 16;
            this.launcherLogTxtBox.TextChanged += new System.EventHandler(this.launcherLogTxtBox_TextChanged);
            // 
            // launcherSettingsNameLbl
            // 
            this.launcherSettingsNameLbl.AutoSize = true;
            this.launcherSettingsNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherSettingsNameLbl.Location = new System.Drawing.Point(329, 55);
            this.launcherSettingsNameLbl.Name = "launcherSettingsNameLbl";
            this.launcherSettingsNameLbl.Size = new System.Drawing.Size(146, 13);
            this.launcherSettingsNameLbl.TabIndex = 15;
            this.launcherSettingsNameLbl.Text = "Launcher Settings Name";
            // 
            // launcherSettingsTxtBox
            // 
            this.launcherSettingsTxtBox.Location = new System.Drawing.Point(332, 71);
            this.launcherSettingsTxtBox.MaxLength = 15;
            this.launcherSettingsTxtBox.Name = "launcherSettingsTxtBox";
            this.launcherSettingsTxtBox.Size = new System.Drawing.Size(295, 20);
            this.launcherSettingsTxtBox.TabIndex = 14;
            this.launcherSettingsTxtBox.TextChanged += new System.EventHandler(this.launcherSettingsTxtBox_TextChanged);
            // 
            // patchInfoLbl
            // 
            this.patchInfoLbl.AutoSize = true;
            this.patchInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patchInfoLbl.Location = new System.Drawing.Point(329, 16);
            this.patchInfoLbl.Name = "patchInfoLbl";
            this.patchInfoLbl.Size = new System.Drawing.Size(141, 13);
            this.patchInfoLbl.TabIndex = 13;
            this.patchInfoLbl.Text = "Patch Folder Info Name";
            // 
            // patchInfoTxtBox
            // 
            this.patchInfoTxtBox.Location = new System.Drawing.Point(332, 32);
            this.patchInfoTxtBox.MaxLength = 31;
            this.patchInfoTxtBox.Name = "patchInfoTxtBox";
            this.patchInfoTxtBox.Size = new System.Drawing.Size(295, 20);
            this.patchInfoTxtBox.TabIndex = 12;
            this.patchInfoTxtBox.TextChanged += new System.EventHandler(this.patchInfoTxtBox_TextChanged);
            // 
            // defaultNewsLinkTxtBox
            // 
            this.defaultNewsLinkTxtBox.Location = new System.Drawing.Point(9, 230);
            this.defaultNewsLinkTxtBox.MaxLength = 32;
            this.defaultNewsLinkTxtBox.Name = "defaultNewsLinkTxtBox";
            this.defaultNewsLinkTxtBox.Size = new System.Drawing.Size(294, 20);
            this.defaultNewsLinkTxtBox.TabIndex = 11;
            this.defaultNewsLinkTxtBox.TextChanged += new System.EventHandler(this.newsPageLinkTxtBox_TextChanged);
            // 
            // defaultnewsLinkLbl
            // 
            this.defaultnewsLinkLbl.AutoSize = true;
            this.defaultnewsLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultnewsLinkLbl.Location = new System.Drawing.Point(6, 214);
            this.defaultnewsLinkLbl.Name = "defaultnewsLinkLbl";
            this.defaultnewsLinkLbl.Size = new System.Drawing.Size(144, 13);
            this.defaultnewsLinkLbl.TabIndex = 10;
            this.defaultnewsLinkLbl.Text = "Default News Page Link";
            // 
            // regionCodeTxtBox
            // 
            this.regionCodeTxtBox.Location = new System.Drawing.Point(10, 191);
            this.regionCodeTxtBox.MaxLength = 2;
            this.regionCodeTxtBox.Name = "regionCodeTxtBox";
            this.regionCodeTxtBox.Size = new System.Drawing.Size(294, 20);
            this.regionCodeTxtBox.TabIndex = 9;
            this.regionCodeTxtBox.TextChanged += new System.EventHandler(this.countryCodeTxtBox_TextChanged);
            // 
            // regionCodeLbl
            // 
            this.regionCodeLbl.AutoSize = true;
            this.regionCodeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionCodeLbl.Location = new System.Drawing.Point(7, 175);
            this.regionCodeLbl.Name = "regionCodeLbl";
            this.regionCodeLbl.Size = new System.Drawing.Size(80, 13);
            this.regionCodeLbl.TabIndex = 8;
            this.regionCodeLbl.Text = "Region Code";
            // 
            // rootGameFolderLbl
            // 
            this.rootGameFolderLbl.AutoSize = true;
            this.rootGameFolderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootGameFolderLbl.Location = new System.Drawing.Point(6, 55);
            this.rootGameFolderLbl.Name = "rootGameFolderLbl";
            this.rootGameFolderLbl.Size = new System.Drawing.Size(145, 13);
            this.rootGameFolderLbl.TabIndex = 7;
            this.rootGameFolderLbl.Text = "Root Game Folder Name";
            // 
            // rootFolderTxtBox
            // 
            this.rootFolderTxtBox.Location = new System.Drawing.Point(9, 71);
            this.rootFolderTxtBox.MaxLength = 2;
            this.rootFolderTxtBox.Name = "rootFolderTxtBox";
            this.rootFolderTxtBox.Size = new System.Drawing.Size(295, 20);
            this.rootFolderTxtBox.TabIndex = 1;
            this.rootFolderTxtBox.TextChanged += new System.EventHandler(this.rootFolderTxtBox_TextChanged);
            // 
            // connectSetupTxtBox
            // 
            this.connectSetupTxtBox.Location = new System.Drawing.Point(9, 152);
            this.connectSetupTxtBox.MaxLength = 26;
            this.connectSetupTxtBox.Name = "connectSetupTxtBox";
            this.connectSetupTxtBox.Size = new System.Drawing.Size(295, 20);
            this.connectSetupTxtBox.TabIndex = 3;
            this.connectSetupTxtBox.TextChanged += new System.EventHandler(this.connectSetupTxtBox_TextChanged);
            // 
            // connectSetupLbl
            // 
            this.connectSetupLbl.AutoSize = true;
            this.connectSetupLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectSetupLbl.Location = new System.Drawing.Point(6, 136);
            this.connectSetupLbl.Name = "connectSetupLbl";
            this.connectSetupLbl.Size = new System.Drawing.Size(108, 13);
            this.connectSetupLbl.TabIndex = 4;
            this.connectSetupLbl.Text = "Connect.ini Setup";
            // 
            // dataDbTxtBox
            // 
            this.dataDbTxtBox.Enabled = false;
            this.dataDbTxtBox.Location = new System.Drawing.Point(9, 113);
            this.dataDbTxtBox.MaxLength = 7;
            this.dataDbTxtBox.Name = "dataDbTxtBox";
            this.dataDbTxtBox.Size = new System.Drawing.Size(295, 20);
            this.dataDbTxtBox.TabIndex = 2;
            this.dataDbTxtBox.TextChanged += new System.EventHandler(this.dataDbTxtBox_TextChanged);
            // 
            // dataDbFixLbl
            // 
            this.dataDbFixLbl.AutoSize = true;
            this.dataDbFixLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDbFixLbl.Location = new System.Drawing.Point(6, 94);
            this.dataDbFixLbl.Name = "dataDbFixLbl";
            this.dataDbFixLbl.Size = new System.Drawing.Size(149, 13);
            this.dataDbFixLbl.TabIndex = 2;
            this.dataDbFixLbl.Text = "Data\\db Fix Folder Name";
            // 
            // patchLinkLbl
            // 
            this.patchLinkLbl.AutoSize = true;
            this.patchLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patchLinkLbl.Location = new System.Drawing.Point(7, 16);
            this.patchLinkLbl.Name = "patchLinkLbl";
            this.patchLinkLbl.Size = new System.Drawing.Size(68, 13);
            this.patchLinkLbl.TabIndex = 1;
            this.patchLinkLbl.Text = "Patch Link";
            // 
            // patchLinkTxtBox
            // 
            this.patchLinkTxtBox.Location = new System.Drawing.Point(9, 32);
            this.patchLinkTxtBox.MaxLength = 16;
            this.patchLinkTxtBox.Name = "patchLinkTxtBox";
            this.patchLinkTxtBox.Size = new System.Drawing.Size(295, 20);
            this.patchLinkTxtBox.TabIndex = 0;
            this.patchLinkTxtBox.TextChanged += new System.EventHandler(this.patchLinkTxtBox_TextChanged);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(492, 274);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 43);
            this.openBtn.TabIndex = 4;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Launcher";
            this.openFileDialog1.Filter = "Launcher|*.exe";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Launcher";
            this.saveFileDialog1.Filter = "Launcher|*.exe";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // patchBtn
            // 
            this.patchBtn.Enabled = false;
            this.patchBtn.Location = new System.Drawing.Point(573, 275);
            this.patchBtn.Name = "patchBtn";
            this.patchBtn.Size = new System.Drawing.Size(75, 42);
            this.patchBtn.TabIndex = 5;
            this.patchBtn.Text = "Patch";
            this.patchBtn.UseVisualStyleBackColor = true;
            this.patchBtn.Click += new System.EventHandler(this.patchBtn_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(554, 320);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(94, 15);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "By: Eperty123";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked_1);
            // 
            // ExportDefBtn
            // 
            this.ExportDefBtn.Enabled = false;
            this.ExportDefBtn.Location = new System.Drawing.Point(12, 275);
            this.ExportDefBtn.Name = "ExportDefBtn";
            this.ExportDefBtn.Size = new System.Drawing.Size(100, 43);
            this.ExportDefBtn.TabIndex = 13;
            this.ExportDefBtn.Text = "Export Definition";
            this.ExportDefBtn.UseVisualStyleBackColor = true;
            this.ExportDefBtn.Click += new System.EventHandler(this.ExportDefBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 341);
            this.Controls.Add(this.ExportDefBtn);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.patchBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.openBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LauncherPatcher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label patchLinkLbl;
        private System.Windows.Forms.TextBox patchLinkTxtBox;
        private System.Windows.Forms.Label dataDbFixLbl;
        private System.Windows.Forms.TextBox dataDbTxtBox;
        private System.Windows.Forms.TextBox connectSetupTxtBox;
        private System.Windows.Forms.Label connectSetupLbl;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button patchBtn;
        private System.Windows.Forms.Label rootGameFolderLbl;
        private System.Windows.Forms.TextBox rootFolderTxtBox;
        private System.Windows.Forms.Label regionCodeLbl;
        private System.Windows.Forms.TextBox regionCodeTxtBox;
        private System.Windows.Forms.TextBox defaultNewsLinkTxtBox;
        private System.Windows.Forms.Label defaultnewsLinkLbl;
        private System.Windows.Forms.Label patchInfoLbl;
        private System.Windows.Forms.TextBox patchInfoTxtBox;
        private System.Windows.Forms.Label launcherSettingsNameLbl;
        private System.Windows.Forms.TextBox launcherSettingsTxtBox;
        private System.Windows.Forms.Label launcherLogLbl;
        private System.Windows.Forms.TextBox launcherLogTxtBox;
        private System.Windows.Forms.Label websiteLinkLbl;
        private System.Windows.Forms.TextBox websiteLinkTxtBox;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button ExportDefBtn;
    }
}

