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

namespace LauncherPatcher.Definiton.Configuration
{
    public class LauncherDefinition
    {
        #region Variables

        #region Singleton
        static LauncherDefinition Instance;
        #endregion

        #region Other

        #endregion

        #region OFFSET SETTINGS
        public static readonly int LAUNCHER_HEADER_OFFSET = 264;
        public static readonly int LAUNCHER_HEADER_OFFSET_READ_COUNT = 4;
        #endregion

        #region LAUNCHER HEADERS

        /// <summary>
        /// A dictionary of all the supported launchers. This can be extended through exporting a launcher definiton from a launcher instance.
        /// <br></br>
        /// This is the base by default.
        /// </summary>
        public List<LauncherInfo> SUPPORTED_AK_LAUNCHERS = new List<LauncherInfo>()
        {
            #region Aura Kingdom

            #region HK
            new LauncherInfo()
            {
                HEADER = "E0 8A 1B 56",
                GAME_TYPE = GameType.AURA_KINGDOM,
                LAUNCHER_REGION = LauncherRegionType.LAUNCHER_HK,
                LAUNCHER_HEADER_CHECK = new LauncherOffset(LauncherOffsetType.LAUNCHER_HEADER_CHECK, new LauncherOffsetInfo((uint)LAUNCHER_HEADER_OFFSET, (uint)LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8)),
                PATCH_LINK = new LauncherOffset(LauncherOffsetType.PATCH_LINK, new LauncherOffsetInfo(1132104, 16)),
                GAME_ABBREVIATION_FOLDER_NAME = new LauncherOffset(LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME, new LauncherOffsetInfo(1132140, 2)),

                #region Patch folder name
                PATCH_DOWNLOAD_FOLDER_NAME = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1131482, 31)),
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1131576, 31)),
                },
                #endregion

                DATA_DB_FIX = new LauncherOffset(LauncherOffsetType.DATA_DB_FIX, new LauncherOffsetInfo(1111730, 7)),
                CONNECT_SETUP = new LauncherOffset(LauncherOffsetType.CONNECT_SETUP, new LauncherOffsetInfo(1128492, 26)),

                #region Region code
                REGION_CODE = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1130036, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1132176, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(3666264, 2)),
                },
                #endregion

                NEWS_PAGE = new LauncherOffset(LauncherOffsetType.NEWS_PAGE, new LauncherOffsetInfo(1128600, 32)),
                LAUNCHER_SETTINGS_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_SETTINGS_NAME, new LauncherOffsetInfo(1131132, 15)),
                LAUNCHER_LOG_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_LOG_NAME, new LauncherOffsetInfo(1126348, 22)),
                WEBSITE_LINK = new LauncherOffset(LauncherOffsetType.WEBSITE_LINK, new LauncherOffsetInfo(1128672, 63)),
                SEND_LOG_LINK = new LauncherOffset(LauncherOffsetType.SEND_LOG_LINK, new LauncherOffsetInfo(1129396, 26))
            },
            new LauncherInfo()
            {
                HEADER =  "D4 6F 64 D0",
                GAME_TYPE = GameType.AURA_KINGDOM,
                LAUNCHER_REGION = LauncherRegionType.LAUNCHER_HK,
                LAUNCHER_HEADER_CHECK = new LauncherOffset(LauncherOffsetType.LAUNCHER_HEADER_CHECK, new LauncherOffsetInfo((uint)LAUNCHER_HEADER_OFFSET, (uint)LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8)),
                PATCH_LINK = new LauncherOffset(LauncherOffsetType.PATCH_LINK, new LauncherOffsetInfo(1132104, 16)),
                GAME_ABBREVIATION_FOLDER_NAME = new LauncherOffset(LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME, new LauncherOffsetInfo(1132140, 2)),

                #region Patch folder name
                PATCH_DOWNLOAD_FOLDER_NAME = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1131482, 31)),
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1131576, 31)),
                },
                #endregion

                DATA_DB_FIX = new LauncherOffset(LauncherOffsetType.DATA_DB_FIX, new LauncherOffsetInfo(1111730, 7)),
                CONNECT_SETUP = new LauncherOffset(LauncherOffsetType.CONNECT_SETUP, new LauncherOffsetInfo(1128492, 26)),

                #region Region code
                REGION_CODE = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1130036, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1132176, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(3666264, 2)),
                },
                #endregion

                NEWS_PAGE = new LauncherOffset(LauncherOffsetType.NEWS_PAGE, new LauncherOffsetInfo(1128600, 32)),
                LAUNCHER_SETTINGS_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_SETTINGS_NAME, new LauncherOffsetInfo(1131132, 15)),
                LAUNCHER_LOG_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_LOG_NAME, new LauncherOffsetInfo(1126348, 22)),
                WEBSITE_LINK = new LauncherOffset(LauncherOffsetType.WEBSITE_LINK, new LauncherOffsetInfo(1128672, 63)),
                SEND_LOG_LINK = new LauncherOffset(LauncherOffsetType.SEND_LOG_LINK, new LauncherOffsetInfo(1129396, 26))
            },

            new LauncherInfo()
            {
                HEADER = "1B 56 84 0B",
                GAME_TYPE = GameType.AURA_KINGDOM,
                LAUNCHER_REGION = LauncherRegionType.LAUNCHER_HK,
                LAUNCHER_HEADER_CHECK = new LauncherOffset(LauncherOffsetType.LAUNCHER_HEADER_CHECK, new LauncherOffsetInfo((uint)LAUNCHER_HEADER_OFFSET, (uint)LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8)),
                PATCH_LINK = new LauncherOffset(LauncherOffsetType.PATCH_LINK, new LauncherOffsetInfo(1132104 + 48, 16)),
                GAME_ABBREVIATION_FOLDER_NAME = new LauncherOffset(LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME, new LauncherOffsetInfo(1132140 + 48, 2)),

                #region Patch folder name
                PATCH_DOWNLOAD_FOLDER_NAME = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1131482 + 48, 31)),
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1131576 + 48, 31)),
                },
                #endregion

                DATA_DB_FIX = new LauncherOffset(LauncherOffsetType.DATA_DB_FIX, new LauncherOffsetInfo(1111730, 7)),
                CONNECT_SETUP = new LauncherOffset(LauncherOffsetType.CONNECT_SETUP, new LauncherOffsetInfo(1128492, 26)),

                #region Region code
                REGION_CODE = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1130036 + 48, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1132176 + 48, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(3666264 + 48, 2)),
                },
                #endregion

                NEWS_PAGE = new LauncherOffset(LauncherOffsetType.NEWS_PAGE, new LauncherOffsetInfo(1128600, 32)),
                LAUNCHER_SETTINGS_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_SETTINGS_NAME, new LauncherOffsetInfo(1131132 + 48, 15)),
                LAUNCHER_LOG_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_LOG_NAME, new LauncherOffsetInfo(1126348, 22)),
                WEBSITE_LINK = new LauncherOffset(LauncherOffsetType.WEBSITE_LINK, new LauncherOffsetInfo(1128672, 63)),
                SEND_LOG_LINK = new LauncherOffset(LauncherOffsetType.SEND_LOG_LINK, new LauncherOffsetInfo(1129396, 26))
            },

            #endregion

            #region TW

            new LauncherInfo()
            {
                HEADER = "00 00 00 00",
                GAME_TYPE = GameType.AURA_KINGDOM,
                LAUNCHER_REGION = LauncherRegionType.LAUNCHER_TW,
                LAUNCHER_HEADER_CHECK = new LauncherOffset(LauncherOffsetType.LAUNCHER_HEADER_CHECK, new LauncherOffsetInfo((uint)LAUNCHER_HEADER_OFFSET, (uint)LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8)),
                PATCH_LINK = new LauncherOffset(LauncherOffsetType.PATCH_LINK, new LauncherOffsetInfo(1169040, 19)),
                GAME_ABBREVIATION_FOLDER_NAME = new LauncherOffset(LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME, new LauncherOffsetInfo(1169080, 3)),

                #region Patch folder name
                PATCH_DOWNLOAD_FOLDER_NAME = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1168418, 31)),
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1168512, 31)),
                },
                #endregion

                DATA_DB_FIX = new LauncherOffset(LauncherOffsetType.DATA_DB_FIX, new LauncherOffsetInfo(1148594, 7)),
                CONNECT_SETUP = new LauncherOffset(LauncherOffsetType.CONNECT_SETUP, new LauncherOffsetInfo(1165356, 26)),

                #region Region code
                REGION_CODE = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1166948, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1169116, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(3707172, 2)),
                },
                #endregion

                NEWS_PAGE = new LauncherOffset(LauncherOffsetType.NEWS_PAGE, new LauncherOffsetInfo(1165464, 32)),
                LAUNCHER_SETTINGS_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_SETTINGS_NAME, new LauncherOffsetInfo(1168064, 15)),
                LAUNCHER_LOG_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_LOG_NAME, new LauncherOffsetInfo(1163212, 22)),
                WEBSITE_LINK = new LauncherOffset(LauncherOffsetType.WEBSITE_LINK, new LauncherOffsetInfo(1165536, 63)),
                SEND_LOG_LINK = new LauncherOffset(LauncherOffsetType.SEND_LOG_LINK, new LauncherOffsetInfo(1166308, 26))
            },

            #endregion

            #endregion
        };

        public List<LauncherInfo> SUPPORTED_EE_LAUNCHERS = new List<LauncherInfo>()
        {
            #region Eden Eternal

            #region TW

            new LauncherInfo()
            {
                HEADER = "00 00 00 00",
                GAME_TYPE = GameType.EDEN_ETERNAL,
                LAUNCHER_REGION = LauncherRegionType.LAUNCHER_TW,
                LAUNCHER_HEADER_CHECK = new LauncherOffset(LauncherOffsetType.LAUNCHER_HEADER_CHECK, new LauncherOffsetInfo((uint)LAUNCHER_HEADER_OFFSET, (uint)LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8)),
                PATCH_LINK = new LauncherOffset(LauncherOffsetType.PATCH_LINK, new LauncherOffsetInfo(1138664, 19)),
                GAME_ABBREVIATION_FOLDER_NAME = new LauncherOffset(LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME, new LauncherOffsetInfo(1138704, 6)),

                #region Patch folder name
                PATCH_DOWNLOAD_FOLDER_NAME = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1138042, 31)),
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1138136, 31)),
                },
                #endregion

                DATA_DB_FIX = new LauncherOffset(LauncherOffsetType.DATA_DB_FIX, new LauncherOffsetInfo(1119190, 7)),
                CONNECT_SETUP = new LauncherOffset(LauncherOffsetType.CONNECT_SETUP, new LauncherOffsetInfo(1135048, 26)),

                #region Region code
                REGION_CODE = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1136108, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1138748, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(3515560, 2)),
                },
                #endregion

                NEWS_PAGE = new LauncherOffset(LauncherOffsetType.NEWS_PAGE, new LauncherOffsetInfo(630228, 22)),
                LAUNCHER_SETTINGS_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_SETTINGS_NAME, new LauncherOffsetInfo(1137704, 15)),
                LAUNCHER_LOG_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_LOG_NAME, new LauncherOffsetInfo(1133056, 22)),
                WEBSITE_LINK = new LauncherOffset(LauncherOffsetType.WEBSITE_LINK, new LauncherOffsetInfo(1135188, 63)),
                SEND_LOG_LINK = new LauncherOffset(LauncherOffsetType.SEND_LOG_LINK, new LauncherOffsetInfo(1135976, 26))
            },

            #endregion

            #endregion
        };

        public List<LauncherInfo> SUPPORTED_TS_LAUNCHERS = new List<LauncherInfo>()
        {
            #region Eden Eternal

            #region TW

            new LauncherInfo()
            {
                HEADER = "00 00 00 00",
                GAME_TYPE = GameType.TWIN_SAGA,
                LAUNCHER_REGION = LauncherRegionType.LAUNCHER_TW,
                LAUNCHER_HEADER_CHECK = new LauncherOffset(LauncherOffsetType.LAUNCHER_HEADER_CHECK, new LauncherOffsetInfo((uint)LAUNCHER_HEADER_OFFSET, (uint)LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8)),
                PATCH_LINK = new LauncherOffset(LauncherOffsetType.PATCH_LINK, new LauncherOffsetInfo(1148560, 19)),
                GAME_ABBREVIATION_FOLDER_NAME = new LauncherOffset(LauncherOffsetType.GAME_ABBREVIATION_FOLDER_NAME, new LauncherOffsetInfo(1148600, 2)),

                #region Patch folder name
                PATCH_DOWNLOAD_FOLDER_NAME = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1147938, 31)),
                    new LauncherOffset(LauncherOffsetType.PATCH_DOWNLOAD_FOLDER_NAME, new LauncherOffsetInfo(1148032, 31)),
                },
                #endregion

                DATA_DB_FIX = new LauncherOffset(LauncherOffsetType.DATA_DB_FIX, new LauncherOffsetInfo(1128106, 7)),
                CONNECT_SETUP = new LauncherOffset(LauncherOffsetType.CONNECT_SETUP, new LauncherOffsetInfo(1144884, 26)),

                #region Region code
                REGION_CODE = new List<LauncherOffset>()
                {
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1146452, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(1148636, 2)),
                    new LauncherOffset(LauncherOffsetType.REGION_CODE, new LauncherOffsetInfo(6283032, 2)),
                },
                #endregion

                NEWS_PAGE = new LauncherOffset(LauncherOffsetType.NEWS_PAGE, new LauncherOffsetInfo(1144992, 33)),
                LAUNCHER_SETTINGS_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_SETTINGS_NAME, new LauncherOffsetInfo(1147588, 15)),
                LAUNCHER_LOG_NAME = new LauncherOffset(LauncherOffsetType.LAUNCHER_LOG_NAME, new LauncherOffsetInfo(1142724, 22)),
                WEBSITE_LINK = new LauncherOffset(LauncherOffsetType.WEBSITE_LINK, new LauncherOffsetInfo(1145064, 63)),
                SEND_LOG_LINK = new LauncherOffset(LauncherOffsetType.SEND_LOG_LINK, new LauncherOffsetInfo(1145826, 26))
            },

            #endregion

            #endregion
        };
        #endregion

        #endregion

        #region Methods

        #region Instance

        #endregion

        #region Static
        public static LauncherDefinition GetInstance()
        {
            return Instance == null ? Instance = new LauncherDefinition() : Instance;
        }
        #endregion

        #endregion
    }
}
