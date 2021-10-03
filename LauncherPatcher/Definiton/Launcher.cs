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

using LauncherPatcher.Definiton.Configuration;
using LauncherPatcher.Definiton.Enum;
using LauncherPatcher.Definiton.Interface;
using LauncherPatcher.Utility;
using System.Collections.Generic;
using System.IO;

namespace LauncherPatcher.Definiton
{
    public abstract class Launcher : LauncherOffsetInfo, ILauncher
    {
        #region Private, Protected Variables
        #endregion

        #region Public Variables
        public string Name { get; set; }
        public Dictionary<LauncherOffset, string> OffsetsToApply { get; set; }
        public LauncherInfo LauncherInfo { get; set; }
        public GameType LauncherType { get; set; }
        public LauncherRegionType LauncherRegion { get; set; }
        public string Header { get; set; }
        public bool Valid { get; set; }

        #endregion

        #region Constructors

        public Launcher(LauncherInfo launcherInfo, string file)
        {
            Initialize();
            LoadFile(file);
            SetLauncherInfo(launcherInfo);
        }

        public Launcher(LauncherRegionType launcherRegionType, string header)
        {
            Initialize();
            LauncherRegion = launcherRegionType;
            Header = header;
        }

        public Launcher(LauncherRegionType launcherRegionType, string header, LauncherInfo launcherInfo)
        {
            Initialize();
            LauncherRegion = launcherRegionType;
            Header = header;
            LauncherInfo = launcherInfo;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Initialize the <see cref="Launcher"/>.
        /// </summary>
        protected virtual void Initialize()
        {
            LauncherInfo = new LauncherInfo();
            OffsetsToApply = new Dictionary<LauncherOffset, string>();
        }

        protected void CheckCompatibility()
        {
            if (ReadBytes != null && ReadBytes.Length > 0)
            {
                // TODO: Detect launcher tye and header through the defintion list.

                var compatibility_string = GetHeader();
                if (!compatibility_string.IsNullOrEmpty() && LauncherInfo.HEADER == compatibility_string)
                {
                    Header = compatibility_string;
                    SetLauncherRegionType(LauncherInfo.LAUNCHER_REGION);
                    Name = $"{LauncherInfo.GAME_TYPE}_{LauncherRegion}_{Header.Replace(" ", "_")}";
                    Valid = true;
                }
            }
        }

        /// <summary>
        /// Initialize <see cref="LauncherInfo"/> and load offsets.
        /// </summary>
        protected virtual void InitializeLauncherInfo()
        {
            LauncherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo.LoadBytes(ReadBytes);
            LauncherInfo.PATCH_LINK.OffsetInfo.LoadBytes(ReadBytes);
            LauncherInfo.GAME_ABBREVIATION_FOLDER_NAME.OffsetInfo.LoadBytes(ReadBytes);

            if (LauncherInfo.PATCH_DOWNLOAD_FOLDER_NAME.Count > 0)
            {
                for (int i = 0; i < LauncherInfo.PATCH_DOWNLOAD_FOLDER_NAME.Count; i++)
                {
                    var patch_folder_name = LauncherInfo.PATCH_DOWNLOAD_FOLDER_NAME[i];
                    patch_folder_name.OffsetInfo.LoadBytes(ReadBytes);
                }
            }

            LauncherInfo.DATA_DB_FIX.OffsetInfo.LoadBytes(ReadBytes);
            LauncherInfo.CONNECT_SETUP.OffsetInfo.LoadBytes(ReadBytes);

            if (LauncherInfo.REGION_CODE.Count > 0)
            {
                for (int i = 0; i < LauncherInfo.REGION_CODE.Count; i++)
                {
                    var region_code = LauncherInfo.REGION_CODE[i];
                    region_code.OffsetInfo.LoadBytes(ReadBytes);
                }
            }

            LauncherInfo.NEWS_PAGE.OffsetInfo.LoadBytes(ReadBytes);
            LauncherInfo.LAUNCHER_SETTINGS_NAME.OffsetInfo.LoadBytes(ReadBytes);
            LauncherInfo.LAUNCHER_LOG_NAME.OffsetInfo.LoadBytes(ReadBytes);
            LauncherInfo.WEBSITE_LINK.OffsetInfo.LoadBytes(ReadBytes);
            LauncherInfo.SEND_LOG_LINK.OffsetInfo.LoadBytes(ReadBytes);

        }

        protected override void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!Disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    Close();
                }

