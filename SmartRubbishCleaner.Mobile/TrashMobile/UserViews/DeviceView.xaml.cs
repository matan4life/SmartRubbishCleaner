using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;


namespace TrashMobile.UserViews
{
    public partial class DeviceView : UserControl
    {
        public DeviceView()
        {
            this.InitializeComponent();
        }

        private void Close(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void OpenAddTrashCanDialog(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AddTrashCanDialog.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
    }
}
