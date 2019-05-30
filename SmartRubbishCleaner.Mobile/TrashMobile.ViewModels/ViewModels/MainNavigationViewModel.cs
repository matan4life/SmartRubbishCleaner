using TrashMobile.Models.Models.Enums;
using Windows.UI.Xaml.Controls;

namespace TrashMobile.ViewModels.ViewModels
{
    public class MainNavigationViewModel : BaseViewModel
    {
        private ViewType viewType;

        public MainNavigationViewModel()
        {
            this.ViewType = ViewType.AuthorizationView;
        }

        public ViewType ViewType
        {
            get
            {
                return this.viewType;
            }
            set
            {
                if(this.viewType != value)
                {
                    this.viewType = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
