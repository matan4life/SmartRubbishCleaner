namespace TrashMobile.Views
{
    using CommonServiceLocator;
    using TrashMobile.Models.Models.Enums;
    using TrashMobile.ViewModels.ViewModels;
    using Windows.UI.Xaml.Controls;

    public partial class RegistrationView : Page
    {
        public RegistrationView()
        {
            this.InitializeComponent();
        }

        private void NavigateToLogIn(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.AuthorizationView;
        }
    }
}
