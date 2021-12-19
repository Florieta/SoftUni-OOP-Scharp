using System;
using System.Runtime.InteropServices;

namespace MockingDemo
{
    public class MessageBoxWriter : IWriter
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public void Write(string text)
        {
            MessageBox(new IntPtr(0), text, text, 0);
        }
    }
}
