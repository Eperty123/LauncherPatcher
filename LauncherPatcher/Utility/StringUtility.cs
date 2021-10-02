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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LauncherPatcher.Utility
{
    public static class StringUtility
    {
        public static string GetLengthInfo(this Label label, TextBox textBox)
        {
            int txtBoxcurrLength = textBox.Text.Length;
            int txtBoxmaxLength = textBox.MaxLength;
            string currText = Regex.Replace(label.Text, @"(\w) (\([0-9]+\/[0-9]+\))", "$1", RegexOptions.IgnoreCase);
            return label.Text = $"{ currText} ({txtBoxcurrLength}/{txtBoxmaxLength})";
        }

        public static void SetMaxLength(this TextBox textBox, int maxLength)
        {
            textBox.MaxLength = maxLength;
        }

        public static void SetMaxLength(this TextBox textBox, uint maxLength)
        {
            textBox.MaxLength = (int)maxLength;
        }

        public static void SetText(this TextBox textBox, string text)
        {
            textBox.Text = text;
        }

        public static string ToHexString(this byte[] b)
        {
            var data = BitConverter.ToString(b).Replace("-", " ").ToUpper();
            return data;
        }

        public static string CleanString(string s)
        {
            return s
                .Replace(" ", "")
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace("\t", "")
                .Trim();
        }

        public static string ToFormatedHexString(this byte[] b)
        {
            if (b == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            string cleaned = CleanString(ToHexString(b));

            int c = 0;
            for (int i = 0; i + 1 < cleaned.Length; i += 2)
            {
                sb.Append($"{cleaned.ElementAt(i)}{cleaned.ElementAt(i + 1)}");
                sb.Append(c % 16 == 15 ? Environment.NewLine : " ");
                c++;
            }

            return sb.ToString();
        }

        public static byte[] ToByteArray(this string raw)
        {
            string hex = CleanString(raw);
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];

            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return bytes;
        }

        public static int ByteArrayLength(this string input)
        {
            return input.ToByteArray().Length;
        }

        public static bool ContainsString(this string source, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
        {
            return toCheck?.IndexOf(source, comp) >= 0;
        }

        public static byte[] ReadAllBytes(string inputFile, int buffer_size = 32768)
        {
            return ReadFully(inputFile, buffer_size);
        }


        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length (in MB)</param>
        public static byte[] ReadFully(string file, int buffer_size = 32768)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.

            using (var fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] buffer = new byte[buffer_size];
                long read = 0;

                int chunk;
                while ((chunk = fs.Read(buffer, (int)read, buffer.Length - (int)read)) > 0)
                {
                    read += chunk;

                    // If we've reached the end of our buffer, check to see if there's
                    // any more information
                    if (read == buffer.Length)
                    {
                        int nextByte = fs.ReadByte();

                        // End of stream? If so, we're done
                        if (nextByte == -1)
                        {
                            return buffer;
                        }

                        // Nope. Resize the buffer, put in the byte we've just
                        // read, and continue
                        byte[] newBuffer = new byte[buffer.Length * 2];
                        Array.Copy(buffer, newBuffer, buffer.Length);
                        newBuffer[read] = (byte)nextByte;
                        buffer = newBuffer;
                        read++;
                    }
                }
                // Buffer is now too big. Shrink it.
                byte[] ret = new byte[read];
                Array.Copy(buffer, ret, read);
                return ret;
            }
        }
    }
}