                // Note disposing has been done.
                Disposed = true;
            }
        }
        #endregion

        #region Public Methods
        public override void LoadFile(string file)
        {
            base.LoadFile(file);
        }

        public override void LoadBytes(byte[] data)
        {
            base.LoadBytes(data);
            WriteBytes = data;
        }

        /// <summary>
        /// Load a <see cref="LauncherInfo"/> from string.
        /// </summary>
        /// <param name="json">The string containing a <see cref="LauncherInfo"/>.</param>
        public void LoadDefinition(string json)
        {
            if (!json.IsNullOrEmpty()) SetLauncherInfo(json.FromJson<LauncherInfo>());
        }

        /// <summary>
        /// Load a <see cref="LauncherInfo"/> from file.
        /// </summary>
        /// <param name="inputFile">A file containing a <see cref="LauncherInfo"/>.</param>
        public void LoadDefinitionFromFile(string inputFile)
        {
            if (File.Exists(inputFile))
            {
                using (var fs = new FileStream(inputFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs))
                {
                    SetLauncherInfo(sr.ReadToEnd().FromJson<LauncherInfo>());
                }
            }
        }

        /// <summary>
        /// Get the header of the <see cref="Launcher"/>.
        /// </summary>
        /// <returns>Returns the header string.</returns>
        public string GetHeader()
        {
            //LauncherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo = new LauncherOffsetInfo(264, 4, EncodingTypes.UTF8);
            LauncherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo = new LauncherOffsetInfo((uint)LauncherDefinition.LAUNCHER_HEADER_OFFSET, (uint)LauncherDefinition.LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8);
            LauncherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo.LoadBytes(ReadBytes);
            return LauncherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo.ReadDataAsBytes();
        }

        /// <summary>
        /// Set the <see cref="Launcher"/> wit the specified <see cref="LauncherInfo"/>.
        /// </summary>
        /// <param name="launcherInfo">The <see cref="LauncherInfo"/>.</param>
        public virtual void SetLauncherInfo(LauncherInfo launcherInfo)
        {
            if (launcherInfo != null)
            {
                LauncherInfo = launcherInfo;
                InitializeLauncherInfo();
                CheckCompatibility();
            }
        }

        /// <summary>
        /// Set the <see cref="Launcher"/>'s <see cref="Enum.LauncherRegionType"/>.
        /// </summary>
        /// <param name="launcherType"></param>
        public void SetLauncherRegionType(LauncherRegionType launcherRegionType)
        {
            LauncherRegion = launcherRegionType;
        }

        /// <summary>
        /// Set the <see cref="LauncherOffset"/> with specified value.
        /// </summary>
        /// <param name="launcherType">The <see cref="LauncherOffsetType"/> to set value of.</param>
        /// <param name="value">The value to write.</param>
        public virtual void SetValue(LauncherOffsetType launcherType, string value)
        {
            switch (launcherType)
            {
                case LauncherOffsetType.LAUNCHER_HEADER_CHECK:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.LAUNCHER_HEADER_CHECK))
                        OffsetsToApply.Add(LauncherInfo.LAUNCHER_HEADER_CHECK, value);
                    break;

                case LauncherOffsetType.PATCH_LINK:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.PATCH_LINK))
                        OffsetsToApply.Add(LauncherInfo.PATCH_LINK, value);
                    break;

                case LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.GAME_ABBREVIATION_FOLDER_NAME))
                        OffsetsToApply.Add(LauncherInfo.GAME_ABBREVIATION_FOLDER_NAME, value);
                    break;

                case LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME:
                    for (int i = 0; i < LauncherInfo.PATCH_DOWNLOAD_FOLDER_NAME.Count; i++)
                    {
                        var patch_folder_name = LauncherInfo.PATCH_DOWNLOAD_FOLDER_NAME[i];
                        if (!OffsetsToApply.ContainsKey(patch_folder_name))
                            OffsetsToApply.Add(patch_folder_name, value);
                    }
                    break;

                case LauncherOffsetType.DATA_DB_FIX:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.DATA_DB_FIX))
                        OffsetsToApply.Add(LauncherInfo.DATA_DB_FIX, value);
                    break;

                case LauncherOffsetType.CONNECT_SETUP:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.CONNECT_SETUP))
                        OffsetsToApply.Add(LauncherInfo.CONNECT_SETUP, value);
                    break;

                case LauncherOffsetType.REGION_CODE:
                    for (int i = 0; i < LauncherInfo.REGION_CODE.Count; i++)
                    {
                        var region_code = LauncherInfo.REGION_CODE[i];
                        if (!OffsetsToApply.ContainsKey(region_code))
                            OffsetsToApply.Add(region_code, value);
                    }
                    break;

                case LauncherOffsetType.NEWS_PAGE:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.NEWS_PAGE))
                        OffsetsToApply.Add(LauncherInfo.NEWS_PAGE, value);
                    break;

                case LauncherOffsetType.LAUNCHER_SETTINGS_NAME:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.LAUNCHER_SETTINGS_NAME))
                        OffsetsToApply.Add(LauncherInfo.LAUNCHER_SETTINGS_NAME, value);
                    break;

                case LauncherOffsetType.LAUNCHER_LOG_NAME:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.LAUNCHER_LOG_NAME))
                        OffsetsToApply.Add(LauncherInfo.LAUNCHER_LOG_NAME, value);
                    break;

                case LauncherOffsetType.WEBSITE_LINK:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.WEBSITE_LINK))
                        OffsetsToApply.Add(LauncherInfo.WEBSITE_LINK, value);
                    break;

                case LauncherOffsetType.SEND_LOG_LINK:
                    if (!OffsetsToApply.ContainsKey(LauncherInfo.SEND_LOG_LINK))
                        OffsetsToApply.Add(LauncherInfo.SEND_LOG_LINK, value);
                    break;
            }
        }

        /// <summary>
        /// Apply the changes.
        /// </summary>
        public void ApplyChanges()
        {
            if (OffsetsToApply != null && OffsetsToApply.Count > 0)
            {
                // Reset the modified bytes to make
                // sure shit won't bloat.
                //WriteBytes = ReadBytes;
                foreach (var entry in OffsetsToApply)
                {
                    var offset = entry.Key;
                    var value = entry.Value;
                    if (offset != null)
                    {
                        //offset.OffsetInfo.WriteChanges(value);
                        offset.OffsetInfo.SetValue(value);
                        WriteChanges(offset);
                    }
                }
            }
        }

        /// <summary>
        /// Reset coming changes.
        /// </summary>
        public void ResetChanges()
        {
            if (OffsetsToApply.Count > 0) OffsetsToApply.Clear();
        }

        /// <summary>
        /// Write changes to the <see cref="Launcher"/> with the specified <see cref="LauncherOffset"/>.
        /// </summary>
        /// <param name="launcherOffset">The specified <see cref="LauncherOffset"/> to write.</param>
        public void WriteChanges(LauncherOffset launcherOffset)
        {
            if (launcherOffset != null)
            {
                var launcherOffsetInfo = launcherOffset.OffsetInfo;
                if (launcherOffsetInfo.Offset < WriteBytes.Length)
                {
                    using (var ms = new MemoryStream(WriteBytes))
                    using (var bw = new BinaryWriter(ms))
                    {
                        Patcher.Write(bw, launcherOffsetInfo.GetValue(), (int)launcherOffsetInfo.GetMaxLength(), (int)launcherOffsetInfo.Offset);
                    }
                }
            }
        }

        /// <summary>
        /// Save the <see cref="Launcher"/>.
        /// </summary>
        /// <param name="outputFile">The output file.</param>
        public void SaveToFile(string outputFile)
        {
            using (var fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (var bw = new BinaryWriter(fs))
            {
                // First apply the changes.
                ApplyChanges();

                // Then write the modified changes to file.
                bw.Write(GetModifiedBytes());
            }
        }

        /// <summary>
        /// Save the <see cref="LauncherInfo"/> to file.
        /// </summary>
        /// <param name="outputFile">The file to save the <see cref="LauncherInfo"/> to.</param>
        public void SaveDefinitionToFile(string outputFile)
        {
            using (var fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(LauncherInfo.ToJson());
            }
        }

        #endregion
    }
}
