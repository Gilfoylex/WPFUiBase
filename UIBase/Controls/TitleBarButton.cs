using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Media;
using UIBase.Extensions;
using UIBase.Interop;

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
    ///     <MyNamespace:TitleBarButton/>
    ///
    /// </summary>
    public class TitleBarButton : Button
    {
        private User32.WM_NCHITTEST _returnValue;
        private readonly Brush _defaultBackgroundBrush = Brushes.Transparent;

        static TitleBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitleBarButton), new FrameworkPropertyMetadata(typeof(TitleBarButton)));
        }

        public static readonly DependencyProperty ButtonTypeProperty = DependencyProperty.Register(
            nameof(ButtonType),
            typeof(TitleBarButtonType),
            typeof(TitleBarButton),
            new PropertyMetadata(TitleBarButtonType.Unknown, ButtonTypePropertyCallback)
        );

        public TitleBarButtonType ButtonType
        {
            get => (TitleBarButtonType)GetValue(ButtonTypeProperty);
            set => SetValue(ButtonTypeProperty, value);
        }

        /// <summary>
        /// Property for <see cref="MouseOverBackground"/>.
        /// </summary>
        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register(
                nameof(MouseOverBackground),
                typeof(Brush),
                typeof(Button),
                new PropertyMetadata(Border.BackgroundProperty.DefaultMetadata.DefaultValue)
            );

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set => SetValue(MouseOverBackgroundProperty, value);
        }

        private void UpdateReturnValue(TitleBarButtonType buttonType) =>
            _returnValue = buttonType switch
            {
                TitleBarButtonType.Unknown => User32.WM_NCHITTEST.HTNOWHERE,
                TitleBarButtonType.Minimize => User32.WM_NCHITTEST.HTMINBUTTON,
                TitleBarButtonType.Close => User32.WM_NCHITTEST.HTCLOSE,
                TitleBarButtonType.Restore => User32.WM_NCHITTEST.HTMAXBUTTON,
                TitleBarButtonType.Maximize => User32.WM_NCHITTEST.HTMAXBUTTON,
                _ => throw new ArgumentOutOfRangeException(nameof(buttonType), buttonType, null)
            };

        private static void ButtonTypePropertyCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
        )
        {
            var titleBarButton = (TitleBarButton)d;
            titleBarButton.UpdateReturnValue((TitleBarButtonType)e.NewValue);
        }

        private bool _isClickedDown;

        public bool IsHovered { get; private set; }
        /// <summary>
        /// Forces button background to change.
        /// </summary>
        public void Hover()
        {
            if (IsHovered)
                return;

            Background = MouseOverBackground;
            IsHovered = true;
        }

        /// <summary>
        /// Forces button background to change.
        /// </summary>
        public void RemoveHover()
        {
            if (!IsHovered)
                return;

            Background = _defaultBackgroundBrush;

            IsHovered = false;
            _isClickedDown = false;
        }

        /// <summary>
        /// Invokes click on the button.
        /// </summary>
        public void InvokeClick()
        {
            if (new ButtonAutomationPeer(this).GetPattern(PatternInterface.Invoke)
                is IInvokeProvider invokeProvider)
            {
                invokeProvider.Invoke();
            }

            _isClickedDown = false;
        }

        internal bool ReactToHWndHook(User32.WM msg, IntPtr lParam, out IntPtr returnIntPtr)
        {
            returnIntPtr = IntPtr.Zero;

            switch (msg)
            {
                case User32.WM.NCHITTEST:
                    if (this.IsMouseOverElement(lParam))
                    {
                        //Debug.WriteLine($"Hitting {ButtonType} | return code {_returnValue}");

                        Hover();
                        returnIntPtr = (IntPtr)_returnValue;
                        return true;
                    }

                    RemoveHover();
                    return false;

                case User32.WM.NCMOUSELEAVE: // Mouse leaves the window
                    RemoveHover();
                    return false;
                case User32.WM.NCLBUTTONDOWN when this.IsMouseOverElement(lParam): // Left button clicked down
                    _isClickedDown = true;
                    return true;
                case User32.WM.NCLBUTTONUP when _isClickedDown && this.IsMouseOverElement(lParam): // Left button clicked up
                    InvokeClick();
                    return true;
                default:
                    return false;
            }
        }
    }
}
