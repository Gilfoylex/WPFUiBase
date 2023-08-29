using System.Windows;

namespace UIBase.Window
{
    public static class DpiHelper
    {
        public static double GetDpiScaleFromVisual(System.Windows.Media.Visual visual)
        {
            var source = PresentationSource.FromVisual(visual);

            var dpiX = 96.0;

            if (source?.CompositionTarget != null)
            {
                dpiX = 96.0 * source.CompositionTarget.TransformToDevice.M11;
            }

            return dpiX / 96.0;
        }

    }
}
