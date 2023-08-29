namespace WPFUiBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UIBase.Window.BaseWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                var custom = new CustomTitleHeader();
                CustomTitleHeader!.Children.Add(custom);
                AddIgnoreCaptionElement(custom.CutomButton);
            };
        }
    }
}
