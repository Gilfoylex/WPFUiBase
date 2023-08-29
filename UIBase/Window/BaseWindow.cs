using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using UIBase.Controls;
using UIBase.Interop;
using Point = System.Windows.Point;

namespace UIBase.Window
{
    public class BaseWindow : System.Windows.Window
    {
        static BaseWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow),
                new FrameworkPropertyMetadata(typeof(BaseWindow)));
        }

        public static readonly DependencyProperty IsMaximizedProperty = DependencyProperty.Register(
            nameof(IsMaximized),
            typeof(bool),
            typeof(BaseWindow),
            new PropertyMetadata(false)
        );

        public static readonly DependencyProperty TemplateButtonCommandProperty =
            DependencyProperty.Register(
                nameof(TemplateButtonCommand),
                typeof(RelayCommand<TitleBarButtonType>),
                typeof(BaseWindow),
                new PropertyMetadata(null)
            );

        public RelayCommand<TitleBarButtonType> TemplateButtonCommand =>
            (RelayCommand<TitleBarButtonType>)GetValue(TemplateButtonCommandProperty);

        public bool IsMaximized
        {
            get => (bool)GetValue(IsMaximizedProperty);
            internal set => SetValue(IsMaximizedProperty, value);
        }

        private readonly TitleBarButton[] _buttons = new TitleBarButton[3];
        private readonly List<FrameworkElement> _ignoreCaptionElements = new List<FrameworkElement>();

        public BaseWindow()
        {
            StateChanged += OnStateChanged;
            Activated += (sender, args) => OnActivated();
            Deactivated += (sender, args) => OnDeactivated();

            SetValue(
                TemplateButtonCommandProperty,
                new RelayCommand<TitleBarButtonType>(OnTemplateButtonClick)
            );
        }

        private void OnActivated()
        {
            _titleBarTopSide!.Background = new System.Windows.Media.SolidColorBrush(Helpers.GetTitleBarActiveColor());
        }

        private void OnDeactivated()
        {
            _titleBarTopSide!.Background = new System.Windows.Media.SolidColorBrush(Helpers.DefaultTitleBarDeActiveColor);
        }

        private void OnStateChanged(object? sender, EventArgs e)
        {
            if (IsMaximized != (WindowState == WindowState.Maximized))
                IsMaximized = WindowState == WindowState.Maximized;

            //_rootGrid!.Margin = WindowState switch
            //{
            //    WindowState.Maximized => GetMaximizeBorderThickness(new WindowInteropHelper(this).Handle),
            //    _ => new Thickness(0d)
            //};
        }

        private Grid? _rootGrid;
        private Grid? _titleBarTopSide;
        private Grid? _titleBar;
        public Grid? CustomTitleHeader { get; private set; }

        public override void OnApplyTemplate()
        {
            _rootGrid = GetRequiredTemplateChild<Grid>("PART_RootGrid");
            _titleBarTopSide = GetRequiredTemplateChild<Grid>("PART_TitleBarTopSide");
            _titleBar = GetRequiredTemplateChild<Grid>("PART_TitleBar");
            CustomTitleHeader = GetRequiredTemplateChild<Grid>("PART_CustomTitleHeader");
            var minimizeBtn = GetRequiredTemplateChild<TitleBarButton>("PART_MinimizeButton");
            var maximizeBtn = GetRequiredTemplateChild<TitleBarButton>("PART_MaximizeButton");
            var closeBtn = GetRequiredTemplateChild<TitleBarButton>("PART_CloseButton");

            _buttons[0] = maximizeBtn;
            _buttons[1] = minimizeBtn;
            _buttons[2] = closeBtn;

            base.OnApplyTemplate();
        }

        public T GetRequiredTemplateChild<T>(string childName) where T : DependencyObject
        {
            if (GetTemplateChild(childName) is not T child)
            {
                throw new NullReferenceException(childName);
            }

            return child;
        }

        protected virtual void OnCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var handle = new WindowInteropHelper(this).Handle;
            var source = HwndSource.FromHwnd(handle);
            source!.AddHook(new HwndSourceHook(WpfHandleWindowMsg));
        }

        private IntPtr WpfHandleWindowMsg(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var message = (User32.WM) msg;

            if (message is User32.WM.NCHITTEST
                or User32.WM.NCMOUSELEAVE
                or User32.WM.NCLBUTTONDOWN
                or User32.WM.NCLBUTTONUP)
            {
                foreach (var button in _buttons)
                {
                    if (!button.ReactToHWndHook(message, lParam, out var returnIntPtr))
                    {
                        continue;
                    }

                    //It happens that the background is not removed from the buttons and you can make all the buttons are in the IsHovered=true
                    //It cleans up
                    foreach (var anotherButton in _buttons)
                    {
                        if (anotherButton == button)
                            continue;

                        if (anotherButton.IsHovered && button.IsHovered)
                        {
                            anotherButton.RemoveHover();
                        }
                    }

                    handled = true;
                    return returnIntPtr;
                }
            }

            switch (message)
            {
                case User32.WM.CREATE:
                {
                    if (!User32.GetWindowRect(hWnd, out var rect))
                    {
                        break;
                    }

                    User32.SetWindowPos(hWnd, User32.HWND_TOPMOST, rect.Left, rect.Top, rect.Width, rect.Height,
                        User32.SWP.FRAMECHANGED | User32.SWP.NOMOVE | User32.SWP.NOSIZE);
                }break;

                case User32.WM.NCCALCSIZE:
                {
                    if (wParam == IntPtr.Zero)
                    {
                        handled = true;
                        return User32.DefWindowProc(hWnd, message, wParam, lParam);
                    }

                    var clientArea = Marshal.PtrToStructure<Interop.WinDef.RECT>(lParam);
                    var dpi = User32.GetDpiForWindow(hWnd);
                    var frameX = User32.GetSystemMetricsForDpi(User32.SM.CXFRAME, dpi);
                    var frameY = User32.GetSystemMetricsForDpi(User32.SM.CYFRAME, dpi);
                    var padding = User32.GetSystemMetricsForDpi(User32.SM.CXPADDEDBORDER, dpi);

                    clientArea.Right -= frameX + padding;
                    clientArea.Left += frameX + padding;
                    clientArea.Bottom -= frameY + padding;
                    if (Helpers.IsWindowMaximized(hWnd))
                    {
                        var sizeY = User32.GetSystemMetricsForDpi(User32.SM.CYSIZEFRAME, dpi);
                        clientArea.Top = clientArea.Top + padding + sizeY;
                    }

                    Marshal.StructureToPtr(clientArea, lParam, false);
                    handled = true;
                } break;

                case User32.WM.NCHITTEST:
                {
                    IntPtr hit = User32.DefWindowProc(hWnd, message, wParam, lParam);
                    switch (hit.ToInt32())
                    {
                        case (int)User32.WM_NCHITTEST.HTNOWHERE:
                        case (int)User32.WM_NCHITTEST.HTRIGHT:
                        case (int)User32.WM_NCHITTEST.HTLEFT:
                        case (int)User32.WM_NCHITTEST.HTTOPLEFT:
                        case (int)User32.WM_NCHITTEST.HTTOP:
                        case (int)User32.WM_NCHITTEST.HTTOPRIGHT:
                        case (int)User32.WM_NCHITTEST.HTBOTTOMRIGHT:
                        case (int)User32.WM_NCHITTEST.HTBOTTOM:
                        case (int)User32.WM_NCHITTEST.HTBOTTOMLEFT:
                        {
                            handled = true;
                            return hit;
                        }
                    }

                    uint dpi = User32.GetDpiForWindow(hWnd);
                    int frameY = User32.GetSystemMetricsForDpi(User32.SM.CYFRAME, dpi);
                    int padding = User32.GetSystemMetricsForDpi(User32.SM.CXPADDEDBORDER, dpi);

                    Interop.WinDef.POINT mousePoint = new Interop.WinDef.POINT(Helpers.Get_X_LParam(lParam), Helpers.Get_Y_LParam(lParam));
                    var screenPoint = new Point(mousePoint.X, mousePoint.Y);
                    User32.ScreenToClient(hWnd, ref mousePoint);
                    if (mousePoint.Y > 0
                        && mousePoint.Y < frameY + padding)
                    {
                        handled = true;
                        return new IntPtr((int)User32.WM_NCHITTEST.HTTOP);
                    }

                    var titlebarRect = GetElementScreenRect(_titleBar!, dpi);
                    if (titlebarRect.Contains(screenPoint)
                        && !InIgnoreCaptionElements(screenPoint, dpi))
                    {
                        handled = true;
                        return new IntPtr((int)User32.WM_NCHITTEST.HTCAPTION);
                    }

                    handled = true;
                    return new IntPtr((int)User32.WM_NCHITTEST.HTCLIENT);
                }

                case User32.WM.SETTINGCHANGE:
                {
                    var changedSetting = Marshal.PtrToStringAuto(lParam);
                    if (string.IsNullOrEmpty(changedSetting))
                    {
                        // handle error
                        break;
                    }

                    if (changedSetting == "ImmersiveColorSet" // dark/light mode
                        || changedSetting == "WindowsThemeElement") // high contrast mode
                    {
                        if (IsActive)
                        {
                            OnActivated();
                        }
                        else
                        {
                            OnDeactivated();
                        }
                    }
                } break;
            }

            return IntPtr.Zero;
        }

        public static readonly RoutedEvent CloseClickedEvent = EventManager.RegisterRoutedEvent(
            nameof(CloseClicked),
            RoutingStrategy.Bubble,
            typeof(TypedEventHandler<BaseWindow, RoutedEventArgs>),
            typeof(BaseWindow)
        );

        public static readonly RoutedEvent MaximizeClickedEvent = EventManager.RegisterRoutedEvent(
            nameof(MaximizeClicked),
            RoutingStrategy.Bubble,
            typeof(TypedEventHandler<BaseWindow, RoutedEventArgs>),
            typeof(BaseWindow)
        );

        public static readonly RoutedEvent MinimizeClickedEvent = EventManager.RegisterRoutedEvent(
            nameof(MinimizeClicked),
            RoutingStrategy.Bubble,
            typeof(TypedEventHandler<BaseWindow, RoutedEventArgs>),
            typeof(BaseWindow)
        );

        public event TypedEventHandler<BaseWindow, RoutedEventArgs> CloseClicked
        {
            add => AddHandler(CloseClickedEvent, value);
            remove => RemoveHandler(CloseClickedEvent, value);
        }

        public event TypedEventHandler<BaseWindow, RoutedEventArgs> MaximizeClicked
        {
            add => AddHandler(MaximizeClickedEvent, value);
            remove => RemoveHandler(MaximizeClickedEvent, value);
        }

        public event TypedEventHandler<BaseWindow, RoutedEventArgs> MinimizeClicked
        {
            add => AddHandler(MinimizeClickedEvent, value);
            remove => RemoveHandler(MinimizeClickedEvent, value);
        }

        private void OnTemplateButtonClick(TitleBarButtonType buttonType)
        {
            switch (buttonType)
            {
                case TitleBarButtonType.Maximize
                    or TitleBarButtonType.Restore:
                    RaiseEvent(new RoutedEventArgs(MaximizeClickedEvent, this));
                    MaximizeWindow();
                    break;

                case TitleBarButtonType.Close:
                    RaiseEvent(new RoutedEventArgs(CloseClickedEvent, this));
                    OnCloseBtn_Click(this, new RoutedEventArgs(CloseClickedEvent, this));
                    break;

                case TitleBarButtonType.Minimize:
                    RaiseEvent(new RoutedEventArgs(MinimizeClickedEvent, this));
                    MinimizeWindow();
                    break;
            }
        }

        private void MaximizeWindow()
        {
            if (WindowState == WindowState.Normal)
            {
                IsMaximized = true;
                WindowState = WindowState.Maximized;
            }
            else
            {
                IsMaximized = false;
                WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow()
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 标题栏增加的控件需要加入忽略的列表，因为标题栏空白区域默认是返回
        /// WM_NCHITTEST.HTCAPTION，如果不忽略会导致控件无法相应鼠标事件
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddIgnoreCaptionElement(FrameworkElement element)
        {
            if (!UIBase.Window.DispatchHelper.CheckMainAccess())
                throw new InvalidOperationException("Access invalid. This operation needs to be called on UI the thread");

            _ignoreCaptionElements.Add(element);
        }

        private bool InIgnoreCaptionElements(Point screenMousePoint, uint dpi)
        {
            foreach (var element in _ignoreCaptionElements)
            {
                var rect = GetElementScreenRect(element, dpi);
                if (rect.Contains(screenMousePoint))
                    return true;
            }

            return false;
        }

        private static Rect GetElementScreenRect(FrameworkElement element, uint dpi)
        {
            var screenPoint = element.PointToScreen(new Point(0, 0));
            return new Rect()
            {
                X = screenPoint.X,
                Y = screenPoint.Y,
                Width = element.ActualWidth * dpi / 96.0,
                Height = element.ActualHeight * dpi / 96.0
            };
        }
    }
}
