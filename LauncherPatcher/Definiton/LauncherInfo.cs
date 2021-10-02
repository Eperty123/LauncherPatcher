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

using LauncherPatcher.Definiton.Enum;
using System.Collections.Generic;

namespace LauncherPatcher.Definiton
{
    public class LauncherInfo
    {
        #region Public Variables
        public string HEADER { get; set; }
        public LauncherRegionType LAUNCHER_REGION { get; set; }
        public LauncherOffset LAUNCHER_HEADER_CHECK { get; set; }
        public LauncherOffset PATCH_LINK { get; set; }
        public LauncherOffset GAME_ABBREVIATION_FOLDER_NAME { get; set; }
        public List<LauncherOffset> PATCH_DOWNLOAD_FOLDER_NAME { get; set; }
        public LauncherOffset DATA_DB_FIX { get; set; }
        public LauncherOffset CONNECT_SETUP { get; set; }
        public List<LauncherOffset> REGION_CODE { get; set; }
        public LauncherOffset NEWS_PAGE { get; set; }
        public LauncherOffset LAUNCHER_SETTINGS_NAME { get; set; }
        public LauncherOffset LAUNCHER_LOG_NAME { get; set; }
        public LauncherOffset WEBSITE_LINK { get; set; }
        public LauncherOffset SEND_LOG_LINK { get; set; }
        #endregion

        #region Constructors
        public LauncherInfo() { Initialize(); }
        #endregion

        #region Private Methods
        private void Initialize()
        {
            LAUNCHER_HEADER_CHECK = new LauncherOffset();
            PATCH_LINK = new LauncherOffset();
            GAME_ABBREVIATION_FOLDER_NAME = new LauncherOffset();
            PATCH_DOWNLOAD_FOLDER_NAME = new List<LauncherOffset>();
            DATA_DB_FIX = new LauncherOffset();
            CONNECT_SETUP = new LauncherOffset();
            REGION_CODE = new List<LauncherOffset>();
            NEWS_PAGE = new LauncherOffset();
            LAUNCHER_SETTINGS_NAME = new LauncherOffset();
            LAUNCHER_LOG_NAME = new LauncherOffset();
            WEBSITE_LINK = new LauncherOffset();
            SEND_LOG_LINK = new LauncherOffset();
        }
        #endregion
    }
}
