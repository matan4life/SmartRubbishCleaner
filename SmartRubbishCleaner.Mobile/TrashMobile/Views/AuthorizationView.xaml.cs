namespace TrashMobile.Views
{
    using CommonServiceLocator;
    using TrashMobile.Models.Models.Enums;
    using TrashMobile.ViewModels.ViewModels;
    using Windows.UI.Xaml.Controls;

    public partial class AuthorizationView : Page
    {
        public AuthorizationView()
        {
            this.InitializeComponent();
        }

        private void NavigateToRegistration(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.RegistrationView;
        }
    }
}
