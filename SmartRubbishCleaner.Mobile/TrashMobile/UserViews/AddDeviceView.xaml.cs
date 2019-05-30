using Windows.UI.Xaml.Controls;

namespace TrashMobile.UserViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddDeviceView : UserControl
    {
        public AddDeviceView()
        {
            this.InitializeComponent();
        }

        private void Close(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
