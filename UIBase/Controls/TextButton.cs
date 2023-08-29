using System.Windows;
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
    ///     <MyNamespace:TextButton/>
    ///
    /// </summary>
    public class TextButton : TextButtonBase
    {
        static TextButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextButton), new FrameworkPropertyMetadata(typeof(TextButton)));
        }

        public VerticalAlignment TextVerAlignment
        {
            get => (VerticalAlignment)GetValue(TextVerAlignmentProperty);
            set => SetValue(TextVerAlignmentProperty, value);
        }

        // Using a DependencyProperty as the backing store for TextHoriAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextVerAlignmentProperty =
            DependencyProperty.Register("TextVerAlignment", typeof(VerticalAlignment), typeof(TextButtonBase));


        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register("HoverBorderBrush", typeof(Brush), typeof(TextButtonBase));
        public Brush HoverBorderBrush
        {
            get => (Brush)GetValue(HoverBorderBrushProperty);
            set => SetValue(HoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PushBorderBrushProperty =
            DependencyProperty.Register("PushBorderBrush", typeof(Brush), typeof(TextButtonBase));
        public Brush PushBorderBrush
        {
            get => (Brush)GetValue(PushBorderBrushProperty);
            set => SetValue(PushBorderBrushProperty, value);
        }

        public static readonly DependencyProperty TextBtnTrimmingProperty = DependencyProperty.Register("TextBtnTrimming", typeof(TextTrimming), typeof(TextButtonBase));
        public TextTrimming TextBtnTrimming
        {
            get => (TextTrimming)GetValue(TextBtnTrimmingProperty);
            set => SetValue(TextBtnTrimmingProperty, value);
        }
    }
}
