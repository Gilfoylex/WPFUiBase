using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UIBase.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:UIBase.controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:UIBase.controls;assembly=UIBase.controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:IconTextButtonBase/>
    ///
    /// </summary>
    public abstract class IconTextButtonBase : Button
    {

        #region Icon

        /// <summary>
        /// Normal 状态图标
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(IconTextButtonBase));
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Hover 状态图标
        /// </summary>
        public static readonly DependencyProperty HoverIconProperty =
           DependencyProperty.Register("HoverIcon", typeof(ImageSource), typeof(IconTextButtonBase));
        public ImageSource HoverIcon
        {
            get { return (ImageSource)GetValue(HoverIconProperty); }
            set { SetValue(HoverIconProperty, value); }
        }

        /// <summary>
        /// Push 状态图标
        /// </summary>
        public static readonly DependencyProperty PushIconProperty =
           DependencyProperty.Register("PushIcon", typeof(ImageSource), typeof(IconTextButtonBase));
        public ImageSource PushIcon
        {
            get { return (ImageSource)GetValue(PushIconProperty); }
            set { SetValue(PushIconProperty, value); }
        }

        /// <summary>
        /// Disable 状态图标
        /// </summary>
        public static readonly DependencyProperty DisableIconProperty =
            DependencyProperty.Register("DisableIcon", typeof(ImageSource), typeof(IconTextButtonBase));
        public ImageSource DisableIcon
        {
            get { return (ImageSource)GetValue(DisableIconProperty); }
            set { SetValue(DisableIconProperty, value); }
        }

        /// <summary>
        /// 图标间距
        /// </summary>
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(IconTextButtonBase));
        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        /// <summary>
        /// 图标宽度
        /// </summary>
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(IconTextButtonBase));
        public double IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        /// <summary>
        /// 图标高度
        /// </summary>
        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register("IconHeight", typeof(double), typeof(IconTextButtonBase));
        public double IconHeight
        {
            get { return (int)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        #endregion

        #region Text

        /// <summary>
        /// Hover 文字颜色
        /// </summary>
        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.Register("HoverForeground", typeof(Brush), typeof(IconTextButtonBase));
        public Brush HoverForeground
        {
            get { return (Brush)GetValue(HoverForegroundProperty); }
            set { SetValue(HoverForegroundProperty, value); }
        }

        /// <summary>
        /// Push 文字颜色
        /// </summary>
        public static readonly DependencyProperty PushForegroundProperty =
            DependencyProperty.Register("PushForeground", typeof(Brush), typeof(IconTextButtonBase));
        public Brush PushForeground
        {
            get { return (Brush)GetValue(PushForegroundProperty); }
            set { SetValue(PushForegroundProperty, value); }
        }

        /// <summary>
        /// Disable 文字颜色
        /// </summary>
        public static readonly DependencyProperty DisableForegroundProperty =
            DependencyProperty.Register("DisableForeground", typeof(Brush), typeof(IconTextButtonBase));
        public Brush DisableForeground
        {
            get { return (Brush)GetValue(DisableForegroundProperty); }
            set { SetValue(DisableForegroundProperty, value); }
        }

        /// <summary>
        /// 文字对齐方式
        /// </summary>
        public static readonly DependencyProperty horAlignmentProperty =
            DependencyProperty.Register("horAlignment", typeof(HorizontalAlignment), typeof(IconTextButtonBase));
        public HorizontalAlignment horAlignment
        {
            get { return (HorizontalAlignment)GetValue(horAlignmentProperty); }
            set { SetValue(horAlignmentProperty, value); }
        }

        /// <summary>
        /// 文字间距
        /// </summary>
        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(IconTextButtonBase));
        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        #endregion

        #region Background

        /// <summary>
        /// Hover 背景
        /// </summary>
        public static readonly DependencyProperty HoverBackgroundProperty =
           DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(IconTextButtonBase));
        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }

        /// <summary>
        /// Push 背景
        /// </summary>
        public static readonly DependencyProperty PushBackgroundProperty =
           DependencyProperty.Register("PushBackground", typeof(Brush), typeof(IconTextButtonBase));
        public Brush PushBackground
        {
            get { return (Brush)GetValue(PushBackgroundProperty); }
            set { SetValue(PushBackgroundProperty, value); }
        }

        /// <summary>
        /// Disable 背景
        /// </summary>
        public static readonly DependencyProperty DisableBackgroundProperty =
           DependencyProperty.Register("DisableBackground", typeof(Brush), typeof(IconTextButtonBase));
        public Brush DisableBackground
        {
            get { return (Brush)GetValue(DisableBackgroundProperty); }
            set { SetValue(DisableBackgroundProperty, value); }
        }

        #endregion

    }
}
