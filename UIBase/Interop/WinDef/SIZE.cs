using System.Runtime.InteropServices;

namespace UIBase.Interop.WinDef
{
    /// <summary>
    /// The SIZE structure defines the width and height of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable InconsistentNaming
    public struct SIZE
    {
        /// <summary>
        /// Specifies the rectangle's width. The units depend on which function uses this structure.
        /// </summary>
        public long cx;

        /// <summary>
        /// Specifies the rectangle's height. The units depend on which function uses this structure.
        /// </summary>
        public long cy;
    }

}
