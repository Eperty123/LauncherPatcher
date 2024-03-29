﻿/*
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

using LauncherPatcher.Definiton;
using LauncherPatcher.Definiton.Configuration;
using LauncherPatcher.Definiton.Enum;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LauncherPatcher.Utility
{
    public static class LauncherUtility
    {
        readonly static LauncherDefinition LauncherDefinition = LauncherDefinition.GetInstance();

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Get the header of the <see cref="Launcher"/>.
        /// </summary>
        /// <returns>Returns the header string.</returns>
        public static string GetHeader(this string launcherFile)
        {
            using (var fs = new FileStream(launcherFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var br = new BinaryReader(fs))
            {
                var bytes = br.ReadBytes((int)fs.Length);

                var launcherInfo = new LauncherInfo();
                //launcherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo = new LauncherOffsetInfo(264, 4, EncodingTypes.UTF8);
                launcherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo = new LauncherOffsetInfo((uint)LauncherDefinition.LAUNCHER_HEADER_OFFSET, (uint)LauncherDefinition.LAUNCHER_HEADER_OFFSET_READ_COUNT, EncodingType.UTF8);
                launcherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo.LoadBytes(bytes);
                return launcherInfo.LAUNCHER_HEADER_CHECK.OffsetInfo.ReadDataAsBytes();
            }
        }

        public static bool HasDefinition(this List<LauncherInfo> defs, string header)
        {
            return defs.Any(x => x.HEADER == header);
        }

        public static LauncherInfo GetLauncherInfo(this List<LauncherInfo> defs, string header)
        {
            return defs.FirstOrDefault(x => x.HEADER == header);
        }
    }
}
