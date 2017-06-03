using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Rbauto.Helpers;
using Rbauto.Models;
using Xamarin.Forms;

namespace Rbauto.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<NewsItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public NewsViewModel()
        {
            Title = "Новости";
            Items = new ObservableRangeCollection<NewsItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await NewsDataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}