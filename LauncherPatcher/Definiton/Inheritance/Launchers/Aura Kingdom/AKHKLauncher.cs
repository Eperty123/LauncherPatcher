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

namespace LauncherPatcher.Definiton.Inheritance.Launchers.AuraKingdom
{
    public class AKHKLauncher : Launcher
    {
        #region Constructors


        public AKHKLauncher(LauncherRegionType launcherRegionType, string header) : base(launcherRegionType, header)
        {
        }

        public AKHKLauncher(LauncherInfo launcherInfo, string file) : base(launcherInfo, file)
        {
        }

        public AKHKLauncher(LauncherRegionType launcherRegionType, string header, LauncherInfo launcherInfo) : base(launcherRegionType, header, launcherInfo)
        {
        }

        #endregion
    }
}
