using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace UIBase.Interop
{
    internal static class Helpers
    {
        public static int Get_X_LParam(IntPtr lParam)
        {
            return (short)(lParam.ToInt32() & 0xFFFF);
        }

        public static int Get_Y_LParam(IntPtr lParam)
        {
            return (short)(lParam.ToInt32() >> 16);
        }

        public static bool IsWindowMaximized(IntPtr hWnd)
        {
            var placement = new User32.WINDOWPLACEMENT();
            if (User32.GetWindowPlacement(hWnd, placement))
            {
                return placement.showCmd == User32.SW.SHOWMAXIMIZED;
            }

            return false;
        }

        public static readonly System.Windows.Media.Color DefaultTitleBarActiveColor = System.Windows.Media.Color.FromArgb(255, 95, 95, 95);
        public static readonly System.Windows.Media.Color DefaultTitleBarDeActiveColor = System.Windows.Media.Color.FromArgb(255, 170, 170, 170);
        public static System.Windows.Media.Color GetTitleBarActiveColor()
        {
            using var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM");
            if (key == null)
            {
                return DefaultTitleBarActiveColor;
            }

            // 判断是否在标题栏和窗口边框使用主题色
            object? useCustomColor = key.GetValue("ColorPrevalence");
            if (useCustomColor == null)
            {
                return DefaultTitleBarActiveColor;
            }
            int on = System.Convert.ToInt32(useCustomColor);
            if (on == 0)
            {
                return DefaultTitleBarActiveColor;
            }

            // 取用户设置的主题色
            object? color = key.GetValue("ColorizationColor");
            if (color == null)
            {
                return DefaultTitleBarActiveColor;
            }
            int argbInt = System.Convert.ToInt32(color);
            byte a = (byte)((argbInt >> 24) & 0xFF);
            byte r = (byte)((argbInt >> 16) & 0xFF);
            byte g = (byte)((argbInt >> 8) & 0xFF);
            byte b = (byte)(argbInt & 0xFF);

            // TODO 貌似不需要设置透明度
            return System.Windows.Media.Color.FromArgb(255, r, g, b);
        }
    }
}
