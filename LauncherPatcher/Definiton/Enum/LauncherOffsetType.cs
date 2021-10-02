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

namespace LauncherPatcher.Definiton.Enum
{
    public enum LauncherOffsetType
    {
        #region BASE - HK & TW
        UNKNOWN,
        LAUNCHER_HEADER_CHECK,
        PATCH_LINK,
        GAME_ABBREVIATION_FOLDER_NAME,
        PATCH_DOWNLOAD_FOLDER_NAME,
        DATA_DB_FIX,
        CONNECT_SETUP,
        REGION_CODE,
        NEWS_PAGE,
        LAUNCHER_SETTINGS_NAME,
        LAUNCHER_LOG_NAME,
        WEBSITE_LINK,
        SEND_LOG_LINK,
        #endregion

        #region CN
        CN_BACKUP_PATCH_LINK,
        CN_HXSY_DATE_LINK,
        #endregion
    }
}
