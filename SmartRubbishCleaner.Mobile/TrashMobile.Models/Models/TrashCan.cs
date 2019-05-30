namespace TrashMobile.Models.Models
{
    public class TrashCan : ObservableObject
    {
        private int trashCanId;
        private double longtitude;
        private double latitude;
        private int deviceId;

        public int TrashCanId
        {
            get
            {
                return this.trashCanId;
            }
            set
            {
                if (this.trashCanId != value)
                {
                    this.trashCanId = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Longtitude
        {
            get
            {
                return this.longtitude;
            }
            set
            {
                if (this.longtitude != value)
                {
                    this.longtitude = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (this.latitude != value)
                {
                    this.latitude = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int DeviceId
        {
            get
            {
                return this.deviceId;
            }
            set
            {
                if (this.deviceId != value)
                {
                    this.deviceId = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
