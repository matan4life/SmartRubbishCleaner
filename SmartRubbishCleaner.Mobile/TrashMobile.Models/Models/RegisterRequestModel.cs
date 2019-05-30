namespace TrashMobile.Models.Models
{
    public class UserRegisterRequestModel : AuthModel
    {
        private string role;

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
    }
}
