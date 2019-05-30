namespace TrashMobile.ViewModels.ViewModels
{
    using TrashMobile.Core.Provider;
    using TrashMobile.Models.Models;
    using TrashMobile.Models.Models.Constants;
    using Newtonsoft.Json;
    using System.Diagnostics;

    public class UserViewModel : BaseViewModel
    {
        private const string UserHttpQuery = "api/Users";

        private User user;
        private JwtToken jwtToken;

        public UserViewModel()
        {
            this.User = new User();
        }

        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                if(this.user != value)
                {
                    this.user = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public JwtToken JwtToken
        {
            get
            {
                return this.jwtToken;
            }
            set
            {
                if (this.jwtToken != value)
                {
                    this.jwtToken = value;
                    this.SetUser(this.jwtToken.userId);
                }
            }
        }

        public async void SetUser(string id)
        {
            var userUrl = string.Format("{0}{1}/{2}", Constants.ServerHostURL, UserHttpQuery, id);
            var userJson = await ServerProvider.Get(userUrl);
            try
            {
                this.User = JsonConvert.DeserializeObject<User>(userJson);
            }
            catch
            {
                Debug.WriteLine("Set user failed.");
            }
        }
    }
}
