namespace TrashMobile.UserViews
{
    using CommonServiceLocator;
    using TrashMobile.Models.Models;
    using TrashMobile.ViewModels.ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Maps;

    public sealed partial class AddTrashCanView : UserControl
    {
        public AddTrashCanView()
        {
            this.InitializeComponent();
        }

        private void AddTrashCan(MapControl sender, MapInputEventArgs args)
        {
            var location = new Point()
            {
                X = args.Location.Position.Latitude,
                Y = args.Location.Position.Longitude
            };
            ServiceLocator.Current.GetInstance<DeviceViewModel>().TrashCanViewModel.AddingTrashCan.Latitude = location.X;
            ServiceLocator.Current.GetInstance<DeviceViewModel>().TrashCanViewModel.AddingTrashCan.Longtitude = location.Y;
            ServiceLocator.Current.GetInstance<DeviceViewModel>().TrashCanViewModel.AddTrashCanCommand.Execute(null);

            this.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Close(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
