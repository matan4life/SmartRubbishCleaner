namespace TrashMobile.Models.Models
{
    using System;

    public class Cleaning : ObservableObject
    {
        private int cleaningId;
        private int amount;
        private DateTime date;
        private string rubbishType;
        private int deviceId;
        private Factory factory;

        public int CleaningId
        {
            get
            {
                return this.cleaningId;
            }
            set
            {
                if (this.cleaningId != value)
                {
                    this.cleaningId = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (this.amount != value)
                {
                    this.amount = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string RubbishType
        {
            get
            {
                return this.rubbishType;
            }
            set
            {
                if (this.rubbishType != value)
                {
                    this.rubbishType = value;
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

        public Factory Factory
        {
            get
            {
                return this.factory;
            }
            set
            {
                if (this.factory != value)
                {
                    this.factory = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
