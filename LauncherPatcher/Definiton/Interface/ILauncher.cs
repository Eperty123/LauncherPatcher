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
using System.Collections.Generic;

namespace LauncherPatcher.Definiton.Interface
{
    public interface ILauncher
    {
        #region Private, Protected Variables
        Dictionary<LauncherOffset, string> OffsetsToApply { get; set; }
        #endregion

        #region Public Variables
        LauncherRegionType LauncherRegion { get; set; }
        string Header { get; set; }
        string Name { get; set; }
        bool Valid { get; set; }
        LauncherInfo LauncherInfo { get; set; }

        #endregion


        #region Public Methods

        bool IsCompatible();

        void LoadFile(string file);

        void LoadBytes(byte[] data);

        /// <summary>
        /// Load a <see cref="LauncherInfo"/> from string.
        /// </summary>
        /// <param name="json">The string containing a <see cref="LauncherInfo"/>.</param>
        void LoadDefinition(string json);

        /// <summary>
        /// Load a <see cref="LauncherInfo"/> from file.
        /// </summary>
        /// <param name="inputFile">A file containing a <see cref="LauncherInfo"/>.</param>
        void LoadDefinitionFromFile(string inputFile);

        /// <summary>
        /// Get the header of the <see cref="Launcher"/>.
        /// </summary>
        /// <returns>Returns the header string.</returns>
        string GetHeader();

        /// <summary>
        /// Set the <see cref="Launcher"/> wit the specified <see cref="LauncherInfo"/>.
        /// </summary>
        /// <param name="launcherInfo">The <see cref="LauncherInfo"/>.</param>
        void SetLauncherInfo(LauncherInfo launcherInfo);

        /// <summary>
        /// Set the <see cref="Launcher"/>'s <see cref="Enum.LauncherRegion"/>.
        /// </summary>
        /// <param name="launcherType"></param>
        void SetLauncherRegionType(LauncherRegionType launcherRegionType);

        /// <summary>
        /// Set the <see cref="LauncherOffset"/> with specified value.
        /// </summary>
        /// <param name="launcherType">The <see cref="LauncherOffsetTypes"/> to set value of.</param>
        /// <param name="value">The value to write.</param>
        void SetValue(LauncherOffsetType launcherType, string value);

        /// <summary>
        /// Apply the changes.
        /// </summary>
        void ApplyChanges();

        /// <summary>
        /// Reset coming changes.
        /// </summary>
        void ResetChanges();

        /// <summary>
        /// Write changes to the <see cref="Launcher"/> with the specified <see cref="LauncherOffset"/>.
        /// </summary>
        /// <param name="launcherOffset">The specified <see cref="LauncherOffset"/> to write.</param>
        void WriteChanges(LauncherOffset launcherOffset);

        /// <summary>
        /// Save the <see cref="Launcher"/>.
        /// </summary>
        /// <param name="outputFile">The output file.</param>
        void SaveToFile(string outputFile);

        /// <summary>
        /// Save the <see cref="LauncherInfo"/> to file.
        /// </summary>
        /// <param name="outputFile">The file to save the <see cref="LauncherInfo"/> to.</param>
        void SaveDefinitionToFile(string outputFile);

        /// <summary>
        /// Assign a <see cref="LauncherDefinition"/>. This is very important to assign!
        /// </summary>
        /// <param name="launcherDefinition">The launcher definition to assign.</param>
        void SetLauncherDefinition(LauncherDefinition launcherDefinition);
        #endregion
    }
}
