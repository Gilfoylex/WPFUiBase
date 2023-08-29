using System.Runtime.InteropServices;

namespace UIBase.Interop.WinDef
{
    /// <summary>
    /// The <see cref="POINTL"/> structure defines the x- and y-coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable InconsistentNaming
    public struct POINTL
    {
        public POINTL(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }
        /// <summary>
        /// Specifies the x-coordinate of the point.
        /// </summary>
        public long X;

        /// <summary>
        /// Specifies the y-coordinate of the point.
        /// </summary>
        public long Y;
    }
}
