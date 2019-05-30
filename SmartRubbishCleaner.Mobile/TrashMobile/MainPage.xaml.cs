using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TrashMobile.Models.Models.Enums;
using TrashMobile.ViewModels.ViewModels;
using TrashMobile.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TrashMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 500));
            this.MainFrame.Navigate(typeof(AuthorizationView));
        }

        private void Navigate(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            var viewModel = ServiceLocator.Current.GetInstance<MainNavigationViewModel>();
            var typeValue = viewModel.ViewType;
            Type type = typeof(AuthorizationView);
            switch (typeValue)
            {
                case ViewType.AuthorizationView:
                    type = typeof(AuthorizationView);
                    break;
                case ViewType.RegistrationView:
                    type = typeof(RegistrationView);
                    break;
                case ViewType.MainAuthorizedView:
                    type = typeof(MainAuthorizedView);
                    break;
            }
            this.MainFrame.Navigate(type);
        }
    }
}
