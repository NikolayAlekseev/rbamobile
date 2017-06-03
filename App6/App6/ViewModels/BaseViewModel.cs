using Rbauto.Helpers;
using Rbauto.Models;
using Rbauto.Services;
using Xamarin.Forms;

namespace Rbauto.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<ContactItem> DataStore => DependencyService.Get<IDataStore<ContactItem>>();
        public IDataStore<NewsItem> NewsDataStore => DependencyService.Get<IDataStore<NewsItem>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the contactItem
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

