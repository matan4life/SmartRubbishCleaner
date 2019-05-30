namespace TrashMobile.ViewModels.ViewModels
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Command;
    using TrashMobile.Core.Provider;
    using TrashMobile.Models.Models;
    using TrashMobile.Models.Models.Enums;
    using Newtonsoft.Json;
    using System;
    using System.Collections.ObjectModel;
    using System.Net;
    using constants = TrashMobile.Models.Models.Constants;

    public class RegistrationViewModel : BaseViewModel
    {
        private const string RegisterHttpQuery = "api/Account/register";
        private int selectedRoleIndex;
        private UserRegisterRequestModel registerRequestModel;
        private bool isErrorOccured;
        private bool isRequestBusy;

        public RegistrationViewModel()
        {
            this.AvailableRoles = new ObservableCollection<string>(Enum.GetNames(typeof(Roles)));
            this.SelectedRoleIndex = 0;
            this.UserRegisterRequestModel = new UserRegisterRequestModel();
            this.RegisterCommand = new RelayCommand(this.RegisterExecute);
        }

        public ObservableCollection<string> AvailableRoles { get; set; }
        public RelayCommand RegisterCommand { get; private set; }

        public UserRegisterRequestModel UserRegisterRequestModel
        {
            get
            {
                return this.registerRequestModel;
            }
            set
            {
                if(this.registerRequestModel != value)
                {
                    this.registerRequestModel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public bool IsErrorOccured
        {
            get
            {
                return this.isErrorOccured;
            }
            set
            {
                if (this.isErrorOccured != value)
                {
                    this.isErrorOccured = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int SelectedRoleIndex
        {
            get
            {
                return this.selectedRoleIndex;
            }
            set
            {
                if(this.selectedRoleIndex != value && value > -1 && value < this.AvailableRoles.Count)
                {
                    this.selectedRoleIndex = value;
                    this.UserRegisterRequestModel.Role = this.AvailableRoles[value];
                    this.OnPropertyChanged();
                }
            }
        }

        private async void RegisterExecute()
        {
            var registerURL = constants.Constants.ServerHostURL + RegisterHttpQuery;

            var json = JsonConvert.SerializeObject(this.UserRegisterRequestModel);
            var responseResult = await ServerProvider.Post(json, registerURL);
            try
            {
                var token = JsonConvert.DeserializeObject<JwtToken>(responseResult);
                ServiceLocator.Current.GetInstance<UserViewModel>().JwtToken = token;
                this.IsErrorOccured = false;
            }
            catch
            {
                this.IsErrorOccured = true;
            }

            if(this.IsErrorOccured)
            {
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.AuthorizationView;
            }
            else
            {
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.MainAuthorizedView;
            }
        }
    }
}
