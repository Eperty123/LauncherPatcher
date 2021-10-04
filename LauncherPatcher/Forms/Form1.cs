/*
Copyright (c) 2021 Eperty123

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

using System;
using System.Windows.Forms;
using LauncherPatcher.Definiton;
using System.Diagnostics;
using LauncherPatcher.Definiton.Enum;
using LauncherPatcher.Utility;
using LauncherPatcher.Definiton.Interface;
using LauncherPatcher.Definiton.Configuration;
using LauncherPatcher.Definiton.Inheritance.Launchers.AuraKingdom;
using System.Collections.Generic;
using LauncherPatcher.Definiton.Inheritance.Launchers.Eden_Eternal;
using LauncherPatcher.Definiton.Inheritance.Launchers.Twin_Saga;

namespace LauncherPatcher
{
    public partial class Form1 : Form
    {

        #region Private Variables
        ILauncher Launcher;
        private string HeaderString;
        LauncherDefinition LauncherDefinition = LauncherDefinition.GetInstance();
        private GameType SelectedGameType;
        #endregion

        #region Constructors
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }
        #endregion

        #region Private Methods

        private void Initialize()
        {
            var launcherTypes = Enum.GetValues(typeof(GameType));
            for (int i = 0; i < launcherTypes.Length; i++)
                launcherTypeCombobox.Items.Add(launcherTypes.GetValue(i));

            // Default selection to Aura Kingdom.
            launcherTypeCombobox.SelectedIndex = 0;

            FormClosing += new FormClosingEventHandler(Form1_Closing);
        }

        private void CheckLauncher(string file)
        {
            CleanUp();

            // Load Launcher as byte array.
            HeaderString = LauncherUtility.GetHeader(file);
            LauncherInfo desiredLauncherInfo = null;
            List<LauncherInfo> desiredLauncherInfoList = null;

            // Implement the necessary configs if needed.

            switch (SelectedGameType)
            {
                case GameType.AURA_KINGDOM:
                    desiredLauncherInfoList = LauncherDefinition.SUPPORTED_AK_LAUNCHERS;
                    break;

                case GameType.EDEN_ETERNAL:
                    desiredLauncherInfoList = LauncherDefinition.SUPPORTED_EE_LAUNCHERS;
                    break;

                case GameType.TWIN_SAGA:
                    desiredLauncherInfoList = LauncherDefinition.SUPPORTED_TS_LAUNCHERS;
                    break;

                default:
                    MessageBox.Show($"This game is not yet supported.", "Game Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            };

            // Process the launcher info list and get the appropriate definition for the selected game.
            if (desiredLauncherInfoList != null && desiredLauncherInfoList.HasDefinition(HeaderString))
            {
                desiredLauncherInfo = desiredLauncherInfoList.GetLauncherInfo(HeaderString);
                var region = desiredLauncherInfo.LAUNCHER_REGION;

                // Create a new instance of the correct launcher based on the region code.
                switch (SelectedGameType)
                {
                    case GameType.AURA_KINGDOM:
                        switch (region)
                        {
                            case LauncherRegionType.LAUNCHER_HK:
                                Launcher = new AKHKLauncher(desiredLauncherInfo, file);
                                break;
                            case LauncherRegionType.LAUNCHER_TW:
                                Launcher = new AKTWLauncher(desiredLauncherInfo, file);
                                break;

                            default:
                                MessageBox.Show($"This launcher with the region code: \"{desiredLauncherInfo.LAUNCHER_REGION}\" is not supported. Please create a definition file for it.", "Unsupported Launcher Region", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;

                    case GameType.EDEN_ETERNAL:
                        switch (region)
                        {
                            case LauncherRegionType.LAUNCHER_TW:
                                Launcher = new EETWLauncher(desiredLauncherInfo, file);
                                break;

                            default:
                                MessageBox.Show($"This launcher with the region code: \"{desiredLauncherInfo.LAUNCHER_REGION}\" is not supported. Please create a definition file for it.", "Unsupported Launcher Region", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;

                    case GameType.TWIN_SAGA:
                        switch (region)
                        {
                            case LauncherRegionType.LAUNCHER_TW:
                                Launcher = new TSTWLauncher(desiredLauncherInfo, file);
                                break;

                            default:
                                MessageBox.Show($"This launcher with the region code: \"{desiredLauncherInfo.LAUNCHER_REGION}\" is not supported. Please create a definition file for it.", "Unsupported Launcher Region", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;
                }
            }

            // Parse the launcher data.
            if (desiredLauncherInfo != null)
            {
                if (Launcher != null && Launcher.Valid)
                {
                    ReadLauncher(Launcher);
                    Text = $"{Application.ProductName} ({Launcher.LauncherRegion} - {Launcher.GetHeader()})";
                }
            }
            else
            {
                // No valid information, disable patcher.

                patchBtn.Enabled = false;
                ExportDefBtn.Enabled = false;
                MessageBox.Show($"This launcher with the header: \"{HeaderString}\" is not defined and therefore not supported for the selected game! Please create a definition file for it.", "Unsupported Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReadLauncher(ILauncher launcher)
        {
            LauncherInfo launcherInfo = launcher.LauncherInfo;

            patchLinkTxtBox.SetText(launcherInfo.PATCH_LINK.OffsetInfo.ReadDataAsString());
            patchLinkTxtBox.SetMaxLength(launcherInfo.PATCH_LINK.OffsetInfo.GetMaxLengthForTextBox());

            rootFolderTxtBox.SetText(launcherInfo.GAME_ABBREVIATION_FOLDER_NAME.OffsetInfo.ReadDataAsString());
            rootFolderTxtBox.SetMaxLength(launcherInfo.GAME_ABBREVIATION_FOLDER_NAME.OffsetInfo.GetMaxLengthForTextBox());

            patchInfoTxtBox.SetText(launcherInfo.PATCH_DOWNLOAD_FOLDER_NAME[0].OffsetInfo.ReadDataAsString());
            patchInfoTxtBox.SetMaxLength(launcherInfo.PATCH_DOWNLOAD_FOLDER_NAME[0].OffsetInfo.GetMaxLengthForTextBox());

            //dataDbTxtBox.SetText("Automatically fixed upon save.");
            dataDbTxtBox.SetText(launcherInfo.DATA_DB_FIX.OffsetInfo.ReadDataAsString());
            dataDbTxtBox.SetMaxLength(launcherInfo.DATA_DB_FIX.OffsetInfo.GetMaxLengthForTextBox());

            connectSetupTxtBox.SetText(launcherInfo.CONNECT_SETUP.OffsetInfo.ReadDataAsString());
            connectSetupTxtBox.SetMaxLength(launcherInfo.CONNECT_SETUP.OffsetInfo.GetMaxLengthForTextBox());

            regionCodeTxtBox.SetText(launcherInfo.REGION_CODE[0].OffsetInfo.ReadDataAsString());
            regionCodeTxtBox.SetMaxLength(launcherInfo.REGION_CODE[0].OffsetInfo.GetMaxLengthForTextBox());

            defaultNewsLinkTxtBox.SetText(launcherInfo.NEWS_PAGE.OffsetInfo.ReadDataAsString());
            defaultNewsLinkTxtBox.SetMaxLength(launcherInfo.NEWS_PAGE.OffsetInfo.GetMaxLengthForTextBox());

            launcherSettingsTxtBox.SetText(launcherInfo.LAUNCHER_SETTINGS_NAME.OffsetInfo.ReadDataAsString());
            launcherSettingsTxtBox.SetMaxLength(launcherInfo.LAUNCHER_SETTINGS_NAME.OffsetInfo.GetMaxLengthForTextBox());

            launcherLogTxtBox.SetText(launcherInfo.LAUNCHER_LOG_NAME.OffsetInfo.ReadDataAsString());
            launcherLogTxtBox.SetMaxLength(launcherInfo.LAUNCHER_LOG_NAME.OffsetInfo.GetMaxLengthForTextBox());

            websiteLinkTxtBox.SetText(launcherInfo.WEBSITE_LINK.OffsetInfo.ReadDataAsString());
            websiteLinkTxtBox.SetMaxLength(launcherInfo.WEBSITE_LINK.OffsetInfo.GetMaxLengthForTextBox());

            UpdateLabels();
            patchBtn.Enabled = true;
            ExportDefBtn.Enabled = true;

        }

        /// <summary>
        /// Update the labels to show the correct allowed amount of characters.
        /// </summary>
        private void UpdateLabels()
        {
            patchLinkLbl.GetLengthInfo(patchLinkTxtBox);
            rootGameFolderLbl.GetLengthInfo(rootFolderTxtBox);
            patchInfoLbl.GetLengthInfo(patchInfoTxtBox);

            //dataDbFixLbl.GetLengthInfo(dataDbTxtBox);
            connectSetupLbl.GetLengthInfo(connectSetupTxtBox);
            regionCodeLbl.GetLengthInfo(regionCodeTxtBox);
            defaultnewsLinkLbl.GetLengthInfo(defaultNewsLinkTxtBox);
            launcherSettingsNameLbl.GetLengthInfo(launcherSettingsTxtBox);
            launcherLogLbl.GetLengthInfo(launcherLogTxtBox);
            websiteLinkLbl.GetLengthInfo(websiteLinkTxtBox);
        }

        private void SaveLauncher()
        {
            if (Launcher == null) return;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Launcher.ResetChanges();
                Launcher.SetValue(LauncherOffsetType.PATCH_LINK, patchLinkTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME, rootFolderTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, patchInfoTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.DATA_DB_FIX, @".......");
                Launcher.SetValue(LauncherOffsetType.CONNECT_SETUP, connectSetupTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.REGION_CODE, regionCodeTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.NEWS_PAGE, defaultNewsLinkTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.LAUNCHER_SETTINGS_NAME, launcherSettingsTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.LAUNCHER_LOG_NAME, launcherLogTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.WEBSITE_LINK, websiteLinkTxtBox.Text);
                Launcher.SetValue(LauncherOffsetType.SEND_LOG_LINK, "");

                Launcher.SaveToFile(saveFileDialog1.FileName);
            }
        }

        private void SaveLauncherDefinition()
        {
            if (Launcher != null && Launcher.Valid)
            {
                var sfd = new SaveFileDialog();
                sfd.Title = "Save launcher definition";
                sfd.FileName = Launcher.Name;
                sfd.Filter = "Json|*.json";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Launcher.SaveDefinitionToFile(sfd.FileName);
                }
            }
        }

        private void CleanUp()
        {
            if (Launcher != null)
            {
                ((Launcher)Launcher).Dispose();
                Launcher = null;
            }
        }

        #region Event Handlers
        private void openBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CheckLauncher(openFileDialog1.FileName);
            }
        }

        private void ExportDefBtn_Click(object sender, EventArgs e)
        {
            SaveLauncherDefinition();
        }

        private void patchBtn_Click(object sender, EventArgs e)
        {
            SaveLauncher();
        }


        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            CleanUp();
        }

        private void patchLinkTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void rootFolderTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void dataDbTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void connectSetupTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void countryCodeTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void newsPageLinkTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void patchInfoTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void launcherSettingsTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void launcherLogTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void websiteLinkTxtBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void launcherTypeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (launcherTypeCombobox.SelectedItem != null)
                SelectedGameType = (GameType)launcherTypeCombobox.SelectedItem;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Eperty123");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys KeyValue)
        {
            if (KeyValue == (Keys.Control | Keys.O))
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    CheckLauncher(openFileDialog1.FileName);
                }
            }
            else if (KeyValue == (Keys.Control | Keys.S))
            {
                if (Launcher != null && ((Launcher)Launcher).IsLoaded())
                {
                    SaveLauncher();
                }
                else
                {
                    MessageBox.Show("Please open up a Launcher first!", "No Launcher selected yet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            // Do some shit.
            return base.ProcessCmdKey(ref msg, KeyValue);
        }
        #endregion

        #endregion
    }
}
