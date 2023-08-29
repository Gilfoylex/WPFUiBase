using System;
using System.Windows;
using UIBase.Interop;

namespace UIBase.Extensions
{
    internal static class UiElementExtensions
    {
        /// <summary>
        /// Do not call it outside of NCHITTEST, NCLBUTTONUP, NCLBUTTONDOWN messages!
        /// </summary>
        /// <returns><see langword="true"/> if mouse is over the element. <see langword="false"/> otherwise.</returns>
        public static bool IsMouseOverElement(this UIElement element, IntPtr lParam)
        {
            // This method will be invoked very often and must be as simple as possible.
            if (lParam == IntPtr.Zero)
            {
                return false;
            }

            try
            {
                var mousePosScreen = new Point(Helpers.Get_X_LParam(lParam), Helpers.Get_Y_LParam(lParam));
                var bounds = new Rect(default(Point), element.RenderSize);

                Point mousePosRelative = element.PointFromScreen(mousePosScreen);

                return bounds.Contains(mousePosRelative);
            }
            catch
            {
                return false;
            }
        }
    }
}
