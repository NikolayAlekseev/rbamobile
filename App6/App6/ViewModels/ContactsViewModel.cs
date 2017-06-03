using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Rbauto.Helpers;
using Rbauto.Models;
using Rbauto.Views;
using Xamarin.Forms;

namespace Rbauto.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ContactItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ContactsViewModel()
        {
            Title = "Контакты";
            Items = new ObservableRangeCollection<ContactItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, ContactItem>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as ContactItem;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
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