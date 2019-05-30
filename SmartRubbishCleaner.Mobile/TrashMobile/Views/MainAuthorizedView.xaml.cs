namespace TrashMobile.Views
{
    using TrashMobile.UserViews;
    using Windows.UI.Xaml.Controls;

    public partial class MainAuthorizedView : Page
    {
        public MainAuthorizedView()
        {
            this.InitializeComponent();
            this.contentFrame.Navigate(typeof(DevicesView));
        }
    }
}