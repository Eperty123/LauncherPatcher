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

using System;
using System.IO;
using System.Text;

namespace LauncherPatcher.Definiton
{
    public static class Patcher
    {
        public static string ReadString(this BinaryReader br, int length, int offset, Encoding encoding)
        {
            br.BaseStream.Seek(offset, SeekOrigin.Begin);
            return encoding.GetString(br.ReadBytes(length));
        }

        public static void Write(this BinaryWriter bw, string text, int maxLength, int offset)
        {
            byte[] inBytes = new byte[maxLength];
            byte[] textBytes = text.ToUnicode();
            bw.BaseStream.Seek(offset, SeekOrigin.Begin);
            Buffer.BlockCopy(textBytes, 0, inBytes, 0, textBytes.Length);
            bw.Write(inBytes);
        }

        public static void Write(this BinaryWriter bw, byte[] text, int maxLength, int offset)
        {
            byte[] inBytes = new byte[maxLength];
            bw.BaseStream.Seek(offset, SeekOrigin.Begin);
            Buffer.BlockCopy(text, 0, inBytes, 0, text.Length);
            bw.Write(inBytes);
        }

        public static byte[] ToUnicode(this string text)
        {
            return Encoding.Unicode.GetBytes(text);
        }
    }
}
