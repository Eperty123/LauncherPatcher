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
using LauncherPatcher.Utility;
using System;
using System.IO;
using System.Text;

namespace LauncherPatcher.Definiton
{
    public class LauncherOffsetInfo : IDisposable
    {

        #region Private Variables

        protected byte[] ReadBytes;
        protected byte[] WriteBytes;
        protected string Value;
        protected bool Loaded;

        private Encoding Encoding = Encoding.Unicode;
        // Track whether Dispose has been called.
        protected bool Disposed = false;


        /// <summary>
        /// A letter in unicode is 2 in length. so text multiplies by 2 to get the right length.
        /// </summary>
        private readonly uint UNICODE_PADDING_LENGTH = 2;
        #endregion

        #region Public Variables

        /// <summary>
        /// The offset to use.
        /// </summary>
        public uint Offset { get; set; }

        public uint MaxLength { get; set; }

        /// <summary>
        /// The encoding to use for reading data.
        /// </summary>
        public EncodingType EncodingType { get; set; }
        #endregion

        #region Constructors

        ~LauncherOffsetInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        public LauncherOffsetInfo()
        {
        }

        /// <summary>
        /// Initialize a new instance with a file.
        /// </summary>
        public LauncherOffsetInfo(string file)
        {
            LoadFile(file);
        }

        /// <summary>
        /// Initialize a new instance with an offset, max length and encoding.
        /// </summary>
        public LauncherOffsetInfo(uint offset, uint maxLength, EncodingType encoding = EncodingType.UNICODE)
        {
            SetEncoding(encoding);
            SetOffset(offset);
            SetMaxLength(maxLength);
        }
        #endregion

        #region Public Methods
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.

            GC.SuppressFinalize(this);
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        /// Load a file.
        /// </summary>
        /// <param name="file">The file to load.</param>
        public virtual void LoadFile(string file)
        {
            if (File.Exists(file))
            {
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var br = new BinaryReader(fs))
                {
                    ReadBytes = br.ReadBytes((int)fs.Length);
                    WriteBytes = ReadBytes;
                    br.BaseStream.Seek(0, SeekOrigin.Begin);
                    Loaded = true;
                }
            }
        }

        /// <summary>
        /// Load data from byte array.
        /// </summary>
        /// <param name="data">The byte array with data.</param>
        public virtual void LoadBytes(byte[] data)
        {
            ReadBytes = data;
        }

        /// <summary>
        /// Get the read byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] GetReadBytes()
        {
            return ReadBytes;
        }

        /// <summary>
        /// Get the modified value byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] GetModifiedValueBytes()
        {
            byte[] inBytes = new byte[GetMaxLength()];
            byte[] textBytes = GetValueBytes();
            Buffer.BlockCopy(textBytes, 0, inBytes, 0, textBytes.Length);
            return inBytes;
        }

        /// <summary>
        /// Get the modified byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] GetModifiedBytes()
        {
            return WriteBytes;
        }

        /// <summary>
        /// Get the <see cref="Value"/> as byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] GetValueBytes()
        {
            byte[] text = null;

            switch (EncodingType)
            {
                case EncodingType.UNICODE:
                    text = Encoding.Unicode.GetBytes(Value);
                    break;
                case EncodingType.UTF8:
                    text = Encoding.UTF8.GetBytes(Value);
                    break;
            }
            return text;
        }

        /// <summary>
        /// Return the max length.
        /// </summary>
        /// <returns></returns>
        public uint GetMaxLength()
        {
            uint properLength = 0;
            switch (EncodingType)
            {
                case EncodingType.UNICODE:
                    properLength = MaxLength * UNICODE_PADDING_LENGTH;
                    break;

                case EncodingType.UTF8:
                    properLength = MaxLength;
                    break;
            }
            return properLength;
        }

        /// <summary>
        /// Return the max length for textboxes.
        /// </summary>
        /// <returns></returns>
        public uint GetMaxLengthForTextBox()
        {
            uint properLength = MaxLength;
            return properLength;
        }

        /// <summary>
        /// Get the value.
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Is the file loaded?
        /// </summary>
        /// <returns></returns>
        public bool IsLoaded()
        {
            return Loaded;
        }

        /// <summary>
        /// Set the encoding.
        /// </summary>
        /// <param name="encoding">Encoding to use.</param>
        public void SetEncoding(EncodingType encoding)
        {
            EncodingType = encoding;
            switch (EncodingType)
            {
                case EncodingType.UNICODE:
                    Encoding = Encoding.Unicode;
                    break;

                case EncodingType.UTF8:
                    Encoding = Encoding.UTF8;
                    break;
            }
        }

