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
    ///     <MyNamespace:TextRadioButton/>
    ///
    /// </summary>
    public class TextRadioButton : RadioButton
    {
        static TextRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextRadioButton), new FrameworkPropertyMetadata(typeof(TextRadioButton)));
        }

        public CornerRadius BorderRadius
        {
            get { return (CornerRadius)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderRadiusProperty =
            DependencyProperty.Register("BorderRadius", typeof(CornerRadius), typeof(TextRadioButton));


        public TextAlignment TextHoriAlignment
        {
            get { return (TextAlignment)GetValue(TextHoriAlignmentProperty); }
            set { SetValue(TextHoriAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextHoriAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextHoriAlignmentProperty =
            DependencyProperty.Register("TextHoriAlignment", typeof(TextAlignment), typeof(TextRadioButton));

        public VerticalAlignment TextVerAlignment
        {
            get { return (VerticalAlignment)GetValue(TextVerAlignmentProperty); }
            set { SetValue(TextVerAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextHoriAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextVerAlignmentProperty =
            DependencyProperty.Register("TextVerAlignment", typeof(VerticalAlignment), typeof(TextRadioButton));

        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(TextRadioButton));


        public Brush HoverForeground
        {
            get { return (Brush)GetValue(HoverForegroundProperty); }
            set { SetValue(HoverForegroundProperty, value); }
        }

        public static readonly DependencyProperty HoverForegroundProperty =
           DependencyProperty.Register("HoverForeground", typeof(Brush), typeof(TextRadioButton));


        public Brush PushForeground
        {
            get { return (Brush)GetValue(PushForegroundProperty); }
            set { SetValue(PushForegroundProperty, value); }
        }

        public static readonly DependencyProperty PushForegroundProperty =
            DependencyProperty.Register("PushForeground", typeof(Brush), typeof(TextRadioButton));


        /// <summary>
        /// Hover 背景
        /// </summary>
        public static readonly DependencyProperty HoverBackgroundProperty =
           DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(TextRadioButton));
        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }

        /// <summary>
        /// Push 背景
        /// </summary>
        public static readonly DependencyProperty PushBackgroundProperty =
           DependencyProperty.Register("PushBackground", typeof(Brush), typeof(TextRadioButton));
        public Brush PushBackground
        {
            get { return (Brush)GetValue(PushBackgroundProperty); }
            set { SetValue(PushBackgroundProperty, value); }
        }


        //  色块
        public static readonly DependencyProperty BlockColorProperty =
            DependencyProperty.Register("BlockColor", typeof(SolidColorBrush), typeof(TextRadioButton));
        public SolidColorBrush BlockColor
        {
            get { return (SolidColorBrush)GetValue(BlockColorProperty); }
            set { SetValue(BlockColorProperty, value); }
        }

        public double BlockWidth
        {
            get { return (double)GetValue(BlockWidthProperty); }
            set { SetValue(BlockWidthProperty, value); }
        }

        public static readonly DependencyProperty BlockWidthProperty =
            DependencyProperty.Register("BlockWidth", typeof(double), typeof(TextRadioButton));

        public double BlockHeight
        {
            get { return (double)GetValue(BlockHeightProperty); }
            set { SetValue(BlockHeightProperty, value); }
        }

        public static readonly DependencyProperty BlockHeightProperty =
            DependencyProperty.Register("BlockHeight", typeof(double), typeof(TextRadioButton));

        public HorizontalAlignment BlockHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(BlockHorizontalAlignmentProperty); }
            set { SetValue(BlockHorizontalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty BlockHorizontalAlignmentProperty =
            DependencyProperty.Register("BlockHorizontalAlignment", typeof(HorizontalAlignment), typeof(TextRadioButton));


        public VerticalAlignment BlockVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(BlockVerticalAlignmentProperty); }
            set { SetValue(BlockVerticalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty BlockVerticalAlignmentProperty =
            DependencyProperty.Register("BlockVerticalAlignment", typeof(VerticalAlignment), typeof(TextRadioButton));


        public TextTrimming TextTrimming
        {
            get { return (TextTrimming)GetValue(TextTrimmingProperty); }
            set { SetValue(TextTrimmingProperty, value); }
        }
        public static readonly DependencyProperty TextTrimmingProperty =
            DependencyProperty.Register("TextTrimming", typeof(TextTrimming), typeof(TextRadioButton));
    }
}
