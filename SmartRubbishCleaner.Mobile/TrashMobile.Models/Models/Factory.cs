namespace TrashMobile.Models.Models
{
    public class Factory : ObservableObject
    {
        private int factoryId;
        private double longtitude;
        private double latitude;

        public int FactoryId
        {
            get
            {
                return this.factoryId;
            }
            set
            {
                if (this.factoryId != value)
                {
                    this.factoryId = value;
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
    }
}
