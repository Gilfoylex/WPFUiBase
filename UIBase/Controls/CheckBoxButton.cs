using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    ///     <MyNamespace:CheckBoxButton/>
    ///
    /// </summary>
    public class CheckBoxButton : CheckBox
    {
        static CheckBoxButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBoxButton), new FrameworkPropertyMetadata(typeof(CheckBoxButton)));
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(CheckBoxButton));
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty HoverIconProperty = DependencyProperty.Register("HoverIcon", typeof(ImageSource), typeof(CheckBoxButton));
        public ImageSource HoverIcon
        {
            get { return (ImageSource)GetValue(HoverIconProperty); }
            set { SetValue(HoverIconProperty, value); }
        }

        public static readonly DependencyProperty CheckIconProperty = DependencyProperty.Register("CheckIcon", typeof(ImageSource), typeof(CheckBoxButton));
        public ImageSource CheckIcon
        {
            get { return (ImageSource)GetValue(CheckIconProperty); }
            set { SetValue(CheckIconProperty, value); }
        }

        public static readonly DependencyProperty CheckHoverIconProperty = DependencyProperty.Register("CheckHoverIcon", typeof(ImageSource), typeof(CheckBoxButton));
        public ImageSource CheckHoverIcon
        {
            get { return (ImageSource)GetValue(CheckHoverIconProperty); }
            set { SetValue(CheckHoverIconProperty, value); }
        }


        /// <summary>
        /// Check 文字颜色
        /// </summary>
        public static readonly DependencyProperty CheckForegroundProperty =
            DependencyProperty.Register("CheckForeground", typeof(Brush), typeof(CheckBoxButton));
        public Brush CheckForeground
        {
            get => (Brush)GetValue(CheckForegroundProperty);
            set => SetValue(CheckForegroundProperty, value);
        }

        /// <summary>
        /// 图标宽度
        /// </summary>
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(CheckBoxButton));
        public double IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        /// <summary>
        /// 图标高度
        /// </summary>
        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register("IconHeight", typeof(double), typeof(CheckBoxButton));
        public double IconHeight
        {
            get { return (int)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }
    }
}
