using System;
using System.Runtime.InteropServices;

namespace UIBase.Interop.WinDef
{
    /// <summary>
    /// The RECTL structure defines a rectangle by the coordinates of its upper-left and lower-right corners.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable InconsistentNaming
    public struct RECTL
    {
        private long _left;
        private long _top;
        private long _right;
        private long _bottom;

        /// <summary>
        /// Specifies the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public long Left
        {
            get => _left;
            set => _left = value;
        }

        /// <summary>
        /// Specifies the x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public long Right
        {
            get => _right;
            set => _right = value;
        }

        /// <summary>
        /// Specifies the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public long Top
        {
            get => _top;
            set => _top = value;
        }

        /// <summary>
        /// Specifies the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public long Bottom
        {
            get => _bottom;
            set => _bottom = value;
        }

        /// <summary>
        /// Specifies the width of the rectangle.
        /// </summary>
        public long Width => _right - _left;

        /// <summary>
        /// Specifies the height of the rectangle.
        /// </summary>
        public long Height => _bottom - _top;

        /// <summary>
        /// Specifies the position of the rectangle.
        /// </summary>
        public POINTL Position => new() { X = _left, Y = _top };

        /// <summary>
        /// Specifies the size of the rectangle.
        /// </summary>
        public SIZE Size => new() { cx = Width, cy = Height };

        /// <summary>
        /// Sets offset of the rectangle.
        /// </summary>
        public void Offset(int dx, int dy)
        {
            _left += dx;
            _top += dy;
            _right += dx;
            _bottom += dy;
        }

        /// <summary>
        /// Combines two RECTLs
        /// </summary>
        public static RECTL Union(RECTL rect1, RECTL rect2)
        {
            return new RECTL
            {
                Left = Math.Min(rect1.Left, rect2.Left),
                Top = Math.Min(rect1.Top, rect2.Top),
                Right = Math.Max(rect1.Right, rect2.Right),
                Bottom = Math.Max(rect1.Bottom, rect2.Bottom),
            };
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is not RECTL rectl)
                return false;

            try
            {
                return rectl._bottom == _bottom
                       && rectl._left == _left
                       && rectl._right == _right
                       && rectl._top == _top;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _top.GetHashCode()
                ^ _bottom.GetHashCode()
                ^ _left.GetHashCode()
                ^ _right.GetHashCode();
        }
    }
}
