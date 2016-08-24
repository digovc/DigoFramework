using System;
using System.Runtime.InteropServices;

namespace DigoFramework.Import
{
    public static class User32
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "SendMessage", ExactSpelling = false, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);
    }
}