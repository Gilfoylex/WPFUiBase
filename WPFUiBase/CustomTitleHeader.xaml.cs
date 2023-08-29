using System.Windows;
using System.Windows.Controls;

namespace WPFUiBase
{
    /// <summary>
    /// CustomTitleHeader.xaml 的交互逻辑
    /// </summary>
    public partial class CustomTitleHeader : UserControl
    {
        public CustomTitleHeader()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("自定义按钮点击");
        }
    }
}
