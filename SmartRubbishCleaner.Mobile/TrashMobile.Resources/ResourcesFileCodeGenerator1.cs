
namespace TrashMobile.Resources
{
	using System.Globalization;
	using TrashMobile.Resources.Core;
	using System;
	using TrashMobile.Models.Models;

	/// <summary>
    /// Provides access to resources from PageResources.resw file.
    /// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Justification = "Yet it will be unstatic.")]
	public class PageResources
	{
		/// <summary>
        /// Contains logic for accessing contsnt of resource file.
        /// </summary>
		private static ResourceProvider resourceProvider = new ResourceProvider("TrashMobile.Resources/PageResources");
		
		/// <summary>
        /// Overrides the current thread's CurrentUICulture property for all
        /// resource lookups using this strongly typed resource class.
        /// </summary>
        public static CultureInfo Culture
        {
            get
            {
                return resourceProvider.OverridedCulture;
            }
            set
            {
                resourceProvider.OverridedCulture = value;
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Add device"
        /// </summary>
		public static string AddDevice
        {
            get
            {
                return resourceProvider.GetString("AddDevice");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Add trash can"
        /// </summary>
		public static string AddTrashCan
        {
            get
            {
                return resourceProvider.GetString("AddTrashCan");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Close"
        /// </summary>
		public static string Close
        {
            get
            {
                return resourceProvider.GetString("Close");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Delete device"
        /// </summary>
		public static string DeleteDevice
        {
            get
            {
                return resourceProvider.GetString("DeleteDevice");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Device"
        /// </summary>
		public static string Device
        {
            get
            {
                return resourceProvider.GetString("Device");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Device id:"
        /// </summary>
		public static string DeviceId
        {
            get
            {
                return resourceProvider.GetString("DeviceId");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Efficiency"
        /// </summary>
		public static string Efficiency
        {
            get
            {
                return resourceProvider.GetString("Efficiency");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Enter max volume"
        /// </summary>
		public static string EnterMaxVolume
        {
            get
            {
                return resourceProvider.GetString("EnterMaxVolume");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Enter password"
        /// </summary>
		public static string EnterPassword
        {
            get
            {
                return resourceProvider.GetString("EnterPassword");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Enter your radius"
        /// </summary>
		public static string EnterRadius
        {
            get
            {
                return resourceProvider.GetString("EnterRadius");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Enter max weight"
        /// </summary>
		public static string EnterWeight
        {
            get
            {
                return resourceProvider.GetString("EnterWeight");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Enter your login"
        /// </summary>
		public static string EnterYourLogin
        {
            get
            {
                return resourceProvider.GetString("EnterYourLogin");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Latitude:"
        /// </summary>
		public static string Latitude
        {
            get
            {
                return resourceProvider.GetString("Latitude");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Login:"
        /// </summary>
		public static string Login
        {
            get
            {
                return resourceProvider.GetString("Login");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Log in"
        /// </summary>
		public static string LogInValue
        {
            get
            {
                return resourceProvider.GetString("LogInValue");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Log out"
        /// </summary>
		public static string LogOut
        {
            get
            {
                return resourceProvider.GetString("LogOut");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Longtitude"
        /// </summary>
		public static string Longtitude
        {
            get
            {
                return resourceProvider.GetString("Longtitude");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Max volume:"
        /// </summary>
		public static string MaxVolume
        {
            get
            {
                return resourceProvider.GetString("MaxVolume");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Max weight:"
        /// </summary>
		public static string MaxWeight
        {
            get
            {
                return resourceProvider.GetString("MaxWeight");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Password:"
        /// </summary>
		public static string Password
        {
            get
            {
                return resourceProvider.GetString("Password");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Radius:"
        /// </summary>
		public static string Radius
        {
            get
            {
                return resourceProvider.GetString("Radius");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Remember me"
        /// </summary>
		public static string RememberMe
        {
            get
            {
                return resourceProvider.GetString("RememberMe");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Save"
        /// </summary>
		public static string Save
        {
            get
            {
                return resourceProvider.GetString("Save");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Served trash cans"
        /// </summary>
		public static string ServedTrashCans
        {
            get
            {
                return resourceProvider.GetString("ServedTrashCans");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Sign in"
        /// </summary>
		public static string SignIn
        {
            get
            {
                return resourceProvider.GetString("SignIn");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Sign up"
        /// </summary>
		public static string SignUp
        {
            get
            {
                return resourceProvider.GetString("SignUp");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "The user isn't registered in system."
        /// </summary>
		public static string TheUserIsNotRegisteredError
        {
            get
            {
                return resourceProvider.GetString("TheUserIsNotRegisteredError");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Trash"
        /// </summary>
		public static string Trash
        {
            get
            {
                return resourceProvider.GetString("Trash");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "Trash can id:"
        /// </summary>
		public static string TrashCanId
        {
            get
            {
                return resourceProvider.GetString("TrashCanId");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "User devices"
        /// </summary>
		public static string UserDevices
        {
            get
            {
                return resourceProvider.GetString("UserDevices");
            }
        }

		/// <summary>
        /// Gets a localized string similar to "User role:"
        /// </summary>
		public static string UserRole
        {
            get
            {
                return resourceProvider.GetString("UserRole");
            }
        }

	}


	public sealed class LocalizedStrings : ObservableObject
    {
		/// <summary>
        /// Initialize a new instance of <see cref="LocalizedStrings"/> class.
        /// </summary>
        public LocalizedStrings()
        {
            this.RefreshLanguageSettings();
        }

		public static event EventHandler LocalizedStringsRefreshedEvent;

		public void OnLocalizedStringsRefreshedEvent()
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler handler = LocalizedStringsRefreshedEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, new EventArgs());
            }
        }

		        /// <summary>
		/// Gets resources that are common across application.
		/// </summary>
		public PageResources PageResources { get; private set; }

	
		public void RefreshLanguageSettings()
        {
			            this.PageResources = new PageResources();
			this.OnPropertyChanged("PageResources");
		

			OnLocalizedStringsRefreshedEvent();
		}
	}
}