        /// <summary>
        /// Set offset.
        /// </summary>
        /// <param name="offset">The offset to use.</param>
        public void SetOffset(uint offset)
        {
            Offset = offset;
        }

        /// <summary>
        /// Set the max length.
        /// </summary>
        /// <param name="length">The length to use.</param>
        public void SetMaxLength(uint length)
        {
            MaxLength = length;
        }

        /// <summary>
        /// Set the value.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public void SetValue(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Read the data.
        /// </summary>
        /// <returns>Returns the read data.</returns>
        public string ReadDataAsString()
        {
            if (ReadBytes.Length > 0)
            {
                using (var ms = new MemoryStream(ReadBytes))
                using (var br = new BinaryReader(ms))
                {
                    Value = br.ReadString((int)GetMaxLength(), (int)Offset, Encoding);
                }
            }
            return Value;
        }

        /// <summary>
        /// Read data from a specific offset and length.
        /// </summary>
        /// <param name="offset">The offset to read data at.</param>
        /// <param name="length">The length of the data.</param>
        /// <param name="encoding">The encoding to read the data as.</param>
        /// <returns>Returns the read data.</returns>
        public string ReadDataAsString(int offset, int length, Encoding encoding)
        {
            string parsedText = null;
            if (ReadBytes.Length > 0)
            {
                using (var ms = new MemoryStream(ReadBytes))
                using (var br = new BinaryReader(ms))
                {
                    parsedText = br.ReadString(length, offset, encoding);
                }
            }
            return parsedText;
        }

        /// <summary>
        /// Read the data in hex as string.
        /// </summary>
        /// <returns>Returns the read data.</returns>
        public string ReadDataAsBytes()
        {
            string parsedText = null;
            if (ReadBytes != null && ReadBytes.Length > 0)
            {
                using (var ms = new MemoryStream(ReadBytes))
                using (var br = new BinaryReader(ms))
                {
                    br.BaseStream.Seek(Offset, SeekOrigin.Begin);
                    parsedText = br.ReadBytes((int)GetMaxLength()).ToHexString();
                }
            }
            return parsedText;
        }

        /// <summary>
        /// Read the specific offset's byte data as string.
        /// </summary>
        /// <param name="offset">The offset to read the byte data at.</param>
        /// <param name="length">The length of the byte data.</param>
        /// <returns></returns>
        public string ReadDataAsBytes(int offset, int length)
        {
            string parsedText = null;
            if (ReadBytes.Length > 0)
            {
                using (var ms = new MemoryStream(ReadBytes))
                using (var br = new BinaryReader(ms))
                {
                    br.BaseStream.Seek(offset, SeekOrigin.Begin);
                    parsedText = br.ReadBytes(length).ToHexString();
                }
            }
            return parsedText;
        }

        /// <summary>
        /// Write the the modified changes.
        /// </summary>
        /// <param name="modified"></param>
        public byte[] WriteChanges(string modified)
        {
            Value = modified;
            WriteBytes = new byte[GetMaxLength()];
            using (var ms = new MemoryStream(WriteBytes))
            using (var bw = new BinaryWriter(ms))
            {
                Patcher.Write(bw, GetValueBytes(), (int)GetMaxLength(), 0);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Write changes to the output file.
        /// </summary>
        /// <param name="outputFile">The path to save the file.</param>
        public void WriteChangesToFile(string outputFile)
        {
            using (var fs = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (var bw = new BinaryWriter(fs))
            {
                WriteChangesToFile(bw, Value);
            }
        }

        /// <summary>
        /// Write changes directly to a <see cref="BinaryWriter"/>.
        /// </summary>
        /// <param name="bw">The <see cref="BinaryWriter"/> to write to.</param>
        /// <param name="modified">The modified data to write.</param>
        public void WriteChangesToFile(BinaryWriter bw, string modified)
        {
            Value = modified;
            Patcher.Write(bw, GetValueBytes(), (int)GetMaxLength(), (int)Offset);
        }

        /// <summary>
        /// Close access to the file.
        /// </summary>
        public void Close()
        {
            ReadBytes = null;
            Loaded = false;
            WriteBytes = null;
            Value = null;
            MaxLength = 0;
        }

        #endregion

        #region Private Methods
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
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
    }
}
