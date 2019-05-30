namespace TrashMobile.Models.Models
{
    using System;

    public class User : ObservableObject
    {
        private string userId;
        private string name;
        private string role;
        private string email;

        public string UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                if (this.userId != value)
                {
                    this.userId = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Role
        {
            get
            {
                return this.role;
            }
            set
            {
                if (this.role != value)
                {
                    this.role = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
