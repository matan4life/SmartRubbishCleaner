namespace TrashMobile.ViewModels.ViewModels
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using TrashMobile.Core.Provider;
    using TrashMobile.Models.Models;
    using constants = TrashMobile.Models.Models.Constants;

    public class TrashCanViewModel : BaseViewModel
    {
        private const string TrashCanHttp = "api/TrashCans";
        private const string DeviceTrashCanHttp = "api/Devices/";

        private int selectedIndex;
        private TrashCan addingTrashCan;

        public TrashCanViewModel()
        {
            this.TrashCans = new ObservableCollection<TrashCan>();
            this.AddingTrashCan = new TrashCan();
            this.AddTrashCanCommand = new RelayCommand(this.AddTrashCanExecute);
            this.DeleteTrashCanCommand = new RelayCommand(this.DeleteTrashCanExecute);
            this.GetActiveTrashCansCommand = new RelayCommand(this.GetActiveTrashCansExecute);
        }

        public ObservableCollection<TrashCan> TrashCans { get; set; }

        public RelayCommand AddTrashCanCommand { get; private set; }

        public RelayCommand DeleteTrashCanCommand { get; private set; }

        public RelayCommand GetActiveTrashCansCommand { get; private set; }

        public TrashCan AddingTrashCan
        {
            get
            {
                return this.addingTrashCan;
            }
            set
            {
                if(this.addingTrashCan != value)
                {
                    this.addingTrashCan = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public TrashCan SelectedTrashCan
        {
            get
            {
                return this.TrashCans[this.selectedIndex];
            }
            set
            {
                if(this.TrashCans[this.selectedIndex] != value)
                {
                    this.TrashCans[this.selectedIndex] = value;
                    this.OnPropertyChanged(nameof(this.TrashCans));
                }
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                if(this.selectedIndex != value)
                {
                    this.selectedIndex = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private async void GetActiveTrashCansExecute()
        {
            var device = ServiceLocator.Current.GetInstance<DeviceViewModel>().SelectedDevice;
            var deviceId = device.DeviceId;
            var devicePoint = new Point()
            {
                X = 49.993499,
                Y = 36.230376
            };

            var trashCans = await this.GetAllTrashCans();
           
            for(int i = this.TrashCans.Count - 1; i >= 0; i++)
            {
                this.TrashCans.RemoveAt(i);
            }

            foreach(var trashCan in trashCans)
            {
                this.TrashCans.Add(trashCan);
            }
        }

        private async Task<List<TrashCan>> GetActiveTrashCans(int deviceId, Point location)
        {
            var activeTrashCans = new List<TrashCan>();
            var httpQuery = string.Format("{0}{1}{2}", constants.Constants.ServerHostURL, DeviceTrashCanHttp, deviceId);
            var json = JsonConvert.SerializeObject(location);
            var serverResponse = await ServerProvider.Post(json, httpQuery);
            try
            {
                var nearestTrashCans = JsonConvert.DeserializeObject<List<TrashCan>>(serverResponse);
                activeTrashCans = nearestTrashCans;
            }
            catch
            {
                Debug.WriteLine("Get active trash cans failed.");
            }
            return activeTrashCans;
        }

        private async Task<List<TrashCan>> GetAllTrashCans()
        {
            var device = ServiceLocator.Current.GetInstance<DeviceViewModel>().SelectedDevice;
            var deviceId = device.DeviceId;
            var deviceTrashCans = new List<TrashCan>();
            var httpQuery = string.Format("{0}{1}", constants.Constants.ServerHostURL, TrashCanHttp);
            var serverResponse = await ServerProvider.Get(httpQuery);
            try
            {
                var allTrashCans = JsonConvert.DeserializeObject<List<TrashCan>>(serverResponse);
                deviceTrashCans = allTrashCans.Where(x => x.DeviceId == deviceId).ToList();
            }
            catch
            {
                Debug.WriteLine("Get all trash cans failed.");
            }
            return deviceTrashCans;
        }

        private async void AddTrashCanExecute()
        {
            var addTrashCanHttpQuery = constants.Constants.ServerHostURL + TrashCanHttp;
            this.AddingTrashCan.DeviceId = ServiceLocator.Current.GetInstance<DeviceViewModel>().SelectedDevice.DeviceId;
            
            var trashCanJson = JsonConvert.SerializeObject(this.addingTrashCan);
            var serverResponse = await ServerProvider.Post(trashCanJson, addTrashCanHttpQuery);
            try
            {
                var trashCanFromJson = JsonConvert.DeserializeObject<TrashCan>(serverResponse);
                this.AddingTrashCan = new TrashCan();
            }
            catch
            {
                Debug.WriteLine("Add trash can failed");
            }
        }

        private async void DeleteTrashCanExecute()
        {
            var deleteTrashCanHttp = string.Format("{0}{1}/{2}", constants.Constants.ServerHostURL, TrashCanHttp, this.SelectedTrashCan.TrashCanId);
            var serverResponse = await ServerProvider.Delete(deleteTrashCanHttp);
        }
    }
}
