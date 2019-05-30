using CommonServiceLocator;
using System.Collections.Generic;
using TrashMobile.Models.Models;
using TrashMobile.ViewModels.ViewModels;
using Windows.UI.Xaml.Controls;

namespace TrashMobile.UserViews
{
    public sealed partial class DevicesView : Page
    {
        public DevicesView()
        {
            this.InitializeComponent();

            List<DeviceEfficiency> lstSource = new List<DeviceEfficiency>();
            lstSource.Add(new DeviceEfficiency() { DeviceId = 1, Value = 10 });
            lstSource.Add(new DeviceEfficiency() { DeviceId = 2, Value = 4 });
            lstSource.Add(new DeviceEfficiency() { DeviceId = 3, Value = 7 });
            lstSource.Add(new DeviceEfficiency() { DeviceId = 4, Value = 2 });
            lstSource.Add(new DeviceEfficiency() { DeviceId = 5, Value = 12 });
            lstSource.Add(new DeviceEfficiency() { DeviceId = 6, Value = 3 });

            this.LineChart.DataContext = lstSource;
        }

        private void OpenAddDeviceDialog(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AddDeviceDialog.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void OpenDevice(object sender, SelectionChangedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<DeviceViewModel>().TrashCanViewModel.GetActiveTrashCansCommand.Execute(null);
            this.DeviceDialog.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
    }
}
