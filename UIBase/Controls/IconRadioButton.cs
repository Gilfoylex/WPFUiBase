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
    ///     <MyNamespace:IconRadioButton/>
    ///
    /// </summary>
    public class IconRadioButton : RadioButton
    {
        static IconRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconRadioButton), new FrameworkPropertyMetadata(typeof(IconRadioButton)));
        }

        //  未选中
        public static readonly DependencyProperty UnSelectedIconProperty =
            DependencyProperty.Register("UnSelectedIcon", typeof(ImageSource), typeof(IconRadioButton));

        public ImageSource UnSelectedIcon
        {
            get { return (ImageSource)GetValue(UnSelectedIconProperty); }
            set { SetValue(UnSelectedIconProperty, value); }
        }

        //  未选中hover
        public static readonly DependencyProperty UnSelectedIconHoverProperty =
            DependencyProperty.Register("UnSelectedIconHover", typeof(ImageSource), typeof(IconRadioButton));

        public ImageSource UnSelectedIconHover
        {
            get { return (ImageSource)GetValue(UnSelectedIconHoverProperty); }
            set { SetValue(UnSelectedIconHoverProperty, value); }
        }

        //  选中
        public static readonly DependencyProperty SelectedIconProperty =
            DependencyProperty.Register("SelectedIcon", typeof(ImageSource), typeof(IconRadioButton));

        public ImageSource SelectedIcon
        {
            get { return (ImageSource)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        //  选中hover
        public static readonly DependencyProperty SelectedIconHoverProperty =
            DependencyProperty.Register("SelectedIconHover", typeof(ImageSource), typeof(IconRadioButton));

        public ImageSource SelectedIconHover
        {
            get { return (ImageSource)GetValue(SelectedIconHoverProperty); }
            set { SetValue(SelectedIconHoverProperty, value); }
        }

        //  图片宽度
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(int), typeof(IconRadioButton));

        public int IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        //图片高度
        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register("IconHeight", typeof(int), typeof(IconRadioButton));
        public int IconHeight
        {
            get { return (int)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }
    }
}
